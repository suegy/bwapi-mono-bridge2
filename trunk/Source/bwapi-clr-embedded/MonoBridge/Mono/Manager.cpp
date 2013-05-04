#include "Manager.h"
#include "..\Util\Utils.h"

Util::FileLogger *fl;
Mono::Manager* Mono::Manager::g_singManager=NULL;

Mono::Manager* Mono::Manager::GetInstance()
{
	if( !Mono::Manager::g_singManager )
		Mono::Manager::g_singManager = new Mono::Manager();

	return Mono::Manager::g_singManager;
}

void Mono::Manager::Init(std::wstring dlldir)
{
	fl = new Util::FileLogger(wstr_to_str(dlldir)+"..\\logs\\Monoailog",Util::LogLevel::MicroDetailed,true);
	fl->logDetailed("------------------------------------------------------");
	fl->logDetailed("Mono Init Started");

	std::string monoPath = getenv("MonoPath");
	fl->logDetailed(("Setting DLL Dir for Mono to ["+monoPath+"]").c_str());
	std::wstring strMonoPath = str_to_wstr(monoPath.c_str());
	SetDllDirectory(strMonoPath.c_str());

	fl->logDetailed(("Setting DLL Dir for Mono to ["+monoPath+"]").c_str());

	//mono_set_dirs(("C:\\Program Files\\Mono-2.8\\lib").c_str(), ("C:\\Program Files\\Mono-2.8\\etc").c_str());

	fl->logDetailed("Initializing JIT");
	std::string file = wstr_to_str((dlldir+str_to_wstr("bot\\MonoBridgeAI.dll")));
	fl->logDetailed(file.c_str());
	
		this->domain = mono_jit_init(file.c_str());

    fl->logDetailed(("Loading AI DLL: ["+file+"]").c_str());
	this->botassembly = mono_domain_assembly_open (this->domain,file.c_str());
	if( !this->botassembly )
		fl->logCritical("Failed to load AI DLL.");

	fl->logDetailed("Loading Assembly");
	this->botimage = mono_assembly_get_image(this->botassembly);
	fl->logDetailed("Finding class: [StarcraftBotProxy]");
	this->klass = NULL;
	this->klass = mono_class_from_name (this->botimage, "MonoBridgeAI", "StarcraftBotProxy");
	if (!this->klass)
		fl->logCritical("StarcraftBotProxy class Not Found in MonoBridgeAI");

	fl->logDetailed("Creating Bot Object - Memory Alloc");
	this->botobject = mono_object_new (this->domain, this->klass);
	//default constructor;
	fl->logDetailed("Creating Bot Object - Constructor");
	mono_runtime_object_init (this->botobject);

	fl->logDetailed("Finding Methods");

	this->InitMethods();

	fl->logDetailed("Mono Init Complete");
}

void Mono::Manager::InitMethods()
{
	this->mOnStart = this->GetMethod("onStart",0);
	this->mOnEnd = this->GetMethod("onEnd",1);
	this->mOnFrame = this->GetMethod("onFrame",0);
	this->mOnSendText = this->GetMethod("onSendText",1);
	this->mOnReceiveText = this->GetMethod("onReceiveText",2);
	this->mOnPlayerLeft = this->GetMethod("onPlayerLeft",1);
	this->mOnNukeDetect = this->GetMethod("onNukeDetect",1);
	this->mOnUnitDiscover = this->GetMethod("onUnitDiscover",1);
	this->mOnUnitEvade = this->GetMethod("onUnitEvade",1);
	this->mOnUnitShow = this->GetMethod("onUnitShow",1);
	this->mOnUnitHide = this->GetMethod("onUnitHide",1);
	this->mOnUnitCreate = this->GetMethod("onUnitCreate",1);
	this->mOnUnitDestroy = this->GetMethod("onUnitDestroy",1);
	this->mOnUnitMorph = this->GetMethod("onUnitMorph",1);
	this->mOnUnitRenegade = this->GetMethod("onUnitRenegade",1);
	this->mOnSaveGame = this->GetMethod("onSaveGame",1);
}

MonoMethod* Mono::Manager::GetMethod(std::string methodName, int numParams)
{
	MonoMethod *method = mono_class_get_method_from_name( this->klass, methodName.c_str(), numParams );
	if( !method )
	{
		fl->logCritical(("["+methodName+"] NOT found in StarcraftBotProxy class").c_str());
		return NULL;
	}
	else
	{
		fl->logDetailed(("["+methodName+"] found in StarcraftBotProxy class").c_str());
		return method;
	}
}

MonoObject* Mono::Manager::Call(MonoMethod* method, void **params = NULL, MonoObject *exc = NULL)
{
	MonoObject *ret = mono_runtime_invoke( method, this->botobject, params, &exc );

	if( exc )
		fl->logCritical(("Error in .Net\n"+this->GetExceptionMsg(exc)).c_str());

	return ret;
}

std::string Mono::Manager::GetExceptionMsg(MonoObject *exc)
{
	MonoClass *mc = mono_object_get_class(exc);
	MonoProperty *prop = mono_class_get_property_from_name (mc, "Message"); 
	MonoMethod *getter = mono_property_get_get_method (prop); 
	MonoString *msg = (MonoString*)mono_runtime_invoke (getter, exc, NULL, NULL); 

	return std::string(mono_string_to_utf8(msg));
}

void Mono::Manager::onStart()
{
	this->Call(this->mOnStart,NULL,NULL);
}

void Mono::Manager::onEnd(bool isWinner)
{
	void *args[1];
	args[0] = &isWinner;
	this->Call(this->mOnEnd,args,NULL);
}

void Mono::Manager::onFrame()
{
	this->Call(this->mOnFrame,NULL,NULL);
}

void Mono::Manager::onSendText(std::string str)
{
	void *args[1];
	args[0] = mono_string_new(this->domain,str.c_str());;
	this->Call(this->mOnSendText,args,NULL);
}

void Mono::Manager::onReceiveText(BWAPI::Player* player, std::string str)
{
	void *args[2];
	long addr = (long)player;
	args[0] = &addr;
	args[1] = mono_string_new(this->domain,str.c_str());
	this->Call(this->mOnReceiveText,args,NULL);
}

void Mono::Manager::onPlayerLeft(BWAPI::Player* player)
{
	void *args[1];
	long addr = (long)player;
	args[0] = &addr;
	this->Call(this->mOnPlayerLeft,args,NULL);
}

void Mono::Manager::onNukeDetect(BWAPI::Position* p)
{
	void *args[1];
	long addr = (long)p;
	args[0] = &addr;
	this->Call(this->mOnNukeDetect,args,NULL);
}

void Mono::Manager::onUnitDiscover(BWAPI::Unit* u)
{
	void *args[1];
	long addr = (long)u;
	args[0] = &addr;
	this->Call(this->mOnUnitDiscover,args,NULL);
}

void Mono::Manager::onUnitEvade(BWAPI::Unit* u)
{
	void *args[1];
	long addr = (long)u;
	args[0] = &addr;
	this->Call(this->mOnUnitEvade,args,NULL);
}

void Mono::Manager::onUnitShow(BWAPI::Unit* u)
{
	void *args[1];
	long addr = (long)u;
	args[0] = &addr;
	this->Call(this->mOnUnitShow,args,NULL);
}

void Mono::Manager::onUnitHide(BWAPI::Unit* u)
{
	void *args[1];
	long addr = (long)u;
	args[0] = &addr;
	this->Call(this->mOnUnitHide,args,NULL);
}

void Mono::Manager::onUnitCreate(BWAPI::Unit* u)
{
	void *args[1];
	long addr = (long)u;
	args[0] = &addr;
	this->Call(this->mOnUnitCreate,args,NULL);
}

void Mono::Manager::onUnitDestroy(BWAPI::Unit* u)
{
	void *args[1];
	long addr = (long)u;
	args[0] = &addr;
	this->Call(this->mOnUnitDestroy,args,NULL);
}

void Mono::Manager::onUnitMorph(BWAPI::Unit* u)
{
	void *args[1];
	long addr = (long)u;
	args[0] = &addr;
	this->Call(this->mOnUnitMorph,args,NULL);
}

void Mono::Manager::onUnitRenegade(BWAPI::Unit* u)
{
	void *args[1];
	long addr = (long)u;
	args[0] = &addr;
	this->Call(this->mOnUnitRenegade,args,NULL);
}

void Mono::Manager::onSaveGame(std::string str)
{
	void *args[1];
	args[0] = mono_string_new(this->domain,str.c_str());;
	this->Call(this->mOnSaveGame,args,NULL);
}
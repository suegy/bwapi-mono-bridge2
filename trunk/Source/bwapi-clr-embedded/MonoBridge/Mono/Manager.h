#pragma once

#include <windows.h>
#include <string>

#include <mono/jit/jit.h>
#include <mono/metadata/object.h>
#include <mono/metadata/environment.h>
#include <mono/metadata/assembly.h>
#include <mono/metadata/debug-helpers.h>
#include <mono/metadata/mono-config.h>

#include "BWAPI.h"
#include "..\Util\FileLogger.h"

namespace Mono
{
	class Manager
	{
	public:
		static Manager* GetInstance();
	private:
		static Manager* g_singManager;

	public:
		void Init(std::wstring dlldir);
		void InitMethods();

		void onStart();
		void onEnd(bool isWinner);
		void onFrame();
		void onSendText(std::string str);
		void onReceiveText(BWAPI::Player *p, std::string str);
		void onPlayerLeft(BWAPI::Player *p);
		void onNukeDetect(BWAPI::Position *p);
		void onUnitDiscover(BWAPI::Unit *u);
		void onUnitEvade(BWAPI::Unit *u);
		void onUnitShow(BWAPI::Unit *u);
		void onUnitHide(BWAPI::Unit *u);
		void onUnitCreate(BWAPI::Unit *u);
		void onUnitDestroy(BWAPI::Unit *u);
		void onUnitMorph(BWAPI::Unit *u);
		void onUnitRenegade(BWAPI::Unit *u);
		void onSaveGame(std::string gameName);

	private:
		MonoMethod* GetMethod(std::string methodName, int numParams);
		MonoObject* Call(MonoMethod* method, void **params, MonoObject *exc);
		std::string GetExceptionMsg(MonoObject *exc);

	private:
		MonoDomain* domain;
		MonoAssembly* botassembly;
		MonoImage* botimage;
		MonoClass* klass;
		MonoObject* botobject;

		MonoMethod *mOnStart;
		MonoMethod *mOnEnd;
		MonoMethod *mOnFrame;
		MonoMethod *mOnSendText;
		MonoMethod *mOnReceiveText;
		MonoMethod *mOnPlayerLeft;
		MonoMethod *mOnNukeDetect;
		MonoMethod *mOnUnitDiscover;
		MonoMethod *mOnUnitEvade;
		MonoMethod *mOnUnitShow;
		MonoMethod *mOnUnitHide;
		MonoMethod *mOnUnitCreate;
		MonoMethod *mOnUnitDestroy;
		MonoMethod *mOnUnitMorph;
		MonoMethod *mOnUnitRenegade;
		MonoMethod *mOnSaveGame;
	};
}
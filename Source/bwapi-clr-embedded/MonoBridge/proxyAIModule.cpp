#include "proxyAIModule.h"
using namespace BWAPI;

bool analyzed;
bool analysis_just_finished;
BWTA::Region* home;
BWTA::Region* enemy_base;

void proxyAIModule::onStart()
{
	Broodwar->sendText("Loaded MonoBridge!");
	Mono::Manager::GetInstance()->onStart();
}

void proxyAIModule::onEnd(bool isWinner)
{
	Mono::Manager::GetInstance()->onEnd(isWinner);
}

void proxyAIModule::onFrame()
{
	Mono::Manager::GetInstance()->onFrame();
}

void proxyAIModule::onSendText(std::string text)
{
	Mono::Manager::GetInstance()->onSendText(text);
}

void proxyAIModule::onReceiveText(BWAPI::Player* player, std::string text)
{
	Mono::Manager::GetInstance()->onReceiveText(player,text);
}

void proxyAIModule::onPlayerLeft(BWAPI::Player* player)
{
	Mono::Manager::GetInstance()->onPlayerLeft(player);
}

void proxyAIModule::onNukeDetect(BWAPI::Position target)
{
	Mono::Manager::GetInstance()->onNukeDetect(&target);
}

void proxyAIModule::onUnitDiscover(BWAPI::Unit* unit)
{
	Mono::Manager::GetInstance()->onUnitDiscover(unit);
}

void proxyAIModule::onUnitEvade(BWAPI::Unit* unit)
{
	Mono::Manager::GetInstance()->onUnitEvade(unit);
}

void proxyAIModule::onUnitShow(BWAPI::Unit* unit)
{
	Mono::Manager::GetInstance()->onUnitShow(unit);
}

void proxyAIModule::onUnitHide(BWAPI::Unit* unit)
{
	Mono::Manager::GetInstance()->onUnitHide(unit);
}

void proxyAIModule::onUnitCreate(BWAPI::Unit* unit)
{
	Mono::Manager::GetInstance()->onUnitCreate(unit);
}

void proxyAIModule::onUnitDestroy(BWAPI::Unit* unit)
{
	Mono::Manager::GetInstance()->onUnitDestroy(unit);
}

void proxyAIModule::onUnitMorph(BWAPI::Unit* unit)
{
	Mono::Manager::GetInstance()->onUnitMorph(unit);
}

void proxyAIModule::onUnitRenegade(BWAPI::Unit* unit)
{
	Mono::Manager::GetInstance()->onUnitRenegade(unit);
}

void proxyAIModule::onSaveGame(std::string gameName)
{
	Mono::Manager::GetInstance()->onSaveGame(gameName);
}
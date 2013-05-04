#define WIN32_LEAN_AND_MEAN		// Exclude rarely-used stuff from Windows headers

#include <windows.h>
#include <stdio.h>
#include <tchar.h>
#include <BWAPI.h>
#include <string>
#include "proxyAIModule.h"

#include "Mono\Manager.h"

using namespace std;

wstring _dllDirectory;

namespace BWAPI { Game* Broodwar; }

BOOL APIENTRY DllMain( HANDLE hModule, 
                       DWORD  ul_reason_for_call, 
                       LPVOID lpReserved
					 )
{
    
	switch (ul_reason_for_call)
	{
	case DLL_PROCESS_ATTACH:
	{
		wchar_t* filename = new wchar_t[300];
		GetModuleFileName((HMODULE) hModule, filename, 300);
		_dllDirectory = filename;
		_dllDirectory = _dllDirectory.substr(0, _dllDirectory.find_last_of('\\') + 1);
		BWAPI::BWAPI_init();
	}
		break;
	case DLL_PROCESS_DETACH:
		break;
	}


	return TRUE;
}

 extern "C" __declspec(dllexport) BWAPI::AIModule* newAIModule(BWAPI::Game* game)
{
  BWAPI::Broodwar=game;
  Mono::Manager::GetInstance()->Init(_dllDirectory);
  return new proxyAIModule();
}
%include <stl.i>
%include "Enhance/std_set.i"
%include "Enhance/std_list.i"
%include "typemaps.i"
%include "cpointer.i"


%module bwapiclient
%{
#include "BWAPI.h"
#include "BWAPI/Client.h"

using namespace BWAPI;
%}                  
//special include for our dllimport attribute
%include "dllimport.i"

%include "Enhance/class-enhancement.i"

//import BWAPI
%import "bwapi-bridge.i"
//ensure BWAPIClient generated classes can see BWAPI by overriding the defaul using statements generated for a class
%typemap(csimports) SWIGTYPE %{ 
	// defaults
	using System; 
	using System.Runtime.InteropServices; 
	// BWAPI
	using BWAPI;
%} 
                
//ensure that the bridge class can see BWAPI 
%pragma(csharp) moduleimports=%{
using System;
using System.Runtime.InteropServices;
using BWAPI;
%}

//BWAPIC as of 3.3 introduces a position struct, this will break our compile, so.. rename
%rename (BWAPIC_Position) BWAPIC::Position;


%include "BWAPI/Client/BulletData.h"
%include "BWAPI/Client/CommandType.h"
%include "BWAPI/Client/Command.h"
%include "BWAPI/Client/Event.h"
%include "BWAPI/Client/ForceData.h"
%include "BWAPI/Client/ForceImpl.h"
%include "BWAPI/Client/UnitData.h"
%include "BWAPI/Client/UnitImpl.h"
%include "BWAPI/Client/PlayerData.h"
%include "BWAPI/Client/PlayerImpl.h"
%include "BWAPI/Client/GameData.h"
%include "BWAPI/Client/GameImpl.h"
%include "BWAPI/Client/ShapeType.h"
%include "BWAPI/Client/Shape.h"
%include "BWAPI/Client/UnitCommand.h"
%include "BWAPI/Client/Client.h"

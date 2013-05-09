%include <stl.i>
%include "Enhance/std_set.i"
%include "Enhance/std_list.i"
%include "typemaps.i"
%include "cpointer.i"


%module bwta
%{
#include "BWAPI.h"
#include "BWTA.h"

using namespace BWTA;
%}                  

%include "Enhance/class-enhancement.i"
//special include for our dllimport attribute
%include "dllimport.i"


//use getcolumn instead
%ignore operator[];

//import BWAPI
%import "bwapi-bridge.i"
//ensure BWTA generated classes can see BWAPI by overriding the defaul using statements generated for a class
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

//BWTA order of includes is important to stop SWIGTYPE_p etc class generation with and without namespace
%include "BWTA/RectangleArray.h"
%include "BWTA/BaseLocation.h"
%include "BWTA/Chokepoint.h"
%include "BWTA/Polygon.h"
%include "BWTA/Region.h"
%include "BWTA.h"
      

//Instantiate our templates

%template (RectangleArrayDouble) BWTA::RectangleArray<double>; 
%template (BaseLocationPtrSet) std::set<BWTA::BaseLocation *>;
%template (RegionPtrSet) std::set<BWTA::Region *>;
%template (ChokepointPtrSet) std::set<BWTA::Chokepoint *>;
%template (PolygonPtrSet) std::set<BWTA::Polygon *>;
%template (PolygonVector) std::vector<BWTA::Polygon>;
%template (RegionPtrRegionPtrPair) std::pair<BWTA::Region *, BWTA::Region *>;





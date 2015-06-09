REM
REM  Builds the cs files and the cxx file from the BWAPI  and BWTA headers for the bwapi-clr-client implementation.
REM



:start
SET SWIGPATH="C:\Program Files (x86)\swigwin-3.0.5"
SET BWAPIINCLUDE=..\..\..\..\include

erase /s /q Classes\*.*
erase /s /q Wrapper\*.*

%SWIGPATH%\swig.exe -csharp -c++ -I%BWAPIINCLUDE% -outdir Classes\BWAPI -namespace SWIG.BWAPI -dllimport \"+importdll+\" -o Wrapper\bwapi-bridge.cxx Interfaces\bwapi-bridge.i

%SWIGPATH%\swig.exe -csharp -c++ -I%BWAPIINCLUDE% -outdir Classes\BWTA -namespace SWIG.BWTA -dllimport \"+importdll+\" -o Wrapper\bwta-bridge.cxx Interfaces\bwta-bridge.i

%SWIGPATH%\swig.exe -csharp -c++ -I%BWAPIINCLUDE% -outdir Classes\BWAPIC -namespace SWIG.BWAPIC -dllimport \"+importdll+\" -o Wrapper\bwapiclient-bridge.cxx Interfaces\bwapiclient-bridge.i

erase /q Classes\BWAPIC\swigtype_p_void.cs
erase /q Classes\BWAPIC\swigtype_p_int.cs
erase /q Classes\BWAPIC\SWIGTYPE_p_std__setT_BWAPI__Region_p_t.cs
erase /q Classes\BWAPIC\SWIGTYPE_p_BWAPI__Region.cs
erase /q Classes\BWAPIC\SWIGTYPE_p_Region.cs

pause
goto start


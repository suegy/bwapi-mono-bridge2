%pragma(csharp) imclasscode=%{
#if CLIENT
  private const string importdll = "bwapi-native.dll";
#else
  private const string importdll = "__Internal";
#endif 
  
%}

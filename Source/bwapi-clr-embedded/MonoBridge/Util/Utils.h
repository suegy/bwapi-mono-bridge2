#pragma once

//borrowed :) from JNI Java proxy bot (thanks cretz)
std::string wstr_to_str(std::wstring str)
{
	size_t returned;
	char* ascii = new char[str.length() + 1];
	wcstombs_s(&returned, ascii, str.length() + 1, str.c_str(), _TRUNCATE);
	return ascii;
}

std::wstring str_to_wstr(std::string str)
{
	size_t returned;
	wchar_t* ret = new wchar_t[str.length() + 1];
	mbstowcs_s(&returned, ret, str.length() + 1, str.c_str(), _TRUNCATE);
	return ret;
}
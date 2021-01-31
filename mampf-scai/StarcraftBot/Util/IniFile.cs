using System.Runtime.InteropServices;
using System.Text;

namespace StarcraftBot.Util
{
    /// <summary>
    /// Borrowed from: http://www.codeproject.com/KB/cs/cs_ini.aspx
    /// Create a New INI file to store or load data
    /// </summary>

    class IniFile
    {
        public string Path { get; set; }

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section,
            string key,string val,string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section,
                 string key,string def, StringBuilder retVal,
            int size,string filePath);

        /// <summary>
        /// INIFile Constructor.
        /// </summary>
        /// <PARAM name="INIPath"></PARAM>

        public IniFile(string INIPath)
        {
            Path = INIPath;
        }
        /// <summary>
        /// Write Data to the INI File
        /// </summary>
        /// <PARAM name="Section"></PARAM>
        /// Section name
        /// <PARAM name="Key"></PARAM>
        /// Key Name <PARAM name="Value"></PARAM>
        /// Value Name
        public void IniWriteValue(string section,string key,string value)
        {
            WritePrivateProfileString(section,key,value,Path);
        }
        
        /// <summary>
        /// Read Data Value From the Ini File
        /// </summary>
        /// <PARAM name="Section"></PARAM>
        /// <PARAM name="Key"></PARAM>
        /// <PARAM name="Path"></PARAM>
        /// <returns></returns>
        public string IniReadValue(string section,string key)
        {
            var temp = new StringBuilder(255);
            int i = GetPrivateProfileString(section,key,"",temp, 
                                            255, Path);
            return temp.ToString();
        }
    }
}
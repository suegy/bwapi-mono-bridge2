namespace StarcraftBot.Settings {
    static class Settings {
        public static bool Debug = false;//true;
        public const string LogFilename = "!bot-log.txt";
        public const string XMLSerializeName = "!StarCraftUnitAgent.xml"; //+DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss | ")
        public const string LastChanceHandlerError = "!LastChanceHandlerErrText.txt";//"TEST.TXT";//"!LastChanceHandlerErrText.txt";
    }
}

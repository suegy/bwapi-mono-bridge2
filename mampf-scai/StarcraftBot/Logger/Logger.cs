using System.IO;

namespace StarcraftBot.Logger {
    public static class Logger 
    {
        public static string Filename = Settings.Settings.LogFilename;
        static readonly StreamWriter Sw = File.AppendText(Filename);

        public static void AddAndPrint(string message) 
        {
            //sw.WriteLine(message);
            //message = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ; ") + message;
            lock (Sw) 
            {
                Sw.WriteLine(message);
                Sw.Flush();
               // if (Settings.Settings.Debug) 
                 //   Wrapper.Game.PrintText(message);
            }
        }

        public static void AddAndPrintSingleLine(string message)
        {
            //sw.WriteLine(message);
            //message = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ; ") + message;
            lock (Sw)
            {
                Sw.Write(message);
                Sw.Flush();
                //if (Settings.Settings.Debug)
                  //  Wrapper.Game.PrintText(message);
            }
        }

        public static void AddAndPrint() 
        {
            AddAndPrint(string.Empty);
        }
    }
}

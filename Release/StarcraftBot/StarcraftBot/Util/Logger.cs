using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace StarcraftBot.Util
{
	internal class Logger : IDisposable
	{
		private static Logger s_inst=null;
		public static Logger Instance
		{
			get
			{
				if (s_inst == null)
					s_inst = new Logger();

				return s_inst;
			}
		}

		private StreamWriter logFile;
		private Logger()
		{
			string log = Path.Combine(Path.Combine(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))), "logs"), "StarcraftBot.log");
			logFile = new StreamWriter(new FileStream(log, FileMode.Create, FileAccess.Write));
		}

		public void Log(string msg)
		{
			string dt = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss");
			logFile.WriteLine(dt + ": " + msg);
			logFile.Flush();
		}

		public void Dispose()
		{
			if (logFile != null)
			{
				logFile.Flush();
				logFile.Close();
			}
		}
	}
}

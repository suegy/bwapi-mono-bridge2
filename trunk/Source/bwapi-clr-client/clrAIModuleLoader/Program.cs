using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using SWIG.BWAPI;
using SWIG.BWAPIC;
using System.IO;

namespace ClrAIModuleLoader
{
    class BotLoaderException : Exception
    {
        public BotLoaderException(string message)
            : base(message)
        {
        }
    }

    static class Program
    {
        private static BWAPI.IStarcraftBot client = null;

        //looking for monointerop? try bwapi-clr instead
        static Assembly PatchMonoInterop(object sender, ResolveEventArgs args)
        {
            Console.WriteLine("Unresolved Assembly Reference: {0}", args.Name);
            if (args.Name.StartsWith("monobridgeai-interop", StringComparison.CurrentCultureIgnoreCase))
            {
                Console.WriteLine("Bot looking for monobridgeai-interop. This should be bwapi-clr for a out of process bot");
                Console.WriteLine("Attempting to use bwapi-clr instead");
                return typeof(bwapi).Assembly;
            }
            else
            {
                //some other assembly not found.
                return null;
            }
        }

        static void patchmonointeropcatch()
        {
            AppDomain currentDomain = AppDomain.CurrentDomain;
            currentDomain.AssemblyResolve += new ResolveEventHandler(PatchMonoInterop);
        }
        
        
        static void reconnect()
        {

            while (!bwapiclient.BWAPIClient.connect())
            {
                System.Console.WriteLine(bwapiclient.BWAPIClient.isConnected());
                System.Threading.Thread.Sleep(1000);
            }

        }

        static void loadBot()
        {
            string dll = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), ClrAIModuleLoader.Properties.Settings.Default.BotDLL);
            System.Console.WriteLine("Loading Bot [{0}]",dll);
            if (!File.Exists(dll)) { throw new BotLoaderException("DLL [" + dll + "] not Found"); }

            //patch in support for loading bwapi-clr instead of monobridgeai-interop
            patchmonointeropcatch();
            
            Assembly a = Assembly.LoadFile(dll);
            if (a == null) { throw new BotLoaderException("Could not load Assembly"); }

            System.Type botType = a.GetExportedTypes().Where((t) => (t.GetInterfaces().Contains(typeof(BWAPI.IStarcraftBot)))).FirstOrDefault();
            if (botType == null) { throw new BotLoaderException("No Types implement IStarcraftBot"); }

            var ci = botType.GetConstructor(new System.Type[0]);
            if (ci == null) { throw new BotLoaderException("No Constructor that take 0 arguments for [" + botType.FullName + "]"); }

            client = (BWAPI.IStarcraftBot)ci.Invoke(new object[0]);
            System.Console.WriteLine("Bot Loaded: OK");
        }

        static void LoadandRunBot()
        {

           loadBot(); //preload our bot so that any module load errors come up now instead of at match start.

           bwapi.BWAPI_init();
           System.Console.WriteLine("Connecting...");
           reconnect();
           while (true)
           {
               //wait for game to start
               System.Console.WriteLine("waiting to enter match\n");
               while (!bwapi.Broodwar.isInGame())
               {
                   bwapiclient.BWAPIClient.update();
                   if (!bwapiclient.BWAPIClient.isConnected())
                   {
                       System.Console.WriteLine("Reconnecting...\n");
                       reconnect();
                   }
               } //wait for game
               loadBot(); //reload the bot at the start of each match (for easy drop in dll replacement)
               System.Console.WriteLine("Starting Match");

                while(bwapi.Broodwar.isInGame())
                {
                  //for(std::list<Event>::iterator e=Broodwar->getEvents().begin();e!=Broodwar->getEvents().end();e++)
                  foreach (Event e in bwapi.Broodwar.getEvents())
                  {
                    EventType_Enum et = e.getType();
                    switch (et)
                    {
                      case EventType_Enum.MatchStart:
                        client.onStart();
                      break;
                      case EventType_Enum.MatchEnd:
                        client.onEnd(e.isWinner());
                      break;
                      case EventType_Enum.MatchFrame:
                        client.onFrame();
                      break;
                      case EventType_Enum.MenuFrame:
                      break;
                      case EventType_Enum.SendText:
                      client.onSendText(e.getText());
                      break;
                      case EventType_Enum.ReceiveText:
                        client.onReceiveText(e.getPlayer(), e.getText());
                      break;
                      case EventType_Enum.PlayerLeft:
                      client.onPlayerLeft(e.getPlayer());
                      break;
                      case EventType_Enum.NukeDetect:
                        client.onNukeDetect(e.getPosition());
                      break;
                      case EventType_Enum.UnitDiscover:
                        client.onUnitDiscover(e.getUnit());
                      break;
                      case EventType_Enum.UnitEvade:
                      client.onUnitEvade(e.getUnit());
                      break;
                      case EventType_Enum.UnitShow:
                      client.onUnitShow(e.getUnit());
                      break;
                      case EventType_Enum.UnitHide:
                      client.onUnitHide(e.getUnit());
                      break;
                      case EventType_Enum.UnitCreate:
                      client.onUnitCreate(e.getUnit());
                      break;
                      case EventType_Enum.UnitDestroy:
                      client.onUnitDestroy(e.getUnit());
                      break;
                      case EventType_Enum.UnitMorph:
                      client.onUnitMorph(e.getUnit());
                      break;
                      case EventType_Enum.UnitRenegade:
                      client.onUnitRenegade(e.getUnit());
                      break;
                      case EventType_Enum.SaveGame:
                      client.onSaveGame(e.getText());
                      break;
                      default:
                      break;
                    }
                  }
                  bwapiclient.BWAPIClient.update();
                  if (!bwapiclient.BWAPIClient.isConnected())
                  {
                    System.Console.WriteLine("Reconnecting...\n");
                    reconnect();
                  }
                }
                System.Console.WriteLine("Game ended\n");
                

           } //main while loop
        }


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            System.Console.WriteLine("ClrAIModuleLoader 1.0");
            try
            {
                LoadandRunBot();
            }
            catch (Exception e)
            {
                System.Console.WriteLine("error occurred: {0}\n{1}", e.Message, e.StackTrace);
                System.Console.WriteLine("Error: {0}", e);
            }
        }
    }
}

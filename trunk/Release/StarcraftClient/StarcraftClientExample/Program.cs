/**
 *   This is an example of interfacing with broodwar directly via the bwapi-clr library. It implements a bot that
 *   does not implement IStarcraftBot. Most bot writers will use the IStarcraftBot interface but the direct interface may
 *   have some advantages.
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SWIG.BWAPI;
using SWIG.BWAPIC;

namespace StarcraftClientExample
{
    class Program
    {
        static void reconnect()
        {

            while (!bwapiclient.BWAPIClient.connect())
            {
                System.Threading.Thread.Sleep(1000);
            }
        
        }
        
        
        static void Main(string[] args)
        {
            try {
                System.Console.WriteLine("Testbot 1.0");
                if (IntPtr.Size == 8)
                {
                    System.Console.WriteLine("64bit");
                } else {
                    System.Console.WriteLine("32bit");
                }
                
                bwapi.BWAPI_init();
                System.Console.WriteLine("Connecting...");
                reconnect();
                while (true)
                {
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

                    System.Console.WriteLine("Starting Match!");
                    bwapi.Broodwar.sendText("Hello world!");

                    bwapi.Broodwar.enableFlag((int)Flag_Enum.UserInput);

                    bwapi.Broodwar.enableFlag((int) Flag_Enum.CompleteMapInformation);

                    //send each worker to the mineral field that is closest to it
                    List<Unit> units = bwapi.Broodwar.self().getUnits().ToList();


                    List<Unit> workers = units.FindAll(u => u.getType().isWorker());

                    Console.WriteLine("minerals set {0}", bwapi.Broodwar.getMinerals().Count);
                    Console.WriteLine("geysers {0}", bwapi.Broodwar.getStaticGeysers().Count);

                    List<Unit> minerals = bwapi.Broodwar.getMinerals().ToList();

                    Console.WriteLine("minerals list {0}", minerals.Count);
                    Console.WriteLine("last error {0}", bwapi.Broodwar.getLastError().toString());

                    foreach (Unit i in workers)
                    {
                        Unit ClosestMineral = minerals.Aggregate((closest, m) => (closest == null || i.getDistance(m) < i.getDistance(closest)) ? m : closest);
                        if (ClosestMineral != null)
                        {
                            i.rightClick(ClosestMineral);
                        }
                    }

                    //tell each depot to build a worker.
                    List<Unit> resourcedepots = units.Where(u => u.getType().isResourceDepot()).ToList();
                    foreach (Unit u in resourcedepots)
                    {
                        if (u.getType().getRace() != bwapi.Races_Zerg)
                        {
                            u.train(bwapi.Broodwar.self().getRace().getWorker());
                        }
                        else
                        {
                            u.getLarva().ToList().ForEach(l => l.morph(bwapi.UnitTypes_Zerg_Drone));
                        }
                    }

                System.Console.WriteLine("Exiting test.");
                    return;
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine("Error: {0}",e);
                System.Console.WriteLine(e.StackTrace);
            }

        }
    }
}

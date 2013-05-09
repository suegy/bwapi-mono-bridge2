using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SWIG.BWAPI;
using SWIG.BWAPIC;

namespace testbot
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

                    /*
                     *  Broodwar->printf("The map is %s, a %d player map",Broodwar->mapName().c_str(),Broodwar->getStartLocations().size());
        // Enable some cheat flags
        Broodwar->enableFlag(Flag::UserInput);
                     */

                  //  bwapi.Broodwar.printf("The map is {0}, a {1} player map", bwapi.Broodwar.mapName(), bwapi.Broodwar.getStartLocations().Count);

                    bwapi.Broodwar.enableFlag((int)Flag_Enum.UserInput);

                    bwapi.Broodwar.enableFlag((int) Flag_Enum.CompleteMapInformation);

                    /*
                     *  BWTA::readMap();
        analyzed=false;
        analysis_just_finished=false;

        show_bullets=false;
        show_visibility_data=false;
                     */

                    //  bwapi.readMap();
                    
//                    bwapi.Broodwar.printf("The match up is {0} v {1}",
//                        bwapi.Broodwar.self().getRace().getName(),
//                        bwapi.Broodwar.enemy().getRace().getName());
                    System.Threading.Thread.Sleep(5000); //test

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

                    /*       else if ((*i)->getType().isResourceDepot())
                        {
                          //if this is a center, tell it to build the appropiate type of worker
                          if ((*i)->getType().getRace()!=Races::Zerg)
                          {
                            (*i)->train(Broodwar->self()->getRace().getWorker());
                          }
                          else //if we are Zerg, we need to select a larva and morph it into a drone
                          {
                            std::set<Unit*> myLarva=(*i)->getLarva();
                            if (myLarva.size()>0)
                            {
                              Unit* larva=*myLarva.begin();
                              larva->morph(UnitTypes::Zerg_Drone);
                            }
                          }
                        }
                      }*/


                    System.Console.WriteLine("bailing");
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

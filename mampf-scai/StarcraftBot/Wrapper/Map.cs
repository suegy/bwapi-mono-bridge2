using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace StarcraftBot.Wrapper {
    static class Map {
        //public static bool IsAnalyzed {
        //    get {
        //        if (analyzeStarted == false) {
        //            Util.Logger.Instance.Log("analyzeStarted == false");
        //            return false;
        //        }
        //        if (analyzeFinished) return true;
        //        //Util.Logger.Instance.Log(threadAnalyze.ThreadState.ToString());
        //        if (threadAnalyze.ThreadState == System.Threading.ThreadState.Stopped) {
        //            analyzeFinished = true;
        //            return true;
        //        }

        //        return false;
        //    }
            

        //}
        public static bool IsAnalyzed { get; private set; }


        //static System.Threading.Thread threadAnalyze = null;
        //static bool analyzeStarted = false;
        //static bool analyzeFinished = false;

        /// <summary>
        /// Before any other global functions can be called, the map must first be analyzed. 
        /// Analyzing a starcraft map can take a long time, depending on your computer, so 
        /// map results are automatically saves to file.
        /// </summary>
        public static void AnalyzeMap() {
            SWIG.BWTA.bwta.readMap();
            SWIG.BWTA.bwta.analyze();// async call is not working, not threadsafe?
            IsAnalyzed = true;
            //threadAnalyze = new System.Threading.Thread(new System.Threading.ThreadStart(AsyncAnalyzeMap));
            //threadAnalyze.Start();
            ////while (!threadAnalyze.IsAlive) {
            ////    Thread.Sleep(1);
            ////}
            //analyzeStarted = true;
            //t.ThreadState == System.Threading.ThreadState.Stopped
        }

        //static void AsyncAnalyzeMap() {
        //    Util.Logger.Instance.Log("AsyncAnalyzeMap() started");
        //    SWIG.BWAPI.bwapi.analyze();
        //    analyzeFinished = true;
        //    Util.Logger.Instance.Log("AsyncAnalyzeMap() finished");
        //}


        /// <summary>
        /// Returns the set of regions in the map. 
        /// </summary>
        /// <returns></returns>
        public static List<MapRegion> GetAllMapRegions() {
            return MapRegion.GetListOfMapRegions(SWIG.BWTA.bwta.getRegions());
        }

        /// <summary>
        /// Returns the set of chokepoints in the map. 
        /// </summary>
        /// <returns></returns>
        public static List<MapChokepoint> GetAllMapChokepoints() {
            return MapChokepoint.GetListOfMapChokepoints(SWIG.BWTA.bwta.getChokepoints());
        }

        /// <summary>
        /// Returns the set of base locations on the map. 
        /// </summary>
        /// <returns></returns>
        public static List<MapBaseLocation> GetAllMapBaseLocations() {
            return MapBaseLocation.GetListOfMapBaseLocations(SWIG.BWTA.bwta.getBaseLocations());
        }

        /// <summary>
        /// Returns the set of base locations that are start locations. 
        /// </summary>
        /// <returns></returns>
        public static List<MapBaseLocation> GetAllStartBaseLocations() {
            return MapBaseLocation.GetListOfMapBaseLocations(SWIG.BWTA.bwta.getStartLocations());
        }

        /// <summary>
        /// Returns start location of player.
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public static MapBaseLocation GetStartBaseLocation(Player player) {
            return new MapBaseLocation(SWIG.BWTA.bwta.getStartLocation(player.BwapiObject));
        }

        /// <summary>
        /// Returns start location of self.
        /// </summary>
        /// <returns></returns>
        public static MapBaseLocation GetStartBaseLocation() {
            return new MapBaseLocation(SWIG.BWTA.bwta.getStartLocation(SWIG.BWAPI.bwapi.Broodwar.self()));
        }

        /// <summary>
        /// Returns the set of unwalkable polygons. 
        /// </summary>
        /// <returns></returns>
        public static List<MapPolygon> GetAllUnwalkablePolygons() {
            return MapPolygon.GetListOfMapPolygons(SWIG.BWTA.bwta.getUnwalkablePolygons());
        }

        /// <summary>
        /// Returns the map region that the build tile position is inside.
        /// </summary>
        /// <param name="buildTile"></param>
        /// <returns></returns>
        public static MapRegion GetRegionByBuildTile(BuildTile buildTile) {
            return new MapRegion(SWIG.BWTA.bwta.getRegion(buildTile.BwapiObject));
        }

        /// <summary>
        /// Returns the nearest chokepoint in ground/walking distance.
        /// </summary>
        /// <param name="buildTile"></param>
        /// <returns></returns>
        public static MapChokepoint GetNearestChokepoint(BuildTile buildTile) {
            return new MapChokepoint(SWIG.BWTA.bwta.getNearestChokepoint(buildTile.BwapiObject));
        }

        /// <summary>
        /// Returns the nearest base location in ground/walking distance.
        /// </summary>
        /// <param name="buildTile"></param>
        /// <returns></returns>
        public static MapBaseLocation GetNearestMapBaseLocation(BuildTile buildTile) {
            return new MapBaseLocation(SWIG.BWTA.bwta.getNearestBaseLocation(buildTile.BwapiObject));
        }

        /// <summary>
        /// Returns the nearest unwalkable polygon. 
        /// Note: The border of the map is not considered an unwalkable polygon. 
        /// </summary>
        /// <param name="buildTile"></param>
        /// <returns></returns>
        public static MapPolygon GetNearestUnwalkablePolygon(BuildTile buildTile) {
            return new MapPolygon(SWIG.BWTA.bwta.getNearestUnwalkablePolygon(buildTile.BwapiObject));
        }

        /// <summary>
        /// Returns the nearest position that is on the boundary of an unwalkable polygon, or border of the map. 
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public static Position GetNearestUnwalkablePosition(Position position) {
            return new Position(SWIG.BWTA.bwta.getNearestUnwalkablePosition(position.BwapiObject));
        }

        /// <summary>
        /// Returns true if there exists a static path between the two given build tile positions. 
        /// </summary>
        /// <param name="buildTileOne"></param>
        /// <param name="buildTileTwo"></param>
        /// <returns></returns>
        public static bool IsBuildTilesConnected(BuildTile buildTileOne, BuildTile buildTileTwo) {
            return SWIG.BWTA.bwta.isConnected(buildTileOne.BwapiObject, buildTileTwo.BwapiObject);
        }

        /// <summary>
        /// Returns the ground distance measured in BuildTiles between the two given build tile positions. 
        /// </summary>
        /// <param name="buildTileOne"></param>
        /// <param name="buildTileTwo"></param>
        /// <returns></returns>
        public static double GetDistanceByGround(BuildTile buildTileOne, BuildTile buildTileTwo) {
            //were in pixels in bwapi, remove "/ 32.0" if you needed.
            return SWIG.BWTA.bwta.getGroundDistance(buildTileOne.BwapiObject, buildTileTwo.BwapiObject) / 32.0;
        }

        /// <summary>
        /// Returns the air distance between the two given build tile positions.
        /// </summary>
        /// <param name="buildTileOne"></param>
        /// <param name="buildTileTwo"></param>
        /// <returns></returns>
        public static double GetDistanceByAir(BuildTile buildTileOne, BuildTile buildTileTwo) {
            return buildTileOne.GetDistanceTo(buildTileTwo);
        }


        /// <summary>
        /// Returns the build tile position in the given set that is closest to the given build tile position, 
        /// along with the ground distance to that build tile position. 
        /// </summary>
        /// <param name="startBuildTile"></param>
        /// <param name="targetBuildTiles"></param>
        /// <returns></returns>
        public static KeyValuePair<BuildTile, double> GetNearestBuildTile(BuildTile buildTileStart, List<BuildTile> targetBuildTiles) {
            SWIG.BWAPI.TilePositionSet bwapiList = GetBwapiTilePositionSet(targetBuildTiles);
            SWIG.BWAPI.TilePositionDoublePair bwapiResult = SWIG.BWTA.bwta.getNearestTilePosition(buildTileStart.BwapiObject, bwapiList);
            KeyValuePair<BuildTile, double> result = new KeyValuePair<BuildTile, double>(new BuildTile(bwapiResult.first), bwapiResult.second);
            return result;
        }

        /// <summary>
        /// Converts List(BuildTile) -> SWIG.BWAPI.TilePositionSet
        /// </summary>
        /// <param name="buildTileList"></param>
        /// <returns></returns>
        private static SWIG.BWAPI.TilePositionSet GetBwapiTilePositionSet(List<BuildTile> buildTileList) {
            SWIG.BWAPI.TilePositionSet result = new SWIG.BWAPI.TilePositionSet();
            foreach (BuildTile bt in buildTileList) {
                result.Add(bt.BwapiObject);
            }
            return result;
        }

        /// <summary>
        /// Returns the distance to each target build tile position. 
        /// </summary>
        /// <param name="startBuildTile"></param>
        /// <param name="targetBuildTiles"></param>
        /// <returns></returns>
        public static Dictionary<BuildTile, double> GetDistancesByGround(BuildTile buildTileStart, List<BuildTile> targetBuildTiles) {
            SWIG.BWAPI.TilePositionSet bwapiList = GetBwapiTilePositionSet(targetBuildTiles);
            SWIG.BWAPI.TilePositionDoubleMap bwapiResult = SWIG.BWTA.bwta.getGroundDistances(buildTileStart.BwapiObject, bwapiList);
            Dictionary<BuildTile, double> result = new Dictionary<BuildTile, double>();
            foreach (SWIG.BWAPI.TilePosition tp in bwapiResult.Keys) {
                result.Add(new BuildTile(tp), bwapiResult[tp]);
            }
            return result;
        }

        #region seems like doesn't implement in bwapi 2.6.1

        ///// <summary>
        ///// Returns the shortest path from the start build tile position to the end build tile position. 
        ///// If no path exists, the result list will be empty. 
        ///// </summary>
        ///// <param name="buildTileStart"></param>
        ///// <param name="buildTileTarget"></param>
        ///// <returns></returns>
        //public static List<BuildTile> GetShortestPath(BuildTile buildTileStart, BuildTile buildTileTarget) {
        //    List<BuildTile> result = new List<BuildTile>();
        //    //strange but TilePositionVector contains Positions
        //    SWIG.BWAPI.TilePositionVector bwapiResult = SWIG.BWAPI.bwapi.getShortestPath(buildTileStart.BwapiObject, buildTileStart.BwapiObject);
        //    //try {
        //        foreach (SWIG.BWAPI.TilePosition t in bwapiResult) {
        //            result.Add(new BuildTile(t));
        //        }
        //    //} catch { }
        //    return result;
        //}

        ///// <summary>
        ///// Returns the shortest path from the start build tile position to the closest target build tile position. 
        ///// If no path exists to any of the target tile positions, the result list will be empty. 
        ///// </summary>
        ///// <param name="buildTileStart"></param>
        ///// <param name="buildTileTargets"></param>
        ///// <returns></returns>
        //public static List<BuildTile> GetShortestPath(BuildTile buildTileStart, List<BuildTile> buildTileTargets) {
        //    List<BuildTile> result = new List<BuildTile>();
        //    Util.Logger.Instance.Log("GetShortestPath on list started");
        //    SWIG.BWAPI.TilePositionVector bwapiResult = null;
        //    try {
        //        bwapiResult = SWIG.BWAPI.bwapi.getShortestPath(buildTileStart.BwapiObject, GetBwapiTilePositionSet(buildTileTargets));
        //    } catch {
        //        Util.Logger.Instance.Log(Game.LastError.ToString());
        //    }
        //    Util.Logger.Instance.Log("GetShortestPath on list finished");
        //    foreach (SWIG.BWAPI.TilePosition t in bwapiResult) {
        //        result.Add(new BuildTile(t));
        //    }
        //    return result;
        //}

        #endregion










    }
}

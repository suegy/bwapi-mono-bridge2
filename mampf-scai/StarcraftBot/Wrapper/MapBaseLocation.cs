using System;
using System.Collections.Generic;
using System.Text;

namespace StarcraftBot.Wrapper {
    class MapBaseLocation : BwapiObjectContainer<SWIG.BWTA.BaseLocation> {

        public MapBaseLocation(SWIG.BWTA.BaseLocation bwapiBaseLocation) : base(bwapiBaseLocation) { }


        //---

        public static List<MapBaseLocation> GetListOfMapBaseLocations(System.Collections.IEnumerable bwapiCollection) {
            List<MapBaseLocation> result = new List<MapBaseLocation>();
            try {
                foreach (SWIG.BWTA.BaseLocation u in bwapiCollection)
                {
                    result.Add(new MapBaseLocation(u));
                }
            } catch { }
            return result;
        }


        //---




        /// <summary>
        /// Returns the position of the center of the base location. 
        /// </summary>
        public Position Position { get { return new Position(this.BwapiObject.getPosition()); } }

        /// <summary>
        /// Returns the build tile position of the base location. 
        /// </summary>
        public BuildTile BuildTile { get { return new BuildTile(this.BwapiObject.getTilePosition()); } }

        /// <summary>
        /// Returns the MapRegion the base location is in. 
        /// </summary>
        public MapRegion MapRegion { get { return new MapRegion(this.BwapiObject.getRegion()); } }

        /// <summary>
        /// Returns the total mineral resource count of all accessible mineral patches. 
        /// </summary>
        public int Minerals { get { return this.BwapiObject.minerals(); } }

        /// <summary>
        /// Returns the total gas resource count of all accessible vespene geysers. 
        /// </summary>
        public int Gas { get { return this.BwapiObject.gas(); } }

        /// <summary>
        /// Returns the set of accessible mineral patches near the base location. 
        /// </summary>
        /// <returns></returns>
        public List<Unit> GetMinerals() {
            return Unit.GetListOfUnits(this.BwapiObject.getMinerals());
        }

        /// <summary>
        /// Returns the set of all mineral patches near the base location, including mined out and invisible ones. 
        /// </summary>
        /// <returns></returns>
        public List<Unit> GetMineralsStatic() {
            return Unit.GetListOfUnits(this.bwapiObject.getStaticMinerals());
        }

        /// <summary>
        /// Returns the set of vespene geysers near the base location. If the set is empty, the base location is mineral only. 
        /// </summary>
        /// <returns></returns>
        public List<Unit> GetGeysers() {
            return Unit.GetListOfUnits(this.bwapiObject.getGeysers());
        }

        /// <summary>
        /// Returns the ground (walking) distance to the given base location. 
        /// If its impossible to reach the given base location from the current one, this will return a negative value. 
        /// </summary>
        /// <param name="otherBaseLocation"></param>
        /// <returns></returns>
        public double GetDistanceGround(MapBaseLocation otherBaseLocation) {
            return this.bwapiObject.getGroundDistance(otherBaseLocation.bwapiObject);
        }

        /// <summary>
        /// Returns the air (flying) distance to the given base location. 
        /// </summary>
        /// <param name="otherBaseLocation"></param>
        /// <returns></returns>
        public double GetDistanceAir(MapBaseLocation otherBaseLocation) {
            return this.bwapiObject.getAirDistance(otherBaseLocation.bwapiObject);
        }

        /// <summary>
        /// Returns true if the base location not in not reachable by ground from any other base location. 
        /// </summary>
        public bool IsIsland { get { return this.bwapiObject.isIsland(); } }

        /// <summary>
        /// Returns true if the base location is mineral-only. 
        /// </summary>
        public bool IsMineralOnly { get { return this.bwapiObject.isMineralOnly(); } }

        /// <summary>
        /// Returns true if the base location is a start location. 
        /// </summary>
        public bool IsStartLocation { get { return this.bwapiObject.isStartLocation(); } }



    }
}

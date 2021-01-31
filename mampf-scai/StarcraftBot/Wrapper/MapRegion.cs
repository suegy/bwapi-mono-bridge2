using System;
using System.Collections.Generic;
using System.Text;

namespace StarcraftBot.Wrapper {
    /// <summary>
    /// MapRegion is a partition of the map with a MapPolygon boundary, and is connected to other regions via MapChokepoints. 
    /// </summary>
    class MapRegion : BwapiObjectContainer<SWIG.BWTA.Region>
    {

        public MapRegion(SWIG.BWTA.Region bwapiRegion) : base(bwapiRegion) { }


        //---

        public static List<MapRegion> GetListOfMapRegions(System.Collections.IEnumerable bwapiCollection) {
            List<MapRegion> result = new List<MapRegion>();
            try {
                foreach (SWIG.BWTA.Region u in bwapiCollection)
                {
                    result.Add(new MapRegion(u));
                }
            } catch { }
            return result;
        }


        //---




        /// <summary>
        /// Returns the polygon border of the region. 
        /// </summary>
        public MapPolygon MapPolygon { get { return new MapPolygon(this.BwapiObject.getPolygon()); } }

        /// <summary>
        /// Returns the center of the region. 
        /// </summary>
        public Position Center { get { return new Position(this.BwapiObject.getCenter()); } }

        /// <summary>
        /// Returns the set of chokepoints adjacent to the region. 
        /// </summary>
        /// <returns></returns>
        public List<MapChokepoint> GetChokepoints() {
            return MapChokepoint.GetListOfMapChokepoints(this.BwapiObject.getChokepoints());
        }

        /// <summary>
        /// Returns the set of base locations in the region. 
        /// </summary>
        /// <returns></returns>
        public List<MapBaseLocation> GetBaseLocations() {
            return MapBaseLocation.GetListOfMapBaseLocations(this.bwapiObject.getBaseLocations());
        }

        /// <summary>
        /// Returns true if its possible to walk from this region to the given region. 
        /// </summary>
        /// <param name="otherMapRegion"></param>
        /// <returns></returns>
        public bool IsReachableByGround(MapRegion otherMapRegion) {
            return this.bwapiObject.isReachable(otherMapRegion.bwapiObject);
        }

        /// <summary>
        /// Returns the set of regions reachable from this region. 
        /// </summary>
        /// <returns></returns>
        public List<MapRegion> GetAllGroundReachableRegions() {
            return MapRegion.GetListOfMapRegions(this.bwapiObject.getReachableRegions());
        }




    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace StarcraftBot.Wrapper {
    /// <summary>
    /// MapChokepoint connects exactly two regions. 
    /// </summary>
    class MapChokepoint : BwapiObjectContainer<SWIG.BWTA.Chokepoint>
    {
        public MapChokepoint(SWIG.BWTA.Chokepoint bwapiChokepoint)
            : base(bwapiChokepoint)
        {
            if (bwapiChokepoint != null) {
                this.MapRegionOne = new MapRegion(bwapiChokepoint.getRegions().first);
                this.MapRegionTwo = new MapRegion(bwapiChokepoint.getRegions().second);
                this.SidePositionOne = new Position(bwapiChokepoint.getSides().first);
                this.SidePositionTwo = new Position(bwapiChokepoint.getSides().second);
            }
                
        }

        /// <summary>
        /// Returns the first MapRegion that current MapChokepoint connects.
        /// See also: MapRegionTwo, GetTwoRegions()
        /// </summary>
        public MapRegion MapRegionOne { get; private set; }

        /// <summary>
        /// Returns the second MapRegion that current MapChokepoint connects.
        /// </summary>
        public MapRegion MapRegionTwo { get; private set; }

        /// <summary>
        /// Returns the two MapRegions the chokepoint connects. 
        /// See also: MapRegionOne, MapRegionTwo
        /// </summary>
        /// <returns></returns>
        public List<MapRegion> GetTwoMapRegions() {
            List<MapRegion> result = new List<MapRegion>();
            try {
                result.Add(this.MapRegionOne);
                result.Add(this.MapRegionTwo);
            } catch { }
            return result;
        }

        /// <summary>
        /// Returns the first side position of current MapChokepoint.
        /// </summary>
        public Position SidePositionOne { get; private set; }

        /// <summary>
        /// Returns the second side position of current MapChokepoint.
        /// </summary>
        public Position SidePositionTwo { get; private set; }

        /// <summary>
        /// Returns the two side positions of current MapChokepoint. 
        /// </summary>
        /// <returns></returns>
        public List<Position> GetTwoSidePositions() {
            List<Position> result = new List<Position>();
            try {
                result.Add(this.SidePositionOne);
                result.Add(this.SidePositionTwo);
            } catch { }
            return result;
        }

        public static List<MapChokepoint> GetListOfMapChokepoints(SWIG.BWTA.ChokepointPtrSet bwapiChokepointSet)
        {
            List<MapChokepoint> result = new List<MapChokepoint>();
            try {
                foreach (SWIG.BWTA.Chokepoint cp in bwapiChokepointSet)
                {
                    result.Add(new MapChokepoint(cp));
                }
            } catch { }
            return result;
        }


        /// <summary>
        /// Returns the center position of current MapChokepoint. 
        /// </summary>
        public Position CenterPosition { get { return new Position(this.BwapiObject.getCenter()); } }

        /// <summary>
        /// Returns the width of current MapChokepoint.
        /// </summary>
        public double Width { get { return this.BwapiObject.getWidth(); } }





    }
}

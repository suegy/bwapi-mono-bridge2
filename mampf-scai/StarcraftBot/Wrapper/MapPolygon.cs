using System;
using System.Collections.Generic;
using System.Text;

namespace StarcraftBot.Wrapper {
    /// <summary>
    /// MapPolygon is a set of connected Position points on the map.
    /// </summary>
    class MapPolygon : BwapiObjectContainer<SWIG.BWTA.Polygon>
    {
        public MapPolygon(SWIG.BWTA.Polygon bwapiPolygon)
            : base(bwapiPolygon)
        {
            this.Positions = Position.GetListOfPositions(this.BwapiObject);
        }


        //---

        public static List<MapPolygon> GetListOfMapPolygons(System.Collections.IEnumerable bwapiCollection) {
            List<MapPolygon> result = new List<MapPolygon>();
            try {
                foreach (SWIG.BWTA.Polygon u in bwapiCollection)
                {
                    result.Add(new MapPolygon(u));
                }
            } catch { }
            return result;
        }


        //---



        /// <summary>
        /// Returns list of Positions of this MapPolygon.
        /// </summary>
        public List<Position> Positions { get; private set; }


        /// <summary>
        /// Returns the area of the map polygon. 
        /// </summary>
        public double Area{ get { return this.bwapiObject.getArea(); } }

        /// <summary>
        /// Returns the perimeter of the map polygon. 
        /// </summary>
        public double Perimeter { get { return this.bwapiObject.getPerimeter(); } }

        /// <summary>
        /// Returns the centroid of the map polygon. 
        /// </summary>
        public Position Center { get { return new Position(this.bwapiObject.getCenter()); } }

        /// <summary>
        /// Returns the position on the boundary of the map polygon that is nearest to the given position.
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public Position GetNearestPosition(Position position) {
            return new Position(this.bwapiObject.getNearestPoint(position.BwapiObject));
        }

        /// <summary>
        /// Returns true if the given point is inside the polygon. 
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public bool PositionIsInside(Position position) {
            return this.bwapiObject.isInside(position.BwapiObject);
        }
        
        

    }
}

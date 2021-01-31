using System;
using System.Collections.Generic;
using System.Text;

namespace StarcraftBot.Wrapper {
    /// <summary>
    /// Positions are measured in pixels and are the highest resolution.
    /// </summary>
    class Position : BwapiObjectContainer<SWIG.BWAPI.Position>
    {

        public Position(SWIG.BWAPI.Position bwapiPosition)
            : base(bwapiPosition)
        {
        }

        public Position(int x, int y)
            : base(new SWIG.BWAPI.Position(x, y))
        {
        }

        //---

        public static List<Position> GetListOfPositions(System.Collections.IEnumerable bwapiCollection) {
            List<Position> result = new List<Position>();
            try {
                foreach (SWIG.BWAPI.Position p in bwapiCollection)
                {
                    result.Add(new Position(p));
                }
            } catch { }
            return result;
        }


        //---


        public int X { get { return this.BwapiObject.xConst(); } }
        public int Y { get { return this.BwapiObject.yConst(); } }

        /// <summary>
        /// Returns geometric distance to other map position.
        /// </summary>
        /// <param name="otherPosition"></param>
        /// <returns></returns>
        public double GetDistance(Position otherPosition) {
            return this.BwapiObject.getDistance(otherPosition.BwapiObject);
        }

        public double GetDistanceApprox(Position otherPosition) {
            return this.BwapiObject.getApproxDistance(otherPosition.BwapiObject);
        }

        public double GetLength() {
            return this.BwapiObject.getLength();
        }

        //***********twsandberg Added All The following Methods (01-10-2010)*********//
        /**
         * Inspiration from: http://msdn.microsoft.com/en-us/library/ms173147.aspx
         * and
         * http://msdn.microsoft.com/en-us/library/ms182276(v=VS.100).aspx
         */

        public override int GetHashCode()
        {
            return X ^ Y;
        }

        public override bool Equals(System.Object obj)
        {
            // If parameter is null return false.
            if (obj == null)
                return false;

            // If parameter cannot be cast to Point return false.
            Position p = obj as Position;
            if ((System.Object)p == null)
                return false;
 
            // Return true if the fields match:
            return (X == p.X) && (Y == p.Y);
        }

        public bool Equals(Position p)
        {
            // If parameter is null return false:
            if ((object)p == null)
                return false;

            // Return true if the fields match:
            return (X == p.X) && (Y == p.Y);
        }

        public static bool operator ==(Position a, Position b)
        {
            // If both are null, or both are same instance, return true.
            if (System.Object.ReferenceEquals(a, b))
                return true;

            // If one is null, but not both, return false.
            if ((((object)a == null) || ((object)b == null)) && ((object)a != null) || ((object)b != null))
                 return false;

            // Return true if the fields match:
            return a.X == b.X && a.Y == b.Y;
        }

        public static bool operator !=(Position a, Position b)
        {
            return !(a == b);
        }

       //************END OF TWSANDBERG CHANGES************//

    }
}

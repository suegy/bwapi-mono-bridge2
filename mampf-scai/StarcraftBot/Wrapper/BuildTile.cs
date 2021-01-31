using System;
using System.Collections.Generic;
using System.Text;

namespace StarcraftBot.Wrapper {
    /// <summary>
    /// Build Tiles - each build tile is a 4x4 square of walk tiles, or a 32x32 square of pixels. 
    /// These are called build tiles because buildability data is available at this resolution, and correspond to the tiles seen in game. 
    /// For example, a command center occupies an area of 4x3 build tiles. Build tiles can be specified in TilePosition objects. 
    /// </summary>
    class BuildTile : BwapiObjectContainer<SWIG.BWAPI.TilePosition>
    {
        public BuildTile(SWIG.BWAPI.TilePosition bwapiTilePosition) : base(bwapiTilePosition) { }

        public BuildTile(int x, int y) : base(new SWIG.BWAPI.TilePosition(x, y)) { }
        //---

        public static List<BuildTile> GetListOfBuildTiles(System.Collections.IEnumerable bwapiCollection) {
            List<BuildTile> result = new List<BuildTile>();
            try {
                foreach (SWIG.BWAPI.TilePosition tp in bwapiCollection)
                {
                    result.Add(new BuildTile(tp));
                }
            } catch { }
            return result;
        }


        //---


        public int X { get { return this.BwapiObject.xConst(); } }
        public int Y { get { return this.BwapiObject.yConst(); } }
        public bool IsValid { get { return this.BwapiObject.isValid(); } }

        /// <summary>
        /// Returns geometric distance to other build tile.
        /// </summary>
        /// <param name="otherTilePosition"></param>
        /// <returns></returns>
        public double GetDistanceTo(BuildTile otherBuildTile) {
            return this.BwapiObject.getDistance(otherBuildTile.BwapiObject);
        }

        public static int Width { get { return 32; } }
        public static int Height { get { return 32; } }
        
    }
}

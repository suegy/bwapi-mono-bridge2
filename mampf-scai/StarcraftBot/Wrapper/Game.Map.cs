using System;
using System.Collections.Generic;
using System.Text;

namespace StarcraftBot.Wrapper {
    static partial class Game {
        /// <summary>
        /// Returns the width of the current map, in build tile units. 
        /// To get the width of the current map in walk tile units, multiply by 4. 
        /// To get the width of the current map in Position units, multiply by 32. 
        /// </summary>
        public static int MapWidthTiles { get { return SWIG.BWAPI.bwapi.Broodwar.mapWidth(); } }

        /// <summary>
        /// Returns the height of the current map, in build tile units. 
        /// To get the height of the current map in walk tile units, multiply by 4. 
        /// To get the height of the current map in Position units, multiply by 32. 
        /// </summary>
        public static int MapHeightTiles { get { return SWIG.BWAPI.bwapi.Broodwar.mapHeight(); } }

        /// <summary>
        /// Returns the file name of the current map. 
        /// </summary>
        public static string MapFilename { get { return SWIG.BWAPI.bwapi.Broodwar.mapFileName(); } }

        /// <summary>
        /// Returns the name/title of the current map. 
        /// </summary>
        public static string MapName { get { return SWIG.BWAPI.bwapi.Broodwar.mapName(); } }

        /// <summary>
        /// Returns a unique identifier for the given map data that does not depend on the file name. 
        /// </summary>
        public static string GetMapHash { get { return SWIG.BWAPI.bwapi.Broodwar.mapHash(); } }

    }
}

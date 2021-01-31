using System;
using System.Collections.Generic;
using System.Text;

namespace StarcraftBot.Wrapper {
    static partial class Game {
        /// <summary>
        /// Returns true if the specified build tile is buildable. 
        /// Note that this just uses the static map data. You will also need to make sure 
        /// no ground units on the tile to see if its currently buildable. To do this, see GetUnitsOnBuildTile. 
        /// </summary>
        /// <param name="buildTile"></param>
        /// <returns></returns>
        public static bool TileIsBuildable(BuildTile buildTile) {
            return SWIG.BWAPI.bwapi.Broodwar.isBuildable(buildTile.BwapiObject);
        }

        /// <summary>
        /// Returns true if the specified build tile is visible. If the tile is concealed by fog of war, the function will return false. 
        /// </summary>
        /// <param name="buildTile"></param>
        /// <returns></returns>
        public static bool TileIsVisible(BuildTile buildTile) {
            return SWIG.BWAPI.bwapi.Broodwar.isVisible(buildTile.BwapiObject);
        }

        /// <summary>
        /// Returns true if the specified build tile has been explored (was visible at some point in the match). 
        /// </summary>
        /// <param name="buildTile"></param>
        /// <returns></returns>
        public static bool TileIsExplored(BuildTile buildTile) {
            return SWIG.BWAPI.bwapi.Broodwar.isExplored(buildTile.BwapiObject);
        }

        /// <summary>
        /// Returns true if the specified build tile has zerg creep on it. 
        /// If the tile is concealed by fog of war, the function will return false. 
        /// </summary>
        /// <param name="buildTile"></param>
        /// <returns></returns>
        public static bool TileHasCreep(BuildTile buildTile) {
            return SWIG.BWAPI.bwapi.Broodwar.hasCreep(buildTile.BwapiObject);
        }

        /// <summary>
        /// Returns true if the given build location is powered by a nearby friendly pylon. 
        /// </summary>
        /// <param name="buildTile"></param>
        /// <param name="tileWidth"></param>
        /// <param name="tileHeight"></param>
        /// <returns></returns>
        public static bool TileHasPower(BuildTile buildTile, int tileWidth, int tileHeight) {
            return SWIG.BWAPI.bwapi.Broodwar.hasPower(buildTile.BwapiObject, tileWidth, tileHeight);
        }

        /// <summary>
        /// Returns true if the given unit type can be built at the given build tile position. 
        /// If builder is not null, the unit will be discarded when determining whether or not any ground units are blocking the build location.
        /// </summary>
        /// <param name="builder">Builder worker.</param>
        /// <param name="buildTile">Top left tile of the building.</param>
        /// <param name="building">Type of a building unit to build.</param>
        /// <returns></returns>
        public static bool CanBuildHere(Unit builder, BuildTile buildTile, UnitType building) {
            return SWIG.BWAPI.bwapi.Broodwar.canBuildHere(builder.BwapiObject, buildTile.BwapiObject, building.BwapiObject);
        }

        /// <summary>
        /// Returns true if the given unit type can be built at the given build tile position. 
        /// If builder is not null, the unit will be discarded when determining whether or not any ground units are blocking the build location.
        /// </summary>
        /// <param name="builder">Builder worker.</param>
        /// <param name="buildTile">Top left tile of the building.</param>
        /// <param name="building">Type of a building unit to build.</param>
        /// <returns></returns>
        public static bool CanBuildHere(Unit builder, BuildTile buildTile, UnitTypes building) {
            return SWIG.BWAPI.bwapi.Broodwar.canBuildHere(builder.BwapiObject, buildTile.BwapiObject, new SWIG.BWAPI.UnitType((int)building));
        }

    }
}

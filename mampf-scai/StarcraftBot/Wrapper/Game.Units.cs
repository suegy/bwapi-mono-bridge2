using System;
using System.Collections.Generic;
using System.Text;

namespace StarcraftBot.Wrapper {
    static partial class Game {

        /// <summary>
        /// Returns all the visible units. If flag EnableCompleteMapInformation is enabled, 
        /// the set of all units is returned, not just visible ones. 
        /// Note that units inside refineries are not included in this set. 
        /// </summary>
        /// <returns></returns>
        public static List<Unit> GetAllUnits() {
            return Unit.GetListOfUnits(SWIG.BWAPI.bwapi.Broodwar.getAllUnits());
        }

        /// <summary>
        /// Returns the list of all accessible mineral patches. 
        /// </summary>
        /// <returns></returns>
        public static List<Unit> GetAllMinerals() {
            return Unit.GetListOfUnits(SWIG.BWAPI.bwapi.Broodwar.getMinerals());
        }

        /// <summary>
        /// Returns the set of all mineral patches (including mined out and other inaccessible ones). 
        /// </summary>
        /// <returns></returns>
        public static List<Unit> GetAllMineralsStatic() {
            return Unit.GetListOfUnits(SWIG.BWAPI.bwapi.Broodwar.getStaticMinerals());

        }

        /// <summary>
        /// Returns the list of all accessible vespene geysers. 
        /// </summary>
        /// <returns></returns>
        public static List<Unit> GetAllGeysers() {
            return Unit.GetListOfUnits(SWIG.BWAPI.bwapi.Broodwar.getGeysers());
        }

        /// <summary>
        /// Returns the set of all vespene geysers (including mined out and other inaccessible ones). 
        /// </summary>
        /// <returns></returns>
        public static List<Unit> GetAllGeysersStatic() {
            return Unit.GetListOfUnits(SWIG.BWAPI.bwapi.Broodwar.getStaticGeysers());
        }

        /// <summary>
        /// Returns the set of all accessible neutral units. 
        /// </summary>
        /// <returns></returns>
        public static List<Unit> GetAllNeutralUnits() {
            return Unit.GetListOfUnits(SWIG.BWAPI.bwapi.Broodwar.getNeutralUnits());
        }

        /// <summary>
        /// Returns the set of all neutral units (including mined out and other inaccessible ones). 
        /// </summary>
        /// <returns></returns>
        public static List<Unit> GetAllNeutralUnitsStatic() {
            return Unit.GetListOfUnits(SWIG.BWAPI.bwapi.Broodwar.getStaticNeutralUnits());
        }

        /// <summary>
        /// Returns the set of units that are on the given build tile. 
        /// Only returns accessible units on accessible tiles. 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static List<Unit> GetUnitsOnBuildTile(BuildTile buildTile) {
            return Unit.GetListOfUnits(SWIG.BWAPI.bwapi.Broodwar.unitsOnTile(buildTile.X, buildTile.Y));
        }


    }
}

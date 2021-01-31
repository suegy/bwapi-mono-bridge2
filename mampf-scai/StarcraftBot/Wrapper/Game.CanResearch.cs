using System;
using System.Collections.Generic;
using System.Text;

namespace StarcraftBot.Wrapper {
    static partial class Game {
        /// <summary>
        /// Returns true if there is enough resources required to research the given tech type.
        /// </summary>
        /// <param name="techType"></param>
        /// <returns></returns>
        public static bool CanResearch(TechType techType) {
            return SWIG.BWAPI.bwapi.Broodwar.canResearch(null, techType.BwapiObject);
        }

        /// <summary>
        /// Returns true if there is enough resources required to research the given tech type.
        /// </summary>
        /// <param name="techType"></param>
        /// <returns></returns>
        public static bool CanResearch(TechTypes techType) {
            return SWIG.BWAPI.bwapi.Broodwar.canResearch(null, new SWIG.BWAPI.TechType((int)techType));
        }

        /// <summary>
        /// Returns true if the given unit can research the given tech type and there is enough resources required to research.
        /// </summary>
        /// <param name="unitWhereToResearch"></param>
        /// <param name="techType"></param>
        /// <returns></returns>
        public static bool CanResearch(Unit unitWhereToResearch, TechType techType) {
            return SWIG.BWAPI.bwapi.Broodwar.canResearch(unitWhereToResearch.BwapiObject, techType.BwapiObject);
        }

        /// <summary>
        /// Returns true if the given unit can research the given tech type and there is enough resources required to research.
        /// </summary>
        /// <param name="unitWhereToResearch"></param>
        /// <param name="techType"></param>
        /// <returns></returns>
        public static bool CanResearch(Unit unitWhereToResearch, TechTypes techType) {
            return SWIG.BWAPI.bwapi.Broodwar.canResearch(unitWhereToResearch.BwapiObject, new SWIG.BWAPI.TechType((int)techType));
        }




    }
}

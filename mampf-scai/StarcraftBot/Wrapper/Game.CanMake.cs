using System;
using System.Collections.Generic;
using System.Text;

namespace StarcraftBot.Wrapper {
    static partial class Game {
        /// <summary>
        /// Returns true if it is enough resources, supply, tech, and required units in order to make the given unit type.
        /// </summary>
        /// <param name="unitType"></param>
        /// <returns></returns>
        public static bool CanMake(UnitType unitType) {
            return SWIG.BWAPI.bwapi.Broodwar.canMake(null, unitType.BwapiObject);
        }

        /// <summary>
        /// Returns true if there is enough resources, supply, tech and required units in order to make the given unit type.
        /// </summary>
        /// <param name="unitType"></param>
        /// <returns></returns>
        public static bool CanMake(UnitTypes unitType) {
            return SWIG.BWAPI.bwapi.Broodwar.canMake(null, new SWIG.BWAPI.UnitType((int)unitType));
        }

        /// <summary>
        /// Returns true if current builder unit can make this unit type and there is enough resources, supply, 
        /// tech and required units in order to make the given unit type.
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="unitType"></param>
        /// <returns></returns>
        public static bool CanMake(Unit builder, UnitType unitType) {
            return SWIG.BWAPI.bwapi.Broodwar.canMake(builder.BwapiObject, unitType.BwapiObject);
        }

        /// <summary>
        /// Returns true if current builder unit can make this unit type and there is enough resources, supply, 
        /// tech and required units in order to make the given unit type.
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="unitType"></param>
        /// <returns></returns>
        public static bool CanMake(Unit builder, UnitTypes unitType) {
            return SWIG.BWAPI.bwapi.Broodwar.canMake(builder.BwapiObject, new SWIG.BWAPI.UnitType((int)unitType));
        }


    }
}

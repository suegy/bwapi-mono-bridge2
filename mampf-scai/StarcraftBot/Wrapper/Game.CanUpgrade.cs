using System;
using System.Collections.Generic;
using System.Text;

namespace StarcraftBot.Wrapper {
    static partial class Game {
        /// <summary>
        /// Returns true if there is enough resources required to upgrade the given tech type.
        /// </summary>
        /// <returns></returns>
        public static bool CanUpgrade(UpgradeType upgradeType) {
            return SWIG.BWAPI.bwapi.Broodwar.canUpgrade(null, upgradeType.BwapiObject);
        }

        /// <summary>
        /// Returns true if there is enough resources required to upgrade the given tech type.
        /// </summary>
        /// <param name="upgradeType"></param>
        /// <returns></returns>
        public static bool CanUpgrade(UpgradeTypes upgradeType) {
            return SWIG.BWAPI.bwapi.Broodwar.canUpgrade(null, new SWIG.BWAPI.UpgradeType((int)upgradeType));
        }

        /// <summary>
        /// Returns true if the given unit can upgrade the given upgrade type and there is enough resources required to upgrade.
        /// </summary>
        /// <param name="unitWhereToUpgrade"></param>
        /// <param name="upgradeType"></param>
        /// <returns></returns>
        public static bool CanUpgrade(Unit unitWhereToUpgrade, UpgradeType upgradeType) {
            return SWIG.BWAPI.bwapi.Broodwar.canUpgrade(unitWhereToUpgrade.BwapiObject, upgradeType.BwapiObject);
        }

        /// <summary>
        /// Returns true if the given unit can upgrade the given upgrade type and there is enough resources required to upgrade.
        /// </summary>
        /// <param name="unitWhereToUpgrade"></param>
        /// <param name="upgradeType"></param>
        /// <returns></returns>
        public static bool CanUpgrade(Unit unitWhereToUpgrade, UpgradeTypes upgradeType) {
            return SWIG.BWAPI.bwapi.Broodwar.canUpgrade(unitWhereToUpgrade.BwapiObject, new SWIG.BWAPI.UpgradeType((int) upgradeType));
        }

    }
}

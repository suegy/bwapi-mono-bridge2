using System;
using System.Collections.Generic;
using System.Text;

namespace StarcraftBot.Wrapper {
    partial class Unit {
        /// <summary>
        /// Returns the upgrade that the unit is currently upgrading.
        /// See also: DoUpgrade(), DoCancelUprgade(), IsUpgrading, UpgradeResearchTimer.
        /// </summary>
        public UpgradeType UpgradeResearching { get { return new UpgradeType(this.BwapiObject.getUpgrade());  } }


        /// <summary>
        /// Returns the amount of time until the unit is done upgrading its current upgrade. If the unit is not upgrading anything, 0 is returned. 
        /// See also: DoUpgrade(), DoCancelUprgade(), IsUpgrading, UpgradeResearching.
        /// </summary>
        public int UpgradeResearchTimer { get { return this.BwapiObject.getRemainingUpgradeTime(); } }

        /// <summary>
        /// Orders the unit to upgrade the given upgrade type. 
        /// See also: UpgradeResearching, UpgradeResearchTimer, IsUpgrading.
        /// </summary>
        /// <param name="upgradeType"></param>
        /// <returns></returns>
        public bool DoUpgrade(UpgradeTypes upgradeType) {
            return this.BwapiObject.upgrade(new SWIG.BWAPI.UpgradeType((int)upgradeType));
        }

        /// <summary>
        /// Returns true if the unit is a building that is upgrading.
        /// See also: UpgradeResearching, UpgradeResearchTimer, DoUpgrade().
        /// </summary>
        public bool IsUpgrading { get { return this.BwapiObject.isUpgrading(); } }

        /// <summary>
        /// Returns true if the owner of this player has upgraded the given upgrade type, and this unit is affected by this upgrade. 
        /// </summary>
        /// <param name="upgradeType"></param>
        /// <returns></returns>
        public int GetUpgradeLevel(UpgradeType upgradeType) {
            return this.BwapiObject.getUpgradeLevel(upgradeType.BwapiObject);
        }

        /// <summary>
        /// Returns true if the owner of this player has upgraded the given upgrade type, and this unit is affected by this upgrade. 
        /// </summary>
        /// <param name="upgradeType"></param>
        /// <returns></returns>
        public int GetUpgradeLevel(UpgradeTypes upgradeType) {
            return this.BwapiObject.getUpgradeLevel(new SWIG.BWAPI.UpgradeType((int)upgradeType));
        }

        /// <summary>
        /// Orders the unit to cancel an upgrade in progress. 
        /// See also: DoUpgrade(), IsUpgrading, UpgradeResearching.
        /// </summary>
        /// <returns></returns>
        public bool DoCancelUpgrade() {
            return this.BwapiObject.cancelUpgrade();
        }



    }
}

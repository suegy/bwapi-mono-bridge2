using System;
using System.Collections.Generic;
using System.Text;

namespace StarcraftBot.Wrapper {
    class UpgradeType : BwapiObjectContainer<SWIG.BWAPI.UpgradeType>
    {
        public UpgradeType(SWIG.BWAPI.UpgradeType bwapiUpgradeType)
            : base(bwapiUpgradeType)
        {
        }

        public UpgradeTypes UpgradeTypeEnum { get { return (UpgradeTypes)this.BwapiObject.getID(); } }

        /// <summary>
        /// Returns the race the upgrade is for. 
        /// </summary>
        public Races Race { get { return (Races)this.BwapiObject.getRace().getID(); } }

        /// <summary>
        /// Returns the mineral price for the first upgrade. 
        /// </summary>
        public int PriceMineralBase { get { return this.BwapiObject.mineralPriceBase(); } }

        /// <summary>
        /// Returns the amount that the mineral price increases for each additional upgrade. 
        /// </summary>
        public int PriceMineralFactor { get { return this.BwapiObject.mineralPriceFactor(); } }

        /// <summary>
        /// Returns the vespene gas price for the first upgrade. 
        /// </summary>
        public int PriceGasBase { get { return this.BwapiObject.gasPriceBase(); } }

        /// <summary>
        /// Returns the amount that the vespene gas price increases for each additional upgrade. 
        /// </summary>
        public int PriceGasFactor { get { return this.BwapiObject.gasPriceFactor(); } }

        /// <summary>
        /// Returns the maximum number of times the upgrade can be researched. 
        /// </summary>
        public int MaxUpgradeLevel { get { return this.BwapiObject.maxRepeats(); } }

        /// <summary>
        /// Returns the type of unit that researches the upgrade. 
        /// </summary>
        public UnitType WhereToUpgrade { get { return new UnitType( this.BwapiObject.whatUpgrades()); } }

        /// <summary>
        /// Returns the set of units that are affected by this upgrade. 
        /// </summary>
        /// <returns></returns>
        public List<UnitType> AffectedUnits() {
            return UnitType.GetListOfUnitTypes(this.bwapiObject.whatUses());
        }

    }
}

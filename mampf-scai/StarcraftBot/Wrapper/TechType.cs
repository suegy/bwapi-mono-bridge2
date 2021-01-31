using System;
using System.Collections.Generic;
using System.Text;

namespace StarcraftBot.Wrapper {
    class TechType : BwapiObjectContainer<SWIG.BWAPI.TechType>
    {

        public TechType(SWIG.BWAPI.TechType bwapiTechType)
            : base(bwapiTechType)
        {
        }

        //---

        public static List<TechType> GetListOfTechTypes(System.Collections.IEnumerable bwapiCollection) {
            List<TechType> result = new List<TechType>();
            try {
                foreach (SWIG.BWAPI.TechType tt in bwapiCollection)
                {
                    result.Add(new TechType(tt));
                }
            } catch { }
            return result;
        }


        //---



        public TechTypes TechTypeEnum {
            get {
                return (TechTypes)this.bwapiObject.getID();
            }
        }

        //public string Name { get { return this.BwapiObject.getName(); } }

        /// <summary>
        /// Returns the mineral cost of the tech type. 
        /// </summary>
        public int PriceMineral { get { return this.BwapiObject.mineralPrice(); } }

        /// <summary>
        /// Returns the vespene gas price of the tech type. 
        /// </summary>
        public int PriceGas { get { return this.BwapiObject.gasPrice(); } }

        /// <summary>
        /// Returns the amount of energy used each time this tech type is used. 
        /// </summary>
        public int EnergyNeededToCast { get { return this.BwapiObject.energyUsed(); } }

        /// <summary>
        /// Returns the type of unit that researches this tech type.
        /// </summary>
        public UnitType WhereToResearch { get { return new UnitType(this.BwapiObject.whatResearches()); } }

        /// <summary>
        /// Returns the corresponding weapon for this tech type.
        /// </summary>
        public WeaponType WeaponType { get { return new WeaponType(this.BwapiObject.getWeapon()); } }

        /// <summary>
        /// Returns the set of units that can use this tech type.
        /// </summary>
        /// <returns></returns>
        public List<UnitType> AffectedUnits() {
            return UnitType.GetListOfUnitTypes(this.bwapiObject.whatUses());
        }




    }
}

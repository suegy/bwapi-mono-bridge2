using System;
using System.Collections.Generic;
using System.Text;

namespace StarcraftBot.Wrapper {
    partial class Unit {

        /// <summary>
        /// Orders the unit to build the given addon. 
        /// The unit must be a Terran building that can have an addon 
        /// and the specified unit type must be an addon unit type. 
        /// </summary>
        /// <param name="unitType"></param>
        /// <returns></returns>
        public bool DoBuildAddon(UnitTypes unitType) {
            return this.BwapiObject.buildAddon(new SWIG.BWAPI.UnitType((int)unitType));
        }

        /// <summary>
        /// Orders the unit to stop making the addon. 
        /// </summary>
        /// <returns></returns>
        public bool DoCancelAddon() {
            return this.BwapiObject.cancelAddon();
        }

        /// <summary>
        /// Returns the add-on of this unit. 
        /// </summary>
        public Unit Addon { get { return new Unit(this.BwapiObject.getAddon()); } }

    }
}

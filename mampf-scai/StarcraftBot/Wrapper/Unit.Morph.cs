using System;
using System.Collections.Generic;
using System.Text;

namespace StarcraftBot.Wrapper {
    partial class Unit {
        /// <summary>
        /// Orders the unit to morph into the specified unit type. Returns false if given a wrong type. 
        /// See also: DoCancelMorph(), IsMorphing.
        /// </summary>
        /// <param name="unitType"></param>
        /// <returns></returns>
        public bool DoMorph(UnitTypes unitType) {
            return this.BwapiObject.morph(new SWIG.BWAPI.UnitType((int)unitType));
        }

        /// <summary>
        /// Returns true if the unit is a zerg unit that is morphing. 
        /// See also: DoMorph(), DoCancelMorph(), BuildingToBecome, BuildTimeRemaining.
        /// </summary>
        public bool IsMorphing { get { return this.BwapiObject.isMorphing(); } }



        /// <summary>
        /// Orders the unit to stop morphing. 
        /// See also: DoMorph(), IsMorphing.
        /// </summary>
        /// <returns></returns>
        public bool DoCancelMorph() {
            return this.BwapiObject.cancelMorph();
        }

    }
}

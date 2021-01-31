using System;
using System.Collections.Generic;
using System.Text;

namespace StarcraftBot.Wrapper {
    partial class Unit {

        /// <summary>
        /// Returns true if the unit is a Terran Siege Tank that is currently in Siege mode. 
        /// See also: DoSiegeMode(), DoUnsiegeMode()
        /// </summary>
        public bool IsInSiegeMode { get { return this.BwapiObject.isSieged(); } }

        /// <summary>
        /// Orders the unit to siege. Unit must be a Terran siege tank. 
        /// See also: DoUnsiegeMode(), IsInSiegeMode.
        /// </summary>
        /// <returns></returns>
        public bool DoSiegeMode() {
            return this.BwapiObject.siege();
        }

        /// <summary>
        /// Orders the unit to unsiege. Unit must be a Terran siege tank. 
        /// See also: DoSiegeMode(), IsInSiegeMode.
        /// </summary>
        /// <returns></returns>
        public bool DoUnsiegeMode() {
            return this.BwapiObject.unsiege();
        }


    }
}

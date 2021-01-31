using System;
using System.Collections.Generic;
using System.Text;

namespace StarcraftBot.Wrapper {
    partial class Unit {
        /// <summary>
        /// Orders the unit to repair the specified unit. Only Terran SCVs can be ordered to repair, 
        /// and the target must be a mechanical Terran unit or building. 
        /// See also: IsRepairing.
        /// </summary>
        /// <param name="unitTarget"></param>
        /// <returns></returns>
        public bool DoRepair(Unit unitTarget) {
            return this.BwapiObject.repair(unitTarget.BwapiObject);
        }

        /// <summary>
        /// Returns true if the unit is a Terran SCV that is repairing or moving to repair another unit. 
        /// See also: DoRepair().
        /// </summary>
        public bool IsRepairing { get { return this.BwapiObject.isRepairing(); } }

    }
}

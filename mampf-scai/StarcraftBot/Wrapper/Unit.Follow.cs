using System;
using System.Collections.Generic;
using System.Text;

namespace StarcraftBot.Wrapper {
    partial class Unit {
        /// <summary>
        /// Orders the unit to follow the specified unit. 
        /// See also: IsFollowing, TargetUnit
        /// </summary>
        /// <param name="unitTarget"></param>
        /// <returns></returns>
        public bool DoFollowUnit(Unit unitTarget) {
            return this.BwapiObject.follow(unitTarget.BwapiObject);
        }

        /// <summary>
        /// Returns true if the unit is following another unit. 
        /// See also: TargetUnit, DoFollow()
        /// </summary>
        public bool IsFollowing { get { return this.BwapiObject.isFollowing(); } }

    }
}

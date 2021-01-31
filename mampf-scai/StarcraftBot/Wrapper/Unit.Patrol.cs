using System;
using System.Collections.Generic;
using System.Text;

namespace StarcraftBot.Wrapper {
    partial class Unit {
        /// <summary>
        /// Orders the unit to patrol between its current position and the specified position. 
        /// See also: IsPatrolling
        /// </summary>
        /// <param name="positionTarget"></param>
        /// <returns></returns>
        public bool DoPatrol(Position positionTarget) {
            return this.BwapiObject.patrol(positionTarget.BwapiObject);
        }

        /// <summary>
        /// Returns true if the unit is patrolling between two positions. 
        /// See also: DoPatrol().
        /// </summary>
        public bool IsPatrolling { get { return this.BwapiObject.isPatrolling(); } }

    }
}

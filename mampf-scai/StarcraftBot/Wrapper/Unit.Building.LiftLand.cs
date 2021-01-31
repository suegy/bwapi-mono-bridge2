using System;
using System.Collections.Generic;
using System.Text;

namespace StarcraftBot.Wrapper {
    partial class Unit {
        /// <summary>
        /// Orders the unit to lift. Unit must be a Terran building that can be lifted. 
        /// See also: DoLand(), IsLifted
        /// </summary>
        /// <returns></returns>
        public bool DoLift() {
            return this.BwapiObject.lift();
        }

        /// <summary>
        /// Orders the unit to land. Unit must be a Terran building that is currently lifted. 
        /// See also: DoLift(), IsLifted
        /// </summary>
        /// <param name="tilePositionTarget"></param>
        /// <returns></returns>
        public bool DoLand(BuildTile tilePositionTarget) {
            return this.BwapiObject.land(tilePositionTarget.BwapiObject);
        }

        /// <summary>
        /// Returns true if the unit is a Terran building that is currently lifted off the ground. 
        /// See also: DoLift(), DoLand().
        /// </summary>
        public bool IsLifted { get { return this.BwapiObject.isLifted(); } }

    }
}

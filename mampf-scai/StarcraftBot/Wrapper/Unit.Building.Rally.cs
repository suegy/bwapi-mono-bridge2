using System;
using System.Collections.Generic;
using System.Text;

namespace StarcraftBot.Wrapper {
    partial class Unit {
        /// <summary>
        /// Returns the position the building is rallied to.
        /// See also: RallyUnit, DoSetRallyPoint().
        /// </summary>
        public Position RallyPosition { get { return new Position(this.BwapiObject.getRallyPosition()); } }

        /// <summary>
        /// Returns the unit the building is rallied to.
        /// See also: RallyPosition, DoSetRallyPoint().
        /// </summary>
        public Unit RallyUnit { get { return new Unit(this.BwapiObject.getRallyUnit()); } }

        /// <summary>
        /// Orders the unit to set its rally position to the specified position. 
        /// See also: RallyPosition, RallyUnit.
        /// </summary>
        /// <param name="positionTarget"></param>
        /// <returns></returns>
        public bool DoSetRallyPoint(Position positionTarget) {
            return this.BwapiObject.setRallyPoint(positionTarget.BwapiObject);

        }

        /// <summary>
        /// Orders the unit to set its rally position to the specified unit.
        /// See also: RallyPosition, RallyUnit.
        /// </summary>
        /// <param name="unitTarget"></param>
        /// <returns></returns>
        public bool DoSetRallyPoint(Unit unitTarget) {
            return this.BwapiObject.setRallyPoint(unitTarget.BwapiObject);
        }

    }
}

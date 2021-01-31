using System;
using System.Collections.Generic;
using System.Text;

namespace StarcraftBot.Wrapper {
    partial class Unit {
        /// <summary>
        /// Orders the unit to use a tech not requiring a target (ex: Stim Pack). Returns true if it is a valid tech. 
        /// </summary>
        /// <param name="techType"></param>
        /// <returns></returns>
        public bool DoUseTech(TechTypes techType) {
            return this.BwapiObject.useTech(new SWIG.BWAPI.TechType((int)techType));
        }

        /// <summary>
        /// Orders the unit to use a tech requiring a position target (ex: Dark Swarm). Returns true if it is a valid tech. 
        /// </summary>
        /// <param name="techType"></param>
        /// <param name="positionTarget"></param>
        /// <returns></returns>
        public bool DoUseTech(TechTypes techType, Position positionTarget) {
            return this.BwapiObject.useTech(new SWIG.BWAPI.TechType((int)techType), positionTarget.BwapiObject);
        }

        /// <summary>
        /// Orders the unit to use a tech requiring a unit target (ex: Irradiate). Returns true if it is a valid tech. 
        /// </summary>
        /// <param name="techType"></param>
        /// <param name="unitTarget"></param>
        /// <returns></returns>
        public bool DoUseTech(TechTypes techType, Unit unitTarget) {
            return this.BwapiObject.useTech(new SWIG.BWAPI.TechType((int)techType), unitTarget.BwapiObject);
        }


    }
}

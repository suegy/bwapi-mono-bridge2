using System;
using System.Collections.Generic;
using System.Text;

namespace StarcraftBot.Wrapper {
    partial class Unit {
        /// <summary>
        /// Returns true if unit is mineral patch or refinery.
        /// </summary>
        public bool CanBeGathered { get { return this.BwapiObject.isBeingGathered(); } }


        /// <summary>
        /// Returns true if the unit is a worker that is carrying gas. 
        /// See also: DoReturnCargo(), IsGatheringGas.
        /// </summary>
        public bool IsCarryingGas { get { return this.BwapiObject.isCarryingGas(); } }

        /// <summary>
        /// Returns true if the unit is in one of the four states for gathering gas (MoveToGas, WaitForGas, HarvestGas, ReturnGas). 
        /// See also: IsCarryingGas, DoReturnCargo().
        /// </summary>
        public bool IsGatheringGas { get { return this.BwapiObject.isGatheringGas(); } }


        /// <summary>
        /// Returns true if the unit is a worker that is carrying minerals. 
        /// See also: DoReturnCargo(), IsGatheringMineral.
        /// </summary>
        public bool IsCarryingMineral { get { return this.BwapiObject.isCarryingMinerals(); } }

        /// <summary>
        /// Returns true if the unit is in one of the four states for gathering minerals (MoveToMinerals, WaitForMinerals, MiningMinerals, ReturnMinerals). 
        /// See also: IsCarryingMineral. DoReturnCargo().
        /// </summary>
        public bool IsGatheringMineral { get { return this.BwapiObject.isGatheringMinerals(); } }

        /// <summary>
        /// Orders the unit to return its cargo to a nearby resource depot such as a Command Center. 
        /// Only workers that are carrying minerals or gas can be ordered to return cargo. 
        /// See also: IsCarryingGas, IsCarryingMineral.
        /// </summary>
        /// <returns></returns>
        public bool DoReturnCargo() {
            return this.BwapiObject.returnCargo();
        }



    }
}

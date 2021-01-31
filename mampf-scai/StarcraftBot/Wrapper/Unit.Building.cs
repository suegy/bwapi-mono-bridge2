using System;
using System.Collections.Generic;
using System.Text;

namespace StarcraftBot.Wrapper {
    partial class Unit {
        /// <summary>
        /// If the unit is an SCV that is constructing a building, this will return the building it is constructing. 
        /// If the unit is a Terran building that is being constructed, this will return the SCV that is constructing it. 
        /// </summary>
        public Unit BuilderUnit { get { return new Unit(this.BwapiObject.getBuildUnit()); } }

        /// <summary>
        /// Returns the building type a worker is about to construct. If the unit is a morphing Zerg unit or 
        /// an incomplete building, this returns the UnitType the unit is about to become upon completion. 
        /// </summary>
        public UnitType BuildingToBecome { get { return new UnitType(this.BwapiObject.getBuildType()); } }

        /// <summary>
        /// Returns the remaining build time of a unit/building that is being constructed. 
        /// </summary>
        public int BuildTimeRemaining { get { return this.BwapiObject.getRemainingBuildTime(); } }
        


        /// <summary>
        /// Returns true if the unit is being constructed. 
        /// Always true for incomplete Protoss and Zerg buildings, and true for incomplete 
        /// Terran buildings that have an SCV constructing them. If the SCV halts construction, 
        /// isUnderConstruction will return false. 
        /// See also: DoBuild(), DoCancelConstruction(), DoHaltContruction(), IsUnderConstruction.
        /// </summary>
        public bool IsUnderConstruction { get { return this.BwapiObject.isBeingConstructed(); } }


        /// <summary>
        /// Returns true when a unit has been issued an order to build a structure and is moving to the build location. Also returns true for Terran SCVs while they construct a building. 
        /// See also: DoBuild(), DoCancelConstruction(), DoHaltContruction(), IsUnderContruction.
        /// </summary>
        public bool IsConstructing { get { return this.BwapiObject.isConstructing(); } }


        /// <summary>
        /// Returns true if the unit is a Protoss building that is unpowered because no pylons are in range. 
        /// </summary>
        public bool IsUnpowered { get { return this.BwapiObject.isUnpowered(); } }


        /// <summary>
        /// Orders the unit to build the given unit type at the given position. 
        /// Note that if the player does not have enough resources when the unit attempts 
        /// to place the building down, the order will fail. 
        /// </summary>
        /// <param name="tilePosition">Top left corner of the building</param>
        /// <param name="unitType"></param>
        /// <returns></returns>
        public bool DoBuild(BuildTile tilePosition, UnitTypes unitType) {
            return this.BwapiObject.build(tilePosition.BwapiObject, new SWIG.BWAPI.UnitType((int)unitType));
        }



        /// <summary>
        /// Orders the building to stop being constructed. This will destroy the building.
        /// See also: IsUnderContruction.
        /// </summary>
        /// <returns></returns>
        public bool DoCancelConstruction() {
            return this.BwapiObject.cancelConstruction();
        }

        /// <summary>
        /// Orders the SCV to stop constructing the building, and the building is left in a partially 
        /// complete state until it is canceled, destroyed, or completed. 
        /// See also: IsConstructing.
        /// </summary>
        /// <returns></returns>
        public bool DoHaltConstruction() {
            return this.BwapiObject.haltConstruction();
        }


        /// <summary>
        /// For Zerg Larva, this returns the Hatchery, Lair, or Hive unit this Larva was spawned from.
        /// </summary>
        public Unit Hatchery { get { return new Unit(this.BwapiObject.getHatchery()); } }

        /// <summary>
        /// Returns the set of larva spawned by this unit. 
        /// If the unit has no larva, or is not a Hatchery, Lair, or Hive, this function returns an empty list. 
        /// Equivalent to clicking "Select Larva" from the Starcraft GUI.
        /// </summary>
        public List<Unit> GetLarvas() {
            return Unit.GetListOfUnits(this.BwapiObject.getLarva());
        }









    }
}

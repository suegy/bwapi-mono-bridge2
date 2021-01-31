using System;
using System.Collections.Generic;
using System.Text;

namespace StarcraftBot.Wrapper {
    partial class Unit : BwapiObjectContainer<SWIG.BWAPI.Unit>
    {
        
        
        UnitType unitType = null;
        public Unit(SWIG.BWAPI.Unit bwapiUnit)
            : base(bwapiUnit)
        {
            this.unitType = new UnitType(bwapiUnit.getType());
        }

        //---

        public static List<Unit> GetListOfUnits(System.Collections.IEnumerable bwapiCollection) {
            List<Unit> result = new List<Unit>();
            try {
                foreach (SWIG.BWAPI.Unit u in bwapiCollection)
                {
                    result.Add(new Unit(u));
                }
            } catch { }
            return result;
        }


        //---


        //public int GetId() {
        //    return bwapiUnit.getID();
        //}

        /// <summary>
        /// Returns true if this unit can be controlled by ai.
        /// </summary>
        public bool IsMine { get { return this.BwapiObject.getPlayer() == SWIG.BWAPI.bwapi.Broodwar.self(); } }

        public UnitType UnitType { get { return this.unitType; } }

        public UnitTypes UnitTypeEnum { get { return this.unitType.UnitTypeEnum; } }


        /// <summary>
        /// Returns the position of the unit on the map. Measured in pixels.
        /// </summary>
        public Position Position { get { return new Position(this.BwapiObject.getPosition()); } }

        /// <summary>
        /// Returns the initial position of the neutral unit on the map.
        /// </summary>
        public Position PositionInitial { get { return new Position(this.BwapiObject.getInitialPosition()); } }

        /// <summary>
        /// Returns the build tile position of the unit on the map. Useful if the unit is a building. 
        /// The tile position is of the top left corner of the building.
        /// One tile = 32x32 pixels.
        /// </summary>
        public BuildTile BuildTile { get { return new BuildTile(this.BwapiObject.getTilePosition()); } }

        /// <summary>
        /// Returns the initial neutral build tile position of the unit on the map. 
        /// The tile position is of the top left corner of the building. 
        /// </summary>
        public BuildTile BuildTileInitial { get { return new BuildTile(this.BwapiObject.getInitialTilePosition()); } }

        /// <summary>
        /// Returns the edge-to-edge geometric distance between the current unit and the target unit. 
        /// </summary>
        /// <param name="unit"></param>
        /// <returns></returns>
        public double GetDistanceToUnit(Unit unit) {
            return this.BwapiObject.getDistance(unit.BwapiObject);
        }

        /// <summary>
        /// Returns the geometric distance from the edge of the current unit to the target position. 
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public double GetDistanceToPosition(Position position) {
            return this.BwapiObject.getDistance(position.BwapiObject);
        }

        /// <summary>
        /// Generally returns the appropriate target unit after issuing an order that accepts a target unit (ex: attack, repair, gather, follow, etc.). 
        /// To check for a target that has been acquired automatically (without issuing an order) see getOrderTarget. 
        /// </summary>
        public Unit TargetUnit { get { return new Unit(this.BwapiObject.getTarget()); } }

        /// <summary>
        /// Returns the target position the unit is moving to (provided a valid path to the target position exists). 
        /// </summary>
        public Position TargetPosition { get { return new Position(this.BwapiObject.getTargetPosition()); } }

        //Unit::getChild() is removed in version 3.2
        //public Unit Child { get { return new Unit(this.BwapiObject.getChild()); } }

        /// <summary>
        /// Orders the unit to attack move to the specified location. 
        /// </summary>
        /// <param name="positionTarget"></param>
        /// <returns></returns>
        public bool DoAttackMove(Position targetPosition) {
            return this.BwapiObject.attackMove(targetPosition.BwapiObject);
        }

        /// <summary>
        /// Orders the unit to attack the specified unit. 
        /// </summary>
        /// <param name="unitTarget"></param>
        /// <returns></returns>
        public bool DoAttackUnit(Unit unitTarget) {
            return this.BwapiObject.attackUnit(unitTarget.BwapiObject);
        }

        /// <summary>
        /// Works like the right click in the GUI. 
        /// </summary>
        /// <param name="targetPosition"></param>
        /// <returns></returns>
        public bool DoRightClick(Position targetPosition) {
            return this.BwapiObject.rightClick(targetPosition.BwapiObject);
        }

        /// <summary>
        /// Orders the unit to move to the specified position. After issuing, the unit's order will become Orders::Move.
        /// See also: Unit::isMoving.
        /// </summary>
        /// <param name="targetPosition"></param>
        /// <returns></returns>
        public bool DoMove(Position targetPosition)
        {
            return this.BwapiObject.move(targetPosition.BwapiObject);
        }

        /// <summary>
        /// Works like the right click in the GUI. 
        /// Right click on a mineral patch to order a worker to mine, right click on an enemy to attack it. 
        /// </summary>
        /// <param name="unitTarget"></param>
        /// <returns></returns>
        public bool DoRightClick(Unit unitTarget) {
            return this.BwapiObject.rightClick(unitTarget.BwapiObject);
        }

        //---

        /// <summary>
        /// Orders the unit to stop. 
        /// See also: IsIdle
        /// </summary>
        /// <returns></returns>
        public bool DoStop() {
            return this.BwapiObject.stop();
        }

        /// <summary>
        /// Returns true if the unit is not doing anything. 
        /// See also: DoStop().
        /// </summary>
        public bool IsIdle { get { return this.BwapiObject.isIdle(); } }

        //---


        /// <summary>
        /// Orders the unit to hold its position. 
        /// </summary>
        /// <returns></returns>
        public bool DoHoldPosition() {
            return this.BwapiObject.holdPosition();
        }

        //ADDED BY TWSANDBERG (24-09-2010)

        /// <summary>
        /// Returns a unique ID for this unit.
        /// </summary>
        public int ID { get { return this.BwapiObject.getID(); } }

















    }
}

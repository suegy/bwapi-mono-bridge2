using System;
using System.Collections.Generic;
using System.Linq;
using StarcraftBot.MathHelpers;
using StarcraftBot.Wrapper;

namespace StarcraftBot.UnitAgents 
{
    /// <summary>
    /// This class is the UnitAgent class that contains all the information and methods that is nessesary for
    /// making the units in StarCraft able to navigate, find and attack the goal specified by the TacticalAssaultAgent.
    /// The goal can be normal units like Zerglings, Zealots, Marine but also buildings.
    /// Potential Fields is used for desiding for each action where it would be best to go in the next frame to reach 
    /// the goal in the end.  
    /// @Author: Thomas Willer Sandberg (http://twsandberg.dk/)
    /// @version (1.0, January 2011)
    /// </summary>
    class UnitAgent
    {
        public UnitAgent(Unit myUnit, UnitAgentOptimizedProperties opProp)
        {
            MyUnit = myUnit;
            OptimizedProperties = opProp;
            LeadingStatus = LeadingStatusEnum.None;
            EmotionalMode = EmotionalModeEnum.None;

            HealthLevelOk = 60; //Health + armor

            UnitAgentTypeName = "Unit_Agent";
        }

        public void ExecuteBestActionForUnitAgent(List<UnitAgent> squad)
        {
            if (MyUnit.IsVisible && GoalUnitToAttack != null) //Always remember to check if the unit is visible, before Moving it.
            {

                SubGoalPosition = CalculateNewSubGoalPosition(squad, GoalUnitToAttack);

                if (MyUnit.WeaponGroundCooldown != 0)
                    MyUnit.DoRightClick(SubGoalPosition);
                else
                    MyUnit.DoAttackMove(SubGoalPosition);
            }
        }

        public Position CalculateNewSubGoalPosition(List<UnitAgent> squad, Unit closestEnemyUnit)
        {
            int currentX = MyUnit.Position.X;
            int currentY = MyUnit.Position.Y;
            List<Position> surroundingPositions = MyMath.GetPossibleSurroundingPositionsRotation(currentX, currentY, 48, 35);
            double currentPotentialFieldValue = -1000;
            double bestPotentialFieldValue = -1000;
            Position bestPosition = MyUnit.Position;

            foreach (Position possibleNextPosition in surroundingPositions)
            {
                currentPotentialFieldValue = CalculatePotentialField(squad, closestEnemyUnit, possibleNextPosition);
                if (currentPotentialFieldValue > bestPotentialFieldValue)
                {
                    bestPotentialFieldValue = currentPotentialFieldValue;
                    bestPosition = possibleNextPosition;
                }
            }
            return bestPosition;
        }

        /// <summary>
        /// Calculate the potential of the specified field/position.
        /// </summary>
        /// <param name="squad"></param>
        /// <param name="enemy"></param>
        /// <param name="field"></param>
        /// <returns></returns>
        public double CalculatePotentialField(List<UnitAgent> squad, Unit enemy, Position field)
        {
            double pVal = 0;

            //DO NOT UPDATE WITH EVOLUTIONARY ALGORITHM
            const double forceNeutralUnitsRepulsion = 200; // 0 - 1000 //REMEMBER TO SET TO A POSITIVE NUMBER.
            const double forceStepNeutralUnitsRepulsion = 1.2; // 0 - 10
            int rangeNeutralUnitsRepulsion = 8; //0-512
           // ///////////////////////////////////////////
    
            double distance = enemy.GetDistanceToPosition(field); 

            if (MyUnit.WeaponGroundCooldown == 0) //If the weapon is ready to fire, PFMaxShootingDistanceAttraction is activated
                pVal += PFMaxShootingDistanceAttraction(distance, enemy, OptimizedProperties.ForceMSD, OptimizedProperties.ForceStepMSD);//, MSDDiffDivValue);
            else if (MyUnit.UnitType.AttackRange > 1) //Else If Weapon is ready to fire and AttackRange is bigger than 1, FLEE/RETREAT until weapon is ready to fire again.
                pVal += PFWeaponCoolDownRepulsion(field, distance, enemy, OptimizedProperties.ForceWeaponCoolDownRepulsion, OptimizedProperties.ForceStepWeaponCoolDownRepulsion, OptimizedProperties.RangeWeaponCooldownRepulsion);

            //Squad attraction
            if (squad.Count>2)
                pVal += PFSquadAttraction(squad, field, OptimizedProperties.ForceSquadAttraction, OptimizedProperties.ForceStepSquadAttraction, OptimizedProperties.RangePercentageSquadAttraction);

            //Center of the map attraction (NEGATES the MSD)
            pVal += PFMapCenterAttraction(field, OptimizedProperties.ForceMapCenterAttraction, OptimizedProperties.ForceStepMapCenterAttraction,
                                  OptimizedProperties.RangePecentageMapCenterAttraction);

            //Map edge repulsion (NEGATES the MSD)
            pVal += MyMath.CalculateMapEdgeRepulsion(field, OptimizedProperties.ForceMapEdgeRepulsion, OptimizedProperties.ForceStepMapEdgeRepulsion, OptimizedProperties.RangeMapEdgeRepulsion);

            //Own Unit Repulsion
            pVal += PFOwnUnitsRepulsion(squad, field, OptimizedProperties.ForceOwnUnitsRepulsion,
                                                         OptimizedProperties.ForceStepOwnUnitsRepulsion, OptimizedProperties.RangeOwnUnitsRepulsion);

            //Enemy Unit Repulsion
            pVal += PFEnemyUnitsRepulsion(field, OptimizedProperties.ForceEnemyUnitsRepulsion,
                                                        OptimizedProperties.ForceStepEnemyUnitsRepulsion);//, rangeEnemyUnitsRepulsion);

            //Neutral Unit Repulsion
            pVal += PFNeutralUnitsRepulsion(field, forceNeutralUnitsRepulsion, 
                                                          forceStepNeutralUnitsRepulsion, rangeNeutralUnitsRepulsion);
            return pVal;
        }

        /// <summary>
        /// Calculates the potential value of the field that the current military unit can go to in the next frame, while the unit's weapon are ready to fire.
        /// The unit's Max Shooting Distance (MSD) will be the optimal place to be, because all enemy units with a shorter MSD then can't harm your unit, unless they move fastest. 
        /// </summary>
        /// <param name="distanceToEnemy"></param>
        /// <param name="enemyUnit"></param>
        /// <param name="forceToOwnMSD"></param>
        /// <param name="forceStepToOwnMSD"></param>
        /// <returns>double potentialValue</returns>
        public double PFMaxShootingDistanceAttraction(double distanceToEnemy, Unit enemyUnit, double forceToOwnMSD, double forceStepToOwnMSD)
        {
            int ownUnitMSD = MyUnit.UnitType.WeaponGround.AttackRangeMax; // / TileSize;// 
            int enemyUnitMSD = enemyUnit.UnitType.WeaponGround.AttackRangeMax;
            int MSDDifference = ownUnitMSD - enemyUnitMSD;

            double potenTialValueMSD = 0; //Weight potenTialValueMSD is used to alter the relative strength of the current tile, which the unit stands on or the possible tiles the unit can go to.

            if (distanceToEnemy > ownUnitMSD) //GET CLOSER TO ENEMY
                return forceToOwnMSD - forceStepToOwnMSD * (distanceToEnemy - ownUnitMSD);

            if (MSDDifference > 0)
            {
                if (distanceToEnemy <= ownUnitMSD && distanceToEnemy > enemyUnitMSD)
                    return forceToOwnMSD + distanceToEnemy;
            }
            else if (distanceToEnemy <= ownUnitMSD) //TOO CLOSE TO ENEMY
                return forceToOwnMSD;
            return potenTialValueMSD;
        }

        public double PFOwnUnitsRepulsion(List<UnitAgent> squad, Position field, double force, double forceStep, int range)
        {
            double pfValue = 0;

            if (SWIG.BWAPI.bwapi.Broodwar.self().getUnits() != null && SWIG.BWAPI.bwapi.Broodwar.self().getUnits().Count > 0)
            {
                foreach (UnitAgent myOtherUnit in squad)
                {
                    pfValue = MyMath.CalculatePFOwnUnitRepulsion(MyUnit, field, myOtherUnit.MyUnit, force, forceStep, range);
                    if (pfValue < 0)
                        return pfValue;
                }
            }
            else
                Logger.Logger.AddAndPrint("Enemy unit list is null in CalculatePFValueForCollisionWithEnemyUnits");
            return 0;
        }

        public double PFEnemyUnitsRepulsion(Position field, double force, double forceStep)
        {
            double pfValue = 0;
            //foreach (Unit myOtherUnit in unitsInMyArea)
            if (SWIG.BWAPI.bwapi.Broodwar.enemy().getUnits() != null && SWIG.BWAPI.bwapi.Broodwar.enemy().getUnits().Count > 0)
            {
                foreach (Unit enemyUnit in Game.PlayerEnemy.GetUnits())
                {
                    pfValue = MyMath.CalculatePFEnemyUnitRepulsion(MyUnit, field, enemyUnit, force, forceStep);
                    if (pfValue < 0)
                        return pfValue;
                }
            }
            else
                Logger.Logger.AddAndPrint("Enemy unit list is null in CalculatePFValueForCollisionWithEnemyUnits");
            return 0;
        }

        public double PFNeutralUnitsRepulsion(Position field, double force, double forceStep, int range)
        {
            double pfValue = 0;
            if (SWIG.BWAPI.bwapi.Broodwar.getStaticNeutralUnits() != null && SWIG.BWAPI.bwapi.Broodwar.getStaticNeutralUnits().Count > 0)
            {
                foreach (Unit neutralUnit in Game.GetAllNeutralUnitsStatic())
                {
                    pfValue = MyMath.CalculatePFNeutralUnitRepulsion(neutralUnit, field, force, forceStep, range);
                    if (pfValue < 0)
                        return pfValue;
                }
            }
            return 0;
        }

        /// <summary>
        /// Calculate the potential value of the field that the current military unit can go to in the next frame, while the unit's weapon has it's cooldown period.
        /// Weapon cooldown happens each time the weapon is reloading. 
        /// Some weapons are very effective, but recharges very slowly. It may therefore be a good tactic to flee when the weapon is in cool down, and thereby avoid being hit.
        /// </summary>
        /// <param name="field"></param>
        /// <param name="enemy"></param>
        /// <param name="distanceToEnemy"></param>
        /// <param name="force"></param>
        /// <param name="forceStep"></param>
        /// <param name="range"></param>
        /// <returns></returns>
        public double PFWeaponCoolDownRepulsion(Position field, double distanceToEnemy, Unit enemy, double force, double forceStep, int range)
        {
            if (enemy.IsVisible && IsInEnemyUnitsRange(field, range)) 
                return MyMath.CalculateRepulsiveMagnitude(force, forceStep, distanceToEnemy, true);
            return 0;
        }

        /// <summary>
        /// Calculates the magnitude of the specified position on the map relative to the centroid of the squad 
        /// (being close to the other units in the squad will give the best magnitude/attraction).
        /// </summary>
        /// <param name="squad"></param>
        /// <param name="possibleNextPosition"></param>
        /// <param name="force"></param>
        /// <param name="forceStep"></param>
        /// <param name="rangePercentage">How big the Range to the centroid of all the Units positions in the Squad/Group</param>
        /// <returns>The magnitude of squad attraction. 0 if a unit is inside the specified range and gives a negative linear drop-off the further away the unit is from the group.</returns>
        public double PFSquadAttraction(List<UnitAgent> squad, Position possibleNextPosition, double force, double forceStep, int rangePercentage)
        {
            var unitPositions = new Position[squad.Count];

            if (SWIG.BWAPI.bwapi.Broodwar.self().getUnits() != null && SWIG.BWAPI.bwapi.Broodwar.self().getUnits().Count > 0)
            {
                int i = 0;
                foreach (UnitAgent meleeUnitAgent in squad)
                {
                    unitPositions[i] = meleeUnitAgent.MyUnit.Position;
                    i++;
                }

                var meleeUnitPolygon = new Polygon(unitPositions);
                double distance = possibleNextPosition.GetDistance(meleeUnitPolygon.FindCentroid());
                return distance <= MyMath.GetPercentageOfMaxDistancePixels(rangePercentage)
                           ? force//0
                           : force - forceStep * distance;
            }
            Logger.Logger.AddAndPrint("Enemy unit list is null or has zero elements in CalculatePFValueForCollisionWithEnemyUnits");
            return 0;
        }

        /// <summary>
        /// Calculates the magnitude of the specified field relative to the center of the map.
        /// </summary>
        /// <param name="field"></param>
        /// <param name="force"></param>
        /// <param name="forceStep"></param>
        /// <param name="rangePercentage"></param>
        /// <returns></returns>
        public double PFMapCenterAttraction(Position field, double force, double forceStep, int rangePercentage)
        {
            double distance = field.GetDistance(MyMath.GetMapCenterPosition());
            return distance <= MyMath.GetPercentageOfMaxDistancePixels(rangePercentage)
                        ? force//0
                        : force - forceStep * distance;
        }

        /// <summary>
        /// Returns true if the specified position is inside one of the enemy units range + the extraRange.
        /// </summary>
        /// <param name="field"></param>
        /// <param name="extraRange"></param>
        /// <returns></returns>
        public Boolean IsInEnemyUnitsRange(Position field, int extraRange)
        {
            if (SWIG.BWAPI.bwapi.Broodwar.enemy().getUnits() != null && SWIG.BWAPI.bwapi.Broodwar.enemy().getUnits().Count > 0)
            {
                foreach (Unit enemyUnit in Game.PlayerEnemy.GetUnits())
                    if (CanBeAttacked(MyUnit, enemyUnit))
                        if (enemyUnit.GetDistanceToPosition(field) <= enemyUnit.UnitType.AttackRange + extraRange)
                            return true;
               // return Game.PlayerEnemy.GetUnits().Where(enemyUnit => CanBeAttacked(MyUnit, enemyUnit)).Any(enemyUnit => enemyUnit.GetDistanceToPosition(field) <= enemyUnit.UnitType.WeaponGround.AttackRangeMax);
            }
            return false;
        }

        /// <summary>
        /// Tells if the type of the specified own unit can be attacked by the specified enemy unitType.
        /// Inspiration from: BTHAI StarCraft bot ver. 1.00
        /// </summary>
        /// <param name="ownUnit"></param>
        /// <param name="enemyUnit"></param>
        /// <returns>True if own unit can be attacked by the enemy unit</returns>
        public Boolean CanBeAttacked(Unit ownUnit, Unit enemyUnit)
        {
            UnitType ownUnitType = ownUnit.UnitType;
            UnitType enemyUnitType = enemyUnit.UnitType;

            if (ownUnitType.IsFlyer)
            {
                //Can enemy unit attack air units.
                if (enemyUnitType.WeaponGround.CanAttackAir)
                    return true;
                if (enemyUnitType.WeaponAir.CanAttackAir)
                    return true;
            }
            else
            {
                //Can enemy unit attack ground units.
                if (enemyUnitType.WeaponGround.CanAttackGround)
                    return true;
                if (enemyUnitType.WeaponAir.CanAttackGround)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Checks if the current unit's health level is ok.
        /// </summary>
        /// <returns>True if the current unit's health level is ok (health and shield level together is over the specified minHealthLevel).</returns>
        public Boolean IsHealthLevelOk(int minHealthLevel)
        {
            if (MyUnit.HitPoints + MyUnit.Shields >= minHealthLevel)
                return true;
            return false;
        }

        /// <summary>
        /// Checks if the current unit's health level is ok.
        /// </summary>
        /// <returns>True if the current unit's health level is ok (health and shield level together is over 60).</returns>
        public Boolean IsHealthLevelOk(Unit unit)
        {
            int health = unit.HitPoints + unit.Shields;
            Boolean lowHealth = true;
            if (health < LastHealth)
                lowHealth = health >= HealthLevelOk;
            LastHealth = health;
            return lowHealth;
        }

        public enum EmotionalModeEnum
        {
            Defensive, Offensive, Exploration, Mining, Healing, Reparing, None
        };

        /// <summary>
        /// GroupLeader should lead a group, while the follower should follow the leader for each frame.
        /// </summary>
        public enum LeadingStatusEnum
        {
            GroupLeader, Follower, None
        };

        /************************************************************
         * All the properties and variables for the UnitAgent class *
         ************************************************************/
        protected int LastHealth = 0;

        public UnitAgentOptimizedProperties OptimizedProperties { get; set; }
        public Position GoalPosition { get; set; }
        public Unit GoalUnitToAttack { get; set; }
        public Position SubGoalPosition { get; set; }
        public Unit MyUnit { get; protected set; }
        public String UnitAgentTypeName { get; protected set;}
        public EmotionalModeEnum EmotionalMode { get; set; }
        public LeadingStatusEnum LeadingStatus { get; set; }
        public int HealthLevelOk { get; set; }
    }
}

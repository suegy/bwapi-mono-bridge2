using System;
using System.Collections.Generic;
using System.Text;

namespace StarcraftBot.Wrapper {

    class UnitType : BwapiObjectContainer<SWIG.BWAPI.UnitType>
    {

        public UnitType(SWIG.BWAPI.UnitType bwapiUnitType)
            : base(bwapiUnitType)
        {
            
        }


        //---

        public static List<UnitType> GetListOfUnitTypes(System.Collections.IEnumerable bwapiCollection) {
            List<UnitType> result = new List<UnitType>();
            try {
                foreach (SWIG.BWAPI.UnitType t in bwapiCollection)
                {
                    result.Add(new UnitType(t));
                }
            } catch { }
            return result;
        }


        //---


        public UnitTypes UnitTypeEnum {
            get{
            return (UnitTypes)this.BwapiObject.getID();
            //switch (this.BwapiObject.getID()) {
            //    caseSWIG.BWAPI.bwapi.UnitTypeNone: return UnitTypes.None;
            //    caseSWIG.BWAPI.bwapi.UnitTypeUnknown: return UnitTypes.Unknown;
            //    caseSWIG.BWAPI.bwapi.Terran_Command_Center: return UnitTypes.TerranCommandCenter;
            //}
            }
        }

        /// <summary>
        /// Returns the set of tech types this unit can use, provided the tech types have been researched and the unit has enough energy. 
        /// </summary>
        /// <returns></returns>
        public List<TechType> AbilitiesAvailable() {
            return TechType.GetListOfTechTypes(this.bwapiObject.abilities());
        }

        /// <summary>
        /// Returns the maximum amount of hit points the unit type can have. 
        /// </summary>
        public int HitPointsMax { get { return this.BwapiObject.maxHitPoints(); } }

        /// <summary>
        /// Returns the maximum amount of shields the unit type can have. 
        /// </summary>
        public int ShieldsMax { get { return this.BwapiObject.maxShields(); } }

        /// <summary>
        /// Returns the maximum amount of energy the unit type can have. 
        /// </summary>
        public int EnergyMax { get { return this.BwapiObject.maxEnergy(); } }

        /// <summary>
        /// Returns the amount of armor the non-upgraded unit type has. 
        /// </summary>
        public int Armor { get { return this.BwapiObject.armor(); } }

        /// <summary>
        /// Returns the mineral price of the unit.
        /// </summary>
        public int PriceMinerals { get { return this.BwapiObject.mineralPrice(); } }

        /// <summary>
        /// Returns the gas price of the unit.
        /// </summary>
        public int PriceGas { get { return this.BwapiObject.gasPrice(); } }

        /// <summary>
        /// Returns the number of frames needed to make this unit type. 
        /// </summary>
        public int BuildTime { get { return this.BwapiObject.buildTime(); } }


        /// <summary>
        /// Returns the doubled amount of supply used by this unit.
        /// </summary>
        public int SupplyRequiredDoubled { get { return this.BwapiObject.supplyRequired(); } }

        /// <summary>
        /// Returns the amount of supply used by this unit.
        /// </summary>
        public int SupplyRequired {
            get {
                int resultDoubled = this.BwapiObject.supplyRequired();
                int result = Convert.ToInt32(resultDoubled * 1.0 / 2.0);
                if (resultDoubled % 2 > 0) result++;
                return result;
            }
        }

        /// <summary>
        /// Returns the doubled amount of supply produced by this unit.
        /// </summary>
        public int SupplyProvidedDoubled { get { return this.BwapiObject.supplyProvided(); } }

        /// <summary>
        /// Returns the amount of supply produced by this unit
        /// </summary>
        public int SupplyProvided {
            get {
                int resultDoubled = this.BwapiObject.supplyProvided();
                int result = Convert.ToInt32(resultDoubled * 1.0 / 2.0);
                if (resultDoubled % 2 > 0) result++;
                return result;
            }
        }

        /// <summary>
        /// Returns the amount of space this unit type takes up inside a bunker or transport unit. 
        /// </summary>
        public int SpaceRequired { get { return this.BwapiObject.spaceRequired(); } }

        /// <summary>
        /// Returns the amount of space this unit type provides. 
        /// </summary>
        public int SpaceProvided { get { return this.BwapiObject.spaceProvided(); } }

        /// <summary>
        /// Returns the score which is used to determine the total scores in the after-game stats screen. 
        /// </summary>
        public int ScoreBuild { get { return this.BwapiObject.buildScore(); } }

        /// <summary>
        /// Returns the score which is used to determine the total scores in the after-game stats screen. 
        /// </summary>
        public int ScoreDestroy { get { return this.BwapiObject.destroyScore(); } }

        /// <summary>
        /// Returns the size of the unit - either Small, Medium, Large, or Independent. 
        /// </summary>
        public UnitSizeTypes SizeTypeEnum { get { return (UnitSizeTypes)this.BwapiObject.size().getID(); } }

        /// <summary>
        /// Returns the tile width of the unit. Useful for determining the size of buildings. Ex: TileWidth of SupplyDepot is 3.
        /// </summary>
        public int TileWidth { get { return this.BwapiObject.tileWidth(); } }

        /// <summary>
        /// Returns the tile height of the unit. Useful for determining the size of buildings. Ex: TileHeight of SupplyDepot is 2.
        /// </summary>
        public int TileHeight { get { return this.BwapiObject.tileHeight(); } }

        /// <summary>
        /// Returns the range at which the unit will start targeting enemy units, measured in pixels.
        /// </summary>
        public int AttackRange { get { return this.BwapiObject.seekRange(); } }

        /// <summary>
        /// Returns how far the un-upgraded unit type can see into the fog of war, measured in pixels.
        /// </summary>
        public int SightRange { get { return this.BwapiObject.sightRange(); } }

        /// <summary>
        /// Returns the unit's non-upgraded top speed in pixels per frame. 
        /// </summary>
        public double SpeedMax { get { return this.BwapiObject.topSpeed(); } }

        /// <summary>
        /// Returns how fast the unit can accelerate to its top speed. What units this quantity is measured in is currently unknown. 
        /// </summary>
        public int Acceleration { get { return this.BwapiObject.acceleration(); } }

        /// <summary>
        /// Related to how fast the unit can halt. What units this quantity is measured in is currently unknown. 
        /// </summary>
        public int HaltDistance { get { return this.BwapiObject.haltDistance(); } }

        /// <summary>
        /// Related to how fast the unit can turn. What units this quantity is measured in is currently unknown. 
        /// </summary>
        public int TurnRadius { get { return this.BwapiObject.turnRadius(); } }

        /// <summary>
        /// Returns true for flying/air units. 
        /// </summary>
        public bool IsFlyer { get { return this.BwapiObject.isFlyer(); } }

        /// <summary>
        /// Returns the unit's air weapon. 
        /// </summary>
        public WeaponType WeaponAir { get { return new WeaponType(this.BwapiObject.airWeapon()); } }

        /// <summary>
        /// Returns the unit's ground weapon. 
        /// </summary>
        public WeaponType WeaponGround { get { return new WeaponType(this.BwapiObject.groundWeapon()); } }

        /// <summary>
        /// Returns true for units that regenerate health. ex: zerg units.
        /// </summary>
        public bool IsRegeneratesHitPoints { get { return this.BwapiObject.regeneratesHP(); } }

        /// <summary>
        /// Returns true if the unit type is capable of casting spells or using technology. 
        /// </summary>
        public bool IsSpellCaster { get { return this.BwapiObject.isSpellcaster(); } }

        /// <summary>
        /// Returns true for the two units that are permanently cloaked - Protoss Observer and Protoss Dark Templar. 
        /// </summary>
        public bool IsPermanentCloaked { get { return this.BwapiObject.hasPermanentCloak(); } }

        /// <summary>
        /// Returns true for units that cannot be destroyed. ex: Terran Nuclear Missile, Mineral Field, Vespene Geyser, etc. 
        /// </summary>
        public bool IsInvincible { get { return this.BwapiObject.isInvincible(); } }

        /// <summary>
        /// Returns true if the unit is organic, such as a Terran Marine. 
        /// </summary>
        public bool IsOrganic { get { return this.BwapiObject.isOrganic(); } }

        /// <summary>
        /// Returns true if the unit is mechanical such as a Terran Vulture. 
        /// </summary>
        public bool IsMechanical { get { return this.BwapiObject.isMechanical(); } }

        /// <summary>
        /// Returns true for the four robotic Protoss units - Probe, Shuttle, Reaver, and Observer. 
        /// </summary>
        public bool IsRobotic { get { return this.BwapiObject.isRobotic(); } }

        /// <summary>
        /// Returns true for the seven units that can detect cloaked units - Terran Science Vessel, 
        /// Spell Scanner Sweep, Zerg Overlord, Protoss Observer, Terran Missile Turret, 
        /// Zerg Spore Colony and Protoss Photon Cannon. 
        /// </summary>
        public bool IsDetector { get { return this.BwapiObject.isDetector(); } }

        /// <summary>
        /// Returns true for the five units that hold resources - Mineral Field, Vespene Geyser, Terran Refinery, Zerg Extractor, and Protoss Assimilator. 
        /// </summary>
        public bool IsResourceContainer { get { return this.BwapiObject.isResourceContainer(); } }

        /// <summary>
        /// Returns true for the five units that can accept resources - Terran Command Center, Protoss Nexus, Zerg Hatchery, Zerg Lair, and Zerg Hive. 
        /// </summary>
        public bool IsResourceDepot { get { return this.BwapiObject.isResourceDepot(); } }

        /// <summary>
        /// Returns true for Terran Refinery, Zerg Extractor, and Protoss Assimilator. 
        /// </summary>
        public bool IsRefinery { get { return this.BwapiObject.isRefinery(); } }

        /// <summary>
        /// Returns true for Protoss Probe, Terran SCV, and Zerg Drone.
        /// </summary>
        public bool IsWorker { get { return this.BwapiObject.isWorker(); } }

        /// <summary>
        /// Returns true for buildings that must be near a pylon to be constructed. 
        /// </summary>
        public bool IsRequiresPylonPsi { get { return this.BwapiObject.requiresPsi(); } }

        /// <summary>
        /// Returns true for buildings that can only be built on zerg creep. 
        /// </summary>
        public bool IsRequiresCreep { get { return this.BwapiObject.requiresCreep(); } }

        /// <summary>
        /// Returns true for Zergling and Scourge. 
        /// </summary>
        public bool IsTwoUnitsInOneEgg { get { return this.BwapiObject.isTwoUnitsInOneEgg(); } }

        /// <summary>
        /// Returns true for Zerg Lurker and units that can burrow when burrow tech is researched. 
        /// </summary>
        public bool IsBurrowable { get { return this.BwapiObject.isBurrowable(); } }

        /// <summary>
        /// Returns true for units that can be cloaked - Terran Ghost and Terran Wraith. Does not include units which have permanent cloak (Protoss Observer and Protoss Dark Templar). 
        /// </summary>
        public bool IsCloakable { get { return this.BwapiObject.isCloakable(); } }

        /// <summary>
        /// Returns true if the unit is a building (also true for mineral field and vespene geyser). 
        /// </summary>
        public bool IsBuilding { get { return this.BwapiObject.isBuilding(); } }

        /// <summary>
        /// Returns true if the unit is an add-on, such as a Terran Comsat Station. 
        /// </summary>
        public bool IsAddon { get { return this.BwapiObject.isAddon(); } }

        /// <summary>
        /// Returns true for Terran buildings that can lift off, like Barracks. 
        /// </summary>
        public bool IsBuildingFlying { get { return this.BwapiObject.isFlyingBuilding(); } }

        /// <summary>
        /// Returns true if the unit is neutral, such as a critter or mineral field. 
        /// </summary>
        public bool IsNeutral { get { return this.BwapiObject.isNeutral(); } }


        public bool IsMineral {
            get {
                return this.UnitTypeEnum == UnitTypes.Resource_MineralPatch1 ||
                    this.UnitTypeEnum == UnitTypes.Resource_MineralPatch2 ||
                    this.UnitTypeEnum == UnitTypes.Resource_MineralPatch3;
            }
        }

        public bool IsGeyser {
            get {
                return this.UnitTypeEnum == UnitTypes.Resource_VespeneGeyser;
            }
        }

        ////ADDED BY TWSANDBERG(DEATHEAGLE -- 23-09-2010

        /// <summary>
        /// Returns the distance from the center of the unit to the left edge of the unit, measured in pixels.
        /// </summary>
        public int DimensionLeft { get { return this.BwapiObject.dimensionLeft(); } }

        /// <summary>
        /// Returns the distance from the center of the unit to the right edge of the unit, measured in pixels.
        /// </summary>
        public int DimensionRight { get { return this.BwapiObject.dimensionRight(); } }

        /// <summary>
        /// Returns the distance from the center of the unit to the left edge of the unit, measured in pixels.
        /// </summary>
        public int DimensionDown { get { return this.BwapiObject.dimensionDown(); } }

        /// <summary>
        /// Returns the distance from the center of the unit to the top edge of the unit, measured in pixels.
        /// </summary>
        public int DimensionUp { get { return this.BwapiObject.dimensionUp(); } }

        /////////////////////
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace StarcraftBot.Wrapper {
    partial class Unit {

        /// <summary>
        /// Returns true if the unit is visible. 
        /// If the CompleteMapInformation cheat flag is enabled, 
        /// existing units hidden by the fog of war will be accessible, but isVisible will still return false. 
        /// See also : Exists
        /// </summary>
        public bool IsVisible { get { return this.BwapiObject.isVisible(); } }

        /// <summary>
        /// Returns true if unit exists. May return false on enemy units in fog of war.
        /// See also: IsVisible.
        /// </summary>
        public bool Exists { get { return this.BwapiObject.exists(); } }

        //---

        /// <summary>
        /// Returns the unit's current amount of hit points. 
        /// </summary>
        public int HitPoints { get { return this.BwapiObject.getHitPoints(); } }

        /// <summary>
        /// Returns the unit's initial amount of hit points, or 0 if it wasn't a neutral unit at the beginning of the game. 
        /// </summary>
        public int HitPointsInitial { get { return this.BwapiObject.getInitialHitPoints(); } }

        /// <summary>
        /// Returns the unit's current amount of shields. 
        /// </summary>
        public int Shields { get { return this.BwapiObject.getShields(); } }

        /// <summary>
        /// Returns the unit's current amount of energy. 
        /// </summary>
        public int Energy { get { return this.BwapiObject.getEnergy(); } }

        /// <summary>
        /// Get count of minerals in mineral patch or count of gas in geyser. Can be called on geyser buildings.
        /// </summary>
        /// <returns></returns>
        public int ResourcesCount { get { return this.BwapiObject.getResources(); } }

        /// <summary>
        /// Returns the unit's current kill count. 
        /// </summary>
        public int KillCount { get { return this.BwapiObject.getKillCount(); } }

        //---

        /// <summary>
        /// Returns unit's ground weapon cooldown. It is 0 if the unit is ready to attack. 
        /// </summary>
        public int WeaponGroundCooldown { get { return this.BwapiObject.getGroundWeaponCooldown(); } }

        /// <summary>
        /// Returns unit's air weapon cooldown. It is 0 if the unit is ready to attack.
        /// </summary>
        public int WeaponAirCooldown { get { return this.BwapiObject.getAirWeaponCooldown(); } }

        //---

        /// <summary>
        /// Returns the direction the unit is facing, measured in radians. An angle of 0 means the unit is facing east. 
        /// </summary>
        public double Angle { get { return this.BwapiObject.getAngle(); } }

        /// <summary>
        /// Returns the X component of the unit's velocity, measured in pixels per frame. 
        /// </summary>
        public double VelocityX { get { return this.BwapiObject.getVelocityX(); } }

        /// <summary>
        /// Returns the Y component of the unit's velocity, measured in pixels per frame. 
        /// </summary>
        public double VelocityY { get { return this.BwapiObject.getVelocityY(); } }

        /// <summary>
        /// Returns true if the unit is currently accelerating. 
        /// </summary>
        public bool IsAccelerating { get { return this.BwapiObject.isAccelerating(); } }

        /// <summary>
        /// Returns true if the unit is currently braking/slowing down. 
        /// </summary>
        public bool IsSlowing { get { return this.BwapiObject.isBraking(); } }


        //---

        /// <summary>
        /// Returns the number of interceptors the Protoss Carrier has. 
        /// </summary>
        public int InterceptorCount { get { return this.BwapiObject.getInterceptorCount(); } }

        /// <summary>
        /// Returns the number of scarabs in the Protoss Reaver. 
        /// </summary>
        public int ScarabCount { get { return this.BwapiObject.getScarabCount(); } }

        /// <summary>
        /// Returns the number of spider mines in the Terran Vulture. 
        /// </summary>
        public int SpiderMineCount { get { return this.BwapiObject.getSpiderMineCount(); } }

        //---





        /// <summary>
        /// Returns true if the unit has been completed. 
        /// </summary>
        public bool IsCompleted { get { return this.BwapiObject.isCompleted(); } }






        /// <summary>
        /// Returns true if the unit is moving. 
        /// See also: DoAttackMove(), DoStop().
        /// </summary>
        public bool IsMoving { get { return this.BwapiObject.isMoving(); } }



        /// <summary>
        /// Returns true if the unit has been selected by the user via the starcraft GUI. 
        /// Only available if you enable UserInput flag during onStart. 
        /// </summary>
        public bool IsSelected { get { return this.BwapiObject.isSelected(); } }

        /// <summary>
        /// Returns true if the unit is starting to attack. 
        /// See also: DoAttackUnit(), WeaponGroundCooldown, WeaponAirCooldown. 
        /// </summary>
        public bool IsStartingAttack { get { return this.BwapiObject.isStartingAttack(); } }






    }
}

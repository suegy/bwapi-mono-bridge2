using System;
using System.Collections.Generic;
using System.Text;

namespace StarcraftBot.Wrapper {
    class WeaponType : BwapiObjectContainer<SWIG.BWAPI.WeaponType>
    {

        public WeaponType(SWIG.BWAPI.WeaponType bwapiWeaponType)
            : base(bwapiWeaponType)
        {
        }

        public WeaponTypes WeaponTypeEnum { get { return (WeaponTypes)this.BwapiObject.getID(); } }

        /// <summary>
        /// Returns the amount of damage that this weapon deals per attack. 
        /// </summary>
        public int DamageAmount { get { return this.BwapiObject.damageAmount(); } }

        public int DamageBonus { get { return this.BwapiObject.damageBonus(); } }

        /// <summary>
        /// Returns the amount of cooldown time between attacks. 
        /// </summary>
        public int DamageCooldown { get { return this.BwapiObject.damageCooldown(); } }

        /// <summary>
        /// Returns the amount that the damage increases per upgrade.
        /// </summary>
        public int DamageFactor { get { return this.BwapiObject.damageFactor(); } }

        /// <summary>
        /// Returns the minimum attack range of the weapon, measured in pixels.
        /// </summary>
        public int AttackRangeMin { get { return this.BwapiObject.minRange(); } }

        /// <summary>
        /// Returns the maximum attack range of the weapon, measured in pixels. 
        /// </summary>
        public int AttackRangeMax { get { return this.BwapiObject.maxRange(); } }

        /// <summary>
        /// Returns true if this weapon can attack air units. 
        /// </summary>
        public bool CanAttackAir { get { return this.BwapiObject.targetsAir(); } }

        /// <summary>
        /// Returns true if this weapon can attack ground units. 
        /// </summary>
        public bool CanAttackGround { get { return this.BwapiObject.targetsGround(); } }




        
    }
}

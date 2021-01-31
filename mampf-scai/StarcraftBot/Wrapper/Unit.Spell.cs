using System;
using System.Collections.Generic;
using System.Text;

namespace StarcraftBot.Wrapper {
    partial class Unit {

        /// <summary>
        /// Returns unit's spell cooldown. It is 0 if the unit is ready cast a spell. 
        /// </summary>
        public int SpellCooldown { get { return this.BwapiObject.getSpellCooldown(); } }

        //---

        /// <summary>
        /// Returns true if the unit has been stasised by a Protoss Arbiter.
        /// See also: StasisFieldTimer.
        /// </summary>
        public bool IsUnderStasisField { get { return this.BwapiObject.isStasised(); } }

        /// <summary>
        /// Returns the time until the stasis field (arbiter's freeze) wears off. 0 if no stasis field is present.
        /// See also: IsUnderStasisField.
        /// </summary>
        public int StasisFieldTimer { get { return this.BwapiObject.getStasisTimer(); } }

        //---

        /// <summary>
        /// Returns true if the unit is currently under Stim Pack.
        /// See also: StimPackTimer.
        /// </summary>
        public bool IsUnderStimPack { get { return this.BwapiObject.isStimmed(); } }
        
        /// <summary>
        /// Returns the time until the stimpack wears off. 0 -> No stimpack boost present. 
        /// See also: IsUnderStimPack.
        /// </summary>
        public int StimPackTimer { get { return this.BwapiObject.getStimTimer(); } }

        //---

        /// <summary>
        /// Returns the remaining hit points of the defense matrix. Initially a defense Matrix has 250 points. 
        /// See also: DefenceMatrixTimer, IsDefenceMatrixed.
        /// </summary>
        public int DefenceMatrixHitpoints { get { return this.BwapiObject.getDefenseMatrixPoints(); } }

        /// <summary>
        /// Returns the time until the defense matrix wears off. 0 if no defense matrix is present.
        /// See also: DefenceMatrixHitpoints, IsUnderDefenceMatrix.
        /// </summary>
        public int DefenceMatrixTimer { get { return this.BwapiObject.getDefenseMatrixTimer(); } }

        /// <summary>
        /// Returns true if the unit has a defense matrix from a Terran Science Vessel. 
        /// See also: DefenceMatrixHitPoints, DefenceMatrixTimer
        /// </summary>
        public bool IsUnderDefenceMatrix { get { return this.BwapiObject.isDefenseMatrixed(); } }

        //---

        /// <summary>
        /// Returns the time until the ensnare effect wears off. 0 if no ensnare effect is present. 
        /// See also: IsUnderEnsnare.
        /// </summary>
        public int EnsnareTimer { get { return this.BwapiObject.getEnsnareTimer(); } }

        /// <summary>
        /// Returns true if the unit has been ensnared by a Zerg Queen. 
        /// See also: EnsnareTimer.
        /// </summary>
        public bool IsUnderEnsnare { get { return this.BwapiObject.isEnsnared(); } }

        //---

        /// <summary>
        /// Returns the time until the radiation wears off. 0 if no radiation is present.
        /// See also: IsUnderIrradiate.
        /// </summary>
        public int IrradiateTimer { get { return this.BwapiObject.getIrradiateTimer(); } }

        /// <summary>
        /// Returns true if the unit is being irradiated by a Terran Science Vessel. 
        /// See also: IrradiateTimer.
        /// </summary>
        public bool IsUnderIrradiate { get { return this.BwapiObject.isIrradiated(); } }

        //---

        /// <summary>
        /// Returns true if the unit is locked down by a Terran Ghost. 
        /// See also: LockdownTimer.
        /// </summary>
        public bool IsUnderLockdown { get { return this.BwapiObject.isLockedDown(); } }

        /// <summary>
        /// Returns the time until the lockdown wears off. 0 if no lockdown is present. 
        /// See also: IsUnderLockdown.
        /// </summary>
        public int LockdownTimer { get { return this.BwapiObject.getLockdownTimer(); } }

        //---

        /// <summary>
        /// Returns the time until the maelstrom wears off. 0 if no maelstrom is present.
        /// See also: IsUnderMaelstrom.
        /// </summary>
        public int MaelstromTimer { get { return this.BwapiObject.getMaelstromTimer(); } }

        /// <summary>
        /// Returns true if the unit is being maelstrommed. 
        /// See also: MaelstromTimer.
        /// </summary>
        public bool IsUnderMaelstrom { get { return this.BwapiObject.isMaelstrommed(); } }

        //---

        /// <summary>
        /// Returns the time until the plague wears off. 0 if no plague is present.
        /// See also: IsUnderPlague.
        /// </summary>
        public int PlagueTimer { get { return this.BwapiObject.getPlagueTimer(); } }

        /// <summary>
        /// Returns true if the unit has been plagued by a Zerg Defiler. 
        /// See also: PlagueTimer.
        /// </summary>
        public bool IsUnderPlague { get { return this.BwapiObject.isPlagued(); } }

        //---

        /// <summary>
        /// Returns true if the unit is a Zerg unit that is current burrowed. 
        /// See also: DoBurrow(), DoUnburrow().
        /// </summary>
        public bool IsBurrowed { get { return this.BwapiObject.isBurrowed(); } }

        /// <summary>
        /// Orders the unit to burrow. Either the unit must be a Zerg Lurker, or the unit must be 
        /// a Zerg ground unit and burrow tech must be researched. 
        /// See also: DoUnburrow(), IsBurrowed.
        /// </summary>
        /// <returns></returns>
        public bool DoBurrow() {
            return this.BwapiObject.burrow();
        }

        /// <summary>
        /// Orders the burrowed unit to unburrow. 
        /// See also: DoBurrow(), IsBurrowed.
        /// </summary>
        /// <returns></returns>
        public bool DoUnburrow() {
            return this.BwapiObject.unburrow();
        }

        //---

        /// <summary>
        /// Returns true if the unit is cloaked. 
        /// See also: DoCloak(), DoDecloak().
        /// </summary>
        public bool IsCloaked { get { return this.BwapiObject.isCloaked(); } }

        /// <summary>
        /// Orders the unit to cloak. 
        /// See also: DoDecloak(), IsCloaked.
        /// </summary>
        /// <returns></returns>
        public bool DoCloak() {
            return this.BwapiObject.cloak();
        }

        /// <summary>
        /// Orders the unit to decloak. 
        /// See also: DoCloak(), IsCloaked.
        /// </summary>
        /// <returns></returns>
        public bool DoDecloak() {
            return this.BwapiObject.decloak();
        }

        //---

        /// <summary>
        /// Returns the amount of time until the unit is removed, or 0 if the unit does not have a remove timer. 
        /// Used to determine how much time remains before hallucinated units, dark swarm, etc have until they are removed. 
        /// </summary>
        public int RemoveTimer { get { return this.BwapiObject.getRemoveTimer(); } }

        /// <summary>
        /// Returns true for hallucinated units, false for normal units. Returns true for hallucinated enemy units only if Complete Map Information is enabled.
        /// See also: RemoveTimer.
        /// </summary>
        public bool IsHallucination { get { return this.BwapiObject.isHallucination(); } }

        /// <summary>
        /// Returns true if the unit is currently being healed by a Terran Medic. 
        /// </summary>
        public bool IsHealedNow { get { return this.BwapiObject.isBeingHealed(); } }

        /// <summary>
        /// Returns true if the unit is currently blind from a Medic's Optical Flare. 
        /// </summary>
        public bool IsUnderBlind { get { return this.BwapiObject.isBlind(); } }

        /// <summary>
        /// Returns true if the unit has been parasited by some other player. 
        /// </summary>
        public bool IsUnderParasite { get { return this.BwapiObject.isParasited(); } }


        /// <summary>
        /// Returns true if the unit is under a Protoss Psionic Storm. 
        /// </summary>
        public bool IsUnderPsionicStorm { get { return this.BwapiObject.isUnderStorm(); } }

    }
}

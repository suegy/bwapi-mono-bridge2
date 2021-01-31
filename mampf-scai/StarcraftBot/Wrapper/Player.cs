using System;
using System.Collections.Generic;
using System.Text;

namespace StarcraftBot.Wrapper {
    class Player : BwapiObjectContainer<SWIG.BWAPI.Player>
    {

        public Player(SWIG.BWAPI.Player bwapiPlayer) : base(bwapiPlayer) { }

        //---

        public static List<Player> GetListOfPlayers(System.Collections.IEnumerable bwapiCollection) {
            List<Player> result = new List<Player>();
            try {
                foreach (SWIG.BWAPI.Player p in bwapiCollection)
                {
                    result.Add(new Player(p));
                }
            } catch { }
            return result;
        }

        //---


        /// <summary>
        /// Returns a unique ID for the player.
        /// </summary>
        /// <returns></returns>
        public int Id { get { return this.BwapiObject.getID(); } }

        /// <summary>
        /// Returns the name of the player. 
        /// </summary>
        /// <returns></returns>
        public string Name { get { return this.BwapiObject.getName(); } }

        /// <summary>
        /// Returns the set of units the player own. 
        /// Note that units loaded into Terran dropships, Terran bunkers, Terran refineries, 
        /// Protoss assimilators and Zerg extractors are not included in the set. 
        /// </summary>
        /// <returns></returns>
        public List<Unit> GetUnits() {
            return Unit.GetListOfUnits(this.BwapiObject.getUnits());
        }

        /// <summary>
        /// Returns the race of the player. 
        /// </summary>
        /// <returns></returns>
        public Races RaceEnum { 
            get {
                if (this.BwapiObject == null) return Races.None;
                SWIG.BWAPI.Race bwapiRace = this.BwapiObject.getRace();
                if (bwapiRace == null) return Races.None;
                return (Races)bwapiRace.getID(); 
            } 
        }

        /// <summary>
        /// Returns the type of the player. Human, Computer, HumanDefated, etc.
        /// </summary>
        /// <returns></returns>
        public PlayerTypes PlayerTypeEnum { 
            get {
                if (this.BwapiObject == null) return PlayerTypes.None;
                SWIG.BWAPI.PlayerType bwapipt = this.BwapiObject.getType();
                if (bwapipt == null) return PlayerTypes.None;
                return (PlayerTypes)bwapipt.getID(); 
            } 
        }

        /// <summary>
        /// Returns true if other player is an ally of this player. 
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public bool IsAllyOfPlayer(Player player) {
            return this.BwapiObject.isAlly(player.BwapiObject);
        }

        /// <summary>
        /// Returns true if other player is an enemy of this player. 
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public bool IsEnemyOfPlayer(Player player) {
            return this.BwapiObject.isEnemy(player.BwapiObject);
        }

        /// <summary>
        /// Returns true if the player is the neutral player. 
        /// </summary>
        /// <returns></returns>
        public bool IsNeutral { get { return this.BwapiObject.isNeutral(); } }

        /// <summary>
        /// Get start location for visible player.
        /// </summary>
        public BuildTile StartLocation { get { return new BuildTile(this.BwapiObject.getStartLocation()); } }

        /// <summary>
        /// Returns true if the player has achieved victory. 
        /// </summary>
        public bool IsVictorious { get { return this.BwapiObject.isVictorious(); } }

        /// <summary>
        /// Returns true if the player has been defeated. 
        /// </summary>
        public bool IsDefeated { get { return this.BwapiObject.isDefeated(); } }

        /// <summary>
        /// Returns true if the player left the game. 
        /// </summary>
        public bool IsQuitFromGame { get { return this.BwapiObject.leftGame(); } }

        /// <summary>
        /// Returns the amount of minerals the player has. 
        /// </summary>
        public int Minerals { get { return this.BwapiObject.minerals(); } }

        /// <summary>
        /// Returns the amount of vespene gas the player has. 
        /// </summary>
        public int Gas { get { return this.BwapiObject.gas(); } }

        /// <summary>
        /// Returns the cumulative amount of minerals the player has mined up to this point (including the 50 minerals at the start of the game). 
        /// </summary>
        public int MineralsTotalMined { get { return this.BwapiObject.cumulativeMinerals(); } }

        /// <summary>
        /// Returns the cumulative amount of gas the player has harvested up to this point. 
        /// </summary>
        public int GasTotalMined { get { return this.BwapiObject.cumulativeGas(); } }

        /// <summary>
        /// Returns the total doubled amount of supply the player has.
        /// </summary>
        public int SupplyTotalDoubled() { 
            return this.BwapiObject.supplyTotal();  
        }

        /// <summary>
        /// Returns the total doubled amount of supply for the specified race if more than one.
        /// </summary>
        /// <param name="race"></param>
        /// <returns></returns>
        public int SupplyTotalDoubled(Races race) {
            return this.BwapiObject.supplyTotal(new SWIG.BWAPI.Race((int)race));
        }

        /// <summary>
        /// Returns the total amount of supply the player has.
        /// </summary>
        public int SupplyTotal() {
            int supplyDoubled = this.BwapiObject.supplyTotal();
            int result = Convert.ToInt32(supplyDoubled * 1.0 / 2.0);
            if (supplyDoubled % 2 > 0) result++;
            return result;

        }

        /// <summary>
        /// Returns the total amount of supply for the specified race if more than one.
        /// </summary>
        /// <param name="race"></param>
        /// <returns></returns>
        public int SupplyTotal(Races race) {
            int doubled = this.SupplyTotalDoubled(race);
            int result = Convert.ToInt32(doubled*1.0/2.0);
            if (doubled % 2 > 0) result++;
            return result;

        }

        /// <summary>
        /// Returns the number of all units of the given type.
        /// </summary>
        /// <param name="unitType"></param>
        /// <returns></returns>
        public int UnitCountTotalOfType(UnitType unitType) {
            return this.BwapiObject.allUnitCount(unitType.BwapiObject);
        }

        /// <summary>
        /// Returns the number of completed units of the given type. 
        /// </summary>
        /// <param name="unitType"></param>
        /// <returns></returns>
        public int UnitCountCompletedOfType(UnitType unitType) {
            return this.BwapiObject.completedUnitCount(unitType.BwapiObject);
        }

        /// <summary>
        /// Returns the number of incomplete units of the given type. 
        /// </summary>
        /// <param name="unitType"></param>
        /// <returns></returns>
        public int UnitCountIncompleteOfType(UnitType unitType) {
            return this.BwapiObject.incompleteUnitCount(unitType.BwapiObject);
        }

        /// <summary>
        /// Returns the number of dead units of the given type. 
        /// </summary>
        /// <param name="unitType"></param>
        /// <returns></returns>
        public int UnitCountDeadOfType(UnitType unitType) {
            return this.BwapiObject.deadUnitCount(unitType.BwapiObject);
        }

        /// <summary>
        /// Returns the number of killed units of the given type. 
        /// </summary>
        /// <param name="unitType"></param>
        /// <returns></returns>
        public int UnitCountKilledOfType(UnitType unitType) {
            return this.BwapiObject.killedUnitCount(unitType.BwapiObject);
        }

        /// <summary>
        /// Returns the player's current upgrade level of the given upgrade.
        /// </summary>
        /// <param name="upgradeType"></param>
        /// <returns></returns>
        public int UpgradeLevel(UpgradeType upgradeType) {
            return this.BwapiObject.getUpgradeLevel(upgradeType.BwapiObject);
        }

        /// <summary>
        /// Returns true if the player is upgrading the given upgrade.
        /// </summary>
        /// <param name="upgradeType"></param>
        /// <returns></returns>
        public bool UpgradeIsUpgrading(UpgradeType upgradeType) {
            return this.BwapiObject.isUpgrading(upgradeType.BwapiObject);
        }

        /// <summary>
        /// Returns true if the player has finished researching the given tech.
        /// </summary>
        /// <param name="techType"></param>
        /// <returns></returns>
        public bool TechHashResearched(TechType techType) {
            return this.BwapiObject.hasResearched(techType.BwapiObject);
        }

        /// <summary>
        /// Returns true if the player is researching the given tech.
        /// </summary>
        /// <param name="techType"></param>
        /// <returns></returns>
        public bool TechIsResearching(TechType techType) {
            return this.BwapiObject.isResearching(techType.BwapiObject);
        }



    }
}

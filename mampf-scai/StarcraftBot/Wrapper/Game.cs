using System;
using System.Collections.Generic;
using System.Text;

namespace StarcraftBot.Wrapper 
{
    static partial class Game 
    {
        /// <summary>
        /// Returns the set of all players in the match. Note that this includes the Neutral player, which owns all the neutral units such as minerals, critters, etc.
        /// </summary>
        /// <returns></returns>
        public static List<Player> GetAllPlayers() {
            return Player.GetListOfPlayers(SWIG.BWAPI.bwapi.Broodwar.getPlayers());
        }

        /// <summary>
        /// Returns the amount of latency the current game has.
        /// </summary>
        public static Latencies Latency { get { return (Latencies)SWIG.BWAPI.bwapi.Broodwar.getLatency(); } }

        /// <summary>
        /// Returns the number of logical frames since the match started. 
        /// If the game is paused, FrameCount will not increase however event OnFrame will still be called while paused. 
        /// On Fastest, there are about 23.8 - 24 frames per second. 
        /// </summary>
        public static int FrameCount { get { return SWIG.BWAPI.bwapi.Broodwar.getFrameCount(); } }

        ///// <summary>
        ///// Pings the given position on the minimap. 
        ///// </summary>
        ///// <param name="x"></param>
        ///// <param name="y"></param>
        //public static void PingMinimap(int x, int y) {
        //   SWIG.BWAPI.bwapi.Broodwar.pingMinimap(x, y);
        //}

        /// <summary>
        /// Pings the given position on the minimap. 
        /// </summary>
        public static void PingMinimap(Position position) {
           SWIG.BWAPI.bwapi.Broodwar.pingMinimap(position.BwapiObject);
        }
        
        /// <summary>
        /// Returns the last error that was set. 
        /// </summary>
        public static Errors LastError { get { return (Errors)SWIG.BWAPI.bwapi.Broodwar.getLastError().getID(); } }

        /// <summary>
        /// Returns the set of starting locations for the given map. 
        /// To determine the starting location for the players in the current match, see Player.StartLocation. 
        /// </summary>
        /// <returns></returns>
        public static List<BuildTile> GetStartLocations() {
            return BuildTile.GetListOfBuildTiles(SWIG.BWAPI.bwapi.Broodwar.getStartLocations());
        }
        
        /// <summary>
        /// Prints text on the screen. Text is not sent to other players in multiplayer games. 
        /// </summary>
        /// <param name="text"></param>
        public static void PrintText(string text) {
           SWIG.BWAPI.bwapi.Broodwar.printf(text);
        }

        /// <summary>
        /// Sends text to other players - as if it were entered in chat. 
        /// In single player games and replays, this will just print the text on the screen. 
        /// If the game is a single player match and not a replay, then this function can 
        /// be used to execute cheat codes like "show me the money". 
        /// </summary>
        /// <param name="text"></param>
        public static void SendText(string text) {
           SWIG.BWAPI.bwapi.Broodwar.sendText(text);
        }

        /// <summary>
        /// Returns true if Broodwar is in a multiplayer game. 
        /// Returns false for single player games and replays. 
        /// </summary>
        public static bool IsMultiplayer { get { return SWIG.BWAPI.bwapi.Broodwar.isMultiplayer(); } }

        /// <summary>
        /// Returns true if Broodwar is paused. 
        /// If the game is paused, Game.FrameCount will not continue to increase 
        /// but the event OnFrame will still be called while paused. 
        /// </summary>
        public static bool IsPaused { get { return SWIG.BWAPI.bwapi.Broodwar.isPaused(); } }

        /// <summary>
        /// Returns true if Broodwar is in a replay. 
        /// </summary>
        public static bool IsReplay { get { return SWIG.BWAPI.bwapi.Broodwar.isReplay(); } }

        /// <summary>
        /// Pauses the game. If the game is paused, Game.FrameCount will not increase however 
        /// event OnFrame will still be called while paused. 
        /// </summary>
        public static void PauseGame() {
           SWIG.BWAPI.bwapi.Broodwar.pauseGame();
        }

        /// <summary>
        /// Resumes the game. 
        /// </summary>
        public static void ResumeGame() {
           SWIG.BWAPI.bwapi.Broodwar.resumeGame();
        }

        /// <summary>
        /// Leaves the current match and goes to the after-game stats screen. 
        /// </summary>
        public static void LeaveGame() {
           SWIG.BWAPI.bwapi.Broodwar.leaveGame();
        }

        /// <summary>
        /// Restarts the match. Works the same way as if you restarted the match 
        /// from the menu screen. Only available in single player mode. 
        /// </summary>
        public static void RestartSinglePlayerGame() 
        {
           SWIG.BWAPI.bwapi.Broodwar.restartGame();
        }

        /// <summary>
        /// Sets the speed of the game to the given number. Lower numbers are faster. 
        /// 0 is the fastest speed Starcraft can handle (which is about as fast as 
        /// the fastest speed you can view a replay at). Any negative value will reset 
        /// the speed to the starcraft default. 
        /// </summary>
        /// <param name="speed"></param>
        public static void SetLocalSpeed(int speed) {
           SWIG.BWAPI.bwapi.Broodwar.setLocalSpeed(speed);            
        }

        /// <summary>
        /// Disables or enables GUI rendering. This includes all rendering both within the game andSWIG.BWAPI.
        /// Calling Game::setLocalSpeed(0) increases the speed of Starcraft. Disabling the GUI with this command can increase the speed even more. 
        /// </summary>
        /// <param name="speed"></param>
        public static void SetGUI(bool enabled)
        {
           SWIG.BWAPI.bwapi.Broodwar.setGUI(enabled);          
        }        

        /// <summary>
        /// Returns the set of units currently selected by the user in the GUI. 
        /// If flag EnableUserInput was not enabled during the event OnStart, 
        /// this function will always return an empty set. 
        /// </summary>
        /// <returns></returns>
        public static List<Unit> GetSelectedUnits() {
            return Unit.GetListOfUnits(SWIG.BWAPI.bwapi.Broodwar.getSelectedUnits());
        }

        static Player playerSelf = null;
        /// <summary>
        /// Returns a player thatSWIG.BWAPI controls. In replays this will return null. 
        /// </summary>
        public static Player PlayerSelf { 
            get 
            {
                if (playerSelf == null)
                    playerSelf = new Player(SWIG.BWAPI.bwapi.Broodwar.self());
                return playerSelf;
            } 
        }

        static Player playerEnemy = null;
        /// <summary>
        /// Returns the enemy player. If there is more than one enemy, this returns just one enemy 
        /// See Game.GetAllPlayers() and Player.IsEnemyOfPlayer() to get the other enemies. 
        /// In replays this will return null. 
        /// </summary>
        public static Player PlayerEnemy 
        {
            get 
            {
                if (playerEnemy == null)
                    playerEnemy = new Player(SWIG.BWAPI.bwapi.Broodwar.enemy());
                return playerEnemy;
                //return playerSelf;
            }            
        }
    }
}

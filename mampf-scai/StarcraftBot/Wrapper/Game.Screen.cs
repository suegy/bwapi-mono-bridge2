using System;
using System.Collections.Generic;
using System.Text;
using SWIG.BWAPIC;

namespace StarcraftBot.Wrapper {
    static partial class Game 
    {
        /// <summary>
        /// Returns the position of the top left corner of the screen on the map. 
        /// Flag EnableUserInput must be enabled. (Returns Positions::Unknown if Flag::UserInput is disabled.)
        /// </summary>
        public static Position ScreenPosition { get { return new Position(SWIG.BWAPI.bwapi.Broodwar.getScreenPosition()); } }


        ///// <summary>
        ///// Moves the screen to the given position on the map. 
        ///// The position specified where the top left corner of the screen will be. 
        ///// </summary>
        ///// <param name="x"></param>
        ///// <param name="y"></param>
        //public static void SetScreenPosition(int x, int y) {
        //   SWIG.BWAPI.bwapi.Broodwar.setScreenPosition(x, y);
        //}

        /// <summary>
        /// Moves the screen to the given position on the map. 
        /// The position specified where the top left corner of the screen will be. 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public static void SetScreenPosition(Position position) {
           SWIG.BWAPI.bwapi.Broodwar.setScreenPosition(position.BwapiObject);
        }

    }
}

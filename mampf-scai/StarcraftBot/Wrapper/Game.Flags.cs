using System;
using System.Collections.Generic;
using System.Text;

namespace StarcraftBot.Wrapper {
    static partial class Game {
        /// <summary>
        /// Enable to get information from the user. What units are selected, chat messages the user enters.
        /// </summary>
        public static void EnableUserInput() {
           SWIG.BWAPI.bwapi.Broodwar.enableFlag(1);
        }

        /// <summary>
        /// Returns true if UserInput flag is enabled.
        /// </summary>
        public static bool IsUserInputEnabled { get { return SWIG.BWAPI.bwapi.Broodwar.isFlagEnabled(1); } }

        /// <summary>
        /// Enable to get information about all units on the map, not just the visible units.
        /// </summary>
        public static void EnableCompleteMapInformation() {
           SWIG.BWAPI.bwapi.Broodwar.enableFlag(0);
        }

        /// <summary>
        /// Returns true of CompleteMapInformation flag is enabled.
        /// </summary>
        public static bool IsCompleteMapInformationEnabled { get { return SWIG.BWAPI.bwapi.Broodwar.isFlagEnabled(0); } }

    }
}

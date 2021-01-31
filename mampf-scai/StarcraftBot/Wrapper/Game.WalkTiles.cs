using System;
using System.Collections.Generic;
using System.Text;

namespace StarcraftBot.Wrapper {
    static partial class Game {
        /// <summary>
        /// Returns true if a given walk tile (4x4 pixels) is on a high ground.
        /// </summary>
        /// <returns></returns>
        public static bool IsHighGround(WalkTile walkTile) {
            return SWIG.BWAPI.bwapi.Broodwar.getGroundHeight(walkTile.X, walkTile.Y) == 1;
        }

        /// <summary>
        /// Returns true if current position is on a high ground.
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public static bool IsHighGround(Position position) {
            return IsHighGround(new WalkTile(position));
        }


        /// <summary>
        /// Returns true if a given walk tile (4x4 pixels) is on a high ground.
        /// </summary>
        /// <returns></returns>
        public static bool IsWalkable(WalkTile walkTile) {
            return SWIG.BWAPI.bwapi.Broodwar.isWalkable(walkTile.X, walkTile.Y);
        }

        /// <summary>
        /// Returns true if current position is on a high ground.
        /// </summary>
        /// <returns></returns>
        public static bool IsWalkable(Position position) {
            return IsWalkable(new WalkTile(position));
        }

    }
}

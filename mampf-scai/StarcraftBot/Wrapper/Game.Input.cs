using System;
using System.Collections.Generic;
using System.Text;

namespace StarcraftBot.Wrapper 
{
    static partial class Game 
    {
        /// <summary>
        /// Returns the position of the mouse on the screen. 
        /// Flag EnableUserInput must be enabled.
        /// </summary>
        public static Position MousePosition { get { return new Position(SWIG.BWAPI.bwapi.Broodwar.getMousePosition()); } }

        /// <summary>
        /// Returns true if left mouse button is pressed.
        /// Flag EnableUserInput must be enabled.
        /// </summary>
        public static bool MouseLeftPressed { get { return SWIG.BWAPI.bwapi.Broodwar.getMouseState((int)SWIG.BWAPI.MouseButton.M_LEFT); } }

        /// <summary>
        /// Returns true if middle mouse button is pressed.
        /// Flag EnableUserInput must be enabled.
        /// </summary>
        public static bool MouseMiddlePressed { get { return SWIG.BWAPI.bwapi.Broodwar.getMouseState((int)SWIG.BWAPI.MouseButton.M_MIDDLE); } }

        /// <summary>
        /// Returns true if right mouse button is pressed.
        /// Flag EnableUserInput must be enabled.
        /// </summary>
        public static bool MouseRightPressed { get { return SWIG.BWAPI.bwapi.Broodwar.getMouseState((int)SWIG.BWAPI.MouseButton.M_LEFT); } }

        /// <summary>
        /// Returns true if the specified key is pressed. 
        /// Flag EnableUserInput must be enabled.
        /// Unfortunately this does not read the raw keyboard input yet - when you hold down a key, 
        /// the IsKeyPressed function is true for a frame, then false for a few frames, 
        /// and then alternates between true and false (as if you were holding down the key in a text box). 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool IsKeyPressed(KeyboardKeys key) {
            return SWIG.BWAPI.bwapi.Broodwar.getKeyState((int)key);
        }

    }
}

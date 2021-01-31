using System;
using System.Collections.Generic;
using System.Text;

namespace StarcraftBot.Wrapper {
    enum PlayerTypes {
        NotUsed = 0,
        Computer = 1,
        Human = 2,
        Rescuable = 3,
        Unknown0 = 4,
        ComputerSlot = 5,
        OpenSlot = 6,
        Neutral = 7,
        ClosedSlot = 8,
        Unknown1 = 9,
        HumanDefeated = 10, /**< Left */
        ComputerDefeated = 11,  /**< Left */
        None = 12

    }
}

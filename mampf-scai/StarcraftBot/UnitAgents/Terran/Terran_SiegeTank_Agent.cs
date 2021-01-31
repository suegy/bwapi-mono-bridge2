using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StarcraftBot.Wrapper;
using StarcraftBot;
using StarcraftBot.UnitAgents;

namespace StarcraftBot.UnitAgents.Terran
{
    /// <summary>
    /// Should be able to go into siege mode and out off siege mode.
    /// </summary>
    class Terran_SiegeTank_Agent : UnitAgent
    {
        public Terran_SiegeTank_Agent(Unit myUnit, UnitAgentOptimizedProperties opProp)
            : base(myUnit, opProp)
        {
            UnitAgentTypeName = "Terran_SiegeTank_Agent";
           // SightRange = 10;
        }
    }
}

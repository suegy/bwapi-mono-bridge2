using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StarcraftBot.Wrapper;
using StarcraftBot;
using StarcraftBot.UnitAgents;

namespace StarcraftBot.UnitAgents.Terran
{
    class Terran_SCV_Agent : UnitAgent
    {
        public Terran_SCV_Agent(Unit myUnit, UnitAgentOptimizedProperties opProp)
            : base(myUnit, opProp)
        {
            UnitAgentTypeName = "Terran_SCV_Agent";
            //SightRange = 7; 
        }
    }
}
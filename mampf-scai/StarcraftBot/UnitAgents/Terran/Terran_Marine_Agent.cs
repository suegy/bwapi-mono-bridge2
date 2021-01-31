using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StarcraftBot.Wrapper;
using StarcraftBot;
using StarcraftBot.UnitAgents;

namespace StarcraftBot.UnitAgents.Terran
{
    class Terran_Marine_Agent : UnitAgent
    {
        public Terran_Marine_Agent(Unit myUnit, UnitAgentOptimizedProperties opProp)
            : base(myUnit, opProp)
        {
            UnitAgentTypeName = "Terran_Marine_Agent";
            //SightRange = 7; //http://wiki.teamliquid.net/starcraft/Marine
        }
    }

    /************************************************************
     * All the properties and variables for the Marine class    *
     ************************************************************/ 
}
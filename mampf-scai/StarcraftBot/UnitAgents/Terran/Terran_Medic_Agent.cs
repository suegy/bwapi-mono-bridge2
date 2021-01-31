using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StarcraftBot.Wrapper;
using StarcraftBot;
using StarcraftBot.UnitAgents;

namespace StarcraftBot.UnitAgents.Terran
{
    class Terran_Medic_Agent : UnitAgent
    {
        public Terran_Medic_Agent(Unit myUnit, UnitAgentOptimizedProperties opProp)
            : base(myUnit, opProp)
        {
            UnitAgentTypeName = "Terran_Medic_Agent";
            //SightRange = 9;
        }
    }

    //public void FindUnitToFollow(List<unit> mySquad, 
}

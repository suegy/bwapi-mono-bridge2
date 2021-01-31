using StarcraftBot.Wrapper;

namespace StarcraftBot.UnitAgents.Terran
{
    class Terran_Firebat_Agent : UnitAgent
    {
        public Terran_Firebat_Agent(Unit myUnit, UnitAgentOptimizedProperties opProp)
            : base(myUnit, opProp)
        {
            UnitAgentTypeName = "Terran_Firebat_Agent";
            //SightRange = 7; 
        }
    }
}
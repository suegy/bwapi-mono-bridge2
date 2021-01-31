using System;
using System.Xml.Serialization;

namespace StarcraftBot.UnitAgents
{
    /// <summary>
    /// UnitAgentOptimizedProperties class. Implements IComparable.
    /// @author Thomas Willer Sandberg (http://twsandberg.dk/)
    /// @version (1.0, January 2011)
    /// </summary>
    public class UnitAgentOptimizedProperties : IComparable
    {
        [XmlAttribute("UnitAgentTypeName")]
        public string UnitTypeName { get; set; }

        [XmlAttribute("Fitness")]
        public int Fitness { get; set; }

        [XmlAttribute("Rank")]
        public int Rank { get; set; }

        /***********************************************************************************************************
         * All the multiplyer properties that will be used to convert the chromosomes to real Optimized properties *
         ***********************************************************************************************************/
        public double ForceOwnUnitsRepulsion { get; set; }//= 100;//-500; // 0 - 1000
        public double ForceEnemyUnitsRepulsion { get; set; }//= 200; // 0 - 1000 //REMEMBER TO SET TO A POSITIVE NUMBER. 
        public double ForceMSD { get; set; }//= 240; //0-2000 or 1000  ....800
        public double ForceSquadAttraction { get; set; }//= 10; //0-1000
        public double ForceMapCenterAttraction { get; set; }//= 20; //0-1000
        public double ForceMapEdgeRepulsion { get; set; }//= 50;//0-1000
        public double ForceWeaponCoolDownRepulsion { get; set; }//= 800;//0-1000

        //Step is used for each distance step.
        public double ForceStepOwnUnitsRepulsion { get; set; }//= 0.6; // 0 - 10 SMALLER THAN punishmentRepulsionOwnUnits
        public double ForceStepEnemyUnitsRepulsion { get; set; }//= 1.2; // 0 - 10
        public double ForceStepMSD { get; set; }//= 0.24;//5; //0-10
        public double ForceStepSquadAttraction { get; set; }//= 0.1; //0 - 10
        public double ForceStepMapCenterAttraction { get; set; }// = 0.09;
        public double ForceStepMapEdgeRepulsion { get; set; }//= 0.3;
        public double ForceStepWeaponCoolDownRepulsion { get; set; }// = 6.4;

        public int RangeOwnUnitsRepulsion { get; set; }//= 8; //0-512    20
        public int RangePercentageSquadAttraction { get; set; }//= 5;//15; //0-100  //SHOULD SOMEHOW DEPEND ON HOW BIG THE SQUAD IS
        public int RangePecentageMapCenterAttraction { get; set; }// = 5; //0-100
        public int RangeMapEdgeRepulsion { get; set; }//= 96; //0-320
        public int RangeWeaponCooldownRepulsion { get; set; }//= 160;

        public int CompareTo(Object o)
        {
            return ((UnitAgentOptimizedProperties)o).Fitness.CompareTo(this.Fitness);
        }
    }
}
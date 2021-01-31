namespace StarcraftBot.UnitAgents
{
    /// <summary>
    /// Multiplyer class...
    /// @author Thomas Willer Sandberg (http://twsandberg.dk/)
    /// @version (1.0, January 2011)
    /// </summary>
    public sealed class OptimizedPropertiesMultiplyers
    {
        static readonly OptimizedPropertiesMultiplyers instance = new OptimizedPropertiesMultiplyers();

        static OptimizedPropertiesMultiplyers()
        {
            //Force multiplyers
            OptimizedPropertiesMultiplyers.Instance.ForceOwnUnitsRepulsionMultiplyer = 1000;
            OptimizedPropertiesMultiplyers.Instance.ForceOwnUnitsRepulsionMultiplyer = 1000;
            OptimizedPropertiesMultiplyers.Instance.ForceEnemyUnitsRepulsionMultiplyer = 1000;
            OptimizedPropertiesMultiplyers.Instance.ForceMSDMultiplyer = 1000;
            OptimizedPropertiesMultiplyers.Instance.ForceSquadAttractionMultiplyer = 1000;
            OptimizedPropertiesMultiplyers.Instance.ForceMapCenterAttractionMultiplyer = 1000;
            OptimizedPropertiesMultiplyers.Instance.ForceMapEdgeRepulsionMultiplyer = 1000;
            OptimizedPropertiesMultiplyers.Instance.ForceWeaponCoolDownRepulsionMultiplyer = 1000;

            //Step is used for each distance step (slope).
            OptimizedPropertiesMultiplyers.Instance.ForceStepOwnUnitsRepulsionMultiplyer = 10;
            OptimizedPropertiesMultiplyers.Instance.ForceStepEnemyUnitsRepulsionMultiplyer = 10;
            OptimizedPropertiesMultiplyers.Instance.ForceStepMSDMultiplyer = 10;
            OptimizedPropertiesMultiplyers.Instance.ForceStepSquadAttractionMultiplyer = 10;
            OptimizedPropertiesMultiplyers.Instance.ForceStepMapCenterAttractionMultiplyer = 10;
            OptimizedPropertiesMultiplyers.Instance.ForceStepMapEdgeRepulsionMultiplyer = 10;
            OptimizedPropertiesMultiplyers.Instance.ForceStepWeaponCoolDownRepulsionMultiplyer = 10;

            //Range multiplyers
            OptimizedPropertiesMultiplyers.Instance.RangeOwnUnitsRepulsionMultiplyer = 512;
            OptimizedPropertiesMultiplyers.Instance.RangePercentageSquadAttractionMultiplyer = 100; //PERCENTAGE
            OptimizedPropertiesMultiplyers.Instance.RangePecentageMapCenterAttractionMultiplyer = 100; //PERCENTAGE
            OptimizedPropertiesMultiplyers.Instance.RangeMapEdgeRepulsionMultiplyer = 512;//0-320
            OptimizedPropertiesMultiplyers.Instance.RangeWeaponCooldownRepulsionMultiplyer = 512;//= 160;
        }

        public static OptimizedPropertiesMultiplyers Instance
        {
            get{return instance;}
        }

        public int ForceOwnUnitsRepulsionMultiplyer { get; private set; }//= 100;//-500; // 0 - 1000
        public int ForceEnemyUnitsRepulsionMultiplyer { get; private set; }//= 200; // 0 - 1000 //REMEMBER TO SET TO A POSITIVE NUMBER. 
        public int ForceMSDMultiplyer { get; private set; }//= 240; //0-2000 or 1000  ....800
        public int ForceSquadAttractionMultiplyer { get; private set; }//= 10; //0-1000
        public int ForceMapCenterAttractionMultiplyer { get; private set; }//= 20; //0-1000
        public int ForceMapEdgeRepulsionMultiplyer { get; private set; }//= 50;//0-1000
        public int ForceWeaponCoolDownRepulsionMultiplyer { get; private set; }//= 800;//0-1000

        //Step is used for each distance step (slope).
        public int ForceStepOwnUnitsRepulsionMultiplyer { get; private set; }//= 0.6; // 0 - 10 SMALLER THAN punishmentRepulsionOwnUnits
        public int ForceStepEnemyUnitsRepulsionMultiplyer { get; private set; }//= 1.2; // 0 - 10
        public int ForceStepMSDMultiplyer { get; private set; }//= 0.24;//5; //0-10
        public int ForceStepSquadAttractionMultiplyer { get; private set; }//= 0.1; //0 - 10
        public int ForceStepMapCenterAttractionMultiplyer { get; private set; }// = 0.09; // 0 - 10
        public int ForceStepMapEdgeRepulsionMultiplyer { get; private set; }//= 0.3;// 0 - 10
        public int ForceStepWeaponCoolDownRepulsionMultiplyer { get; private set; }// = 6.4;// 0 - 10

        public int RangeOwnUnitsRepulsionMultiplyer { get; private set; }//= 8; //0-512    20
        public int RangePercentageSquadAttractionMultiplyer { get; private set; }//= 5;//15; //0-100  //SHOULD SOMEHOW DEPEND ON HOW BIG THE SQUAD IS
        public int RangePecentageMapCenterAttractionMultiplyer { get; private set; }// = 5; //0-100
        public int RangeMapEdgeRepulsionMultiplyer { get; private set; }//= 96; //0-320
        public int RangeWeaponCooldownRepulsionMultiplyer { get; private set; }//= 160;
    }
}
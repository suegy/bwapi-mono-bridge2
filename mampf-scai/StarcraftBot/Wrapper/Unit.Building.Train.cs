using System;
using System.Collections.Generic;
using System.Text;

namespace StarcraftBot.Wrapper {
    partial class Unit {
        /// <summary>
        /// Orders this unit to add the specified unit type to the training queue. 
        /// Note that the player must have sufficient resources to train. 
        /// If you wish to make units from a hatchery, use GetLarvas() to get the larva 
        /// associated with the hatchery and then call morph on the larva you want to morph. 
        /// This command can also be used to make interceptors and scarabs. 
        /// See also: TrainTimeRemaining, GetTrainingQueue(), IsTraining, DoCancelTrainLastUnit(), DoCancelTrain().
        /// </summary>
        /// <param name="unitType"></param>
        /// <returns></returns>
        public bool DoTrainUnit(UnitType unitType) {
            return this.BwapiObject.train(unitType.BwapiObject);
        }

        public bool DoTrainUnit(UnitTypes unitType) {
            return this.bwapiObject.train(new SWIG.BWAPI.UnitType((int)unitType));
        }

        /// <summary>
        /// Returns the remaining time of the unit that is currently being trained. 
        /// If the unit is a Hatchery, Lair, or Hive, this returns the amount of time until the next larva spawns, or 0 if the unit already has 3 larva. 
        /// See also: DoTrainUnit(), GetTrainingQueue(), IsTraining, DoCancelTrainLastUnit(), DoCancelTrain().
        /// </summary>
        public int TrainTimeRemaining { get { return this.BwapiObject.getRemainingTrainTime(); } }

        /// <summary>
        /// Returns the list of units queued up to be trained. 
        /// See also: DoTrainUnit(), IsTraining, DoCancelTrainLastUnit(), DoCancelTrain().
        /// </summary>
        /// <returns></returns>
        public List<UnitType> GetTrainingQueue() {
            return UnitType.GetListOfUnitTypes(this.BwapiObject.getTrainingQueue());
        }

        /// <summary>
        /// Returns true if the unit is training units (ex. Barracks training Marines). 
        /// See also: DoTrainUnit(), TrainTimeRemaining, GetTrainingQueue(), DoCancelTrainLastUnit(), DoCancelTrain().
        /// </summary>
        public bool IsTraining { get { return this.BwapiObject.isTraining(); } }

        /// <summary>
        /// Orders the unit to remove the last unit from its training queue. 
        /// See also: DoTrainUnit(), TrainTimeRemaining, GetTrainingQueue(), IsTraining, DoCancelTrain()
        /// </summary>
        /// <returns></returns>
        public bool DoCancelTrainLastUnit() {
            return this.BwapiObject.cancelTrain();
        }

        /// <summary>
        /// Orders the unit to remove the specified unit from its training queue. 
        /// See also: DoCancelTrainLastUnit(), DoTrainUnit(), TrainTimeRemaining, GetTrainingQueue(), IsTraining.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public bool DoCancelTrain(int index) {
            return this.BwapiObject.cancelTrain(index);//TODO: or index+1?
        }

    }
}

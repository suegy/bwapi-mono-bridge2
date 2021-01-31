using System;
using System.Collections.Generic;
using System.Text;

namespace StarcraftBot.Wrapper {
    partial class Unit {
        /// <summary>
        /// Returns true if the unit is a building that is researching tech.
        /// See also: DoResearch(), DoCancelResearch(), TechResearching, TechResearchTimer.
        /// </summary>
        public bool IsResearching { get { return this.BwapiObject.isResearching(); } }

        /// <summary>
        /// Returns the tech that the unit is currently researching.
        /// See also: DoResearch(), DoCancelResearch(), IsResearching, TechResearchTimer.
        /// </summary>
        public TechType TechResearching { get { return new TechType(this.BwapiObject.getTech());  } }

        /// <summary>
        /// Returns the amount of time until the unit is done researching its current tech. If the unit is not researching anything, 0 is returned. 
        /// See also: DoResearch(), DoCancelResearch(), IsResearching, TechResearching.
        /// </summary>
        public int TechResearchTimer { get { return this.BwapiObject.getRemainingResearchTime(); } }

        /// <summary>
        /// Orders the unit to research the given tech type. 
        /// See also: IsResearching, TechResearching, TechResearchTimer, DoCancelResearch().
        /// </summary>
        /// <param name="techType"></param>
        /// <returns></returns>
        public bool DoResearch(TechTypes techType) {
            return this.BwapiObject.research(new SWIG.BWAPI.TechType((int)techType));
        }

        /// <summary>
        /// Orders the unit to cancel a research in progress. 
        /// See also: DoResearch(), IsResearching, TechResearching, TechResearchTimer.
        /// </summary>
        /// <returns></returns>
        public bool DoCancelResearch() {
            return this.BwapiObject.cancelResearch();
        }




    }
}

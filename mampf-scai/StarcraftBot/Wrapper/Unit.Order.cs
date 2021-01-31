using System;
using System.Collections.Generic;
using System.Text;

namespace StarcraftBot.Wrapper {
    partial class Unit {
        /// <summary>
        /// Returns current order for the unit.
        /// </summary>
        public Orders Order { get { return (Orders)this.BwapiObject.getOrder().getID(); } }

        /// <summary>
        /// This is usually set when the low level unit AI acquires a new target automatically. 
        /// For example if an enemy probe comes in range of your marine, the marine will start attacking it, 
        /// and OrderTarget will be set in this case, but not Target. 
        /// </summary>
        public Unit OrderTarget { get { return new Unit(this.BwapiObject.getOrderTarget()); } }

        /// <summary>
        /// Time left for the current order.
        /// </summary>
        public int OrderTimer { get { return this.BwapiObject.getOrderTimer(); } }



        public Orders OrderSecondary { get { return (Orders)this.BwapiObject.getSecondaryOrder().getID(); } }

    }
}

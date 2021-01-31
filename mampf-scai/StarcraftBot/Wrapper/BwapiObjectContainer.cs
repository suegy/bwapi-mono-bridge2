using System;
using System.Collections.Generic;
using System.Text;

namespace StarcraftBot.Wrapper {
    /// <summary>
    /// Base class used for holding the object fromSWIG.BWAPI.
    /// </summary>
    /// <typeparam name="BwapiType"></typeparam>
    class BwapiObjectContainer<BwapiType> {
        protected BwapiType bwapiObject = default(BwapiType);

        public virtual BwapiType BwapiObject { get { return this.bwapiObject; } }
        public virtual bool IsNull { get { return this.bwapiObject == null; } }
        public virtual bool IsNotNull { get { return this.bwapiObject != null; } }

        public BwapiObjectContainer(BwapiType bwapiObject) {
            this.bwapiObject = bwapiObject;
        }



    }

}

using System;
using System.Collections.Generic;
using System.Text;

namespace StarcraftBot.Wrapper {
    partial class Unit {
        /// <summary>
        /// Returns the dropship, shuttle, overlord, or bunker that is this unit is loaded in to. 
        /// </summary>
        public Unit TransportContainer { get { return new Unit(this.BwapiObject.getTransport()); } }



        /// <summary>
        /// Returns a list of the units loaded into a Terran Bunker, Terran Dropship, Protoss Shuttle or Zerg Overlord. 
        /// See also: IsLoaded, DoLoad(), DoUnload(), DoUnloadAll().
        /// </summary>
        /// <returns></returns>
        public List<Unit> GetLoadedUnits() {
            return Unit.GetListOfUnits(this.BwapiObject.getLoadedUnits());
        }

        /// <summary>
        /// Return true if the unit is loaded into a Terran Bunker, Terran Dropship, Protoss Shuttle, or Zerg Overlord. 
        /// See also: DoLoad(), DoUnload(), DoUnloadAll(), GetLoadedUnits().
        /// </summary>
        public bool IsLoaded { get { return this.BwapiObject.isLoaded(); } }

        /// <summary>
        /// Orders the unit to load the target unit. 
        /// See also: DoUnload(), DoUnloadAll(), GetLoadedUnits(), IsLoaded.
        /// </summary>
        /// <param name="unitTarget"></param>
        /// <returns></returns>
        public bool DoLoad(Unit unitTarget) {
            return this.BwapiObject.load(unitTarget.BwapiObject);
        }

        /// <summary>
        /// Orders the unit to unload the target unit. 
        /// See also: DoLoad(), DoUnloadAll(), GetLoadedUnits(), IsLoaded.
        /// </summary>
        /// <param name="unitTarget"></param>
        /// <returns></returns>
        public bool DoUnload(Unit unitTarget) {
            return this.BwapiObject.unload(unitTarget.BwapiObject);
        }

        /// <summary>
        /// Orders the unit to unload all loaded units at the unit's current position. 
        /// See also: DoLoad(), DoUnload(), GetLoadedUnits(), IsLoaded.
        /// </summary>
        /// <returns></returns>
        public bool DoUnloadAll() {
            return this.BwapiObject.unloadAll();
        }

        /// <summary>
        /// Orders the unit to unload all loaded units at the specified location. 
        /// Unit should be a Terran Dropship, Protoss Shuttle, or Zerg Overlord. 
        /// If the unit is a Terran Bunker, the units will be unloaded right outside the bunker. 
        /// See also: DoLoad(), DoUnload(), GetLoadedUnits(), IsLoaded.
        /// </summary>
        /// <param name="positionTarget"></param>
        /// <returns></returns>
        public bool DoUnloadAll(Position positionTarget) {
            return this.BwapiObject.unloadAll(positionTarget.BwapiObject);
        }



    }
}

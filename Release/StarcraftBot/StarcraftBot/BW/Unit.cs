using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StarcraftBot.BW
{
	class Unit
	{
		public SWIG.BWAPI.Unit theUnit;
        public SWIG.BWAPI.Unit theTarget;

        public Unit(SWIG.BWAPI.Unit u)
		{
			theUnit = u;
			theTarget = null;
		}

		public bool HasTarget()
		{
			return (theTarget != null);
		}

        public void Attack(SWIG.BWAPI.Unit t)
		{
			if (t == null && theTarget != null)
			{
				theUnit.stop();
				theTarget = null;
			}
			else if (t != null && t != theTarget)
			{
				theTarget = t;
				theUnit.attack(theTarget);
			}
		}
	}
}

using System;
using System.Collections.Generic;
using System.Text;

namespace BWAPI
{
	public class Helper
	{
		public static SWIG.BWAPI.Player NewPlayer(IntPtr ptr)
		{
            return ((ptr == IntPtr.Zero) ? null : new SWIG.BWAPI.Player(ptr, false));
		}

        public static SWIG.BWAPI.Unit NewUnit(IntPtr ptr)
		{
            return ((ptr == IntPtr.Zero) ? null : new SWIG.BWAPI.Unit(ptr, false));
		}

        public static SWIG.BWAPI.Position NewPosition(IntPtr ptr)
		{
            return ((ptr == IntPtr.Zero) ? null : new SWIG.BWAPI.Position(ptr, false));
		}
	}
}

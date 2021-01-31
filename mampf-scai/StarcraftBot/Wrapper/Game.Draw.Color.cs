using System;
using System.Collections.Generic;
using System.Text;

namespace StarcraftBot.Wrapper {
    class DrawColor {
        SWIG.BWAPI.Color bwapiColor = null;
        public SWIG.BWAPI.Color BwapiColor { get { return this.bwapiColor; } }
        public DrawColor(int red, int green, int blue) {
            this.bwapiColor = new SWIG.BWAPI.Color(red, green, blue);
        }

        public DrawColor(int colorId) {
            this.bwapiColor = new SWIG.BWAPI.Color(colorId);
        }

        public static DrawColor Green { get { return new DrawColor(0, 200, 0); } }
        public static DrawColor White { get { return new DrawColor(300, 0, 0); } }
        public static DrawColor Gray { get { return new DrawColor(170, 170, 170); } }
        public static DrawColor DarkGray { get { return new DrawColor(70, 70, 70); } }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace StarcraftBot.Wrapper {
    enum DrawTextColors {
        LightBlue = 0x02,
        DarkYellow = 0x03,
        White = 0x04,
        DarkGray = 0x05,
        DarkRed = 0x06,
        Green = 0x07,
        Red = 0x08,
        Blue = 0x0E,
        Teal = 0x0F,
        Purple = 0x10,
        Orange = 0x11,
        Brown = 0x15,
        LightGray = 0x16,
        Yellow = 0x17,
        DarkGreen = 0x18,
        LightYellow = 0x19,
        PalePink = 0x1B,
        RoyalBlue = 0x1C,
        GreyGreen = 0x1D,
        GreyBlue = 0x1E,
        Cyan = 0x1F

    }

    enum DrawPlaces {
        Screen = 1,
        Map = 2,
        Mouse = 3,
    }
    static partial class Game {
        static string GetTextInColor(string text, DrawTextColors textColor) {
            return Char.ConvertFromUtf32((int)textColor) + " " + text;
        }


        public static void DrawText(DrawPlaces drawWhere, int x, int y, string text) {
           SWIG.BWAPI.bwapi.Broodwar.drawText((int)drawWhere, x, y, text);
        }

        public static void DrawText(DrawPlaces drawWhere, int x, int y, string text, DrawTextColors color) {
           SWIG.BWAPI.bwapi.Broodwar.drawText((int)drawWhere, x, y, GetTextInColor(text, color));
        }

        public static void DrawBox(DrawPlaces drawWhere, int x, int y, int width, int height, DrawColor color, bool isSolid) {
           SWIG.BWAPI.bwapi.Broodwar.drawBox((int)drawWhere, x, y, width, height, color.BwapiColor, isSolid);
        }

        public static void DrawCircle(DrawPlaces drawWhere, int x, int y, int radius, DrawColor color, bool isSolid) {
           SWIG.BWAPI.bwapi.Broodwar.drawCircle((int)drawWhere, x, y, radius, color.BwapiColor, isSolid);
        }

        public static void DrawEllipse(DrawPlaces drawWhere, int x, int y, int radiusX, int radiusY, DrawColor color, bool isSolid) {
           SWIG.BWAPI.bwapi.Broodwar.drawEllipse((int)drawWhere, x, y, radiusX, radiusY, color.BwapiColor, isSolid);
        }

        public static void DrawDot(DrawPlaces drawWhere, int x, int y, DrawColor color) {
           SWIG.BWAPI.bwapi.Broodwar.drawDot((int)drawWhere, x, y, color.BwapiColor);
        }

        public static void DrawLine(DrawPlaces drawWhere, int x1, int y1, int x2, int y2, DrawColor color) {
           SWIG.BWAPI.bwapi.Broodwar.drawLine((int)drawWhere, x1, y1, x2, y2, color.BwapiColor);
        }

        public static void DrawTriangle(DrawPlaces drawWhere, int x1, int y1, int x2, int y2, int x3, int y3, DrawColor color, bool isSolid) {
           SWIG.BWAPI.bwapi.Broodwar.drawTriangle((int)drawWhere, x1, y1, x2, y2, x3, y3, color.BwapiColor, isSolid);
        }

        public static void DrawMapPolygon(MapPolygon mapPolygon, DrawColor color) {
            if (mapPolygon.Positions.Count <= 1) return;
            for (int i = 0; i < mapPolygon.Positions.Count - 1; i++) {
                DrawLine(DrawPlaces.Map, mapPolygon.Positions[i].X, mapPolygon.Positions[i].Y, mapPolygon.Positions[i + 1].X, mapPolygon.Positions[i + 1].Y, color);
            }
            Position lastPoint = mapPolygon.Positions[mapPolygon.Positions.Count - 1];
            Position firstPoint = mapPolygon.Positions[0];
            DrawLine(DrawPlaces.Map, firstPoint.X, firstPoint.Y,  lastPoint.X, lastPoint.Y, color);
        }





    }
}

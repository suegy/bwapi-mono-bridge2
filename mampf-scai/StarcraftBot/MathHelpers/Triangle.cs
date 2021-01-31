using StarcraftBot.Wrapper;

namespace StarcraftBot.MathHelpers
{
    /// <summary>
    /// Borrowed from: http://blog.csharphelper.com/2010/01/04/perform-geometric-operations-on-polygons-in-c.aspx.
    /// Adapted to bwapi-CLR-client by Thomas Willer Sandberg.
    /// @version (1.0, January 2011)
    /// </summary>
    class Triangle : Polygon
    {
        public Triangle(Position p0, Position p1, Position p2)
        {
            Points = new[] { p0, p1, p2 };
        }
    }
}
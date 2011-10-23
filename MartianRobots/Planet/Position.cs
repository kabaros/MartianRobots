using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MartianRobots.Planets
{
    /// <summary>
    /// Class representing a single X,Y coordinate cell in the surface of the planet
    /// </summary>
    public class Position
    {
        /// <summary>
        /// X coordinate of the position
        /// </summary>
        public int X {get; set;}

        /// <summary>
        /// Y coordinate of the position
        /// </summary>
        public int Y {get; set;}

        /// <summary>
        /// Constructor for a point
        /// </summary>
        /// <param name="x">the X coordinate of the point</param>
        /// <param name="y">the Y coordinate of the point</param>
        public Position(int x, int y)
        {
            X = x; Y = y; HasScent = false;
        }

        /// <summary>
        /// Whether this position has scent in it or not
        /// </summary>
        public bool HasScent { get; set; }
    }
}

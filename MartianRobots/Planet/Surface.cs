using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MartianRobots.Planets
{
    /// <summary>
    /// Data structure that abstracts the surface of the planet implemented internally as a 2-dimentional array of points
    /// </summary>
    public class Surface
    {
        /// <summary>
        /// 2-dimensional array of points representing the surface
        /// </summary>
        private Position[,] surface { get; set; }

        /// <summary>
        /// Constructor take top right X and Y coordinate of the planet
        /// </summary>
        public Surface(int x, int y)
        {
            surface = new Position[x + 1, y + 1];

            for (int i = 0; i <= x; i++)
            {
                for (int j = 0; j <= y; j++)
                {
                    surface[i, j] = new Position(i, j);
                }
            }
        }
        /// <summary>
        /// Indexer to get the Position from coordinate X and Y
        /// </summary>
        public Position this[int x, int y]
        {
            get
            {
                return surface[x, y];
            }
        }
        /// <summary>
        /// Indexer to get the surface position based on another Position instance
        /// </summary>
        public Position this[Position position]
        {
            get
            {
                return surface[position.X, position.Y];
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MartianRobots.Planets
{
    public class Surface
    {
        private Position[,] surface { get; set; }

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
        public Position this[int x, int y]
        {
            get
            {
                return surface[x, y];
            }
        }
        public Position this[Position position]
        {
            get
            {
                return surface[position.X, position.Y];
            }
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Robots
{
    public class Planet
    {
        /// <summary>
        /// Upper right X coordinate of our rectangular planet
        /// </summary>
        public readonly int UpperX;

        /// <summary>
        /// Upper right Y coordinate of our rectangular planet
        /// </summary>
        public readonly int UpperY;

        public Surface Surface { get; set; }
        
        public Queue<Robot> Robots { get; private set; }

        /// <summary>
        /// The X, Y represent the upper right corner of our rectangular planet
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Planet(byte x, byte y)
        {
            Robots = new Queue<Robot>();
            UpperX = x;
            UpperY = y;
            Surface = new Surface(x, y);
        }
    }
}

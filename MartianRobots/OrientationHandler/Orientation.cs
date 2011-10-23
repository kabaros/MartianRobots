using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MartianRobots.Orientations
{
    /// <summary>
    /// Class representing the different orientations handled by OrientationHandler
    /// </summary>
    public class Orientation
    {
        Directions Name { get; set; }
        public Orientation(Directions direction)
        {
            Name = direction;
        }
        public override string ToString()
        {
            return Name.ToString();
        }
    }
}

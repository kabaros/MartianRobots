using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MartianRobots.ProblemDescription
{
    /// <summary>
    /// A class representing the problem definition
    /// </summary>
    public class PlanetDescription
    {
        /// <summary>
        /// The rightmost X coordinate of the planet
        /// </summary>
        public int UpperX { get; set; }
        
        /// <summary>
        /// The topmost Y coordinate of the planet
        /// </summary>
        public int UpperY { get; set; }

        /// <summary>
        /// List of Robot descriptions from the problem definition
        /// </summary>
        public List<RobotDescription> Robots { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MartianRobots.ProblemDescription
{
    /// <summary>
    /// A class representing the robots in the problem definition
    /// </summary>
    public class RobotDescription
    {
        /// <summary>
        /// Initial position X coordinate of the robot
        /// </summary>
        public int PositionX { get; set; }

        /// <summary>
        /// Initial position Y coordinate of the robot
        /// </summary>
        public int PositionY { get; set; }

        /// <summary>
        /// Initial oritentation of the robot
        /// </summary>
        public string Orientation { get; set; }

        /// <summary>
        /// Instructions that the Robot should follow
        /// </summary>
        public string Instruction { get; set; }
    }
}

using System;

namespace MartianRobots.Exceptions
{
    /// <summary>
    /// Exception thrown if robot is initially placed out of the borders of the planet
    /// </summary>
    public class RobotOutOfRangeException : MartianException
    {
        public RobotOutOfRangeException()
            : base("Robot out of order! Make sure to place your Robots within the boundary of the planet")
        {
        }
    }
}

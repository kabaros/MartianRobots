using System;

namespace MartianRobots.Exceptions
{
    public class RobotOutOfRangeException : MartianException
    {
        public RobotOutOfRangeException()
            : base("Robot out of order! Make sure to place your Robots within the boundary of the planet")
        {
        }
    }
}

using System;

namespace MartianRobots.Exceptions
{
    /// <summary>
    /// Invalid instruction raised if failing to parse the instructions
    /// </summary>
    public class InvalidInstructionsException : MartianException
    {
        public InvalidInstructionsException()
            : base("Instructions not in Martian language")
        {
        }
    }
}

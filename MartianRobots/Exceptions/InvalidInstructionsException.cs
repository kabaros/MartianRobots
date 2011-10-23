using System;

namespace MartianRobots.Exceptions
{
    public class InvalidInstructionsException : MartianException
    {
        public InvalidInstructionsException()
            : base("Instructions not in Martian language")
        {
        }
    }
}

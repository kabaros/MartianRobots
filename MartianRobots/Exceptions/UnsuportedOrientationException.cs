using System;

namespace MartianRobots.Exceptions
{
    /// <summary>
    /// If an orientation other than N,W,E or S is passed 
    /// </summary>
    /// <remarks>right now, the regex parser will ignore any other letter but this might change</remarks>
    public class UnsuportedOrientation : MartianException
    {
        public UnsuportedOrientation()
            : base("Orientations should be N,W,E or S")
        {
        }
    }
}

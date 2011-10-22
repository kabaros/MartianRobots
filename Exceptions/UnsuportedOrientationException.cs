using System;

namespace MartianRobots.Exceptions
{
    public class UnsuportedOrientation : MartianException
    {
        public UnsuportedOrientation()
            : base("Orientations should be N,W,E or S")
        {
        }
    }
}

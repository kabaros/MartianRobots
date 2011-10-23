using System;

namespace MartianRobots.Exceptions
{
    public class PlanetBiggerThanAllowedException : MartianException
    {
        public PlanetBiggerThanAllowedException()
            : base("Maximum dimensions for planet is 50x50, bigger planets will be supported in future versions")
        {
        }
    }
}

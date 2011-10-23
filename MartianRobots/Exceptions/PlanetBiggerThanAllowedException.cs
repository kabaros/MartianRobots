using System;

namespace MartianRobots.Exceptions
{
    /// <summary>
    /// Exception thrown if the problem definition defines a dimension bigger than 50x50
    /// </summary>
    public class PlanetBiggerThanAllowedException : MartianException
    {
        public PlanetBiggerThanAllowedException()
            : base("Maximum dimensions for planet is 50x50, bigger planets will be supported in future versions")
        {
        }
    }
}

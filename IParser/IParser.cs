using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MartianRobots.ProblemDescription;

namespace MartianRobots.Parsers
{
    public interface IParser
    {
        PlanetDescription Parse(string commands);
    }
}

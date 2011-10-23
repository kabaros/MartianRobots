using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MartianRobots.ProblemDescription;

namespace MartianRobots.Parsers
{
    /// <summary>
    /// Interface that any parser need to speak to Mars
    /// </summary>
    public interface IParser 
    {
        /// <summary>
        /// parses input into a PlanetDescription instance
        /// </summary>
        /// <param name="input">input to be parsed</param>
        /// <returns>a PlanetDesription instance describing the planet and the robots to live in it</returns>
        PlanetDescription Parse(string input);
    }
}

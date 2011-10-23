using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using MartianRobots.ProblemDescription;
using MartianRobots.Planets;
using MartianRobots.Exceptions;
using MartianRobots.Robots;

namespace MartianRobots.Builder
{
    /// <summary>
    /// Class that builds the planet based on the PlanetDescription parsed from the problem definition
    /// </summary>
    public class PlanetBuilder
    {
        /// <summary>
        /// Builds the planet and returns a Queue of Robots to be processed sequentially
        /// </summary>
        /// <param name="description">the planet description object (typically parsed from a problem definition)</param>
        /// <returns>Queue of Robots</returns>
        public Queue<Robot> BuildPlanet(PlanetDescription description)
        {
                Queue<Robot> Robots = new Queue<Robot>();
                if (description.UpperX< 0 || description.UpperX > 50 || description .UpperY<0 || description.UpperY > 50)
                {
                    throw new PlanetBiggerThanAllowedException();
                }
                Planet planet = new Planet((byte)description.UpperX, (byte)description.UpperY);

                foreach (RobotDescription robotDescription in description.Robots)
                {
                    Robot robot = new Robot(planet, robotDescription.PositionX, robotDescription.PositionY,
                            robotDescription.Orientation, robotDescription.Instruction);
                        
                    Robots.Enqueue(robot);
                }

                return Robots;
        }
    }
}

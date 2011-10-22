using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using MartianRobots.ProblemDescription;
using Robots;
using MartianRobots.Exceptions;

namespace MartianRobots.Builder
{
    public class PlanetBuilder
    {
        public Planet BuildPlanet(PlanetDescription description)
        {
            try
            {
                if (description.UpperX< 0 || description.UpperX > 50 || description .UpperY<0 || description.UpperY > 50)
                {
                    throw new PlanetBiggerThanAllowedException();
                }
                Planet planet = new Planet((byte)description.UpperX, (byte)description.UpperY);

                foreach (RobotDescription robotDescription in description.Robots)
                {
                    Robot robot = new Robot(planet, robotDescription.PositionX, robotDescription.PositionY,
                            robotDescription.Orientation, robotDescription.Instruction);
                        planet.Robots.Enqueue(robot);
                }

                return planet;
            }
            catch(InvalidInstructionsException)
            {
                //God will log your exception and throw
                throw;
            }
        }
    }
}

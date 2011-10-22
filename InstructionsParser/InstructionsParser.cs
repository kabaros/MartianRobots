using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using MartianRobots.ProblemDescription;

namespace MartianRobots.Parsers
{
    public class InstructionParser: IParser
    {
        public PlanetDescription Parse(string commands)
        {
            PlanetDescription planetDescription = ParsePlanetDescription(commands);
            planetDescription.Robots = ParsesRobotDescription(commands);
            return planetDescription;
        }

        private PlanetDescription ParsePlanetDescription(string commands)
        {
            Regex reg = new Regex(@"\s*(?<PLANET_X>\d{1,2})\s+(?<PLANET_Y>\d{1,2})\s*");
            Match matchPlanet = reg.Match(commands);
            byte planetX = byte.Parse(matchPlanet.Groups["PLANET_X"].Value);
            byte planetY = byte.Parse(matchPlanet.Groups["PLANET_Y"].Value);

            return new PlanetDescription { UpperX = planetX, UpperY = planetY };
        }

        private Queue<RobotDescription> ParsesRobotDescription(string commands)
        {
            Queue<RobotDescription> robotDescriptions = new Queue<RobotDescription>();

            Regex reg = new Regex(@"\s*(?<X>\d{1,2})\s+(?<Y>\d{1,2})\s+(?<ORIENTATION>[N|W|E|S]{1})\s*[\r\n]*(?<INSTRUCTION>[F|L|R]+)", RegexOptions.IgnoreCase);
            MatchCollection matches = reg.Matches(commands);

            if (matches.Count > 0)
            {
                foreach (Match match in matches)
                {
                    var positionX = byte.Parse(match.Groups["X"].Value);
                    var positionY = byte.Parse(match.Groups["Y"].Value);
                    string orientation = match.Groups["ORIENTATION"].Value;
                    string instruction = match.Groups["INSTRUCTION"].Value;

                    RobotDescription description = new RobotDescription()
                    {
                        PositionX = positionX,
                        PositionY = positionY,
                        Orientation = orientation,
                        Instruction = instruction
                    };
                    robotDescriptions.Enqueue(description);
                }
            }

            return robotDescriptions;
        }
    }
}

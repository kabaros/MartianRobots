using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using MartianRobots.ProblemDescription;
using MartianRobots.Exceptions;

namespace MartianRobots.Parsers
{
    /// <summary>
    /// Instructions Parser is the default implementation of IParser
    /// It uses Regular expressions to parse the earth commands and translate them into Martian
    /// </summary>
    public class InstructionParser: IParser
    {
        /// <summary>
        /// Parses a string of commands in the following format:
        /// The first line of input is the upper-right coordinates of the rectangular world, 
        /// the lower-left coordinates are assumed to be 0, 0. 
        /// The remaining input consists of a sequence of robot positions and instructions (two lines per robot).
        /// A position consists of two integers specifying the initial coordinates of the robot and an orientation (N, S, E, W),
        /// all separated by white space on one line.
        /// A robot instruction is a string of the letters “L”, “R”, and “F” on one line.
        /// Sample Input
        /// 5 3 
        /// 1 1 E 
        /// RFRFRFRF 
        /// 3 2 N 
        /// FRRFLLFFRRFLL 
        /// </summary>
        /// <param name="input">the input to be parsed in the Desc</param>
        /// <returns>
        /// A PlanetDescription object - multiple parsers can parse different formats in different ways 
        /// but this is the only representation that Mars understand
        /// </returns>
        public PlanetDescription Parse(string input)
        {
            try
            {
                PlanetDescription planetDescription = ParsePlanetDescription(input);
                planetDescription.Robots = ParsesRobotDescription(input);
                return planetDescription;
            }
            catch
            {
                //log then throw
                throw new InvalidInstructionsException();
            }
        }

        /// <summary>
        /// Gets the planet description from the first line of the input
        /// </summary>
        /// <param name="input">input in earth language</param>
        /// <returns>a Planet Description instance with the dimensions of the planet</returns>
        private PlanetDescription ParsePlanetDescription(string input)
        {
            //Regex is tolerant to white spaces - will match the following: 
            //spaces - {1 or 2 digits => Right X coordinate} - spaces - { 1 or 2 digits => Upper Y coordinate}
            Regex reg = new Regex(@"\s*(?<PLANET_X>\d{1,2})\s+(?<PLANET_Y>\d{1,2})\s*");
            Match matchPlanet = reg.Match(input);
            
            if (matchPlanet.Captures.Count == 0)
                throw new InvalidInstructionsException();

            byte planetX = byte.Parse(matchPlanet.Groups["PLANET_X"].Value);
            byte planetY = byte.Parse(matchPlanet.Groups["PLANET_Y"].Value);

            return new PlanetDescription { UpperX = planetX, UpperY = planetY };
        }

        private List<RobotDescription> ParsesRobotDescription(string commands)
        {
            //Regex is tolerant to white spaces - will match the following: 
            //spaces - {1 or 2 digits => Position X of Robot} - spaces - { 1 or 2 digits => Position Y of Robot}
            //- spaces - {N or W or E or S => Orientation} - NEW LINE
            //{any sequence of letters => Commands} <- this used to match F or L or R only but changed to support future commands
            Regex reg = new Regex(@"\s*(?<X>\d{1,2})\s+(?<Y>\d{1,2})\s+(?<ORIENTATION>[N|W|E|S]{1})\s*[\r\n]*(?<INSTRUCTION>.+)", RegexOptions.IgnoreCase);
            MatchCollection matches = reg.Matches(commands);

            List<RobotDescription> robotDescriptions = new List<RobotDescription>();

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
                    robotDescriptions.Add(description);
                }
            }
            else throw new InvalidInstructionsException();

            return robotDescriptions;
        }
    }
}

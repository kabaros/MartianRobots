using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MartianRobots.Exceptions;

namespace Robots
{
    /// <summary>
    /// Robot are the inhabitants of the planet
    /// Since "God" gave them "freedom of choice" so they hold the responsibility of moving themselves 
    /// </summary>
    public class Robot
    {
        public Position CurrentPosition { get; private set; }
        public Orientation CurrentOrientation { get; private set; }
        public string InstructionString { get; private set; }
 
        public Planet Planet { get; set; }

        public bool IsLost { get; private set; }

        /// <summary>
        /// Constuctor of a Martian Robot
        /// </summary>
        /// <param name="planet">The planet where this robot lives</param>
        /// <param name="x">the X coordinate of the initial position of the Robot</param>
        /// <param name="y">the Y coordinate of the initial position of the Robot</param>
        /// <param name="orientation">The initial orientation of the Robot</param>
        /// <param name="instructionString">The initial instruction string of the robot</param>
        /// <exception cref="RobotOutOfRangeException">The exception is thrown if the Robot is placed outside of the Planet initally</exception>
        public Robot(Planet planet, int x, int y, string orientation, string instructionString)
        {
            try
            {
                Planet = planet;
                CurrentPosition = planet.Surface[x,y];
                InstructionString = instructionString;
                switch (orientation)
                {
                    case "N":
                        CurrentOrientation = OrientationsHandler.North;
                        break;
                    case "S":
                        CurrentOrientation = OrientationsHandler.South;
                        break;
                    case "W":
                        CurrentOrientation = OrientationsHandler.West;
                        break;
                    case "E":
                        CurrentOrientation = OrientationsHandler.East;
                        break;
                    default:
                        throw new UnsuportedOrientation();
                }
            }
            catch (IndexOutOfRangeException)
            {
                //log that something wrong happened and throw RobotOutOfRangeException
                throw new RobotOutOfRangeException();
            }
        }

        public void ExecuteCommands(string command)
        {
            InstructionString = command;
            ExecuteCommands();
        }

        public void ExecuteCommands()
        {
            foreach (char command in InstructionString)
            {
                switch(command)
                {
                    case 'L':
                        CurrentOrientation = OrientationsHandler.ToLeft(CurrentOrientation);
                        break;
                    case 'R':
                        CurrentOrientation = OrientationsHandler.ToRight(CurrentOrientation);
                        break;
                    case 'F':
                            bool willFall = WillFallOffMars(CurrentPosition, CurrentOrientation);

                            if (Planet.Surface[CurrentPosition].HasScent && willFall)
                                break;
                            else if (willFall)
                            {
                                this.IsLost = true;
                                Planet.Surface[CurrentPosition].HasScent = true;
                                return;
                            }                            
                            else
                            {
                                if (CurrentOrientation == OrientationsHandler.North)
                                {
                                    CurrentPosition.Y++;
                                }
                                else if (CurrentOrientation == OrientationsHandler.East)
                                {
                                    CurrentPosition.X++;
                                }
                                else if (CurrentOrientation == OrientationsHandler.South)
                                {
                                    CurrentPosition.Y--;
                                }
                                else if (CurrentOrientation == OrientationsHandler.West)
                                {
                                    CurrentPosition.X--;
                                }
                                break;
                            }
                }
            }
        }

        private bool WillFallOffMars(Position CurrentPosition, Orientation CurrentOrientation)
        {
            bool willFall = false;

            if (
                (CurrentOrientation == OrientationsHandler.North && CurrentPosition.Y == Planet.UpperY)
                || (CurrentOrientation == OrientationsHandler.East && CurrentPosition.X == Planet.UpperX)
                || (CurrentOrientation == OrientationsHandler.South && CurrentPosition.Y == 0)
                || (CurrentOrientation == OrientationsHandler.West && CurrentPosition.X == 0)
                )
            {
                willFall = true;
            }

            return willFall;
       }
    }
}

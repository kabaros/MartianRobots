using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MartianRobots.Exceptions;
using MartianRobots.Planets;
using MartianRobots.Orientations;

namespace MartianRobots.Robots
{
    /// <summary>
    /// Robot are the inhabitants of the planet
    /// They are responsible of their own movement and they know their current position and orientation
    /// and they take an instruction string that they will execute when asked to do so
    /// and they also know the planet where they live (not the other way around)
    /// </summary>
    public class Robot
    {
        /// <summary>
        /// Current position of the robot
        /// </summary>
        public Position CurrentPosition { get; private set; }

        /// <summary>
        /// Current orientation of the robot
        /// </summary>
        public Orientation CurrentOrientation { get; private set; }

        /// <summary>
        /// Instruction string of the robot
        /// </summary>
        public string InstructionString { get; private set; }
 
        /// <summary>
        /// Reference to the planet where the Robot lives
        /// </summary>
        public Planet Planet { get; set; }

        /// <summary>
        /// Property where this Robot is lost or not
        /// </summary>
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

        /// <summary>
        /// Executes the commands in the Robot's instruction string
        /// </summary>
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


        /// <summary>
        /// Overrides the Robot's instruction string then executes the command
        /// </summary>
        /// <param name="command">command to execute</param>
        public void ExecuteCommands(string command)
        {
            InstructionString = command;
            ExecuteCommands();
        }

        /// <summary>
        /// Determines if the Robot is about to fall off the face of the Mars
        /// </summary>
        /// <param name="CurrentPosition">Current position of the robot</param>
        /// <param name="CurrentOrientation">Current orientation of the robot</param>
        /// <returns></returns>
        private bool WillFallOffMars(Position CurrentPosition, Orientation CurrentOrientation)
        {
            bool willFall = false;
            
            //checks for edge cases after which the robot will fall
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

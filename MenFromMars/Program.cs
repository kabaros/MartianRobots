using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Robots;

namespace MenFromMars
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = "5 3\r\n"
                +"1 1 E\r\n RFRFRFRF \r\n"
                + "3 2 N\r\n FRRFLLFFRRFLL \r\n"
                + "0 3 W \r\n LLFFFLFLFL \r\n";

            IPlanetBuilder builder = new PlantBuilder(); 
            Planet planet = builder.ParseCommands(command);

            Console.WriteLine("No of robots: " + planet.Robots.Count);
            Console.WriteLine(String.Format("Planet length:{0} x {1}", planet.UpperX, planet.UpperY));

            while (planet.Robots.Count>0)
            {
                Robot robot = planet.Robots.Dequeue();
                robot.ExecuteCommands();
                Console.WriteLine(String.Format("X:{0}, Y:{1}, Orientation:{2}. {3}.", robot.CurrentPosition.X,
                    robot.CurrentPosition.Y, robot.CurrentOrientation, ((robot.IsLost)?"LOST":"")));
                
            }
        }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MartianRobots.ProblemDescription
{
    public class PlanetDescription
    {
        public int UpperX { get; set; }
        public int UpperY { get; set; }
        public Queue<RobotDescription> Robots { get; set; }
    }
}

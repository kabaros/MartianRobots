using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Robots
{
    public class Orientation
    {
        Directions Name { get; set; }
        public Orientation(Directions direction)
        {
            Name = direction;
        }
        public override string ToString()
        {
            return Name.ToString();
        }
    }
}

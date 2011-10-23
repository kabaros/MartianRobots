using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Robots
{
    public class OrientationsHandler
    {
        static private LinkedList<Orientation> orientationsList;

        static public Orientation North {get; private set;}
        static public Orientation South {get; private set;}
        static public Orientation East {get; private set;}
        static public Orientation West {get; private set;}

        static OrientationsHandler( )
        {
            orientationsList = new LinkedList<Orientation>();
            
            North = new Orientation(Directions.North);
            South = new Orientation(Directions.South);
            East = new Orientation(Directions.East);
            West = new Orientation(Directions.West);

            orientationsList.AddFirst(North);
            orientationsList.AddLast(East);
            orientationsList.AddLast(South);
            orientationsList.AddLast(West);
        }
        
        public static Orientation ToRight(Orientation currentOrientation)
        {
            if (orientationsList.Last.Value == currentOrientation)
                return orientationsList.First.Value;

            return orientationsList.Find(currentOrientation).Next.Value;
        }

        public static Orientation ToLeft(Orientation currentOrientation)
        {
            if (orientationsList.First.Value == currentOrientation)
                return orientationsList.Last.Value;

            return orientationsList.Find(currentOrientation).Previous.Value;
        }

    }
}

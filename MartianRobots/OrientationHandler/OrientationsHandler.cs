using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MartianRobots.Orientations
{
    /// <summary>
    /// Orientation Handler handles orientations and interpret right and left commands, 
    /// it is implemented as a singleton cyclic doubly linked list (where first and last are linked)
    /// </summary>
    public sealed class OrientationsHandler
    {
        static private LinkedList<Orientation> orientationsList;

        static public Orientation North {get; private set;}
        static public Orientation South {get; private set;}
        static public Orientation East {get; private set;}
        static public Orientation West {get; private set;}
        
        private OrientationsHandler()
        {
        }

        /// <summary>
        /// Type constructor initializes the 4 directions object (just to have a handy pointer to them)
        /// and adds them in order to the cyclic doubly linked list
        /// </summary>
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
        
        /// <summary>
        /// Gets the element to the right, it is the Next pointer of the linked list Node
        /// and in the case of the last element then it is the first element
        /// </summary>
        /// <param name="currentOrientation">Orientation to move from</param>
        /// <returns>Orientation after moving to the right</returns>
        public static Orientation ToRight(Orientation currentOrientation)
        {
            if (orientationsList.Last.Value == currentOrientation)
                return orientationsList.First.Value;

            return orientationsList.Find(currentOrientation).Next.Value;
        }
        /// <summary>
        /// Gets the element to the left, it is the Next pointer of the linked list Node
        /// and in the case of the last element then it is the first element       
        /// <param name="currentOrientation">Orientation to move from</param>
        /// <returns>Orientation after moving to the left</returns>
        public static Orientation ToLeft(Orientation currentOrientation)
        {
            if (orientationsList.First.Value == currentOrientation)
                return orientationsList.Last.Value;

            return orientationsList.Find(currentOrientation).Previous.Value;
        }

    }
}

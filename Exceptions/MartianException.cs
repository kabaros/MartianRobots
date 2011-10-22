using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MartianRobots.Exceptions
{
    /// <summary>
    /// Base class for our Martian Exceptions
    /// </summary>
    public class MartianException: Exception
    {
        public MartianException(string message)
            : base(message)
        {
        }
    }
}

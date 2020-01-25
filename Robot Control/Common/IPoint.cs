using System;
using System.Collections.Generic;
using System.Text;

namespace Robot_Control.Common
{
    public interface IPoint
    {
        // Property signatures:
        int X
        {
            get;
            set;
        }

        int Y
        {
            get;
            set;
        }


    }
    public class Point : IPoint
    {        
        public int X { get; set ;}
        public int Y { get; set; }
    }
}


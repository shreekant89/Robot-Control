using Robot_Control.Logic;
using System;
using Robot_Control.Common;

namespace Robot_Control
{
    class Program
    {
       

        static void Main(string[] args)
        {
            try
            {
                Position obj = new Position(new Point());
                obj.Movement();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
            
        }        
    }
}

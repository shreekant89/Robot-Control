using System;
using System.Collections.Generic;
using System.Text;

namespace Robot_Control.Common
{
    public interface IRoom
    {
        IPoint StartPosition { get; set; }
        //bool Contains(IPoint position);
    }

    public class Room : IRoom
    {
        public IPoint StartPosition { get ; set; }

        //public bool Contains(IPoint position)
        //{
        //    throw new NotImplementedException();
        //}
    }
}

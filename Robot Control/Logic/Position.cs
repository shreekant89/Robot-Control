using Robot_Control.Common;
using System;

namespace Robot_Control.Logic
{
    public class Position : IRoom
    {
        public IPoint StartPosition { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public Position(IPoint point)
        {
            StartPosition = point;
        }


        public void Movement()
        {

            StartPosition.X = Validation.Validate.GetNumberInput("Enter x axis starting point (int)");
            StartPosition.Y = Validation.Validate.GetNumberInput("Enter y axis starting point(int)");
            X = Validation.Validate.GetNumberInput("Enter x length limit ");
            Y = Validation.Validate.GetNumberInput("Enter y length limit ");

            Console.WriteLine("Enter String for movement: ");
            string move = Console.ReadLine();
            finalPosition(move);

            Console.WriteLine("If You want to continue then press Y else any button to quite:");
            string decision = Console.ReadLine();
            if (decision.ToLower() == "y")
                Movement();
        }

        public object finalPosition(string path)
        {

            try
            {
                if (path.Length < 1)
                    throw new Exception("Instruction is missing");

                int x = StartPosition.X, y = StartPosition.Y; int dir = 0;
                path = path.ToUpper();

                for (int i = 0; i < path.Length; i++)
                {
                    char move = path[i];
                    // If move is left or 
                    // right, then change direction 
                    if (((char)Direction.Right).Equals(move) || ((char)Direction.Hoger).Equals(move))                    
                        dir = (dir + 1) % 4;
                    
                    else if (((char)Direction.Left).Equals(move) || ((char)Direction.Vanster).Equals(move))
                        dir = (4 + dir - 1) % 4;

                    // If move is Go, then  
                    // change x or y according to 
                    // current direction 
                    else if (((char)Direction.Forward).Equals(move) || ((char)Direction.Go).Equals(move))
                    {
                        if (dir == 0)
                            y++;
                        else if (dir == 1)
                            x++;
                        else if (dir == 2)
                            y--;
                        else // dir == 3 
                            x--;
                    }
                    else
                    {
                        Console.WriteLine("incorrect instruction:-" + move);
                        return false;
                    }

                }

                Console.WriteLine("x position: " + x + ", y position: " + y + "");
                getDirection(dir);
                if (x > X || x < X * -1 || y > Y || y < Y * -1)
                {
                    Console.WriteLine("movement is out side of you limit so invalide move");
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                return ex;
            }
        }



        private static void getDirection(int dir)
        {
            string direction = "Unknown";
            if (dir == 0)
                direction = "North";
            if (dir == 1)
                direction = "East";
            if (dir == 2)
                direction = "South";
            if (dir == 3)
                direction = "West";
            Console.WriteLine("robot direction is :-" + direction);
        }

        public bool Contains(IPoint position)
        {
            throw new NotImplementedException();
        }
    }
}

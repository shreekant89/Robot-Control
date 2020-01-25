using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Robot_Control.Validation
{
    static class Validate
    {
        public static int GetNumberInput(string instruction,int  x=0)
        {
            
            Console.WriteLine(instruction);
            string text = Console.ReadLine();
            Regex regex = new Regex(@"^[-+]?[0-9]*\.?[0-9]+$");
            if (regex.IsMatch(text))
                x = Convert.ToInt32(text);
            else
            {
                Console.WriteLine("this is not number try again: ");
                x= GetNumberInput(instruction,x);                
            }

            return x;
        }
    }
}

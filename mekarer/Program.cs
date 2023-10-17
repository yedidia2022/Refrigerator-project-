using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mekarer
{
    internal class Program
    {   public static void menuProgram()
        {
            int currentChoice;
            Console.WriteLine("enter 1:the program will give you to choose a refrigerator num and the program prints all the refrigerator's detailes + his capcity detailes" +
                             "  enter 2: the program will give you to choose a refrigerator num and it prints the refrigerator's free place" +
                              "enter 3:the program will give you to choose a refrigerator num and then the program give you to enter item to its by enter the item's id " +
                              "enter 4:the program will give you to choose a refrigerator num and then the program give you to takeOut item from its by enter the item's id " +
                              "enter 5:the program will give you to choose a refrigerator num and then the program clean its and print you the detailes of the item were checked"+
                              "enter 6:the program will give you to choose a refrigerator num and then the program ask you what you want to eat and which kashrut you can now and it suggest you"+
                              "enter 7:the program will give you to choose a refrigerator num and the program prints alll the item sort by expired day"+
                              "enter 8:the program will give you to choose a refrigerator num and then the program prints the shelves drteiles sort by their free place"+
                             "enter 9:the program print all thr refrigerators sort by their free place"+
                             "enter 10:the program will give you to choose a refrigerator num and then the program prepare its for shopping"+
                             "enter 100:close the program");
            string input = Console.ReadLine();
            if (!int.TryParse(input, out currentChoice) )
            {
                Console.WriteLine("Invalid input!");
                return;
            }
            else
            {

            }

        }
        static void Main(string[] args)
        {
        }
    }
}

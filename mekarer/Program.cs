using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace mekarer
{
    internal class Program
    {   public static void menuProgram()
        {
            int currentChoice;
            Console.WriteLine("enter 1:the program will give you to choose a refrigerator num and the program prints all the refrigerator's detailes + his capcity detailes" +
                             "  enter 2: the program will give you to choose a refrigerator num and it prints the refrigerator's free place" +
                              "enter 3:the program will give you to choose a refrigerator num and then the program give you to enter item to its by enter the item's name " +
                              "enter 4:the program will give you to choose a refrigerator num and then the program give you to takeOut item from its by enter the item's id " +
                              "enter 5:the program will give you to choose a refrigerator num and then the program clean its and print you the detailes of the item were checked" +
                              "enter 6:the program will give you to choose a refrigerator num and then the program ask you what you want to eat and which kashrut you can now and it suggest you" +
                              "enter 7:the program will give you to choose a refrigerator num and the program prints alll the item sort by expired day" +
                              "enter 8:the program will give you to choose a refrigerator num and then the program prints the shelves drteiles sort by their free place" +
                             "enter 9:the program print all thr refrigerators sort by their free place" +
                             "enter 10:the program will give you to choose a refrigerator num and then the program prepare its for shopping" +
                             "enter 100:close the program");
            string input = Console.ReadLine();
            if (!int.TryParse(input, out currentChoice))
            {
                Console.WriteLine("Invalid input!");
                return;
            }
            else

            {
                string strChoice;
                int numberChioice;
                switch (currentChoice)
                {
                    case 1:
                        {
                            Console.WriteLine("enter the refrgitor number");
                            strChoice = Console.ReadLine();
                            if (!int.TryParse(strChoice, out numberChioice))
                            {
                                Console.WriteLine("Invalid input!");
                                break;
                            }
                            else
                            {
                                List<Refrigerator> newList = new List<Refrigerator>();

                                if ((Refrigerator.seerefregitorList().Exists(x => x.RefrigeratorId == numberChioice)) == false)
                                {
                                    Console.WriteLine("we dont have this refrgitor!");
                                    break;
                                }
                                else
                                {
                                    foreach (Refrigerator r in Refrigerator.seerefregitorList())
                                    {
                                        if (r.RefrigeratorId == numberChioice)
                                        {
                                            Console.WriteLine(r);
                                            break;
                                        }
                                    }

                                }

                            }
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("enter the refrgitor number");
                            strChoice = Console.ReadLine();
                            if (!int.TryParse(strChoice, out numberChioice))
                            {
                                Console.WriteLine("Invalid input!");
                                break;
                            }
                            else
                            {
                                foreach (Refrigerator r in Refrigerator.seerefregitorList())
                                {
                                    if (r.RefrigeratorId == numberChioice)
                                    {
                                        Console.WriteLine(r.placeWasLeft());
                                        break;
                                    }
                                }

                            }
                            break;
                        }
                    case 3:
                        {
                            bool need = true, refrigetorBool = false;
                            double place = 0;
                            string name, inputStr;
                            DateTime date = DateTime.Now;
                            Kinds kind = Kinds.FOOD;
                            Kashruiot kashrut = Kashruiot.FLASHY; ;
                            double SMR = 0;
                            int floorNum = 0;
                            Refrigerator refrigerator = null;
                           
                            Console.WriteLine("enter the refrgitor number");
                            strChoice = Console.ReadLine();
                            while (!refrigetorBool)
                            {
                                if (int.TryParse(strChoice, out numberChioice))
                                {
                                    numberChioice = int.Parse(strChoice);
                                    foreach (Refrigerator r in Refrigerator.seerefregitorList())
                                    {
                                        if (r.RefrigeratorId == numberChioice)
                                        {
                                            refrigerator = r;
                                            place = r.placeWasLeft();
                                        }
                                    }

                                    Console.WriteLine("enter the item name");
                                    name = Console.ReadLine();
                                    while (need)
                                    {
                                        Console.WriteLine("enter the item expired date");
                                        inputStr = Console.ReadLine();
                                        if (!DateTime.TryParse(inputStr, out date))
                                        {
                                            Console.WriteLine("Invalid input! enter valid input ");

                                        }
                                        else
                                        {
                                            date = DateTime.Parse(inputStr);
                                            need = false;
                                        }

                                    }
                                    need = true;
                                    while (need)
                                    {
                                        Console.WriteLine("enter the item kind");
                                        inputStr = Console.ReadLine();
                                        if (inputStr.Equals(Kinds.FOOD))
                                        {
                                            kind = Kinds.FOOD;
                                            need = false;
                                        }
                                        else
                                            if (inputStr.Equals(Kinds.DRINK))
                                        {
                                            kind = Kinds.DRINK;
                                            need = false;
                                        }


                                        else
                                            Console.WriteLine("Invalid input! enter valid input ");



                                    }
                                    need = true;
                                    while (need)
                                    {
                                        Console.WriteLine("enter the item Kashrut");
                                        inputStr = Console.ReadLine();
                                        if (inputStr.Equals(Kashruiot.MILKY))
                                        {
                                            kashrut = Kashruiot.MILKY;
                                            need = false;
                                        }
                                        else
                                            if (inputStr.Equals(Kashruiot.PARVE))
                                        {
                                            kashrut = Kashruiot.PARVE;
                                            need = false;
                                        }


                                        else
                                            if (inputStr.Equals(Kashruiot.FLASHY))
                                        {
                                            kashrut = Kashruiot.FLASHY;
                                            need = false;
                                        }
                                        else
                                            Console.WriteLine("Invalid input! enter valid input ");



                                    }
                                    need = true;
                                    while (need)
                                    {
                                        Console.WriteLine("enter the item size of the item");
                                        inputStr = Console.ReadLine();
                                        if (!double.TryParse(inputStr, out SMR))
                                        {
                                            Console.WriteLine("Invalid input! enter valid input ");

                                        }
                                        else
                                        {
                                            SMR = double.Parse(inputStr);
                                            need = false;
                                        }

                                    }
                                    need = true;
                                    while (need)
                                    {
                                        Console.WriteLine("enter the item to the floor num");
                                        inputStr = Console.ReadLine();
                                        if (!int.TryParse(inputStr, out floorNum))
                                        {
                                            Console.WriteLine("Invalid input! enter valid input ");

                                        }
                                        else
                                        {
                                            floorNum = int.Parse(inputStr);
                                            need = false;
                                        }


                                    }
                                    
                                    if (place < SMR) 
                                    { 
                                        Console.WriteLine("try another refrugetor");
                                        refrigetorBool = false;
                                    }
                                    else
                                    {
                                        refrigetorBool=true; 
                                    }




                                }
                                else
                                {
                                    Console.WriteLine("Invalid input!");
                                    refrigetorBool = true;
                                }

                            }
                            foreach(Shelf s in refrigerator.getShelveesLost())
                                if(s != null)
                                {
                                    if(s.FloorNum == floorNum)
                                        if(s.addItem(newItemFromUser))
                                }


                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("enter the refriget number");

                            strChoice = Console.ReadLine();
                            if (!int.TryParse(strChoice, out numberChioice))
                                Console.WriteLine("Invalid input!");
                                break;

                            foreach(Refrigerator r in Refrigerator.seerefregitorList())
                            {
                                if(r != null)
                                {
                                    if(r.RefrigeratorId==numberChioice)
                                    {
                                        Console.WriteLine("enter the item name");

                                        strChoice = Console.ReadLine();
                                        List<Shelf> list = r.getShelveesLost();
                                        foreach (Item item in r.getShelveesLost())
                                        {
                                            if(item != null)
                                            {
                                                if(shelf.Name)
                                            }
                                        }

                                    }
                                }
                            }
                            
                             

                        }

                }

            }
        }
        static void Main(string[] args)
        {
        }
    }
}

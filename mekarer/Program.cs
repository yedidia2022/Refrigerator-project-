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
    {
        public static void menuProgram()
        {
            string inputStr;
            Refrigerator MyRefrigeritor = Refrigerator.seeRefregitorList().First();
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
                            Console.WriteLine("print all the cacity of mt refregitor {0}", MyRefrigeritor);
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("the place was left in my Refrigertor {0}", MyRefrigeritor.placeWasLeft());
                            break;
                        }
                    case 3:
                        {

                            double place;
                            string name;
                            DateTime date;
                            Kinds kind;
                            Kashruiot kashrut;
                            double SMR;
                            Console.WriteLine("enter the item name");
                            name = Console.ReadLine();
                            Console.WriteLine("enter the item expired date");
                            inputStr = Console.ReadLine();
                            if (!DateTime.TryParse(inputStr, out date))
                                if (!DateTime.TryParse(inputStr, out date))
                                    throw new Exception("not valid input for date");
                                else
                                    date = DateTime.Parse(inputStr);

                            Console.WriteLine("enter the item kind");
                            inputStr = Console.ReadLine();

                            if (inputStr.Equals(Kinds.FOOD))
                            {
                                kind = Kinds.FOOD;

                            }
                            else
                                if (inputStr.Equals(Kinds.DRINK))
                            {
                                kind = Kinds.DRINK;
                            }
                            else
                                throw new Exception("it is not valid kind");
                            Console.WriteLine("enter the item Kashrut");
                            inputStr = Console.ReadLine();
                            if (inputStr.Equals(Kashruiot.MILKY))
                            {
                                kashrut = Kashruiot.MILKY;
                            }
                            else
                                if (inputStr.Equals(Kashruiot.PARVE))
                            {
                                kashrut = Kashruiot.PARVE;
                            }
                            else
                                if (inputStr.Equals(Kashruiot.FLASHY))
                            {
                                kashrut = Kashruiot.FLASHY;
                            }
                            else
                                throw new Exception("not valid kashrut");
                            Console.WriteLine("enter the item size of the item");
                            inputStr = Console.ReadLine();
                            if (!double.TryParse(inputStr, out SMR))
                            {
                                throw new Exception("invalid input for SMR");
                            }
                            else
                            {
                                SMR = double.Parse(inputStr);
                            }
                            Item newItemForEnter = new Item(name, date, kind, kashrut, SMR);
                            MyRefrigeritor.enterItemToRefrigerator(newItemForEnter);
                            break;
                        }

                    case 4:
                        {
                            int codeItem;
                            Console.WriteLine("enter the item code");
                            inputStr = Console.ReadLine();
                            if (!int.TryParse(inputStr, out codeItem))
                                throw new Exception("invalid input for itemCode");
                            else
                            {
                                codeItem = int.Parse(inputStr);
                                try
                                {
                                    MyRefrigeritor.takeOutItem(codeItem);
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine("we dont have item with this code");
                                }
                            }
                            break;
                        }

                    case 5:
                        {
                            MyRefrigeritor.cleanTheRefrigeratorFromExpiredItems();
                            break;
                        }
                    case 6:
                        {
                            Kinds kind;
                            Kashruiot Kashrut;
                            Console.WriteLine("what do you want to eat ?");
                            inputStr = Console.ReadLine();
                            if (!Kinds.TryParse(inputStr, out kind))
                                throw new Exception("invalid input for kind");
                            else
                                kind = inputStr.Equals(Kinds.FOOD) ? Kinds.FOOD : Kinds.DRINK;

                            Console.WriteLine("which kashrut do you want ?");
                            inputStr = Console.ReadLine();
                            if (!Kashruiot.TryParse(inputStr, out Kashrut))
                                throw new Exception("invalid input for kashrut");
                            else
                                Kashrut = inputStr.Equals(Kashruiot.MILKY) ? Kashruiot.MILKY : inputStr.Equals(Kashruiot.FLASHY) ? Kashruiot.FLASHY : Kashruiot.PARVE;
                            List<Item> itemsList = MyRefrigeritor.findItemsByKashrut(Kashrut, kind);
                            if (itemsList.Count > 0)
                                foreach (Item item in itemsList)
                                {
                                    Console.WriteLine(item);
                                }

                            break;
                        }
                    case 7:
                        {
                            List<Item> itemsList = MyRefrigeritor.sortItemByExpiredDate();
                            if (itemsList.Count > 0)
                                foreach (Item item in itemsList)
                                {
                                    Console.WriteLine(item);
                                }

                            break;
                        }
                    case 8:
                        {
                            MyRefrigeritor.sortByFreePlace();
                            break;
                        }
                    case 9:
                        {
                            Refrigerator.sortRefrgitors();
                            break;
                        }
                    case 100: { break; }

                }

            }

        }

        static void Main(string[] args)
        {
            menuProgram();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace mekarer
{
    internal class Refrigerator
    {
        //?אם לא רושמים סט אז הסט פרטי?
        private int refrigeratorId { get; }
        private string refrigeratorModel { get; set; }
        private Colors refrigeratorColor { get; set; }
        private int amountOfShelves { get; set; }
        private List<Shelf>shelves;
        //
        private static List<Refrigerator> refregitorList;

        public Refrigerator(string model,Colors color, int amount)
        {  this.refrigeratorId = IdGenrator.giveId();
           this.refrigeratorId = IdGenrator.giveIdHash();
            this.refrigeratorModel = model;
            this.refrigeratorColor = color;
            this.amountOfShelves = amount;
            shelves = new List<Shelf>();
            //מהו this
            refregitorList.Add(this);
        }
        //public static bool isThisShelfExist(int id)
        //{

        //}
        public override string ToString()
        { string shelvesToString = "this is the ShelvesDetails";
            foreach (Shelf shelf in shelves) { 
                shelvesToString += shelf.ToString();}

            return this.refrigeratorId + " " + this.refrigeratorModel + " " + this.amountOfShelves + " "
                + this.refrigeratorColor + " " + shelvesToString;
        }
        public double placeWasLeft()
        {  double placeWasLeft = 0;
            foreach (Shelf shelf in shelves)
            {
                placeWasLeft += shelf.placewasLeft();
            }
            return placeWasLeft;

        }
        //האם כבר יהיה למדף קומה או שעכשיו נצטרך לבחור או שעכשיו נקצה לפי איפה שיש מקום 
        public bool enterItemToRefrigerator(Item item)
        {     if (this.placeWasLeft() <= 0)
                {
                Console.WriteLine("there is no place in that refrigerator");
                return false;
                 }
                  foreach (Shelf shelf in shelves)
                  {
                    if (shelf.placewasLeft() > item.PlaceOnSMR) 
                    {
                     shelf.addItem(item);
                     item.FloorNum = shelf.FloorNum;
                     }
                   }
                  return true;
        }

        public Item takeOutItem(int itemid)
        {
            foreach (Shelf shelf in shelves)
            {
                if (shelf.isThisItemInThisShelf(itemid))
                {
                   Item BackItem=shelf.takeOutItem(itemid);
                   if (BackItem is null) {
                        return null;
                    }
                      return BackItem;
                }
               
               
            }
            Console.WriteLine("there isn't this iteemId on our refrigerator");
            return null;
        }
        public void cleanTheRefrigeratorFromExpiredItems()
        {
            foreach(Shelf shelf in shelves)
            {
                shelf.itemAreExpired();
            }
        }
        public List<Item> findItemsByKashrut(Kashruiot kashrut,Kinds kind)
        {
            List<Item> itemsBySpecificKushrut = new List<Item>();
            foreach (Shelf shelf in shelves)
            {
                itemsBySpecificKushrut.AddRange(shelf.findItemsByKashrut(kashrut, kind));

            }
            return itemsBySpecificKushrut;
        }
        public void sortByFreePlace()
        {
            shelves.Sort((x, y) => x.placewasLeft().CompareTo(y.placewasLeft()));
          //  List<Item> SortedList = shelves.OrderBy(o=>o.placewasLeft).ToList();
            //foreach (Item item in SortedList)
            //{
            //    Console.WriteLine(item);
            //}
            shelves.Reverse();
            foreach (Shelf shelf in shelves)
            {
                Console.WriteLine(shelf);
            }
        }
        public static void sortRefrgitor()
        {
            refregitorList.Sort((x,y)=>x.placeWasLeft().CompareTo(y.placeWasLeft()));
            refregitorList.Reverse();
            foreach(Refrigerator refrigerator in refregitorList)
            {
                Console.WriteLine(refrigerator);
            }
        }
        //כעת בפונקציות של הקניות לא יודעת אם לעבור דף או לא?
        public void getReadyShopping()
        {
            List<Item> newList = new List<Item>();
            List<Item> longList = new List<Item>();
            double placefree=placeWasLeft();
            if (placefree < 29)
            {
                while (placefree < 20)
                { 
                foreach (Shelf shelf in shelves)
                {
                  List<Item>sortedShelvsListByDate=  shelf.sortByDate();
                  sortedShelvsListByDate.Reverse();

                    foreach (Item item in sortedShelvsListByDate)
                    {
                        if (!item.isExpired())
                        {
                                sortedShelvsListByDate.Remove(item);
                                placefree += item.PlaceOnSMR;

                        }
                    }
                }
               
               
                
                   
                        foreach (Shelf shelf in shelves)
                        {
                            List<Item> sortedShelvsListByDate = shelf.sortByDate();
                            sortedShelvsListByDate.Reverse();
                            
                            foreach (Item item in sortedShelvsListByDate)
                            {
                                if ((item.LastDayUse-DateTime.Today).Days<3&&item.Kashrut==Kashruiot.MILKY)
                                {
                                newList.Add(item);
                                placefree += item.PlaceOnSMR;

                                }
                            }
                        }

                    foreach (Shelf shelf in shelves)
                    {
                        List<Item> sortedShelvsListByDate = shelf.sortByDate();
                        sortedShelvsListByDate.Reverse();

                        foreach (Item item in sortedShelvsListByDate)
                        {
                            if ((item.LastDayUse - DateTime.Today).Days < 7 && item.Kashrut == Kashruiot.FLASHY)
                            {   
                                newList.Add(item);
                               placefree += item.PlaceOnSMR;

                            }
                        }
                    }

                    foreach (Shelf shelf in shelves)
                    {
                        List<Item> sortedShelvsListByDate = shelf.sortByDate();
                        sortedShelvsListByDate.Reverse();

                        foreach (Item item in sortedShelvsListByDate)
                        {
                            if ((item.LastDayUse - DateTime.Today).Days < 2 && item.Kashrut == Kashruiot.PARVE)
                            {
                                newList.Add(item);
                                placefree += item.PlaceOnSMR;

                            }
                        }
                    }





                }
                if (placefree < 20)
                {
                    Console.WriteLine("its not the time for shopping");
                }
                else
                {foreach (Shelf shelf in shelves)
                    {
                        longList.AddRange(shelf.getMyList());
                    }
                 foreach (Item item in longList)
                    { foreach(Item item1 in newList)
                        {
                            if (item.Equals(item1))
                            {
                                //יש לי דרך להמשיך לזרוק אותו ולחפש באיזה מדף נמצא ואז ללכת להסיר מהפריטים שבאותו מדף
                            }
                        }

                    }
                   
                  
                }



            }
            else
                Console.WriteLine("you are free to go shopping now");

        }




    }
}

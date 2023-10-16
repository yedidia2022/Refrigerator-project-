using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mekarer
{
    internal class Item
    {
        private int itemId; 
        private string name;
        private DateTime lastDayUse;
        private Kinds kind;
        private Kashruiot kashrut;
        private double placeOnSMR;
        //אולי לשנות שמכיל מדף 
        private int shelfId;
        public int ItemId { get; set; }
        public int Name { get; set; }
        public DateTime LastDayUse { get {  return lastDayUse; } set {  lastDayUse = value; } }
        public Kinds Kind { get { return kind; } set { kind = value; } }
        public Kashruiot Kashrut { get { return kashrut; } set { kashrut = value; } }
public double PlaceOnSMR { get {  return placeOnSMR; } set {  placeOnSMR = value; } }
        //זה לא נכון כדאי לשנות למשהו שמחייב להצמד למספר של מדף קיים
        public int ShelfId { get { return shelfId; } set { shelfId = value; } }
        public Item()
        {
            
        }



    }
}

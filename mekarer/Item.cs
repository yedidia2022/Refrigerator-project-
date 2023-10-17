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
        private int floorNum;
        public int ItemId { get; set; }
        public string Name { get; set; }
        public DateTime LastDayUse { get {  return lastDayUse; } set { if(value >DateTime.Today) lastDayUse = value; } }
        public Kinds Kind { get { return kind; } set { kind = value; } }
        public Kashruiot Kashrut { get { return kashrut; } set { kashrut = value; } }
        public double PlaceOnSMR { get {  return placeOnSMR; } set {  placeOnSMR = value; } }

      
        //זה לא נכון כדאי לשנות למשהו שמחייב להצמד למספר של מדף קיים
        //אולי לעשות פונקציה במלקת מקרר  שבודקת האם הקוד שהמשתמש רוצה לשנות אליו האם יש כזה מדף
        //שינתי לקומה בעקבות שררוצים להכניס פריט למקרר הפריט אמור להגיד לאיפה רוצה להכנס קוד מדף היה 
        // גורם שבכלל לא בטוח שהמדף הזה נמצא במקרר הנ"ל לכן ככה
        //אז עכשיו צריך לבדוק מתי לעשות את מספר המדף כי א"א לקבוע מראש כי תלוי לאיזה מקרר אכניס כי כל מקרר כמות
        // המדפים שונה . לכן לטפל פה בבנאי וכן בסט הנוכחי.
        public int FloorNum
        {
            get { return floorNum; }
            set {
                floorNum = value; } }

        //בנאי זה נוצר בשביל פונקצית קונטיין
        public Item(int itemId,string name)
        {
            this.itemId = itemId;
            this.name = name;
        }
        public Item(string name,DateTime date,Kinds kind,Kashruiot kashrut,double SMR,int floorNum)
        {
            this.ItemId = IdGenrator.giveIdHash();
            this.Name = name;
            this.LastDayUse=date;
            this.kind = kind;
            this.Kashrut = kashrut;
            this.PlaceOnSMR = SMR;
            this.FloorNum = floorNum;
        }
        public override string ToString()
        {
            return this.Name + " " + this.Kashrut + " " + this.Kind + " " + this.PlaceOnSMR + " " +
                this.LastDayUse + " " + this.ItemId;
        }
        //לכאורה יכולתי לגשת ממחלקת מדף ולבדוק בגט תאריך האם גדוך מהיום אך למען הסדר עשיתי פה
        public Boolean isExpired()
        {
            if(this.LastDayUse>DateTime.Now)
                return true;
            return false;
        }
        


    }
}

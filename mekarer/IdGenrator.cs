


using System.Dynamic;

namespace mekarer
{
    internal class IdGenrator
    { public static int idNumber { get; private set; }
        public static int giveId()
        {
         return idNumber++;
        }
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace mekarer
{
    internal class Refrigerator
    {
        private int refrigeratorId;
        private string refrigeratorModel;
        private Colors refrigeratorColor;
        private int amountOfShelves;
        private Shelf[] shelves;

        public Refrigerator()
        {
            this.refrigeratorId = IdGenrator.giveId();

        }
    }
}

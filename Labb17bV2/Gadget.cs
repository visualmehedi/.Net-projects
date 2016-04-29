using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labb17bV2
{
    public class Gadget
    {

        private string gadgetname;
        private decimal price;

        public int GadgetID { get; set; }

        public string GadgetName
        {
            get
            {
                return this.gadgetname;
            }
            set
            {
                this.gadgetname = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }
            set
            {
                this.price = value;

            }
        }
    }

    //public class Gadgets
    //{
    //    private List<Gadget> gadgets;

    //    public List<Gadget> SuperGadgets
    //    {
    //        get
    //        {
    //            return this.gadgets;
    //        }
    //        set
    //        {
    //            this.gadgets = value;
    //        }
    //    }
    //}
}

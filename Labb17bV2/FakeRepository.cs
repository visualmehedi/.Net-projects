using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb17bV2
{
    class FakeRepository : Labb17bV2.IRepository
    {
        private List<Customer> customers;
        private List<Gadget> gadgets;
        public FakeRepository()
        {
            this.customers = new List<Customer> {
                new Customer() { CustomerName = "Kund A",OrderValue = 500},
                new Customer() { CustomerName = "Kund B",OrderValue = 1000},
                new Customer() { CustomerName = "Kund C",OrderValue = 5000},
            };

            this.gadgets = new List<Gadget> {
                new Gadget() { GadgetName = "Gadget 1",Price = 10},
                new Gadget() { GadgetName = "gadget 2",Price = 25},
                new Gadget() { GadgetName = "Gadget 3",Price = 50},
            };
        }
        public List<Customer> Customers()
        {
            return customers;
        }

        public List<Gadget> Gadgets()
        {
            return gadgets;
        }

    }
}

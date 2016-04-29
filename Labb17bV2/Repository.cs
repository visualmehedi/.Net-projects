using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Labb17bV2.Repositories.Contexts;

namespace Labb17bV2.Repositories
{
    class Repository : IRepository
    {
        private List<Customer> customers;
        private List<Gadget> gadgets;
        public Repository()
        {
            using (var db = new CustomerDataStore())
            {
                this.customers = db.Customers.Select(c => c).ToList<Customer>();
                this.gadgets = db.Gadgets.Select(g => g).ToList<Gadget>();
            }
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

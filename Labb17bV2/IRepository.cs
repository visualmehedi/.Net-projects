using System;
using System.Collections.Generic;
namespace Labb17bV2
{
    interface IRepository
    {
        List<Customer> Customers();
        List<Gadget> Gadgets();
    }
}

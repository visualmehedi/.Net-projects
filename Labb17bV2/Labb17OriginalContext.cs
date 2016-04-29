namespace Labb17bV2.Repositories.Contexts
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class Labb17OriginalContext : DbContext
    {

        public Labb17OriginalContext()
            : base("name=Labb17OriginalContext")
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Gadget> Gadgets { get; set; }
    }


}
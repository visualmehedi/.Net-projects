namespace Labb17bV2
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class CustomerDataStore : DbContext
    {
        // Your context has been configured to use a 'CustomerDataStore' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Labb17bV2.CustomerDataStore' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'CustomerDataStore' 
        // connection string in the application configuration file.
        public CustomerDataStore()
            : base("name=CustomerDataStore")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Gadget> Gadgets { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}
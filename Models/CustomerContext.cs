using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;

namespace NawazDemoWebApi.Models
{
    public class CustomerContext :DbContext
    {
        public CustomerContext()
            :base("name=constr")
        {

        }

        //register entity
        public DbSet<Customer> Customers { get; set; }
    }
}
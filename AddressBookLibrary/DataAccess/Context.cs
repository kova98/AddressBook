using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using AddressBookLibrary.Models;

namespace AddressBookLibrary.DataAccess
{
    public class Context : DbContext
    {
        /// <summary>
        /// A list of all the people in the database.
        /// </summary>
        public DbSet<Person> People { get; set; }

        /// <summary>
        /// A list of all the addresses in the database.
        /// </summary>
        public DbSet<Address> Addresses { get; set; }
    }
}

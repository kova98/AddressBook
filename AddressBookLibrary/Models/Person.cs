using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookLibrary.Models
{
    /// <summary>
    /// Contains full information of a person in the address book.
    /// </summary>
    class Person
    {
        /// <summary>
        /// The ID of the person. Used as the primary key.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// The person's first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// The person's last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// The person's phone number.
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// The person's address.
        /// </summary>
        public Address Address { get; set; }
    }
}

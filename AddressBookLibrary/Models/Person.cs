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
    public class Person
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
        /// The person's full name.
        /// </summary>
        public string FullName
        {
            get { return $"{FirstName} {LastName}"; }
        }

        /// <summary>
        /// The person's phone number.
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// The person's email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// The person's date of birth.
        /// </summary>
        public DateTime DateOfBirth { get; set; } = DateTime.Now;

        /// <summary>
        /// The person's address.
        /// </summary>
        public Address Address { get; set; }

        /// <summary>
        /// The person's profile photo name.
        /// </summary>
        public string ProfilePhoto { get; set; }

        /// <summary>
        /// The first character of the person's name.
        /// Used for sorting.
        /// </summary>
        public char FirstChar
        {
            get
            {
                if (String.IsNullOrEmpty(FirstName)) 
                {
                    return ' ';
                }
                else
                {
                    return FirstName.ToUpper()[0];
                }
            }
        }
    }
}

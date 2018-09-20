using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookLibrary.Models
{
    /// <summary>
    /// Contains full address information. 
    /// </summary>
    public class Address
    {
        /// <summary>
        /// The ID of the address. Used as the primary key.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// The street name.
        /// </summary>
        public string StreetName { get; set; }

        /// <summary>
        /// The street number.
        /// </summary>
        public string StreetNumber { get; set; }

        /// <summary>
        /// Returns the street name and number in a single string.
        /// </summary>
        public string StreetNameAndNumber
        {
            get { return $"{StreetName} {StreetNumber}"; }
        }

        /// <summary>
        /// The city.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// The state.
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// The country.
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// The zip code.
        /// </summary>
        public int ZipCode { get; set; }
    }
}

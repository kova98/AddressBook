using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookLibrary.Models
{
    /// <summary>
    /// Contains a list of people whose names start with a certain letter.
    /// </summary>
    class Group
    {
        /// <summary>
        /// The letter of the alphabet which this group represents.
        /// </summary>
        public char Letter { get; set; }

        /// <summary>
        /// The list of people in this group.
        /// </summary>
        public List<Person> People { get; set; }
    }
}

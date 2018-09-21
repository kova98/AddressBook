using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AddressBookLibrary.Models;
using Caliburn.Micro;

namespace AddressBookUI.ViewModels
{
    public class DisplayPersonViewModel : Screen
    {
        public Person SelectedPerson { get; set; }

        public DisplayPersonViewModel(Person personToDisplay)
        {
            SelectedPerson = personToDisplay;
        }
    }
}

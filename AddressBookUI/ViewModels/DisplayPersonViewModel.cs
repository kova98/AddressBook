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
        private readonly IShell shell;

        public Person SelectedPerson { get; set; }

        public DisplayPersonViewModel(Person personToDisplay, IShell sender)
        {
            SelectedPerson = personToDisplay;
            shell = sender;
        }

        public void Delete()
        {
            shell.DeleteSelectedPerson();
        }

        public void Edit()
        {
            shell.ShowEditPerson();
        }
    }
}

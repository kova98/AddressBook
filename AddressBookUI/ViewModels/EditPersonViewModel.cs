using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AddressBookLibrary.Models;
using Caliburn.Micro;

namespace AddressBookUI.ViewModels
{
    public class EditPersonViewModel : Screen
    {
        private readonly IShell shell;
        private Person _selectedPerson;

        public Person SelectedPerson
        {
            get { return _selectedPerson; }
            set
            {
                _selectedPerson = value;
                NotifyOfPropertyChange(() => SelectedPerson);
            }
        }

        public EditPersonViewModel(Person personToEdit, IShell sender)
        {
            SelectedPerson = personToEdit;
            shell = sender;
        }

        public void Save()
        {
            shell.EditPerson(SelectedPerson);
        }
    }
}

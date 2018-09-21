using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AddressBookLibrary.DataAccess;
using AddressBookLibrary.Models;

namespace AddressBookUI.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        private Person _selectedPerson;
        private List<Person> _people;

        public ShellViewModel()
        {
            
        }

        public List<Person> People
        {
            get { return Connector.People.OrderBy(x => x.FirstName).ToList(); }
            set
            {
                _people = value;
                NotifyOfPropertyChange(() => People);
            }
        }

        public Person SelectedPerson
        {
            get { return _selectedPerson; }
            set
            {
                _selectedPerson = value;
                NotifyOfPropertyChange(() => SelectedPerson);
                ActivateItem(new DisplayPersonViewModel(SelectedPerson));
            }
        }
    }
}

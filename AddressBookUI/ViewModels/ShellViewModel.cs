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
    public class ShellViewModel : Conductor<object>, IShell
    {
        private Person _selectedPerson;
        private List<Person> _people;

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
            get
            {
                Person person = _selectedPerson;
                if (person != null)
                {
                    person.DateOfBirth = person.DateOfBirth.Date;
                }

                return person;
            }
            set
            {
                _selectedPerson = value;
                NotifyOfPropertyChange(() => SelectedPerson);
                ShowDisplayPerson();
            }
        }

        public void ShowDisplayPerson()
        {
            ActivateItem(new DisplayPersonViewModel(SelectedPerson, this));
        }

        public void ShowCreatePerson()
        {
            ActivateItem(new CreatePersonViewModel(this));
        }

        public void CreatePerson(Person person)
        {
            Connector.CreatePerson(person);
            NotifyOfPropertyChange(() => People);
            SelectedPerson = person;
        }

        public void DeleteSelectedPerson()
        {
            Connector.DeletePerson(SelectedPerson);
            NotifyOfPropertyChange(() => People);
            SelectedPerson = People.FirstOrDefault();
        }
    }
}

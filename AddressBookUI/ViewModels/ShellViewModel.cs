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
    public class ShellViewModel : Screen
    {
        public BindableCollection<Group> Groups { get; set; } = new BindableCollection<Group>();
        private Person _selectedPerson;
        private List<Person> _people;

        public ShellViewModel()
        {
            PopulateGroups();
        }

        public List<Person> People
        {
            get { return Connector.People; }
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
                int.TryParse("0", out int result);

                _selectedPerson = value;
                NotifyOfPropertyChange(() => SelectedPerson);
            }
        }

        void PopulateGroups()
        {
            foreach (var person in Connector.People)
            {
                var group = Groups.FirstOrDefault(x => x.Letter == person.FirstName.ToUpper()[0]);

                if (group == null)
                {
                    Groups.Add(new Group
                    {
                        Letter = person.FirstName.ToUpper()[0],
                        People = new List<Person>
                        {
                            person
                        }
                    });
                }
                else
                {
                    group.People.Add(person);
                }
            }
        }
    }
}

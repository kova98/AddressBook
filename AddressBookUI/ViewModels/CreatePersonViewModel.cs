using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AddressBookLibrary.Models;

namespace AddressBookUI.ViewModels
{
    public class CreatePersonViewModel : Screen
    {
        private IShell shell;

        public CreatePersonViewModel(IShell sender)
        {
            shell = sender;
        }

        public Person PersonToCreate { get; set; } = new Person { Address = new Address()};

        public bool IsValid
        {
            get
            {
                if (string.IsNullOrEmpty(PersonToCreate.FirstName)) return false;
                return true;
            }
        }

        public void Save(string firstName)
        {
            if (IsValid)
            {
                shell.CreatePerson(PersonToCreate);
            }     
        }
    }
}

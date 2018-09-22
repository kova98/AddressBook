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

        private string _firstName;

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                NotifyOfPropertyChange(FirstName);
            }
        }

        public bool IsValid
        {
            get
            {
                if (string.IsNullOrEmpty(FirstName)) return false;
                return true;
            }
        }


        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; } = DateTime.Now;

        public string StreetName { get; set; }
        public string StreetNumber { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public int ZipCode { get; set; }

        public void Save(string firstName)
        {
            if (IsValid)
            {
                shell.CreatePerson(new Person
                {
                    FirstName = FirstName,
                    LastName = LastName,
                    PhoneNumber = PhoneNumber,
                    Email = Email,
                    DateOfBirth = DateOfBirth,

                    Address = new Address
                    {
                        StreetName = StreetName,
                        StreetNumber = StreetNumber,
                        City = City,
                        State = State,
                        Country = Country,
                        ZipCode = ZipCode
                    }
                });
            }     
        }
    }
}

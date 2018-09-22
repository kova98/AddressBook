using AddressBookLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookUI
{
    public interface IShell
    {
        void CreatePerson(Person person);
        void DeleteSelectedPerson();
        void ShowEditPerson();
        void EditPerson(Person person);
    }
}

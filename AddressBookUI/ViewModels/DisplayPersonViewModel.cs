using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
            if (SelectedPerson != null)
            {
                MessageBoxResult result = MessageBox.Show($"Are you sure you want to delete {SelectedPerson.FullName}?", "Delete Confirmation", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    shell.DeleteSelectedPerson();
                }
            }     
        }

        public void Edit()
        {
            shell.ShowEditPerson();
        }
    }
}

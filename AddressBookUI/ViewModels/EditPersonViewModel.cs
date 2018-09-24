using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using AddressBookLibrary.Models;
using Caliburn.Micro;
using Microsoft.Win32;

namespace AddressBookUI.ViewModels
{
    public class EditPersonViewModel : Screen
    {
        private readonly IShell shell;
        private readonly Random rnd = new Random();
        private readonly string DirectoryPath;
        private const string DirectoryName = "AddressBook";

        private string _photoName;
        private Person _selectedPerson;
        private ImageSource _profilePhoto;
        
        public EditPersonViewModel(Person personToEdit, IShell sender)
        {
            SelectedPerson = personToEdit;
            shell = sender;

            var appData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            DirectoryPath = $"{appData}\\{DirectoryName}";

            if (SelectedPerson.ProfilePhoto != null)
            {
                ProfilePhoto = new BitmapImage(new Uri(SelectedPerson.ProfilePhoto));
            }
        }

        public Person SelectedPerson
        {
            get { return _selectedPerson; }
            set
            {
                _selectedPerson = value;
                NotifyOfPropertyChange(() => SelectedPerson);
            }
        }

        public string PhotoName
        {
            get { return _photoName; }
            set
            {
                _photoName = value;
                NotifyOfPropertyChange(() => PhotoName);
            }
        }

        public ImageSource ProfilePhoto
        {
            get { return _profilePhoto; }
            set
            {
                _profilePhoto = value;
                NotifyOfPropertyChange(() => ProfilePhoto);
            }
        }

        public void Save()
        {
            shell.EditPerson(SelectedPerson);
        }

        public void Upload()
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";

            if (fd.ShowDialog() == true)
            {
                ProfilePhoto = new BitmapImage(new Uri(fd.FileName));
                PhotoName = fd.SafeFileName;

                Directory.CreateDirectory(DirectoryPath);

                var random = rnd.Next(9999).ToString();

                File.Copy(fd.FileName, GetFilePath(random), true);

                SelectedPerson.ProfilePhoto = GetFilePath(random);
            }
        }

        private string GetFilePath(string random)
        {
            return $"{DirectoryPath}\\{PhotoName}_{random}";
        }
    }
}

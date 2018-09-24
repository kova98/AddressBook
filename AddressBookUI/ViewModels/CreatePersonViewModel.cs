using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AddressBookLibrary.Models;
using Microsoft.Win32;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.IO;

namespace AddressBookUI.ViewModels
{
    public class CreatePersonViewModel : Screen
    {
        private readonly IShell shell;
        private readonly Random rnd = new Random();
        private readonly string DirectoryPath;
        private const string DirectoryName = "AddressBook";

        private string _photoName;
        private ImageSource _profilePhoto;
        private Person _personToCreate;

        public CreatePersonViewModel(IShell sender)
        {
            shell = sender;


            PersonToCreate = new Person { Address = new Address() };

            var appData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            DirectoryPath = $"{appData}\\{DirectoryName}";
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

        public Person PersonToCreate
        {
            get { return _personToCreate; }
            set
            {
                _personToCreate = value;
                NotifyOfPropertyChange(() => PersonToCreate);
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

        public void Upload()
        {
            OpenFileDialog fd = new OpenFileDialog
            {
                Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png"
            };

            if (fd.ShowDialog() == true)
            {
                ProfilePhoto = new BitmapImage(new Uri(fd.FileName));
                PhotoName = fd.SafeFileName;

                Directory.CreateDirectory(DirectoryPath);

                var random = rnd.Next(9999).ToString();

                File.Copy(fd.FileName, GetFilePath(random), true);

                PersonToCreate.ProfilePhoto = GetFilePath(random);
            }
        }

        private string GetFilePath(string random)
        {
            return $"{DirectoryPath}\\{_photoName}_{random}";
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AddressBookLibrary.Models;

namespace AddressBookLibrary.DataAccess
{
    class Connector
    {
        /// <summary>
        /// Adds a new Person to the database.
        /// </summary>
        /// <param name="person">The person to add.</param>
        public void CreatePerson(Person person)
        {
            using (var db = new Context())
            {
                if (person != null)
                {
                    db.People.Add(person);
                    db.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Deletes a person from the database.
        /// </summary>
        /// <param name="person">The person to delete.</param>
        public void DeletePerson(Person person)
        {
            using (var db = new Context())
            {
                if (person != null)
                {
                    var personToRemove = db.People.FirstOrDefault(x => x.ID == person.ID);

                    if (personToRemove != null)
                    { 
                        db.People.Remove(personToRemove);
                        db.SaveChanges();
                    }
                }
            }
        }

        /// <summary>
        /// Edits a Person in the database.
        /// Returns false if the Person doesn't exist.
        /// </summary>
        /// <param name="person">The person to edit.</param>
        /// <returns></returns>
        public bool TryEditPerson(Person person)
        {
            using (var db = new Context())
            {
                var personToEdit = db.People.FirstOrDefault(x => x.ID == person.ID);

                if (personToEdit != null)
                {
                    personToEdit.FirstName = person.FirstName;
                    personToEdit.LastName = person.LastName;

                    // Perhaps change this to use a name.
                    personToEdit.Address = db.Addresses.FirstOrDefault(x => x.ID == person.Address.ID);

                    db.Entry(personToEdit.Address).State = EntityState.Modified;
                    db.SaveChanges();

                    return true;
                }
                else
                {
                    return false;
                }
            }
        }


    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactManagerApi.Models;

namespace ContactManagerApiTests.Data
{
    [TestClass]
    class ContactRepositoryTests
    {
        public LiteDatabase SetupTestDb()
        {
            var db = new LiteDatabase("Data/TestContactsDb");
            var col = db.GetCollection<Contact>("contacts");

            return db;
        }

        public Contact CreateTestContact()
        {
            Name name = new Name
            {
                First = "Harold",
                Middle = "Francis",
                Last = "Gikey"
            };

            Address address = new Address
            {
                Street = "8360 High Autumn Row",
                City = "Cannon",
                State = "Delaware",
                Zip = "19797"
            };

            Contact contact = new Contact
            {
                name = name,
                address = address,
                Email = "harold.gikey@yahoo.com"
            };

            contact.phone.Add(new Phone
            {
                Number = "302-611-9148",
                Type = "home"
            });            
            
            contact.phone.Add(new Phone
            {
                Number = "302-532-9427",
                Type = "mobile"
            });

            return contact;
        }

    }
}

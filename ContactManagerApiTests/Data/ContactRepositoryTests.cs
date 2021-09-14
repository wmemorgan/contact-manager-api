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
        [TestMethod]
        public void GetAllRecordsTest()
        {

        }

        [TestMethod]
        public void GetRecordsByIdTest()
        {

        }

        [TestMethod]
        public void InsertRecordTest()
        {

        }

        [TestMethod]
        public void UpdateRecordTest()
        {

        }


        [TestMethod]
        public void DeleteRecordTest()
        {

        }

        private ILiteDatabase SetupTestDb()
        {
            var db = new LiteDatabase("Data/TestContactsDb");
            
            return db;
        }

        private ILiteCollection<Contact> SetupTestCollection(ILiteDatabase db)
        {
            var col = db.GetCollection<Contact>("contacts");
            col.DeleteAll();

            return col;
        }

        private Contact CreateTestContact()
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

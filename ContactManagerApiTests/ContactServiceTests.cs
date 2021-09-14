using System.Linq;
using ContactManagerApi.Data;
using ContactManagerApi.Models;
using ContactManagerApi.Services;
using LiteDB;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ContactManagerApiTests
{
    
    [TestClass]
    public class ContactServiceTests
    {
        [TestMethod]
        public void TestCreateCallList()
        {
            IContactService contactService = new ContactService(this.SetupMockRepository(this.SetupTestDb()));
            var testContact1 = this.CreateTestContact(
                "Harold",
                "Francis",
                "Gilkey",
                "8360 High Autumn Row",
                "Cannon",
                "Delaware",
                "19797",
                "harold.gilkey@yahoo.com"
                );
            testContact1.phone.Add(new Phone
            {
                Number = "302-611-9148",
                Type = "home"
            });
            testContact1.phone.Add(new Phone
            {
                Number = "302-532-9427",
                Type = "mobile"
            });
            var testContact2 = this.CreateTestContact(
                "Steve",
                "Allen",
                "Rogers",
                "123 Main Street",
                "Springfield",
                "Massachusetts",
                "01020",
                "steve@example.com"
                );
            testContact2.phone.Add(new Phone
            {
                Number = "413-555-3414",
                Type = "home"
            });
            var testContact3 = this.CreateTestContact(
                "Anthony",
                "Edward",
                "Stark",
                "123 Main Street",
                "Springfield",
                "Malibu",
                "90265",
                "tstark@example.com"
                );
            testContact3.phone.Add(new Phone
            {
                Number = "310-424-5555",
                Type = "mobile"
            });
            contactService.Save(testContact1);
            contactService.Save(testContact2);
            contactService.Save(testContact3);

            var actual = contactService.CreateCallList();

            Assert.AreEqual(2, actual.Count());
            Assert.AreEqual("302-611-9148", actual.First<CallListContact>().phone);
        }

        private IContactRepository SetupMockRepository(LiteDatabase db)
        {
            IContactRepository contactRepository = new ContactRepository(db);

            return contactRepository;
        }

        private LiteDatabase SetupTestDb()
        {
            var db = new LiteDatabase(":memory:");

            return db;
        }

        private Contact CreateTestContact(
            string firstName,
            string middleName,
            string lastName,
            string street,
            string city,
            string zip,
            string state,
            string email
        )
        {
            Contact contact = new Contact
            {
                name = new Name
                {
                    First = firstName,
                    Middle = middleName,
                    Last = lastName
                },
                address = new Address
                {
                    Street = street,
                    City = city,
                    State = state,
                    Zip = zip
                },
                Email = email
            };


            return contact;
        }


    }
}

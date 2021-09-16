using Microsoft.VisualStudio.TestTools.UnitTesting;
using LiteDB;
using System.Linq;
using ContactManagerApi.Models;
using ContactManagerApi.Data;
using static ContactManagerApiTests.TestUtilities;

namespace ContactManagerApiTests
{
    [TestClass]
    public class ContactRepositoryTests
    {
        [TestMethod]
        public void GetAllRecordsTest()
        {
            IContactRepository contactRepository = new ContactRepository(SetupTestDb());
            var testContact = CreateTestContact(
                "Harold",
                "Francis",
                "Gilkey",
                "8360 High Autumn Row",
                "Cannon",
                "Delaware",
                "19797",
                "harold.gilkey@yahoo.com"
                );
            testContact.phone.Add(new Phone
            {
                Number = "302-611-9148",
                Type = "home"
            });
            testContact.phone.Add(new Phone
            {
                Number = "302-532-9427",
                Type = "mobile"
            });
            var testContact2 = TestUtilities.CreateTestContact(
                "Steve",
                "Allen",
                "Rogers",
                "123 Main Street",
                "Springfield",
                "Massachusetts",
                "01020",
                "steve@example.com"
                );
            contactRepository.Insert(testContact);
            contactRepository.Insert(testContact2);

            var actual = contactRepository.FindAll();

            Assert.AreEqual(2, actual.Count());
            Assert.AreEqual("Gilkey", actual.First().name.Last);
        }

        [TestMethod]
        public void GetRecordsByIdTest()
        {
            IContactRepository contactRepository = new ContactRepository(SetupTestDb());
            var testContact = CreateTestContact(
                "Harold",
                "Francis",
                "Gikey",
                "8360 High Autumn Row",
                "Cannon",
                "Delaware",
                "19797",
                "harold.gilkey@yahoo.com"
                );

            testContact.phone.Add(new Phone
            {
                Number = "302-611-9148",
                Type = "home"
            });

            testContact.phone.Add(new Phone
            {
                Number = "302-532-9427",
                Type = "mobile"
            });
            contactRepository.Insert(testContact);

            var actual = contactRepository.FindOne(1);

            Assert.AreEqual(1, actual.Id);
            Assert.AreEqual("Harold", actual.name.First);
        }

        [TestMethod]
        public void InsertRecordTest()
        {
            IContactRepository contactRepository = new ContactRepository(SetupTestDb());
            var testContact = CreateTestContact(
                "Harold",
                "Francis",
                "Gikey",
                "8360 High Autumn Row",
                "Cannon",
                "Delaware",
                "19797",
                "harold.gilkey@yahoo.com"
                );

            testContact.phone.Add(new Phone
            {
                Number = "302-611-9148",
                Type = "home"
            });

            testContact.phone.Add(new Phone
            {
                Number = "302-532-9427",
                Type = "mobile"
            });
            var actual = contactRepository.Insert(testContact);

            Assert.IsNotNull(actual);
            Assert.AreEqual(1, actual);
            
        }

        [TestMethod]
        public void UpdateRecordTest()
        {
            IContactRepository contactRepository = new ContactRepository(SetupTestDb());
            var testContact = CreateTestContact(
                "Harold",
                "Francis",
                "Gilkey",
                "8360 High Autumn Row",
                "Cannon",
                "Delaware",
                "19797",
                "harold.gilkey@yahoo.com"
                );
            testContact.phone.Add(new Phone
            {
                Number = "302-611-9148",
                Type = "home"
            });
            var contactId = contactRepository.Insert(testContact);
            var retrievedContact = contactRepository.FindOne(contactId);

            retrievedContact.name.Last = "Gilkey-Scott";
            var actual = contactRepository.Update(retrievedContact);
            var updatedContact = contactRepository.FindOne(contactId);

            Assert.IsTrue(actual);
            Assert.AreEqual("Gilkey-Scott", updatedContact.name.Last);
        }


        [TestMethod]
        public void DeleteRecordTest()
        {
            IContactRepository contactRepository = new ContactRepository(SetupTestDb());
            var testContact = CreateTestContact(
                "Harold",
                "Francis",
                "Gilkey",
                "8360 High Autumn Row",
                "Cannon",
                "Delaware",
                "19797",
                "harold.gilkey@yahoo.com"
                );
            testContact.phone.Add(new Phone
            {
                Number = "302-611-9148",
                Type = "home"
            });
            var contactId = contactRepository.Insert(testContact);

            var actual = contactRepository.Delete(contactId);
            var allContacts = contactRepository.FindAll();

            Assert.IsTrue(actual);
            Assert.AreEqual(0, allContacts.Count());
        }
    }
}

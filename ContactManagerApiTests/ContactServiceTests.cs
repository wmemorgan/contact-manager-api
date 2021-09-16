using System.Linq;
using ContactManagerApi.Data;
using ContactManagerApi.Models;
using ContactManagerApi.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static ContactManagerApiTests.TestUtilities;

namespace ContactManagerApiTests
{
    [TestClass]
    public class ContactServiceTests
    {
        [TestMethod]
        public void TestCreateCallList()
        {
            IContactRepository contactRepository = SetupMockRepository(SetupTestDb());
            var testContact1 = CreateTestContact(
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
            var testContact2 = CreateTestContact(
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
            var testContact3 = CreateTestContact(
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
            contactRepository.Insert(testContact1);
            contactRepository.Insert(testContact2);
            contactRepository.Insert(testContact3);
            IContactService contactService = new ContactService(contactRepository);

            var actual = contactService.CreateCallList();

            Assert.AreEqual(2, actual.Count());
            Assert.AreEqual("302-611-9148", actual.First<CallListContact>().phone);
        }

        [TestMethod]
        public void TestSaveContact()
        {
            IContactRepository contactRepository = SetupMockRepository(SetupTestDb());
            var testContact1 = CreateTestContact(
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
            IContactService contactService = new ContactService(contactRepository);

            var actual = contactService.SaveContact(testContact1);
            var actualNewContact = contactRepository.FindAll().Last();

            Assert.AreEqual("Harold", actualNewContact.name.First);

        }

        [TestMethod]
        public void TestUpdateContact()
        {
            IContactRepository contactRepository = SetupMockRepository(SetupTestDb());
            var testContact1 = CreateTestContact(
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
            contactRepository.Insert(testContact1);
            IContactService contactService = new ContactService(contactRepository);

            var contactId = contactRepository.FindAll().Last().Id;
            var updatedContactInfo = new Contact
            {
                Email = "hgilkey@gmail.com"
            };
            var actual = contactService.UpdateContact(updatedContactInfo, contactId);
            var actualUpdatedContact = contactRepository.FindOne(contactId);

            Assert.AreEqual("hgilkey@gmail.com", actualUpdatedContact.Email);
        }
    
    }
}

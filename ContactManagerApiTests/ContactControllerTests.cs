using ContactManagerApi.Controllers;
using ContactManagerApi.Models;
using ContactManagerApi.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using static ContactManagerApiTests.TestUtilities;

namespace ContactManagerApiTests
{
    [TestClass]
    public class ContactControllerTests
    {
        [TestMethod]
        public void GetAllContactsTest()
        {
            IContactService contactService = new ContactService(SetupMockRepository(SetupTestDb()));
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
            contactService.Save(testContact1);
            contactService.Save(testContact2);
            contactService.Save(testContact3);
            var controller = new ContactController(contactService);

            var result = controller.GetContacts();


            Assert.AreEqual(3, result.Count());

        }

        [TestMethod]
        public void DeleteContactTest()
        {
            IContactService contactService = new ContactService(SetupMockRepository(SetupTestDb()));
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
            contactService.Save(testContact);
            var controller = new ContactController(contactService);

            var result = controller.DeleteContact(1);
            var contacts = controller.GetContacts();
            Assert.IsNull(result.Value);
            Assert.AreEqual(0, contacts.Count());

        }
    }
}

using ContactManagerApi.Data;
using ContactManagerApi.Models;
using LiteDB;

/// <summary>
/// A collection of methods for mocking application infrastructure
/// </summary>

namespace ContactManagerApiTests
{
    public static class TestUtilities
    {
        public static IContactRepository SetupMockRepository(LiteDatabase db)
        {
            IContactRepository contactRepository = new ContactRepository(db);

            return contactRepository;
        }

        public static LiteDatabase SetupTestDb()
        {
            var db = new LiteDatabase(":memory:");

            return db;
        }

        public static Contact CreateTestContact(
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

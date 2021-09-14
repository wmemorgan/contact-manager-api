using ContactManagerApi.Models;
using System.Collections.Generic;
using LiteDB;
using System.Linq;

/// <summary>
/// Implementation of the IContactRepository interface
/// </summary>

namespace ContactManagerApi.Data
{
    public class ContactRepository : IContactRepository
    {
        private LiteDatabase _db;

        public ContactRepository(IDbContext dbContext)
        {
            _db = dbContext.Database;
        }

        public IEnumerable<Contact> FindAll()
        {
            return _db.GetCollection<Contact>("Contacts").FindAll();
        }

        public Contact FindOne(int id)
        {
            return _db.GetCollection<Contact>("Contacts")
                .Find(c => c.Id == id).FirstOrDefault();
        }

        public int Insert(Contact contact)
        {
            return _db.GetCollection<Contact>("Contacts")
                .Insert(contact);
        }

        public bool Update(Contact contact)
        {
            return _db.GetCollection<Contact>("Contacts")
                .Update(contact);
        }

        public bool Delete(int id)
        {
            return _db.GetCollection<Contact>("Contacts").Delete(id);
        }
    }
}

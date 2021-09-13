using ContactManagerApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// CRUD repository connecting the Contact model to the rest of the application
/// </summary>

namespace ContactManagerApi.Data
{
    public interface IContactRepository
    {
        IEnumerable<Contact> FindAll();
        Contact FindOne(int id);
        int Insert(Contact contact);
        bool Update(Contact contact);
        bool Delete(int id);
    }
}

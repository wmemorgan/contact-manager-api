using ContactManagerApi.Models;
using System.Collections.Generic;

/// <summary>
/// The service that works with the Contacts and CallListContact models
/// </summary>

namespace ContactManagerApi.Services
{
    public interface IContactService
    {
        IEnumerable<Contact> GetAllContacts();
        Contact GetContactById(int id);
        List<CallListContact> CreateCallList();
        int SaveContact(Contact contact);
        bool UpdateContact(Contact contact, int id);
        bool Delete(int id);
    }
}

using ContactManagerApi.Models;
using System.Collections.Generic;

/// <summary>
/// The service that works with the Contacts and CallListContact models
/// </summary>

namespace ContactManagerApi.Services
{
    public interface IContactService
    {
        List<Contact> GetAllContacts();
        Contact GetContactById(int id);
        List<CallListContact> GetCallListContacts();
        int Save(Contact contact);
        bool Update(Contact contact, int id);
        bool Delete(int id);
    }
}

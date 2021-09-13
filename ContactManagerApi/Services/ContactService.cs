using ContactManagerApi.Data;
using ContactManagerApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Implements the IContactService interface
/// </summary>

namespace ContactManagerApi.Services
{
    public class ContactService : IContactService
    {
        private IContactRepository contactRepository;

        public List<Contact> GetAllContacts()
        {
            List<Contact> rtnList = new List<Contact>();

            foreach(Contact contact in contactRepository.FindAll())
            {
                rtnList.Add(contact);
            }

            return rtnList;
        }

        public Contact GetContactById(int id)
        {
            return contactRepository.FindOne(id);
        }

        public List<CallListContact> CreateCallList()
        {
            List<CallListContact> rtnList = new List<CallListContact>();

            foreach(Contact contact in contactRepository.FindAll())
            {
                int idx = contact.phone.FindIndex(p => p.Type.ToLower() == "home");
                if (idx >= 0)
                {
                    rtnList.Add(
                        new CallListContact
                        {
                            name = contact.name,
                            PhoneNumber = contact.phone[idx].Number
                        }
                    );
                }
            }

            return rtnList.OrderBy(c => c.name.Last)
                        .ThenBy(c => c.name.First)
                        .ToList();
        }


        public int Save(Contact contact)
        {
            return contactRepository.Insert(contact);
        }

        public bool Update(Contact contact, int id)
        {
            if (contactRepository.FindOne(id) != null)
            {
                return contactRepository.Update(contact);
            }
            else
            {
                throw new Exception($"Contact {id} not found");
            }
        }

        public bool Delete(int id)
        {
            if (contactRepository.FindOne(id) != null)
            {
                return contactRepository.Delete(id);
            }
            else
            {
                throw new Exception($"Contact {id} not found");
            }
                
        }
    }
}

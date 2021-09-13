using ContactManagerApi.Data;
using ContactManagerApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public List<CallListContact> GetCallListContacts()
        {
            throw new NotImplementedException();
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

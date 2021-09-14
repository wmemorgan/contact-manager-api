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
        private readonly IContactRepository _contactRepository;

        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public IEnumerable<Contact> GetAllContacts()
        {
            return _contactRepository.FindAll();
        }

        public Contact GetContactById(int id)
        {
            return _contactRepository.FindOne(id);
        }

        public List<CallListContact> CreateCallList()
        {
            List<CallListContact> rtnList = new List<CallListContact>();

            foreach(Contact contact in _contactRepository.FindAll())
            {
                int idx = contact.phone.FindIndex(p => p.Type.ToLower() == "home");
                if (idx >= 0)
                {
                    rtnList.Add(
                        new CallListContact
                        {
                            name = contact.name,
                            phone = contact.phone[idx].Number
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
            Contact newContact = this.CreateContact(contact);
            
            return _contactRepository.Insert(newContact);
        }

        public bool Update(Contact contact, int id)
        {
            if (_contactRepository.FindOne(id) != null)
            {
                contact.Id = id;
                Contact updatedContact = this.CreateContact(contact);
                return _contactRepository.Update(updatedContact);
            }
            else
            {
                throw new Exception($"Contact {id} not found");
            }
        }

        public bool Delete(int id)
        {
            if (_contactRepository.FindOne(id) != null)
            {
                return _contactRepository.Delete(id);
            }
            else
            {
                throw new Exception($"Contact {id} not found");
            }
                
        }

        private Contact CreateContact(Contact contact)
        {
            //Name name = new Name
            //{
            //    First = contact.name.First,
            //    Middle = contact.name.Middle,
            //    Last = contact.name.Last
            //};

            //Address address = new Address
            //{
            //    Street = contact.address.Street,
            //    City = contact.address.City,
            //    State = contact.address.State,
            //    Zip = contact.address.Zip
            //};

            Contact newContact = new Contact
            {
                name = new Name
                {
                    First = contact.name.First,
                    Middle = contact.name.Middle,
                    Last = contact.name.Last
                },
                address = new Address
                {
                    Street = contact.address.Street,
                    City = contact.address.City,
                    State = contact.address.State,
                    Zip = contact.address.Zip
                },
                Email = contact.Email
            };

            if (contact.Id >= 0)
            {
                newContact.Id = contact.Id;
            }

            foreach (Phone p in contact.phone)
            {
                newContact.phone.Add(new Phone 
                { 
                    Number = p.Number, 
                    Type = p.Type 
                });
            }

            return newContact;
        }
    }
}

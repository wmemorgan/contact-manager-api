using ContactManagerApi.Models;
using ContactManagerApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace ContactManagerApi.Controllers
{
    [Route("api/contacts")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public IEnumerable<Contact> GetContacts()
        {
            return _contactService.GetAllContacts();
        }

        [HttpGet("{id}", Name="FindOne")]
        public ActionResult<Contact> GetContactById(int id)
        {
            var result = _contactService.GetContactById(id);
            if (result != default)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("/call-list")]
        public List<CallListContact> GetCallList()
        {
            return _contactService.CreateCallList();
        }

        [HttpPost]
        public ActionResult<Contact> CreateContact(Contact contact)
        {
            var id = _contactService.Save(contact);
            if (id != default)
            {
                return Created("", id);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Contact> UpdateContact(Contact contact, int id)
        {
            var result = _contactService.Update(contact, id);
            if (result)
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
        
        [HttpDelete("{id}")]
        public ActionResult<Contact> DeleteContact(int id)
        {
            var result = _contactService.Delete(id);
            if (result)
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}

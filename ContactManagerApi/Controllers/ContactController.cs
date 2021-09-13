using ContactManagerApi.Models;
using ContactManagerApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactManagerApi.Controllers
{
    [Route("api/contacts")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private IContactService contactService;

        [HttpGet]
        public List<Contact> GetContacts()
        {
            return contactService.GetAllContacts();
        }

        [HttpGet("{id}", Name="FindOne")]
        public ActionResult<Contact> GetContactById(int id)
        {
            var result = contactService.GetContactById(id);
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
            return contactService.CreateCallList();
        }

        [HttpPost]
        public ActionResult<Contact> CreateContact(Contact contact)
        {
            var id = contactService.Save(contact);
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
            var result = contactService.Update(contact, id);
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
            var result = contactService.Delete(id);
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

using ContactManagerApi.Models;
using ContactManagerApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace ContactManagerApi.Controllers
{
    [Produces("application/json")]
    [Route("contacts")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        /// <summary>
        /// List all contacts
        /// </summary>
        /// <returns>A list of contacts</returns>
        [HttpGet]
        public IEnumerable<Contact> GetContacts()
        {
            return _contactService.GetAllContacts();
        }


        /// <summary>
        /// Get a specific contact with the provided id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Get a list of all contacts with home phone numbers
        /// </summary>
        /// <returns>A list of contacts with their names and home phone numbers</returns>
        [HttpGet]
        [Route("call-list")]
        public List<CallListContact> GetCallList()
        {
            return _contactService.CreateCallList();
        }

        /// <summary>
        /// Create a new contact
        /// </summary>
        /// <param name="contact"></param>
        /// <returns>response code</returns>
        /// <response code="201">Returns response code</response>
        /// <response code="400">If the item is null</response>  
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Contact> CreateContact(Contact contact)
        {
            var id = _contactService.SaveContact(contact);
            if (id != default)
            {
                return Created("", id);
            }
            else
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Update a new contact
        /// </summary>
        /// <param name="contact"></param>
        /// <param name="id"></param>
        /// <returns>response code</returns>
        [HttpPut("{id}")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Contact> UpdateContact(Contact contact, int id)
        {
            var result = _contactService.UpdateContact(contact, id);
            if (result)
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Deletes a contact.
        /// </summary>
        /// <param name="id"></param> 
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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

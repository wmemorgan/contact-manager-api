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
    }
}

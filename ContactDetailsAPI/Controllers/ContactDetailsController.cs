using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Configuration;
using BussinessLayer;
using EntityLayer;

namespace ContactDetailsAPI.Controllers
{
    public class ContactDetailsController : ApiController
    {
        IContactService _contactService;
       
        public ContactDetailsController(IContactService contactService)
        {
            _contactService = contactService;
        }
        public HttpResponseMessage Get()
        {
            List<ContactDetails> contactDetails = new List<ContactDetails>();           
            contactDetails= _contactService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, contactDetails);
        }
        public HttpResponseMessage Get(int ID)
        {
            ContactDetails contactDetail = new ContactDetails();

            contactDetail = _contactService.Get(ID);
            return Request.CreateResponse(HttpStatusCode.OK, contactDetail);
        }
        public string Post(ContactDetails contactDetails)
        {
            try
            {                
                return _contactService.Post(contactDetails);
            }
            catch 
            {

                return "Failed to add";
            }
        }
        public string Put(ContactDetails contactDetails)
        {
            try
            {
                return _contactService.Put(contactDetails);
            }
            catch (Exception)
            {

                return "Failed to Update";
            }
        }
        public string Delete(int ID)
        {
            try
            {
                return _contactService.Delete(ID);
            }
            catch (Exception)
            {

                return "Failed to Delete";
            }
        }
    }
}

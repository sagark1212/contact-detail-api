using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactDetailsAPI.Models
{
    public class ContactDetails
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public bool Status { get; set; }
    }
}
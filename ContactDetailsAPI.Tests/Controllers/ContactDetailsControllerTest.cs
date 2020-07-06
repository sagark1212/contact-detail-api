using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Routing;
using BussinessLayer;
using ContactDetailsAPI.Controllers;
using EntityLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repositories;

namespace ContactDetailsAPI.Tests.Controllers
{
    [TestClass]
    public class ContactDetailsControllerTest
    {
        ContactDetailsController _controller;
        IContactService _contactService;


        public ContactDetailsControllerTest()
        {
            _contactService = new ContactServiceFake();
            _controller = new ContactDetailsController(_contactService);
        }
        [TestMethod]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.Get();

            // Assert
           // Assert.IsType<OkObjectResult>(okResult.Result);
        }
        [TestMethod]
        public void GetReturnsProduct()
        {
            // Arrange
            var controller = new ContactDetailsController(_contactService);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            // Act
            var response = controller.Get(3);

            // Assert        
            ContactDetails contactDetails;
            Assert.IsTrue(response.TryGetContentValue<ContactDetails>(out contactDetails));
            Assert.AreEqual(3, contactDetails.ID);
        }
        [TestMethod]
        public void GetSetsLocationHeader()
        {
            // Arrange
            ContactDetailsController controller = new ContactDetailsController(_contactService);

            controller.Request = new HttpRequestMessage
            {
                RequestUri = new Uri("https://localhost:44336/api/ContactDetails")
            };
            controller.Configuration = new HttpConfiguration();
            controller.Configuration.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });

            controller.RequestContext.RouteData = new HttpRouteData(
                route: new HttpRoute(),
                values: new HttpRouteValueDictionary { { "controller", "ContactDetails" } });

            // Act
            //ContactDetails contactdetail = new ContactDetails() { ID = 27, FirstName = "sag", LastName = "kap", Email = "sk@gmail.com", PhoneNo = "9876543210", Status = false };
            var response = controller.Get();
           
            // Assert
            Assert.AreEqual("https://localhost:44336/api/ContactDetails", response.RequestMessage.RequestUri);
        }
        //private List<ContactDetails> GetTestProducts()
        //{
        //    var testContact = new List<ContactDetails>();
        //    testContact.Add(new ContactDetails { ID = 3, FirstName = "sagar", LastName = "kapsssssss", Email = "sk @gmail.com", PhoneNo = "9876543210", Status = false });
        //    testContact.Add(new ContactDetails { ID = 7, FirstName = "sag", LastName = "kap", Email = "sk@gmail.com", PhoneNo = "9876543210", Status = false });
        //    testContact.Add(new ContactDetails { ID = 8, FirstName = "sagar", LastName = "sasa" , Email = "sagar@gmail.com", PhoneNo = "1234567890", Status = true });
        //    testContact.Add(new ContactDetails { ID = 9, FirstName = "sagar", LastName = "aa" ,Email= "sagar@gmail.com", PhoneNo="1234567890",Status=true});

        //return testContact;
        //}
    }
    public class ContactServiceFake : IContactService
    {
        private readonly List<ContactDetails> testContact;

        public ContactServiceFake()
        {
            testContact = new List<ContactDetails>()
            {
           new ContactDetails { ID = 3, FirstName = "sagar", LastName = "kapsssssss", Email = "sk @gmail.com", PhoneNo = "9876543210", Status = false },
           new ContactDetails { ID = 7, FirstName = "sag", LastName = "kap", Email = "sk@gmail.com", PhoneNo = "9876543210", Status = false },
           new ContactDetails { ID = 8, FirstName = "sagar", LastName = "sasa", Email = "sagar@gmail.com", PhoneNo = "1234567890", Status = true },
           new ContactDetails { ID = 9, FirstName = "sagar", LastName = "aa", Email = "sagar@gmail.com", PhoneNo = "1234567890", Status = true },
        };
        }

        public List<ContactDetails> Get()
        {
            return testContact;
        }

        public string Post(ContactDetails newItem)
        {
            newItem.ID = 10;
            testContact.Add(newItem);
            return "added Sucessfully";
        }

        public string Put(ContactDetails newItem)
        {
            return "added Sucessfully";
        }
        public ContactDetails Get(int Id)
        {
            return testContact.Where(a => a.ID == Id)
                .FirstOrDefault();
        }

        public string Delete(int Id)
        {
            var existing = testContact.First(a => a.ID == Id);
            testContact.Remove(existing);

            return "Deleted Sucessfully";
        }
    }
}

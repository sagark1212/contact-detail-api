using EntityLayer;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public class ContactService : IContactService
    {
        IContactRepo _contactRepo;
        //public ContactService()
        //{
        //    _contactRepo = new ContactRepo();
        //}
        public ContactService(IContactRepo contactRepo)
        {
             _contactRepo = contactRepo;
        }
        public string Delete(int ID)
        {
            return _contactRepo.Delete(ID);
        }

        public List<ContactDetails> Get()
        {
            return _contactRepo.Get();
        }
        public ContactDetails Get(int ID)
        {
            return _contactRepo.Get(ID);
        }
        public string Post(ContactDetails contactDetails)
        {
           return _contactRepo.Post(contactDetails);
        }

        public string Put(ContactDetails contactDetails)
        {
            return _contactRepo.Put(contactDetails);
        }
    }
}

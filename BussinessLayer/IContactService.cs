using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public interface IContactService
    {
        List<ContactDetails> Get();
        ContactDetails Get(int ID);
        string Post(ContactDetails contactDetails);
        string Put(ContactDetails contactDetails);
        string Delete(int ID);
    }
}

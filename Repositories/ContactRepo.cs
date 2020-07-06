using Dapper;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ContactRepo: IContactRepo
    {
        public List<ContactDetails> Get()
        {
            List<ContactDetails> contactDetails = new List<ContactDetails>();
            string query = @"SELECT [ID],[FirstName],[LastName], [Email],[PhoneNo],[Status] FROM [dbo].ContactDetails";
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ContactAPPDB"].ConnectionString))
            {
                contactDetails = connection.Query<ContactDetails>(query).ToList();
            }
                return contactDetails;
        }
        public ContactDetails Get(int ID)
        {
            ContactDetails contactDetails = new ContactDetails();
            string query = @"SELECT [ID],[FirstName],[LastName], [Email],[PhoneNo],[Status] FROM [dbo].ContactDetails  WHERE ID=" + ID + ";";
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ContactAPPDB"].ConnectionString))
            {
                contactDetails = connection.Query<ContactDetails>(query).FirstOrDefault();
            }
            return contactDetails;
        }
        public string Post(ContactDetails contactDetails)
        {
            try
            {
                DataTable table = new DataTable();

                string query = @"INSERT INTO [dbo].ContactDetails ([FirstName],[LastName], [Email],[PhoneNo],[Status]) VALUES  ('" + contactDetails.FirstName + "', '" + contactDetails.LastName + "','" + contactDetails.Email + "','" + contactDetails.PhoneNo + "','" + contactDetails.Status + "')";
                using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ContactAPPDB"].ConnectionString))
                {
                    connection.Execute(query);
                }              
                return "added Sucessfully";
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
                string query = @"UPDATE [dbo].ContactDetails  SET [FirstName]='" + contactDetails.FirstName + "'," +
                    "[LastName]='" + contactDetails.LastName + "'," +
                    "[Email]='" + contactDetails.Email + "'," +
                    "[PhoneNo]='" + contactDetails.PhoneNo + "'," +
                    "[Status]='" + contactDetails.Status + "'" +
                    "WHERE ID=" + contactDetails.ID;

                using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ContactAPPDB"].ConnectionString))
                {
                    connection.Execute(query);
                }
                return "Updated Sucessfully";
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
                DataTable table = new DataTable();
                string query = @"DELETE FROM [dbo].ContactDetails WHERE ID=" + ID + ";";
                using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ContactAPPDB"].ConnectionString))
                {
                    connection.Execute(query);
                }
                return "Deleted Sucessfully";
            }
            catch (Exception)
            {
                return "Failed to Delete";
            }
        }
    }
}

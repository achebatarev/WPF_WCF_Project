using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : Service
    {
        const string ServerName = "localhost\\SQLEXPRESS";
        const string Database = "WCF";
        SqlConnection conn;
        SqlCommand comm;
        SqlConnectionStringBuilder connStringBuilder;

        public Service1()
        {
            ConnectToDb();
        }
        void ConnectToDb()
        {
            connStringBuilder = new SqlConnectionStringBuilder();
            connStringBuilder.DataSource = ServerName;
            connStringBuilder.InitialCatalog = Database;
            connStringBuilder.Encrypt = true;
            connStringBuilder.TrustServerCertificate = true;
            connStringBuilder.ConnectTimeout = 30;
            connStringBuilder.AsynchronousProcessing = true;
            connStringBuilder.MultipleActiveResultSets = true;
            connStringBuilder.IntegratedSecurity = true;
            string a = connStringBuilder.ToString();
            conn = new SqlConnection(connStringBuilder.ToString());
            comm = conn.CreateCommand();
        }

        public int UpdateCustomerPhone(Customer c) 
        { 
        try
            {
                comm.CommandText = "UPDATE TCustomers SET Phone=@Phone WHERE FirstName=@FirstName and LastName=@LastName";
                comm.Parameters.Add("FirstName", System.Data.SqlDbType.VarChar, 50).Value = c.FirstName;
                comm.Parameters.Add("LastName", System.Data.SqlDbType.VarChar, 50).Value = c.LastName;
                comm.Parameters.Add("Phone", System.Data.SqlDbType.VarChar, 50).Value = c.Phone;

                comm.CommandType = System.Data.CommandType.Text;
                conn.Open();

                return comm.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }
        public int InsertCustomer(Customer c)
        {
            try
            {
             
                comm.CommandText = "INSERT INTO TCustomers VALUES(@FirstName, @LastName, @Phone)";
                comm.Parameters.Add("FirstName", System.Data.SqlDbType.VarChar, 50).Value = c.FirstName;
                comm.Parameters.Add("LastName", System.Data.SqlDbType.VarChar, 50).Value = c.LastName;
                comm.Parameters.Add("Phone", System.Data.SqlDbType.VarChar, 50).Value = c.Phone;

                comm.CommandType = System.Data.CommandType.Text;
                conn.Open();

                return comm.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }
        public List<Customer> GetAllCustomers()
        {
            List<Customer> customers = new List<Customer>();
            try {
                comm.CommandText = "SELECT * FROM TCustomers";
                comm.CommandType = System.Data.CommandType.Text;

                conn.Open();

                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read()) 
                {
                    Customer customer = new Customer()
                    {
                        FirstName = reader[0].ToString(),
                        LastName = reader[1].ToString(),
                        Phone = reader[2].ToString()
                    };
                    customers.Add(customer);
                }
                return customers;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }
    }
}

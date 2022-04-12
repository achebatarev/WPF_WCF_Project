using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService1
{
    [ServiceContract]
    public interface Service
    {
        [OperationContract]
        int InsertCustomer(Customer c);
        [OperationContract]
        int UpdateCustomerPhone(Customer c);
        [OperationContract]
        List<Customer> GetAllCustomers();
    }


   
}

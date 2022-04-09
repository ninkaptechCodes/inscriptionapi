using Ni_Soft.InscriptionApi.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ni_Soft.InscriptionApi.Business.Interfaces
{
    public interface ICustomerService
    {
        Task<List<Customer>> GetCustomers(CancellationToken cancellation = default);
        Task<Customer> GetCustomer(long Id, CancellationToken cancellation = default);
        Task<Customer> AddCustomer(Customer customer, CancellationToken cancellation = default);
    }
}

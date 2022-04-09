using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Ni_Soft.InscriptionApi.Business.Interfaces;
using Ni_Soft.InscriptionApi.Business.Models;
using Ni_Soft.InscriptionApi.Data;
using Ni_Soft.InscriptionApi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ni_Soft.InscriptionApi.Business.Services
{
    public class CustomerService: ICustomerService
    {
        private readonly ILogger<CustomerService> _logger;
        private readonly InscriptionDbService _db;
        private readonly IMapper _mapper;

        public CustomerService(
            InscriptionDbService db,
            ILogger<CustomerService> logger
            )
        {
            _db = db;
            _logger = logger;
            _mapper = MappingConfig.Mapper;
        }

        public async Task<List<Customer>> GetCustomers(CancellationToken cancellation = default)
        {
            try
            {
                var result = await _db.CustomerRepos.All()
                    .Where(c => !c.DeletedOn.HasValue)
                    .ToListAsync(cancellation);

                var models = result.Select(r => _mapper.Map<Customer>(r)).ToList();

                return models;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, nameof(GetCustomers));
            }
            return null;
        }

        public async Task<Customer> GetCustomer(long Id, CancellationToken cancellation = default)
        {
            try
            {
                var entity = await _db.CustomerRepos.All()
                    .Where(c => !c.DeletedOn.HasValue && c.Id == Id)
                    .SingleOrDefaultAsync(cancellation);
                if (entity != null)
                {
                    var customer = _mapper.Map<Customer>(entity);
                    return customer;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{nameof(GetCustomer)} failed for id {Id}.");
            }

            return null;
        }

        public async Task<Customer> AddCustomer(Customer customer, CancellationToken cancellation = default)
        {
            Customer result = null;
            var transactionActive = false;
            try
            {
                if (await _db.BeginTransaction())
                {
                    transactionActive = true;
                    result = await AddCustomerInternal(customer, cancellation);
                }
                if (result != null)
                {
                    await _db.CommitTransaction(cancellation);
                }
                else
                {
                    await _db.RollbackTransaction(cancellation);
                }
                transactionActive = false;
                return result;
            }
            catch (Exception)
            {
                _logger.LogTrace($"Failed to add a customer");
                await _db.RollbackTransaction(cancellation);
                return null;
            }
        }

        private async Task<Customer> AddCustomerInternal(Customer customer, CancellationToken cancellation)
        {
            Customer result = null;
            try
            {
                var entity = _mapper.Map<CustomerEntity>(customer);
                var added = await _db.CustomerRepos.Create(entity, cancellation);
                if (added != null && added.Id > 0)
                {
                    result = _mapper.Map<Customer>(added);
                }
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }
    }
}

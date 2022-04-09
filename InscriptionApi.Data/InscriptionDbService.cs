using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Ni_Soft.InscriptionApi.Data.Databases;
using Ni_Soft.InscriptionApi.Data.Entities;
using Ni_Soft.InscriptionApi.Data.Interfaces;
using Ni_Soft.InscriptionApi.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ni_Soft.InscriptionApi.Data
{
    public class InscriptionDbService : IDisposable
    {
        private bool disposed = false;
        private readonly InscriptionDbContext _Context;

        private IRepository<CustomerEntity> _CustomerRepos;


        private IDbContextTransaction _Transaction;

        public InscriptionDbService(
            InscriptionDbContext context)
        {
            _Context = context;
        }
        public InscriptionDbService(
            InscriptionDbContext context,
            IRepository<CustomerEntity> customerRepos)
            : this(context)
        {
            _CustomerRepos = customerRepos;
        }

        #region Properties
        public IRepository<CustomerEntity> CustomerRepos =>
            _CustomerRepos ?? new CustomerRepository(this, _Context);

        #endregion
        #region Transactions

        public async Task<bool> BeginTransaction()
        {
            if (_Transaction == null)
            {
                _Transaction = await _Context.Database.BeginTransactionAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> CommitTransaction(CancellationToken cancellation = default)
        {
            if (_Transaction != null)
            {
                await _Transaction.CommitAsync(cancellation);
                _Transaction = null;
                return true;
            }
            return false;
        }

        public async Task<bool> RollbackTransaction(CancellationToken cancellation = default)
        {
            if (_Transaction != null)
            {
                await _Transaction.RollbackAsync(cancellationToken: cancellation);
                _Transaction = null;
                return true;
            }
            return false;
        }

        public void Migrate()
        {
            _Context.Database.Migrate();
        }

        #endregion

        #region Inherited Methods
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _Context.Dispose();
                }
            }
        }
        #endregion
    }
}

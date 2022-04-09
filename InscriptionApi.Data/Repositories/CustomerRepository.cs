using Ni_Soft.InscriptionApi.Data.Databases;
using Ni_Soft.InscriptionApi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ni_Soft.InscriptionApi.Data.Repositories
{
    public class CustomerRepository : BaseRepository<CustomerEntity>
    {
        private InscriptionDbService _dbService;
        private InscriptionDbContext _context;

        public CustomerRepository(
            InscriptionDbService dbService,
            InscriptionDbContext context)
            : base(context)
        {
            _dbService = dbService;
            _context = context;
        }
    }
}

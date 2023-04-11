using Selfdoctor.Domain.Interfaces.Repositories;
using Selfdoctor.Domain.Models;
using Selfdoctor.Infrastructure.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selfdoctor.Infrastructure.Repositories
{
    public class GenderRepository : GenericRepository<Gender>, IGenderRepository
    {
        public GenderRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}

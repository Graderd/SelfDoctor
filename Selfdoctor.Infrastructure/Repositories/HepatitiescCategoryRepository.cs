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
    public class HepatitiescCategoryRepository : GenericRepository<HepatitiscCategory>, IHepatitiscCategoryRepository
    {
        public HepatitiescCategoryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}

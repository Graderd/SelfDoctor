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
    public class BreastCancerDiagnosisRepository : GenericRepository<BreastCancerDiagnosis>, IBreastCancerDiagnosisRepository
    {
        public BreastCancerDiagnosisRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}

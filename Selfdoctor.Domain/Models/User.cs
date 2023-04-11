using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selfdoctor.Domain.Models
{
    public class User: IdentityUser<int>
    {
        public virtual ICollection<DiabetesDiagnostic> DiabetesDiagnostics { get; set; }
        public virtual ICollection<HepatitiscDiagnostic> HepatitiscDiagnostics { get; set; }
        public virtual ICollection<BreastCancerDiagnostic> BreastCancerDiagnostics { get; set; }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selfdoctor.Domain.Models
{
    public class HepatitiscCategory
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public virtual ICollection<HepatitiscDiagnostic> HepatitiscDiagnostics { get; set; }
    }
}

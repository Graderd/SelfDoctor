using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selfdoctor.Domain.Models
{
    public class HepatitiscDiagnostic
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int Age { get; set; }
        public int GendenId { get; set; }
        public float ALB { get; set; }
        public float ALP { get; set; }
        public float ALT { get; set; }
        public float AST { get; set; }
        public float BIL { get; set; }
        public float CHE { get; set; }
        public float CHOL { get; set; }
        public int CREA { get; set; }
        public float GGT { get; set; }
        public float PROT { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }

        public virtual Gender Gender { get; set; }

        public virtual HepatitiscCategory Category { get; set; }
    }
}

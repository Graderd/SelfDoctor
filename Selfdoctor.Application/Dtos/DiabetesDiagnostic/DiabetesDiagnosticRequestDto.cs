using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selfdoctor.Application.Dtos.DiabetesDiagnostic
{
    public class DiabetesDiagnosticRequestDto
    {
        public int Pregnancies { get; set; }
        public int Glucose { get; set; }
        public int BloodPeresure { get; set; }
        public int SkinThickness { get; set; }
        public int Insulin { get; set; }
        public float BMI { get; set; }
        public float DiabetesPedigreeFunction { get; set; }
        public int Age { get; set; }
        public short Outcome { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }
        public int UserId { get; set; }
    }
}

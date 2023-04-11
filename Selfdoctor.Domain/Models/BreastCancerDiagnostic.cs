using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selfdoctor.Domain.Models
{
    public class BreastCancerDiagnostic
    {
        public int Id { get; set; } 
        public int BreaastCancerDiagnosisId { get; set; }
        public float RadiusMean { get; set; }
        public float TextureMean { get; set;}
        public float PerimeterMean { get; set; }
        public float AreaMean { get; set; }
        public float SmoothnessMean { get; set; }
        public float CompactnessMean { get; set; }
        public float ConcavityMean { get; set;  }
        public float ConcavePointsMean { get; set; }
        public float SymmetryMean { get; set; }
        public float FractalDimensionMean { get; set; }
        public float RadiusSe { get; set; }
        public float TextureSe { get; set; }
        public float PerimeterSe { get; set; }
        public float AreaSe { get; set; }
        public float SmoothnessSe { get; set; }
        public float CompactnessSe { get; set;}
        public float ConcavitySe { get; set; }
        public float ConcavePointsSe { get; set; }
        public float SymmetrySe { get; set; }
        public float FractalDimensionSe { get; set; }
        public float RadiusWorst { get; set; }
        public float TextureWorst { get; set; }
        public float perimeter_worst { get; set; }
        public float AreaWorst { get; set; }
        public float SmoothnessWorst { get; set; }
        public float CompactnessWorst { get; set; }
        public float ConcavityWorst { get; set; }
        public float ConcavePointsWorst { get; set; }
        public float SymmetryWorst { get; set; }
        public float FractalDimensionWorst { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public virtual BreastCancerDiagnosis BreastCancerDiagnosis { get; set; }
    }
}

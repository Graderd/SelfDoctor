using AutoMapper;
using Microsoft.Extensions.Logging;
using Selfdoctor.Application.Dtos.BreastCancerDiagnostic;
using Selfdoctor.Application.Dtos.DiabetesDiagnostic;
using Selfdoctor.Application.Interfaces.Services;
using Selfdoctor.Domain.Interfaces.Repositories;
using Selfdoctor.Domain.Models;
using Selfdoctor.Infrastructure.Repositories;
using Selfdoctor_TrainingModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Selfdoctor.Infrastructure.Services
{
    public class BreastCancerDiagnosticService : IBreastCancerDiagnosticService
    {
        private readonly ILogger<BreastCancerDiagnosticService> _logger;
        private readonly IMapper _mapper;
        private readonly IBreastCancerDiagnosticRepository _breastCancerDiagnosticRepository;
        private readonly IBreastCancerDiagnosisRepository _breastCancerDiagnosisRepository;

        public BreastCancerDiagnosticService(ILogger<BreastCancerDiagnosticService> logger,
            IMapper mapper, IBreastCancerDiagnosticRepository breastCancerDiagnosticRepository, IBreastCancerDiagnosisRepository breastCancerDiagnosisRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _breastCancerDiagnosticRepository = breastCancerDiagnosticRepository;
            _breastCancerDiagnosisRepository = breastCancerDiagnosisRepository;
        }

        public async Task<bool> DeleteDiagnosticAsync(int diagnosticId)
        {
            try
            {
                var breastCancerDiagnostic = await _breastCancerDiagnosticRepository.FirstOrDefaultAsync(x => x.Id == diagnosticId);
                if (breastCancerDiagnostic != null)
                {
                    _breastCancerDiagnosticRepository.Delete(breastCancerDiagnostic);
                    var deleted = await _breastCancerDiagnosticRepository.SaveChangesAsync();
                    if (deleted > 0)
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
           
        }
        //Falta este que es despues de ML
        public async Task<string> DoDiagnosticAsync(BreastCancerDiagnosticRequestDto breastCancerDiagnostic)
        {
            try
            {
                var sampleData = new BreastCancerDiagnosticML.ModelInput()
                {
                Radius_mean = breastCancerDiagnostic.RadiusMean,
                Texture_mean = breastCancerDiagnostic.TextureMean,
                Perimeter_mean = breastCancerDiagnostic.PerimeterMean,
                Area_mean = breastCancerDiagnostic.AreaMean,
                Smoothness_mean = breastCancerDiagnostic.SmoothnessMean,
                Compactness_mean = breastCancerDiagnostic.CompactnessMean,
                Concavity_mean = breastCancerDiagnostic.ConcavityMean,
                Concave_points_mean = breastCancerDiagnostic.ConcavePointsMean,
                Symmetry_mean = breastCancerDiagnostic.SymmetryMean,
                Fractal_dimension_mean = breastCancerDiagnostic.FractalDimensionMean,
                Radius_se = breastCancerDiagnostic.RadiusSe,
                Texture_se = breastCancerDiagnostic.TextureSe,
                Perimeter_se = breastCancerDiagnostic.PerimeterSe,
                Area_se = breastCancerDiagnostic.AreaSe,
                Smoothness_se = breastCancerDiagnostic.SmoothnessSe,
                Compactness_se = breastCancerDiagnostic.CompactnessSe,
                Concavity_se = breastCancerDiagnostic.ConcavitySe,
                Concave_points_se = breastCancerDiagnostic.ConcavePointsSe,
                Symmetry_se = breastCancerDiagnostic.SymmetrySe,
                Fractal_dimension_se = breastCancerDiagnostic.FractalDimensionSe,
                Radius_worst = breastCancerDiagnostic.RadiusWorst,
                Texture_worst = breastCancerDiagnostic.TextureWorst,
                Perimeter_worst = breastCancerDiagnostic.PerimeterWorst,
                Area_worst = breastCancerDiagnostic.AreaWorst,
                Smoothness_worst = breastCancerDiagnostic.SmoothnessWorst,
                Compactness_worst = breastCancerDiagnostic.CompactnessWorst,
                Concavity_worst = breastCancerDiagnostic.ConcavityWorst,
                Concave_points_worst = breastCancerDiagnostic.ConcavePointsWorst,
                Symmetry_worst = breastCancerDiagnostic.SymmetryWorst,
                Fractal_dimension_worst = breastCancerDiagnostic.FractalDimensionWorst
            };

                var result = BreastCancerDiagnosticML.Predict(sampleData);

                breastCancerDiagnostic.Date = DateTime.Now;
                breastCancerDiagnostic.Comment = result.PredictedLabel;
                var code = await _breastCancerDiagnosisRepository.FirstOrDefaultAsync(d => d.Code.Equals(result.PredictedLabel));
                breastCancerDiagnostic.BreastCancerDiagnosisId = (code != null) ? code.Id : 0;

                var entity = _mapper.Map<BreastCancerDiagnostic>(breastCancerDiagnostic);
                await _breastCancerDiagnosticRepository.AddAsync(entity);
                await _breastCancerDiagnosticRepository.SaveChangesAsync();
                return result.PredictedLabel;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public async Task<BreastCancerDiagnosticRequestDto> GetBreastCancerDiagnosticByIdAsync(int BreastCancerDiagnosticId)
        {
            try
            {
                var breastCancerDiagnostic = await _breastCancerDiagnosticRepository.FirstOrDefaultAsync(h => h.Id == BreastCancerDiagnosticId);
                if (breastCancerDiagnostic != null) return _mapper.Map<BreastCancerDiagnosticRequestDto>(breastCancerDiagnostic);

                throw new Exception("Diagnostico no existente");
            }

            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public async Task<IEnumerable<BreastCancerDiagnosticListDto>> GetBreastCancerDiagnosticListAsync(int userId)
        {
            try
            {
                var breastCancerDiagnostic = await _breastCancerDiagnosticRepository.FilterAsync(h => h.UserId == userId, new List<Expression<Func<BreastCancerDiagnostic, object>>>()
                {
                    x => x.BreastCancerDiagnosis

                });
                var result = _mapper.Map<IEnumerable<BreastCancerDiagnosticListDto>>(breastCancerDiagnostic);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public async Task<BreastCancerDiagnosticListDto> GetLastBreastCancerDiagnostic()
        {
            try
            {
                var breastCancerDiagnostics = await _breastCancerDiagnosticRepository.GetAllAsync();
                var lastBreastCancerDiagnostic = breastCancerDiagnostics.OrderByDescending(x => x.Id).FirstOrDefault();
                return _mapper.Map<BreastCancerDiagnosticListDto>(lastBreastCancerDiagnostic);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }
    }
}




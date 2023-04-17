using AutoMapper;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
    public class DiabetesDiagnosticService : IDiabetesDiagnosticService
    {
        private readonly ILogger<DiabetesDiagnosticService> _logger;
        private readonly IMapper _mapper;
        private readonly IDiabetesDiagnosticRepository _diabetesDiagnosticRepository;

        public DiabetesDiagnosticService(ILogger<DiabetesDiagnosticService> logger,
            IMapper mapper,
            IDiabetesDiagnosticRepository diabetesDiagnosticRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _diabetesDiagnosticRepository = diabetesDiagnosticRepository;
        }
        public async Task<bool> DeleteDiagnosticAsync(int diagnosticId)
        {
            try
            {
                var diabetesDiagnostic = await _diabetesDiagnosticRepository.FirstOrDefaultAsync(x => x.Id == diagnosticId);
                if (diabetesDiagnostic != null)
                {
                    _diabetesDiagnosticRepository.Delete(diabetesDiagnostic);
                    var deleted = await _diabetesDiagnosticRepository.SaveChangesAsync();
                    if (deleted > 0)
                    {
                        return true;
                    }
                }
                return false;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        
        public async Task<string> DoDiagnosticAsync(DiabetesDiagnosticRequestDto diabetesDiagnostic)
        {
            try
            {
                var sampleData = new DiabetesDiagnosticML.ModelInput()
                {
                    Pregnancies = diabetesDiagnostic.Pregnancies,
                    Glucose = diabetesDiagnostic.Glucose,
                    BloodPressure = diabetesDiagnostic.BloodPeresure,
                    SkinThickness = diabetesDiagnostic.SkinThickness,
                    Insulin = diabetesDiagnostic.Insulin,
                    BMI = diabetesDiagnostic.BMI,
                    DiabetesPedigreeFunction = diabetesDiagnostic.DiabetesPedigreeFunction,
                    Age = diabetesDiagnostic.Age,
                };

                var result = DiabetesDiagnosticML.Predict(sampleData);

                diabetesDiagnostic.Date = DateTime.Now;
                
                diabetesDiagnostic.Outcome = (short)result.PredictedLabel;

                await _diabetesDiagnosticRepository.AddAsync(_mapper.Map<DiabetesDiagnostic>(diabetesDiagnostic));
                await _diabetesDiagnosticRepository.SaveChangesAsync();

                return result.PredictedLabel.ToString();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public async Task<DiabetesDiagnosticRequestDto> GetDiabetesDiagnosticByIdAsync(int DiabetesDiagnosticId)
        {
            try
            {
                var diabetesDiagnostic = await _diabetesDiagnosticRepository.FirstOrDefaultAsync(h => h.Id == DiabetesDiagnosticId);
                if (diabetesDiagnostic != null) return _mapper.Map<DiabetesDiagnosticRequestDto>(diabetesDiagnostic);

                throw new Exception("Diagnostico no existente");
            }
            
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public async Task<IEnumerable<DiabetesDiagnosticListDto>> GetDiabetesDiagnosticsAsync(int userId)
        {
            try
            {
                var diabetesDiagnostics = await _diabetesDiagnosticRepository.FilterAsync(u => u.UserId == userId);
                return _mapper.Map<IEnumerable<DiabetesDiagnosticListDto>>(diabetesDiagnostics);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

       
    }
}

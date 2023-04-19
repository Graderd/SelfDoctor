using AutoMapper;
using Microsoft.Extensions.Logging;
using Selfdoctor.Application.Dtos.HepatitisDiagnostic;
using Selfdoctor.Application.Interfaces.Services;
using Selfdoctor.Domain.Interfaces.Repositories;
using Selfdoctor.Domain.Models;
using Selfdoctor_TrainingModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Selfdoctor.Infrastructure.Services
{
    public class HepatitiscDiagnosticSerrvice : IHepatitisDiagnosticService
    {
        private readonly ILogger<HepatitiscDiagnosticSerrvice> _logger;
        private readonly IMapper _mapper;
        private readonly IGenderRepository _genderRepository;
        private readonly IHepatitiscDiagnosticRepository _hepatitisDiagnosticRepository;
        private readonly IHepatitiscCategoryRepository _hepatitisCategoryRepository;

        public HepatitiscDiagnosticSerrvice(ILogger<HepatitiscDiagnosticSerrvice> logger,
            IMapper mapper,
            IHepatitiscDiagnosticRepository hepatitisDiagnosticRepository,
            IHepatitiscCategoryRepository hepatitisCategoryRepository,
            IGenderRepository genderRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _genderRepository = genderRepository;
            _hepatitisDiagnosticRepository = hepatitisDiagnosticRepository;
            _hepatitisCategoryRepository = hepatitisCategoryRepository;
        }
        public async Task<bool> DeleteDiagnosticAsync(int diagnosticId)
        {
            try
            {
                var hepatiticDiagnostic = await _hepatitisDiagnosticRepository.FirstOrDefaultAsync(x => x.Id == diagnosticId);
                if (hepatiticDiagnostic != null)
                {
                    _hepatitisDiagnosticRepository.Delete(hepatiticDiagnostic);
                    var deleted = await _hepatitisDiagnosticRepository.SaveChangesAsync();
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

        public async Task<string> DoDiagnosticAsync(HepatitisDiagnosticRequestDto hepatitisDiagnostic)
        {
            try
            {
                var gender = await _genderRepository.FirstOrDefaultAsync(g => g.Id == hepatitisDiagnostic.GenderId);
                var sampleData = new HepatitisDiagnosticML.ModelInput()
                {
                    Age = hepatitisDiagnostic.Age,
                    Sex = gender?.Description ?? "m",
                    ALB = hepatitisDiagnostic.ALB,
                    ALP = hepatitisDiagnostic.ALP,
                    ALT = (hepatitisDiagnostic.ALT == 0) ? "NA" : hepatitisDiagnostic.ALT.ToString(),
                    AST = hepatitisDiagnostic.AST,
                    BIL = hepatitisDiagnostic.BIL,
                    CHE = hepatitisDiagnostic.CHE,
                    CHOL = hepatitisDiagnostic.CHOL,
                    CREA = hepatitisDiagnostic.CREA,
                    GGT = hepatitisDiagnostic.GGT,
                    PROT = hepatitisDiagnostic.PROT
                };

                var result = HepatitisDiagnosticML.Predict(sampleData);

                hepatitisDiagnostic.Date = DateTime.Now;
                hepatitisDiagnostic.Comment = result.PredictedLabel;
                var category = await _hepatitisCategoryRepository.FirstOrDefaultAsync(c => c.Description.Equals(result.PredictedLabel));
                hepatitisDiagnostic.CategoryId = (category != null) ? category.Id : 0;

                await _hepatitisDiagnosticRepository.AddAsync(_mapper.Map<HepatitiscDiagnostic>(hepatitisDiagnostic));
                await _hepatitisDiagnosticRepository.SaveChangesAsync();

                return result.PredictedLabel;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public async Task<HepatitisDiagnosticRequestDto> GetHepatitisDiagnosticByIdAsync(int hepatitisDiagnosticId)
        {
            try
            {
                var hepatitisDiagnostic = await _hepatitisDiagnosticRepository.FirstOrDefaultAsync(h => h.Id == hepatitisDiagnosticId);
                if (hepatitisDiagnostic != null) return _mapper.Map<HepatitisDiagnosticRequestDto>(hepatitisDiagnostic);

                throw new Exception("Diágnostico no existente");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public async Task<IEnumerable<HepatitisDiagnosticListDto>> GetHepatitisDiagnosticsAsync(int userId)
        {
            try
            {
                var hepatitisDiagnostics = await _hepatitisDiagnosticRepository.FilterAsync(h => h.UserId == userId, new List<Expression<Func<HepatitiscDiagnostic, object>>>()
                {
                    x => x.Gender,
                    x => x.Category
                });
                var result = _mapper.Map<IEnumerable<HepatitisDiagnosticListDto>>(hepatitisDiagnostics);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

		public async Task<HepatitisDiagnosticListDto> GetLastHepatitisDiagnostic()
		{
			try
			{
				var hepatitisDiagnostics = await _hepatitisDiagnosticRepository.GetAllAsync();
                var lastHepatitisDiagnostic = hepatitisDiagnostics.OrderByDescending(x => x.Id).FirstOrDefault();
                return _mapper.Map<HepatitisDiagnosticListDto>(lastHepatitisDiagnostic);    
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				throw;
			}
		}
	}
}

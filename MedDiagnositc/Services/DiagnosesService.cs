using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedDiagnostic.Models;
using System.Data.Entity;
using MedDiagnositc.Models;
using MedDiagnositc.Services.Interfaces;
using MedDiagnositc.Repositories;
using MedDiagnositc.UnitOfWork;

namespace MedDiagnositc.Services
{
    public class DiagnosesService: IDiagnosisService
    {
        protected readonly IUnitOfWorkAsync _unitOfWork;
        private readonly IRepositoryAsync<Diagnosis> _dignosisRepo;
        private readonly IRepositoryAsync<DiagnosisSymptom> _dignosisSymptomRepo;

        public DiagnosesService(IUnitOfWorkAsync unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _dignosisRepo = unitOfWork.RepositoryAsync<Diagnosis>();
            _dignosisSymptomRepo = unitOfWork.RepositoryAsync<DiagnosisSymptom>();
        }

        public async Task<bool> DeleteSymptom(long diagnosisId, long symptomId)
        {
            var d = await _dignosisRepo.FindAsync(diagnosisId);
            var s = d.Symptoms.Single(ss => ss.Id == symptomId);
            await _dignosisSymptomRepo.DeleteAsync(symptomId);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }

        public async Task<Diagnosis> Get(long id)
        {
            return await _dignosisRepo.FindAsync(id);
        }

        public async Task<IList<Diagnosis>> GetAll()
        {
            return await _dignosisRepo.Queryable().ToListAsync();
        }
    }
}
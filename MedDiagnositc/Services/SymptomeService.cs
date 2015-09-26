using MedDiagnositc.Services.Interfaces;
using System.Collections.Generic;
using MedDiagnostic.Models;
using System.Threading.Tasks;
using MedDiagnositc.UnitOfWork;
using System.Data.Entity;

namespace MedDiagnositc.Services
{
    public class SymptomeService : ISymptomeService
    {
        protected readonly IUnitOfWorkAsync _unitOfWork;

        public SymptomeService(IUnitOfWorkAsync unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IList<Symptom>> GetAll()
        {
            return await _unitOfWork.RepositoryAsync<Symptom>().Queryable().ToListAsync();
        }
    }
}
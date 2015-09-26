using MedDiagnostic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MedDiagnositc.Services.Interfaces
{
    public interface IDiagnosisService
    {
        Task<IList<Diagnosis>> GetAll();

        Task<Diagnosis> Get(long id);

        Task<bool> DeleteSymptom(long diagnosisId, long symptomId);
    }
}
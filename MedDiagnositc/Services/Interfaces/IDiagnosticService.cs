using MedDiagnositc.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedDiagnositc.Services.Interfaces
{
    public interface IDiagnosticService
    {
        Task<IList<DiagnosisResultDTO>> Process(IList<FuzzySymptomDTO> symptomes);
    }
}
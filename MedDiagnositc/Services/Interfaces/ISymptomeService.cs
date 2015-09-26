using MedDiagnositc.UnitOfWork;
using MedDiagnostic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MedDiagnositc.Services.Interfaces
{
    public interface ISymptomeService
    {
        Task<IList<Symptom>> GetAll();
    }
}
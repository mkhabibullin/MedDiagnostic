using MedDiagnositc.Entities;
using MedDiagnostic.Models;
using System.ComponentModel.DataAnnotations;

namespace MedDiagnositc.Models
{
    public class DiagnosisSymptom: Entity
    {
        [Key]
        public long Id { get; set; }

        public long SymptomId { get; set; }
        public virtual Symptom Symptom { get; set; }

        public long DiagnosisId { get; set; }
        public virtual Diagnosis Diagnosis { get; set; }

        public string SymptomFuzzySet { get; set; }
    }
}
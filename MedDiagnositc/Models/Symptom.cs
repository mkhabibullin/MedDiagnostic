using MedDiagnositc.Entities;
using System.ComponentModel.DataAnnotations;

namespace MedDiagnostic.Models
{
    public class Symptom : Entity
    {
        [Key]
        public long Id { get; set; }

        public string Name { get; set; }

        public string DisplayName { get; set; }
    }
}

using MedDiagnositc.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using MedDiagnositc.Entities;

namespace MedDiagnostic.Models
{
    public class Diagnosis: Entity
    {
        [Key]
        public long Id { get; set; }

        public string Name { get; set; }

        public string DisplayName { get; set; }

        public virtual ICollection<DiagnosisSymptom> Symptoms { get; set; }

        public string DiagnisisFuzzySet { get; set; }

        [NotMapped]
        public string Rule
        {
            get
            {
                if (Symptoms.Count == 0)
                {
                    return string.Empty;
                }

                return string.Format("IF {0} THEN {1} IS {2}", 
                    string.Join<string>(" AND ", Symptoms.Select(s => string.Format("{0} IS {1}", s.Symptom.Name, s.SymptomFuzzySet))),
                    "Diagnosis",
                    "Diagnosis");
            }
        }

        [NotMapped]
        public string RuleName {
            get
            {
                return string.Format("Rule {0}", Id);
            }
        }
    }
}

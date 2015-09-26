using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedDiagnositc.Models.Diagnoses
{
    public class DiagnosisViewModel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public IList<SymptomItemViewModel> Symptomes { get; set; }
    }
}
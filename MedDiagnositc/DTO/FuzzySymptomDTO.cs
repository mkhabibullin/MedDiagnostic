using AForge.Fuzzy;

namespace MedDiagnositc.DTO
{
    public class FuzzySymptomDTO
    {
        public long SymptomId { get; set; }
        public FuzzySet FuzzySet { get; set; }
    }
}
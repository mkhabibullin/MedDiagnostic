using AForge.Fuzzy;

namespace MedDiagnositc.Constants
{
    public static class SymptomFuzzySet
    {
        public static FuzzySet Near = new FuzzySet("Near", new NormalMembershipFunction(
                25, 25));
        public static FuzzySet Medium = new FuzzySet("Medium", new NormalMembershipFunction(
                50, 25));
        public static FuzzySet Far = new FuzzySet("Far", new TrapezoidalFunction(
                60, 100, TrapezoidalFunction.EdgeType.Left));
        public static FuzzySet Common = new FuzzySet("Common", new TrapezoidalFunction(
                0, 50, 50, 100));
    }
}
using AForge.Fuzzy;

namespace MedDiagnositc.Constants
{
    public static class DiagnosisFuzzySet
    {
        public static FuzzySet VN = new FuzzySet("VeryNegative", new TrapezoidalFunction(
                -40, -35, TrapezoidalFunction.EdgeType.Right));
        public static FuzzySet N = new FuzzySet("Negative", new TrapezoidalFunction(
            -40, -35, -25, -20));
        public static FuzzySet LN = new FuzzySet("LittleNegative", new TrapezoidalFunction(
            -25, -20, -10, -5));
        public static FuzzySet Zero = new FuzzySet("Zero", new TrapezoidalFunction(
            -10, 5, 5, 10));
        public static FuzzySet LP = new FuzzySet("LittlePositive", new TrapezoidalFunction(
            5, 10, 20, 25));
        public static FuzzySet P = new FuzzySet("Positive", new TrapezoidalFunction(
            20, 25, 35, 40));
        public static FuzzySet VP = new FuzzySet("VeryPositive", new TrapezoidalFunction(
            35, 40, TrapezoidalFunction.EdgeType.Left));
    }
}
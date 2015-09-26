using AForge;
using AForge.Fuzzy;
using System;

namespace FuzzyLogic
{
    class Program
    {
        public static InferenceSystem IS;

        static void Main(string[] args)
        {
            InitFuzzyEngineDiagnosis2();

            //IS.SetInput("RightDistance", 100);
            //IS.SetInput("LeftDistance", 10);

            IS.SetInput("SN", 50);
            IS.SetInput("VGBHYVG", 50);
            IS.SetInput("GBPDKH", 50);
            IS.SetInput("GBVZO", 50);
            IS.SetInput("GBVO", 0);

            IS.SetInput("PAD", 1);
            IS.SetInput("OS", 1);
            IS.SetInput("G", 1);
            IS.SetInput("SHVG", 1);
            IS.SetInput("NK", 1);
            IS.SetInput("US", 1);
            IS.SetInput("GBVI", 1);
            IS.SetInput("MMPG", 1);
            IS.SetInput("NRRSRKH", 0);

            // evaluating outputs
            try
            {
                double NewAngle = IS.Evaluate("Diagnosis");
                //double NewAngle = IS.Evaluate("Angle");
                Console.WriteLine(NewAngle);
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
            }
            Console.Read();
        }
        public static void InitFuzzyEngineDiagnosis2()
        {
            FuzzySet fsCommon0 = new FuzzySet("Common0", new TrapezoidalFunction(-50, -25, 0, 5));
            FuzzySet fsCommon = new FuzzySet("Common", new TrapezoidalFunction(0, 35, 70, 100));

            //IF PAD IS Common AND OS IS Common AND G IS Common AND SHVG IS Common AND VGBHYVG IS Common AND GBPDKH IS Common 
            //AND NK IS Common AND US IS Common AND GBVZO IS Common AND GBVO IS Common AND GBVI IS Common AND MMPG IS Common
            //AND NRRSRKH IS Common
            //THEN Diagnosis IS Diagnosis1

            // right Distance (Input)
            LinguisticVariable SN = new LinguisticVariable("SN", -50, 100);
            SN.AddLabel(fsCommon0);            
            SN.AddLabel(fsCommon);
            LinguisticVariable PAD = new LinguisticVariable("PAD", -50, 100);
            PAD.AddLabel(fsCommon0);
            PAD.AddLabel(fsCommon);
            LinguisticVariable OS = new LinguisticVariable("OS", -50, 100);
            OS.AddLabel(fsCommon0);
            OS.AddLabel(fsCommon);
            LinguisticVariable G = new LinguisticVariable("G", -50, 100);
            G.AddLabel(fsCommon0);
            G.AddLabel(fsCommon);
            LinguisticVariable SHVG = new LinguisticVariable("SHVG", -50, 100);
            SHVG.AddLabel(fsCommon0);
            SHVG.AddLabel(fsCommon);
            LinguisticVariable VGBHYVG = new LinguisticVariable("VGBHYVG", -50, 100);
            VGBHYVG.AddLabel(fsCommon0);
            VGBHYVG.AddLabel(fsCommon);
            LinguisticVariable GBPDKH = new LinguisticVariable("GBPDKH", -50, 100);
            GBPDKH.AddLabel(fsCommon0);
            GBPDKH.AddLabel(fsCommon);
            LinguisticVariable NK = new LinguisticVariable("NK", -50, 100);
            NK.AddLabel(fsCommon0);
            NK.AddLabel(fsCommon);
            LinguisticVariable US = new LinguisticVariable("US", -50, 100);
            US.AddLabel(fsCommon0);
            US.AddLabel(fsCommon);
            LinguisticVariable GBVZO = new LinguisticVariable("GBVZO", -50, 100);
            GBVZO.AddLabel(fsCommon0);
            GBVZO.AddLabel(fsCommon);
            LinguisticVariable GBVO = new LinguisticVariable("GBVO", -50, 100);
            GBVO.AddLabel(fsCommon0);
            GBVO.AddLabel(fsCommon);
            LinguisticVariable GBVI = new LinguisticVariable("GBVI", -50, 100);
            GBVI.AddLabel(fsCommon0);
            GBVI.AddLabel(fsCommon);
            LinguisticVariable MMPG = new LinguisticVariable("MMPG", -50, 100);
            MMPG.AddLabel(fsCommon0);
            MMPG.AddLabel(fsCommon);
            LinguisticVariable NRRSRKH = new LinguisticVariable("NRRSRKH", -50, 100);
            NRRSRKH.AddLabel(fsCommon0);
            NRRSRKH.AddLabel(fsCommon);

            // linguistic labels (fuzzy sets) that compose the angle
            FuzzySet fsVN = new FuzzySet("Diagnosis1", new TrapezoidalFunction(0, 50, 50, 100));
            // linguistic labels (fuzzy sets) that compose the angle
            FuzzySet fsVN2 = new FuzzySet("Diagnosis2", new TrapezoidalFunction(100, 150, 150, 200));
            // angle
            LinguisticVariable diagnosis = new LinguisticVariable("Diagnosis", 0, 200);
            diagnosis.AddLabel(fsVN);
            diagnosis.AddLabel(fsVN2);

            // the database
            Database fuzzyDB = new Database();
            fuzzyDB.AddVariable(SN);
            fuzzyDB.AddVariable(PAD);
            fuzzyDB.AddVariable(OS);
            fuzzyDB.AddVariable(G);
            fuzzyDB.AddVariable(SHVG);
            fuzzyDB.AddVariable(VGBHYVG);
            fuzzyDB.AddVariable(GBPDKH);
            fuzzyDB.AddVariable(NK);
            fuzzyDB.AddVariable(US);
            fuzzyDB.AddVariable(GBVZO);
            fuzzyDB.AddVariable(GBVO);
            fuzzyDB.AddVariable(GBVI);
            fuzzyDB.AddVariable(MMPG);
            fuzzyDB.AddVariable(NRRSRKH);
            fuzzyDB.AddVariable(diagnosis);

            // creating the inference system
            IS = new InferenceSystem(fuzzyDB, new CentroidDefuzzifier(1000));

            //// going Straight
            //IS.NewRule("Rule 1", @"IF PAD IS Common AND OS IS Common 
            //THEN Diagnosis IS Diagnosis1");
            //IS.NewRule("Rule 2", @"IF SN IS Common 
            //THEN Diagnosis IS Diagnosis2");

            // going Straight
            IS.NewRule("Rule 1", @"IF PAD IS Common AND OS IS Common AND G IS Common AND SHVG IS Common 
                AND VGBHYVG IS Common AND GBPDKH IS Common AND NK IS Common AND US IS Common 
                AND GBVZO IS Common AND GBVO IS Common AND GBVI IS Common AND MMPG IS Common AND NRRSRKH IS Common 
                THEN Diagnosis IS Diagnosis1");
            IS.NewRule("Rule 2", @"IF VGBHYVG IS Common AND GBPDKH IS Common AND GBVZO IS Common AND GBVO IS Common AND SN IS Common 
                THEN Diagnosis IS Diagnosis2");

            //// going Straight
            //IS.NewRule("Rule 1", "IF FrontalDistance IS Far THEN Angle IS Zero");
            //// going Straight (if can go anywhere)
            //IS.NewRule("Rule 2", "IF FrontalDistance IS Far AND RightDistance IS Far AND " +
            //    "LeftDistance IS Far THEN Angle IS Zero");
            //// near right wall
            //IS.NewRule("Rule 3", "IF RightDistance IS Near AND LeftDistance IS Medium " +
            //    "THEN Angle IS LittleNegative");
            //// near left wall
            //IS.NewRule("Rule 4", "IF RightDistance IS Medium AND LeftDistance IS Near " +
            //    "THEN Angle IS LittlePositive");
            //// near front wall - room at right
            //IS.NewRule("Rule 5", "IF RightDistance IS Far AND FrontalDistance IS Near " +
            //    "THEN Angle IS Positive");
            //// near front wall - room at left
            //IS.NewRule("Rule 6", "IF LeftDistance IS Far AND FrontalDistance IS Near " +
            //    "THEN Angle IS Negative");
            //// near front wall - room at both sides - go right
            //IS.NewRule("Rule 7", "IF RightDistance IS Far AND LeftDistance IS Far AND " +
            //    "FrontalDistance IS Near THEN Angle IS Positive");
        }

        public static void InitFuzzyEngineDiagnosis()
        {
            // linguistic labels (fuzzy sets) that compose the distances
            FuzzySet fsNear = new FuzzySet("Near", new TrapezoidalFunction(
                0, 25, 25, 50));
            FuzzySet fsMedium = new FuzzySet("Medium", new TrapezoidalFunction(
                50, 75, 75, 100));
            FuzzySet fsFar = new FuzzySet("Far", new TrapezoidalFunction(
                100, 150, 150, 200));

            //IF PAD IS Common AND OS IS Common AND G IS Common AND SHVG IS Common AND VGBHYVG IS Common AND GBPDKH IS Common 
            //AND NK IS Common AND US IS Common AND GBVZO IS Common AND GBVO IS Common AND GBVI IS Common AND MMPG IS Common
            //AND NRRSRKH IS Common
            //THEN Diagnosis IS Diagnosis1

            // right Distance (Input)
            LinguisticVariable lvRight = new LinguisticVariable("RightDistance", 0, 00);
            lvRight.AddLabel(fsNear);
            lvRight.AddLabel(fsMedium);
            lvRight.AddLabel(fsFar);

            // left Distance (Input)
            LinguisticVariable lvLeft = new LinguisticVariable("LeftDistance", 0, 200);
            lvLeft.AddLabel(fsNear);
            lvLeft.AddLabel(fsMedium);
            lvLeft.AddLabel(fsFar);

            // front Distance (Input)
            LinguisticVariable lvFront = new LinguisticVariable("FrontalDistance", 0, 200);
            lvFront.AddLabel(fsNear);
            lvFront.AddLabel(fsMedium);
            lvFront.AddLabel(fsFar);

            // linguistic labels (fuzzy sets) that compose the angle
            FuzzySet fsVN = new FuzzySet("VeryNegative", new TrapezoidalFunction(
                -40, -35, TrapezoidalFunction.EdgeType.Right));
            FuzzySet fsN = new FuzzySet("Negative", new TrapezoidalFunction(
                -40, -35, -25, -20));
            FuzzySet fsLN = new FuzzySet("LittleNegative", new TrapezoidalFunction(
                -25, -20, -10, -5));
            FuzzySet fsZero = new FuzzySet("Zero", new TrapezoidalFunction(
                -10, 5, 5, 10));
            FuzzySet fsLP = new FuzzySet("LittlePositive", new TrapezoidalFunction(
                5, 10, 20, 25));
            FuzzySet fsP = new FuzzySet("Positive", new TrapezoidalFunction(
                5, 25, 35, 40));
            FuzzySet fsVP = new FuzzySet("VeryPositive", new TrapezoidalFunction(
                35, 40, TrapezoidalFunction.EdgeType.Left));

            // angle
            LinguisticVariable lvAngle = new LinguisticVariable("Angle", -50, 50);
            lvAngle.AddLabel(fsVN);
            lvAngle.AddLabel(fsN);
            lvAngle.AddLabel(fsLN);
            lvAngle.AddLabel(fsZero);
            lvAngle.AddLabel(fsLP);
            lvAngle.AddLabel(fsP);
            lvAngle.AddLabel(fsVP);

            // the database
            Database fuzzyDB = new Database();
            fuzzyDB.AddVariable(lvFront);
            fuzzyDB.AddVariable(lvLeft);
            fuzzyDB.AddVariable(lvRight);
            fuzzyDB.AddVariable(lvAngle);

            // creating the inference system
            IS = new InferenceSystem(fuzzyDB, new CentroidDefuzzifier(1000));

            // going Straight
            IS.NewRule("Rule 1", "IF RightDistance IS Far AND LeftDistance IS Far THEN Angle IS VeryNegative");
            // going Straight
            IS.NewRule("Rule 2", "IF FrontalDistance IS Far THEN Angle IS Negative");
            IS.NewRule("Rule 3", "IF FrontalDistance IS Far AND RightDistance IS Far AND LeftDistance IS Far THEN Angle IS LittleNegative");

            //// going Straight
            //IS.NewRule("Rule 1", "IF FrontalDistance IS Far THEN Angle IS Zero");
            //// going Straight (if can go anywhere)
            //IS.NewRule("Rule 2", "IF FrontalDistance IS Far AND RightDistance IS Far AND " +
            //    "LeftDistance IS Far THEN Angle IS Zero");
            //// near right wall
            //IS.NewRule("Rule 3", "IF RightDistance IS Near AND LeftDistance IS Medium " +
            //    "THEN Angle IS LittleNegative");
            //// near left wall
            //IS.NewRule("Rule 4", "IF RightDistance IS Medium AND LeftDistance IS Near " +
            //    "THEN Angle IS LittlePositive");
            //// near front wall - room at right
            //IS.NewRule("Rule 5", "IF RightDistance IS Far AND FrontalDistance IS Near " +
            //    "THEN Angle IS Positive");
            //// near front wall - room at left
            //IS.NewRule("Rule 6", "IF LeftDistance IS Far AND FrontalDistance IS Near " +
            //    "THEN Angle IS Negative");
            //// near front wall - room at both sides - go right
            //IS.NewRule("Rule 7", "IF RightDistance IS Far AND LeftDistance IS Far AND " +
            //    "FrontalDistance IS Near THEN Angle IS Positive");
        }

        // initialization of the Fuzzy Inference System
        public static void InitFuzzyEngine()
        {
            // linguistic labels (fuzzy sets) that compose the distances
            FuzzySet fsNear = new FuzzySet("Near", new TrapezoidalFunction(
                15, 50, TrapezoidalFunction.EdgeType.Right));
            FuzzySet fsMedium = new FuzzySet("Medium", new TrapezoidalFunction(
                15, 50, 60, 100));
            FuzzySet fsFar = new FuzzySet("Far", new TrapezoidalFunction(
                60, 100, TrapezoidalFunction.EdgeType.Left));

            // right Distance (Input)
            LinguisticVariable lvRight = new LinguisticVariable("RightDistance", 0, 120);
            lvRight.AddLabel(fsNear);
            lvRight.AddLabel(fsMedium);
            lvRight.AddLabel(fsFar);

            // left Distance (Input)
            LinguisticVariable lvLeft = new LinguisticVariable("LeftDistance", 0, 120);
            lvLeft.AddLabel(fsNear);
            lvLeft.AddLabel(fsMedium);
            lvLeft.AddLabel(fsFar);

            // front Distance (Input)
            LinguisticVariable lvFront = new LinguisticVariable("FrontalDistance", 0, 120);
            lvFront.AddLabel(fsNear);
            lvFront.AddLabel(fsMedium);
            lvFront.AddLabel(fsFar);

            // linguistic labels (fuzzy sets) that compose the angle
            FuzzySet fsVN = new FuzzySet("VeryNegative", new TrapezoidalFunction(
                -40, -35, TrapezoidalFunction.EdgeType.Right));
            FuzzySet fsN = new FuzzySet("Negative", new TrapezoidalFunction(
                -40, -35, -25, -20));
            FuzzySet fsLN = new FuzzySet("LittleNegative", new TrapezoidalFunction(
                -25, -20, -10, -5));
            FuzzySet fsZero = new FuzzySet("Zero", new TrapezoidalFunction(
                -10, 5, 5, 10));
            FuzzySet fsLP = new FuzzySet("LittlePositive", new TrapezoidalFunction(
                5, 10, 20, 25));
            FuzzySet fsP = new FuzzySet("Positive", new TrapezoidalFunction(
                20, 25, 35, 40));
            FuzzySet fsVP = new FuzzySet("VeryPositive", new TrapezoidalFunction(
                35, 40, TrapezoidalFunction.EdgeType.Left));

            // angle
            LinguisticVariable lvAngle = new LinguisticVariable("Angle", -50, 50);
            lvAngle.AddLabel(fsVN);
            lvAngle.AddLabel(fsN);
            lvAngle.AddLabel(fsLN);
            lvAngle.AddLabel(fsZero);
            lvAngle.AddLabel(fsLP);
            lvAngle.AddLabel(fsP);
            lvAngle.AddLabel(fsVP);

            // the database
            Database fuzzyDB = new Database();
            fuzzyDB.AddVariable(lvFront);
            fuzzyDB.AddVariable(lvLeft);
            fuzzyDB.AddVariable(lvRight);
            fuzzyDB.AddVariable(lvAngle);

            // creating the inference system
            IS = new InferenceSystem(fuzzyDB, new CentroidDefuzzifier(1000));

            // going Straight
            IS.NewRule("Rule 1", "IF FrontalDistance IS Far THEN Angle IS Zero");
            // going Straight (if can go anywhere)
            IS.NewRule("Rule 2", "IF FrontalDistance IS Far AND RightDistance IS Far AND " +
                "LeftDistance IS Far THEN Angle IS Zero");
            // near right wall
            IS.NewRule("Rule 3", "IF RightDistance IS Near AND LeftDistance IS Medium " +
                "THEN Angle IS LittleNegative");
            // near left wall
            IS.NewRule("Rule 4", "IF RightDistance IS Medium AND LeftDistance IS Near " +
                "THEN Angle IS LittlePositive");
            // near front wall - room at right
            IS.NewRule("Rule 5", "IF RightDistance IS Far AND FrontalDistance IS Near " +
                "THEN Angle IS Positive");
            // near front wall - room at left
            IS.NewRule("Rule 6", "IF LeftDistance IS Far AND FrontalDistance IS Near " +
                "THEN Angle IS Negative");
            // near front wall - room at both sides - go right
            IS.NewRule("Rule 7", "IF RightDistance IS Far AND LeftDistance IS Far AND " +
                "FrontalDistance IS Near THEN Angle IS Positive");
        }
    }
}

using MedDiagnositc.Constants;
using MedDiagnositc.Models;
using MedDiagnostic.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MedDiagnositc
{
    public class DbInitializer : CreateDatabaseIfNotExists<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            if (!context.Symptoms.Any())
            {
                var PAD = context.Symptoms.Add(new Symptom { Name = "PAD", DisplayName = "Повышение артериального давления (высокое давление, гипертония, артериальная гипертензия)" });
                var OS = context.Symptoms.Add(new Symptom { Name = "OS", DisplayName = "Общая слабость (утомляемость, усталость, слабость организма)" });
                var G = context.Symptoms.Add(new Symptom { Name = "G", DisplayName = "Головокружение" });
                var SHVG = context.Symptoms.Add(new Symptom { Name = "SHVG", DisplayName = "Шум в голове" });
                var VGBHYVG = context.Symptoms.Add(new Symptom { Name = "VGBHYVG", DisplayName = "Выраженная головная боль, распространяющаяся на всю голову" });
                var GBPDKH = context.Symptoms.Add(new Symptom { Name = "GBPDKH", DisplayName = "Головная боль пульсирующего, давящего характера" });
                var NK = context.Symptoms.Add(new Symptom { Name = "NK", DisplayName = "Носовые кровотечения (кровь из носа, эпистаксис)" });
                var US = context.Symptoms.Add(new Symptom { Name = "US", DisplayName = "Учащенное сердцебиение — более 60 ударов в минуту (тахикардия)" });
                var GBVZO = context.Symptoms.Add(new Symptom { Name = "GBVZO", DisplayName = "Головная боль в затылочной области (боль в затылке)" });
                var BGVO = context.Symptoms.Add(new Symptom { Name = "GBVO", DisplayName = "Головная боль в лобной области (мигрень)" });
                var GBVI = context.Symptoms.Add(new Symptom { Name = "GBVI", DisplayName = "Головная боль внезапная интенсивная" });
                var MMPG = context.Symptoms.Add(new Symptom { Name = "MMPG", DisplayName = "Мелькание «мушек» перед глазами" });
                var NRRSRKH = context.Symptoms.Add(new Symptom { Name = "NRRSRKH", DisplayName = "Нарушение ритма работы сердца различного характера (аритмия) (нарушение сердечного ритма, перебои в сердце)" });

                var SN = context.Symptoms.Add(new Symptom { Name = "SN", DisplayName = "Сниженное настроение (плохое настроение)" });

                context.Diagnoses.AddRange
                    (
                        new Diagnosis[] {
                            new Diagnosis{
                                Name = "AG",
                                DisplayName = "Артериальная гипертензия",
                                Symptoms = new List<DiagnosisSymptom> {
                                    new DiagnosisSymptom {Symptom = PAD, SymptomFuzzySet = SymptomFuzzySet.Common.Name },
                                    new DiagnosisSymptom {Symptom = OS, SymptomFuzzySet = SymptomFuzzySet.Common.Name },
                                    new DiagnosisSymptom {Symptom = G, SymptomFuzzySet = SymptomFuzzySet.Common.Name },
                                    new DiagnosisSymptom {Symptom = SHVG, SymptomFuzzySet = SymptomFuzzySet.Common.Name },
                                    new DiagnosisSymptom {Symptom = VGBHYVG, SymptomFuzzySet = SymptomFuzzySet.Common.Name },
                                    new DiagnosisSymptom {Symptom = GBPDKH, SymptomFuzzySet = SymptomFuzzySet.Common.Name },
                                    new DiagnosisSymptom {Symptom = NK, SymptomFuzzySet = SymptomFuzzySet.Common.Name },
                                    new DiagnosisSymptom {Symptom = US, SymptomFuzzySet = SymptomFuzzySet.Common.Name },
                                    new DiagnosisSymptom {Symptom = GBVZO, SymptomFuzzySet = SymptomFuzzySet.Common.Name },
                                    new DiagnosisSymptom {Symptom = BGVO, SymptomFuzzySet = SymptomFuzzySet.Common.Name },
                                    new DiagnosisSymptom {Symptom = GBVI, SymptomFuzzySet = SymptomFuzzySet.Common.Name },
                                    new DiagnosisSymptom {Symptom = MMPG, SymptomFuzzySet = SymptomFuzzySet.Common.Name },
                                    new DiagnosisSymptom {Symptom = NRRSRKH, SymptomFuzzySet = SymptomFuzzySet.Common.Name }
                                },
                                DiagnisisFuzzySet = DiagnosisFuzzySet.VP.Name
                            },
                            new Diagnosis{
                                Name = "GBN",
                                DisplayName = "Головная боль напряжения",
                                Symptoms = new List<DiagnosisSymptom> {
                                    new DiagnosisSymptom {Symptom = SN, SymptomFuzzySet = SymptomFuzzySet.Common.Name },
                                    new DiagnosisSymptom {Symptom = VGBHYVG, SymptomFuzzySet = SymptomFuzzySet.Common.Name },
                                    new DiagnosisSymptom {Symptom = GBVZO, SymptomFuzzySet = SymptomFuzzySet.Common.Name },
                                    new DiagnosisSymptom {Symptom = GBPDKH, SymptomFuzzySet = SymptomFuzzySet.Common.Name },
                                    new DiagnosisSymptom {Symptom = BGVO, SymptomFuzzySet = SymptomFuzzySet.Common.Name }
                                },
                                DiagnisisFuzzySet = DiagnosisFuzzySet.VP.Name
                            }
                        }
                    );

                context.SaveChanges();

                foreach(var d in context.Diagnoses)
                {
                    d.DiagnisisFuzzySet = "Diagnosis" + d.Id;
                }
                context.SaveChanges();
            }
        }
    }
}
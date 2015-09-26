using System;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;
using MedDiagnositc.DTO;
using MedDiagnositc.Services.Interfaces;
using AForge.Fuzzy;
using MedDiagnositc.UnitOfWork;
using System.Threading.Tasks;
using MedDiagnostic.Models;
using MedDiagnositc.Constants;

namespace MedDiagnositc.Services
{
    public class DiagnosticService : IDiagnosticService
    {
        protected readonly IUnitOfWorkAsync _unitOfWork;

        public DiagnosticService(IUnitOfWorkAsync unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IList<DiagnosisResultDTO>> Process(IList<FuzzySymptomDTO> symptomes)
        {
            var symptomIds = symptomes.Select(s => s.SymptomId).ToArray();

            var diagnosesRepo = _unitOfWork.RepositoryAsync<Diagnosis>();
            var diagnosis = diagnosesRepo.Query(d => d.Symptoms.Any(s => symptomIds.Any(id => id == s.SymptomId))).Select().Distinct().OrderBy(d => d.Id).ToList();
            var diagnosesIds = diagnosis.Select(d => d.Id).ToArray();

            var IS = await InitFuzzyEngineDiagnosis(symptomIds, diagnosesIds);

            var symptomRepo = _unitOfWork.RepositoryAsync<Symptom>();
            var symptoms = await symptomRepo.Queryable().Where(s => symptomIds.Any(sId => sId == s.Id)).ToListAsync();
            foreach(var s in symptoms)
            {
                var fuzzySymptom = symptomes.Single(fs => fs.SymptomId == s.Id);
                var fuzzy = fuzzySymptom.FuzzySet != null ? fuzzySymptom.FuzzySet : SymptomFuzzySet.Common;
                var average = (fuzzy.RightLimit + fuzzy.LeftLimit) / 2;
                try
                {
                    IS.SetInput(s.Name, average);
                }
                catch(Exception exc)
                {

                }
            }

            var result = new List<DiagnosisResultDTO>();

            var evaluate = IS.Evaluate("Diagnosis");

            var i = 0;
            foreach (var diagnoses in diagnosis)
            {
                i++;

                var predel = new Tuple<int, int>(i > 1 ? (i - 1) * 100 : -1, i * 100);

                if(predel.Item1 <= (int)evaluate && predel.Item2 >= (int)evaluate)
                {
                    result.Add(new DiagnosisResultDTO
                    {
                        DiagnosisId = diagnoses.Id,
                        DiagnosisName = diagnoses.DisplayName,
                        Coefficient = 100//TODO:
                    });
                    break;
                }
                //try
                //{
                //    result.Add(new DiagnosisResultDTO {
                //        DiagnosisId = diagnoses.Id,
                //        DiagnosisName = diagnoses.DisplayName,
                //        Coefficient = IS.Evaluate(diagnoses.Name)
                //    });
                //}
                //catch(Exception exc)
                //{

                //}
            }

            return result;
        }

        private async Task<InferenceSystem> InitFuzzyEngineDiagnosis(long[] symptomesId, long[] diagnosesId)
        {
            var fuzzyDB = new AForge.Fuzzy.Database();

            LinguisticVariable lv = new LinguisticVariable("Diagnosis", 0, diagnosesId.Count() * 100);

            fuzzyDB.AddVariable(lv);

            var diagnosesRepo = _unitOfWork.RepositoryAsync<Diagnosis>();

            var diagnosis = diagnosesRepo.Query(d => diagnosesId.Any(did => did == d.Id)).Select().Distinct().OrderBy(d => d.Id).ToList();

            var i = 0;
            foreach (var diagnoses in diagnosis)
            {
                i++;

                lv.AddLabel(new FuzzySet("Diagnosis" + i, new TrapezoidalFunction(
                (i-1) * 100, i * 100 - 50, i * 100 - 50, i * 100)));
                
                foreach(var s in diagnoses.Symptoms)
                {
                    LinguisticVariable lvs = new LinguisticVariable(s.Symptom.Name, 0, 100);
                    lvs.AddLabel(SymptomFuzzySet.Common);

                    try
                    {
                        fuzzyDB.AddVariable(lvs);
                    }
                    catch(Exception exc)
                    {

                    }
                }
            }

            var IS = new InferenceSystem(fuzzyDB, new CentroidDefuzzifier(1000));

            i = 0;
            foreach (var diagnoses in diagnosis)
            {
                i++;
                IS.NewRule(diagnoses.RuleName, diagnoses.Rule + i);
            }

            foreach (var diagnoses in diagnosis)
            {
                foreach (var s in diagnoses.Symptoms)
                {
                    if (!symptomesId.Any(sid => sid == s.SymptomId))
                    {
                        IS.SetInput(s.Symptom.Name, 1);
                    }
                }
            }

            return IS;
        }
    }
}
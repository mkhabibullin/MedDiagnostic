using MedDiagnositc.Diagnoses.Models;
using MedDiagnositc.DTO;
using MedDiagnositc.Models.Diagnoses;
using MedDiagnositc.Models.Symptomes;
using MedDiagnositc.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MedDiagnositc.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDiagnosisService _diagnosesService;
        private readonly ISymptomeService _symptomeService;
        private readonly IDiagnosticService _diagnosticService;

        public HomeController(IDiagnosisService diagnosesService, ISymptomeService symptomService,
            IDiagnosticService diagnosticService)
        {
            _diagnosesService = diagnosesService;
            _symptomeService = symptomService;
            _diagnosticService = diagnosticService;
        }

        public async Task<ActionResult> Index()
        {
            var symptomes = await _symptomeService.GetAll();
            ViewBag.Symptomes = symptomes.Select(s => new SymptomItemViewModel {
                Id = s.Id,
                Name = s.DisplayName
            });
            return View();
        }

        public async Task<ActionResult> Diagnoses()
        {
            var ds = await _diagnosesService.GetAll();

            var model = new DiagnosesListViewModel { Diagnosis = ds.Select(d => new DiagnosesItemViewModel { Id = d.Id, Name = d.DisplayName }).ToList()};

            return View(model);
        }

        public async Task<ActionResult> Diagnosis(long id)
        {
            var d = await _diagnosesService.Get(id);

            var model = new DiagnosisViewModel {
                Id = d.Id,
                Name = d.Name,
                Symptomes = d.Symptoms.Select(s => new SymptomItemViewModel {
                    Id = s.Id,
                    Name = s.Symptom.DisplayName
                }).ToList()
            };

            return View(model);
        }

        public async Task<JsonResult> DeleteSymptom(long diagnosId, long symptomId)
        {
            try
            {
                await _diagnosesService.DeleteSymptom(diagnosId, symptomId);

                return Json(true, JsonRequestBehavior.AllowGet);
            }
            catch(Exception exc)
            {
                return null;
            }
        }

        [HttpPost]
        public async Task<JsonResult> Process(IList<SelectedSymptom> symptomes)
        {
            try
            {
                if(symptomes == null)
                {
                    return Json(false, JsonRequestBehavior.AllowGet);
                }
                return Json(await _diagnosticService.Process(symptomes.Select(s => new FuzzySymptomDTO {
                    SymptomId = s.Id
                }).ToList()), JsonRequestBehavior.AllowGet);
            }
            catch(Exception exc)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
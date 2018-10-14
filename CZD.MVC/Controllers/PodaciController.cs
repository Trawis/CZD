using CZD.Service.Podaci;
using CZD.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CZD.Controllers
{
    public class PodaciController : Controller
    {
        private readonly IPodaciService _podaciService;

        public PodaciController(IPodaciService podaciService)
        {
            _podaciService = podaciService;
        }

        // GET: Podaci
        public ActionResult Index()
        {
            var model = new PodaciViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(PodaciViewModel model)
        {
            if (ModelState.IsValid)
            {
                var path = ConfigurationManager.AppSettings["CSVFileLocation"];
                if (System.IO.File.Exists(path))
                {
                    if (path.EndsWith(".csv"))
                    {
                        model.Podaci = new List<Model.Podaci.DTO.PodaciDTO>();
                        model.Podaci = _podaciService.UcitajDatoteku(path);
                        TempData["podaci"] = model.Podaci;
                    }
                    else
                    {
                        ModelState.AddModelError("Datoteka", "Format datoteke nije podržan!");
                    }
                }
                else
                {
                    ModelState.AddModelError("Datoteka", "Datoteka ne postoji!");
                }
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Spremi()
        {
            var podaci = (List<Model.Podaci.DTO.PodaciDTO>)TempData["podaci"];
            _podaciService.SpremiDatoteku(podaci);
            return RedirectToAction("Index");
        }
    }
}
using System.Collections.Generic;
using System.Configuration;
using System.Web.Mvc;
using CZD.Service;
using CZD.Service.DTO;
using CZD.ViewModels;

namespace CZD.Controllers
{
	public class DataController : Controller
    {
        private readonly IDataService _dataService;

        public DataController(IDataService podaciService)
        {
            _dataService = podaciService;
        }

        // GET: Data
        public ActionResult Index()
        {
            var model = new DataViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(DataViewModel model)
        {
            if (ModelState.IsValid)
            {
                var path = ConfigurationManager.AppSettings["CSVFileLocation"];
                if (System.IO.File.Exists(path))
                {
                    if (path.EndsWith(".csv"))
                    {
                        model.Data = new List<DataDTO>();
                        model.Data = _dataService.LoadFile(path);
                        TempData["podaci"] = model.Data;
                    }
                    else
                    {
                        ModelState.AddModelError("FileError", "File format not supported!");
                    }
                }
                else
                {
                    ModelState.AddModelError("FileError", "File doesn't exist!");
                }
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save()
        {
            var podaci = (List<DataDTO>)TempData["podaci"];
            _dataService.SaveFile(podaci);

            return RedirectToAction("Index");
        }
    }
}
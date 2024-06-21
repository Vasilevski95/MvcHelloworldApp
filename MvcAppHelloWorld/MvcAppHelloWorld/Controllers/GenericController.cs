using System;
using System.Web.Mvc;
using MvcAppHelloWorld.ApplicationService.Generic;

namespace MvcAppHelloWorld.Controllers
{
    public class GenericController<TViewModel, TQueryViewModel> : Controller
        where TViewModel : class
        where TQueryViewModel : class
    {
        private readonly IGenericAppService<TViewModel, TQueryViewModel> _appService;

        public GenericController(IGenericAppService<TViewModel, TQueryViewModel> appService)
        {
            _appService = appService;
        }

        public ActionResult Index()
        {
            var items = _appService.GetAll();
            return View(items);
        }

        public ActionResult Search(string searchTerm)
        {
            var items = _appService.Search(searchTerm);
            return View("Index", items);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(TViewModel viewModel)
        {
            if (!ModelState.IsValid) return View(viewModel);
            _appService.Add(viewModel);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(Guid id)
        {
            var item = _appService.GetById(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _appService.Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult EditDetails(Guid id, bool edit = false)
        {
            var item = _appService.GetById(id);
            if (item == null)
            {
                return HttpNotFound();
            }

            ViewBag.Edit = edit;
            ViewBag.ReadOnly = !edit;
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(TViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Edit = true;
                ViewBag.ReadOnly = false;
                return View("EditDetails", viewModel);
            }

            _appService.Update(viewModel);
            return RedirectToAction("EditDetails", new { id = (viewModel as dynamic).Id });
        }

        public ActionResult DownloadDetails(Guid id)
        {
            var item = _appService.GetById(id);
            if (item == null)
            {
                return HttpNotFound();
            }

            var content = _appService.GenerateDetailsContent(item);

            var byteArray = System.Text.Encoding.UTF8.GetBytes(content);
            var stream = new System.IO.MemoryStream(byteArray);

            return File(stream, "text/plain", $"{((dynamic)item).Name} details.txt");
        }
    }
}
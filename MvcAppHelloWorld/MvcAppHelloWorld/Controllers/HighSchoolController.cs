using MvcAppHelloWorld.ApplicationService.HighSchoolAppService;
using MvcAppHelloWorld.ViewModels;
using System;
using System.Web.Mvc;

namespace MvcAppHelloWorld.Controllers
{
    public class HighSchoolController : Controller
    {
        private readonly IHighSchoolAppService _highSchoolAppService;

        public HighSchoolController(IHighSchoolAppService highSchoolAppService)
        {
            _highSchoolAppService = highSchoolAppService;
        }

        public ActionResult Index()
        {
            var learners = _highSchoolAppService.GetAllHighSchoolLearners();
            return View(learners);
        }

        public ActionResult Search(string searchTerm)
        {
            var learners = _highSchoolAppService.SearchHighSchoolLearners(searchTerm);
            return View("Index", learners);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(HighSchoolViewModel highSchoolLearner)
        {
            if (!ModelState.IsValid) return View(highSchoolLearner);
            _highSchoolAppService.AddHighSchoolLearner(highSchoolLearner);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(Guid id)
        {
            var learner = _highSchoolAppService.GetHighSchoolLearnerById(id);
            if (learner == null)
            {
                return HttpNotFound();
            }
            return View(learner);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _highSchoolAppService.DeleteHighSchoolLearner(id);
            return RedirectToAction("Index");
        }

        public ActionResult EditDetails(Guid id, bool edit = false)
        {
            var learner = _highSchoolAppService.GetHighSchoolLearnerById(id);
            if (learner == null)
            {
                return HttpNotFound();
            }

            ViewBag.Edit = edit;
            ViewBag.ReadOnly = !edit;
            return View(learner);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(HighSchoolViewModel highSchoolLearner)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Edit = true;
                ViewBag.ReadOnly = false;
                return View("EditDetails", highSchoolLearner);
            }

            _highSchoolAppService.UpdateHighSchoolLearner(highSchoolLearner);
            return RedirectToAction("EditDetails", new { id = highSchoolLearner.Id });
        }

        public ActionResult DownloadDetails(Guid id)
        {
            var learner = _highSchoolAppService.GetHighSchoolLearnerById(id);
            if (learner == null)
            {
                return HttpNotFound();
            }

            var content = $"Name: {learner.Name}\n" +
                          $"Surname: {learner.Surname}\n" +
                          $"Date of Birth: {learner.DateOfBirth.ToShortDateString()}\n" +
                          $"Address: {learner.Address}\n" +
                          $"Email: {learner.Email}\n" +
                          $"Phone: {learner.Phone}\n" +
                          $"School Name: {learner.SchoolName}\n" +
                          $"Date of Entry: {learner.DateOfEntry.ToShortDateString()}";

            var byteArray = System.Text.Encoding.UTF8.GetBytes(content);
            var stream = new System.IO.MemoryStream(byteArray);

            return File(stream, "text/plain", $"{learner.Name} {learner.Surname} details.txt");
        }
    }
}
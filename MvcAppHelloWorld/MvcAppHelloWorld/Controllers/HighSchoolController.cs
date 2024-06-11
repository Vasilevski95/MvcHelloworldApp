using System;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using BusinessLayer.HighSchool;
using _4_BusinessObjectModel;

namespace MvcAppHelloWorld.Controllers
{
    public class HighSchoolController : Controller
    {
        private readonly IHighSchoolService _highSchoolService;

        public HighSchoolController(IHighSchoolService highSchoolService)
        {
            _highSchoolService = highSchoolService;
        }

        public ActionResult Index()
        {
            var learners = _highSchoolService.GetAllHighSchoolLearners();
            return View(learners);
        }

        
        public ActionResult Search(string searchTerm)
        {
            var learners = _highSchoolService.SearchHighSchoolLearners(searchTerm);
            return View("Index", learners);
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(HighSchoolLearner highSchoolLearner)
        {
            if (!IsValidEmail(highSchoolLearner.Email))
            {
                ModelState.AddModelError("Email", "Invalid email format.");
            }

            if (!ModelState.IsValid) return View(highSchoolLearner);
            _highSchoolService.AddHighSchoolLearner(highSchoolLearner);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(Guid id)
        {
            var learner = _highSchoolService.GetHighSchoolLearnerById(id);
            if (learner == null)
            {
                return HttpNotFound();
            }
            return View(learner);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _highSchoolService.DeleteHighSchoolLearner(id);
            return RedirectToAction("Index");
        }
        
        public ActionResult EditDetails(Guid id, bool edit = false)
        {
            var learner = _highSchoolService.GetHighSchoolLearnerById(id);
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
        public ActionResult Save(HighSchoolLearner highSchoolLearner)
        {
            if (!IsValidEmail(highSchoolLearner.Email))
            {
                ModelState.AddModelError("Email", "Invalid email format.");
            }
            if (ModelState.IsValid)
            {
                _highSchoolService.UpdateHighSchoolLearner(highSchoolLearner);
                return RedirectToAction("EditDetails", new { id = highSchoolLearner.Id });
            }

            ViewBag.Edit = true;
            ViewBag.ReadOnly = false;
            return View("Details", highSchoolLearner);
        }
        
        public ActionResult DownloadDetails(Guid id)
        {
            var learner = _highSchoolService.GetHighSchoolLearnerById(id);
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

        private static bool IsValidEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                return true;

            const string emailRegex = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, emailRegex);
        }
    }
}

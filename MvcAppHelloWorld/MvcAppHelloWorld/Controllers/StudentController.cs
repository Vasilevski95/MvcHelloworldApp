using MvcAppHelloWorld.ApplicationService.StudentAppService;
using MvcAppHelloWorld.ViewModels;
using System;
using System.Web.Mvc;

namespace MvcAppHelloWorld.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentAppService _studentAppService;

        public StudentController(IStudentAppService studentAppService)
        {
            _studentAppService = studentAppService;
        }

        public ActionResult Index()
        {
            var students = _studentAppService.GetAllStudentLearners();
            return View(students);
        }
        
        public ActionResult Search(string searchTerm)
        {
            var students = _studentAppService.SearchStudentLearners(searchTerm);
            return View("Index", students);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(StudentViewModel studentLearner)
        {
            if (!ModelState.IsValid) return View(studentLearner);
            _studentAppService.AddStudentLearner(studentLearner);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(Guid id)
        {
            var student = _studentAppService.GetStudentLearnerById(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _studentAppService.DeleteStudentLearner(id);
            return RedirectToAction("Index");
        }
        
        public ActionResult EditDetails(Guid id, bool edit = false)
        {
            var learner = _studentAppService.GetStudentLearnerById(id);
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
        public ActionResult Save(StudentViewModel studentLearner)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Edit = true;
                ViewBag.ReadOnly = false;
                return View("EditDetails", studentLearner);
            }

            _studentAppService.UpdateStudentLearner(studentLearner);
            return RedirectToAction("EditDetails", new { id = studentLearner.Id });
        }

        public ActionResult DownloadDetails(Guid id)
        {
            var learner = _studentAppService.GetStudentLearnerById(id);
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
                          $"College Name: {learner.CollegeName}\n" +
                          $"Generation: {learner.Generation}";

            var byteArray = System.Text.Encoding.UTF8.GetBytes(content);
            var stream = new System.IO.MemoryStream(byteArray);

            return File(stream, "text/plain", $"{learner.Name} {learner.Surname} details.txt");
        }
    }
}
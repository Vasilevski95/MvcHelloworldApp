using System;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using BusinessLayer.Student;
using _4_BusinessObjectModel;

namespace MvcAppHelloWorld.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public ActionResult Index()
        {
            var students = _studentService.GetAllStudentLearners();
            return View(students);
        }
        
        public ActionResult Search(string searchTerm)
        {
            var students = _studentService.SearchStudentLearners(searchTerm);
            return View("Index", students);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(StudentLearner studentLearner)
        {
            if (!IsValidEmail(studentLearner.Email))
            {
                ModelState.AddModelError("Email", "Invalid email format.");
            }

            if (!ModelState.IsValid) return View(studentLearner);
            _studentService.AddStudentLearner(studentLearner);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(Guid id)
        {
            var student = _studentService.GetStudentLearnerById(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _studentService.DeleteStudentLearner(id);
            return RedirectToAction("Index");
        }
        
        public ActionResult EditDetails(Guid id, bool edit = false)
        {
            var learner = _studentService.GetStudentLearnerById(id);
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
        public ActionResult Save(StudentLearner studentLearner)
        {
            if (!IsValidEmail(studentLearner.Email))
            {
                ModelState.AddModelError("Email", "Invalid email format.");
            }
            if (ModelState.IsValid)
            {
                _studentService.UpdateStudentLearner(studentLearner);
                return RedirectToAction("EditDetails", new { id = studentLearner.Id });
            }

            ViewBag.Edit = true;
            ViewBag.ReadOnly = false;
            return View("Details", studentLearner);
        }
        
        public ActionResult DownloadDetails(Guid id)
        {
            var learner = _studentService.GetStudentLearnerById(id);
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

        private static bool IsValidEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                return true;

            const string emailRegex = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, emailRegex);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Student_Entity;
using Student_Interface;

namespace tutorial_dot_net.Areas.Student.Controllers
{
    [Area("Student")]
    public class EntryController : Controller
    {
        public readonly IStudent _student;
        public EntryController(IStudent student)
        {
            _student = student;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResponse AddStudent(Student_Entity.Student student)
        {
            return _student.AddStudent(student);
        }
        [HttpPost]
        public JsonResponse GetAllStudents(int? ID = null)
        {
            return _student.GetAllStudents(ID);
        }

        [HttpPost]
        public JsonResponse UpdateStudent(Student_Entity.Student updatedStudent)
        {
            return _student.UpdateStudent(updatedStudent);
        }

        [HttpPost]
        public JsonResponse DeleteStudent(int ID)
        {
            return _student.DeleteStudent(ID);  
        }
    }
}

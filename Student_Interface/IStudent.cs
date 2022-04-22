using Student_Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Student_Interface
{
    public interface IStudent
    {
        // To ADD
        JsonResponse AddStudent(Student student);

       
        JsonResponse GetAllStudents(int? ID);

        JsonResponse UpdateStudent(Student updatedStudent);

        JsonResponse DeleteStudent(int ID);

    }
}

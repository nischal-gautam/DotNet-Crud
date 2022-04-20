using Student_Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Student_Interface
{
    public interface IStudent
    {
        JsonResponse AddStudent(Student student);

    }
}

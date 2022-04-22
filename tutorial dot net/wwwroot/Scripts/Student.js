var StudentViewModal = function () {
    self.StudentID = ko.observable();
    self.StudentName = ko.observable();
    self.StudentAge = ko.observable();
    self.StudentRoll = ko.observable();
    self.StudentClass = ko.observable();

    self.SaveStudent = function ()

    {
        var Student = {
            'ID': self.StudentID(),
            'StudentName': self.StudentName(),
            'StudentClass': self.StudentClass(),
            'StudentAge': self.StudentAge(),
            'StudentRoll': self.StudentRoll()

        }
        $.ajax({
            type: "Post",
            url: '/Student/Entry/AddStudent',
            data: { "student": Student },
            datatype: "json",
            success: function (result) {
                if (result.isSuccess) {
                    alert(result.message)
                } else {
                    alert(result.message)
                }
            },
            error: function (error) {
                alert('error', error.message)
            }

        })

    }


    self.StudentID.subscribe(function () {
        $.ajax({
            type: "Post",
            url: '/Student/Entry/GetAllStudents',
            data: { "ID": self.StudentID()},
            datatype: "json",
            success: function (result) {
                self.StudentName(result.responseData.studentName)
                self.StudentAge(result.responseData.studentAge)
                self.StudentRoll(result.responseData.studentRoll)
                self.StudentClass(result.responseData.studentClass)
            },
            error: function (error) {
                alert (error.message)
            }

        })

    })
    self.UpdateStudent = function () {

        var Student = {
            'ID': self.StudentID(),
            'StudentName': self.StudentName(),
            'StudentClass': self.StudentClass(),
            'StudentAge': self.StudentAge(),
            'StudentRoll': self.StudentRoll()
        }

        $.ajax({
            type: "Post",
            url: '/Student/Entry/UpdateStudent',
            data: { "updatedStudent": Student },
            datatype: "json",
            success: function (result) {
                
                    alert(result.message)
               
            },
            error: function (error) {
                alert('error', error.message)
            }

        })

    }
    self.DeleteStudent = function () {


        $.ajax({
            type: "Post",
            url: '/Student/Entry/DeleteStudent',
            data: { "ID": self.StudentID() },
            datatype: "json",
            success: function (result) {

                alert(result.message)

            },
            error: function (error) {
                alert('error', error.message)
            }

        })
    }

}
self.ClearControls

$(function () {
    ko.applyBindings(new StudentViewModal());
});

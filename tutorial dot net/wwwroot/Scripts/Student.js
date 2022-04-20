var StudentViewModal = function () {
    self.StudentID = ko.observable();
    self.StudentName = ko.observable();
    self.StudentAge = ko.observable();
    self.StudentRoll= ko.observable();
    self.StudentClass = ko.observable();

    self.SaveStudent = function () {
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

  
}

$(function () {
    ko.applyBindings(new StudentViewModal());
});

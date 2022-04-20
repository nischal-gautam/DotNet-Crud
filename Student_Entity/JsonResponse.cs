using System;
using System.Collections.Generic;
using System.Text;

namespace Student_Entity
{
    public class JsonResponse
    {
        public bool IsSuccess { get; set; }
        public bool IsValidSubmissionNo { get; set; }
        public bool IsValid { get; set; }
        public string Message { get; set; }
        public dynamic data { get; set; }
        public string token { get; set; }
        public object ResponseData { get; set; }
        public object Records { get; set; }
        public string OutputParam { get; set; }
        public object TotalRecords { get; set; }
        public string CallBack { get; set; }
        public bool IsToken { get; set; }
        public string ChangePassword { get; set; }

    }
}

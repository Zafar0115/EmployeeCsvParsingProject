using System.Net;

namespace EmployeeTask.Models
{
    public class Error
    {
        public string? ErrorMessage { get; set; } = "Unknown error. Something went wrong";
        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccess { get; set; }
        public Exception Result { get; set; }
    }
}

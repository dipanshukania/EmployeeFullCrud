using System.ComponentModel.DataAnnotations.Schema;

namespace crudapi.Models.ViewModels
{
    public class RepsonseModel
    {
    }

    public class CommonResponseModel
    {
        public bool Success { get; set; }

        public string Message { get; set; }

        [NotMapped]
        public dynamic data { get; set; }
    }

    public class ServerResponseModel
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}

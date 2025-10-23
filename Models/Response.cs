namespace Pschool.API.Models
{
    public class Response
    {
        public string UniqueID { get; set; } = Guid.NewGuid().ToString();
        public string ResponseCode { get; set; }
        public string ResponseDescription { get; set; }
        public object ResponseObject { get; set; }
    }
}

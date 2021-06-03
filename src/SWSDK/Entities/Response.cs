using System.Runtime.Serialization;

namespace SW.Entities
{
    public class Response
    {
        public string status { get; set; }
        public string message { get; set; }
        public string messageDetail { get; set; }
    }
}
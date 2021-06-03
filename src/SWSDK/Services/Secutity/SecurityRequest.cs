using System.Runtime.Serialization;

namespace SW.Services.Security
{
    public class SecurityRequest
    {
        [DataMember]
        public string Password { get; set; }
    }
}

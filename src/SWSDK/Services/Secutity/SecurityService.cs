using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SW.Services.Security
{
    public abstract class SecurityService : Services
    {
        public SecurityService(string url, string token, string proxy, int proxyPort) : base(url, token, proxy, proxyPort) { }

        internal abstract Task<SecurityResponse> ResetAsync(string idUser);

        internal abstract Task<SecurityResponse> RecoveryAsync(string idUser, string password);

        internal virtual Dictionary<string, string> GetHeadersAsync()
        {
            Dictionary<string, string> headers = new Dictionary<string, string>() {
                    { "Authorization", "bearer " + this.Token }
                };
            return headers;
        }

        internal virtual StringContent RequestSecurityAsync(string password)
        {
            var body = Newtonsoft.Json.JsonConvert.SerializeObject(new SecurityRequest()
            {
                Password = password
            });
            StringContent content = new StringContent(body, Encoding.UTF8, "application/json");
            return content;
        }

    }
}

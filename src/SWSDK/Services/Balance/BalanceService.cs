using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SW.Services.Balance
{
    public abstract class BalanceService : Services
    {
        public BalanceService(string url, string token, string proxy, int proxyPort) : base(url, token, proxy, proxyPort) { }

        internal abstract Task<BalanceResponse<string>> AddAsync(string idUser, int stamps, string comment);

        internal abstract Task<BalanceResponse<string>> RemoveAsync(string idUser, int stamps, string comment);
        
        internal abstract Task<BalanceResponse<Data>> BalanceTokenAsync();
        
        internal abstract Task<BalanceResponse<Data>> BalanceAsync(string idUser);
        
        internal virtual Dictionary<string, string> GetHeadersAsync()
        {
            Dictionary<string, string> headers = new Dictionary<string, string>() {
                    { "Authorization", "bearer " + this.Token }
                };
            return headers;
        }
        
        internal virtual StringContent RequestBalanceAsync(string comment)
        {
            var body = Newtonsoft.Json.JsonConvert.SerializeObject(new BalanceRequest()
            {
                Comentario = comment
            });
            StringContent content = new StringContent(body, Encoding.UTF8, "application/json");
            return content;
        }
    }
}

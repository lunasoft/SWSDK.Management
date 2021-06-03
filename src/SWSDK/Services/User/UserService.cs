using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SW.Services.User
{
    public abstract class UserService : Services
    {
        public UserService(string url, string token, string proxy, int proxyPort) : base(url, token, proxy, proxyPort) { }

        internal abstract Task<UserResponse<object>> CreateAsync<T>(T user);

        internal abstract Task<UserResponse<string>> DeleteAsync(string idUser);

        internal abstract Task<UserResponse<string>> UpdateAsync(UserUpdate user, string idUser);

        internal abstract Task<UserResponse<List<Data>>> GetAllAsync(int page, int pageSize);

        internal abstract Task<UserResponse<Data>> GetByIdAsync(string idUser);

        internal abstract Task<UserResponse<Data>> GetByTokenAsync();

        internal virtual Dictionary<string, string> GetHeadersAsync()
        {
            Dictionary<string, string> headers = new Dictionary<string, string>() {
                    { "Authorization", "bearer " + this.Token }
                };
            return headers;
        }

        internal virtual StringContent RequestUserAsync<T>(T user)
        {
            var body = Newtonsoft.Json.JsonConvert.SerializeObject(user);
            StringContent content = new StringContent(body, Encoding.UTF8, "application/json");
            return content;
        }

    }
}

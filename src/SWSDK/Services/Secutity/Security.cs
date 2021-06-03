using SW.Helpers;
using System;
using System.Threading.Tasks;

namespace SW.Services.Security
{
    public class Security : SecurityService
    {
        private readonly SecurityResponseHandler _handler;

        public Security(string url, string token, int proxyPort = 0, string proxy = null)
            : base(url, token, proxy, proxyPort)
            => _handler = new SecurityResponseHandler();

        internal async override Task<SecurityResponse> RecoveryAsync(string idUser, string password)
        {
            try
            {
                Validation.ValidateHeaderParameters(Url, Token);
                Validation.ValidateGuid(idUser);
                Validation.validateValue(password);

                var headers = GetHeadersAsync();
                var content = this.RequestSecurityAsync(password);
                var proxy = Helpers.RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                return await _handler.GetPutResponseAsync(this.Url,
                                $"management/api/users/{idUser}/reset_password", headers, proxy, content);
            }
            catch (Exception e)
            {
                return _handler.HandleException(e);
            }
        }

        internal async override Task<SecurityResponse> ResetAsync(string idUser)
        {
            try
            {
                Validation.ValidateHeaderParameters(Url, Token);
                Validation.ValidateGuid(idUser);
            
                var headers = GetHeadersAsync();
                var proxy = Helpers.RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                return await _handler.GetPutResponseAsync(this.Url,
                                $"management/api/users/{idUser}/reset_token", headers, proxy);
            }
            catch (Exception e)
            {
                return _handler.HandleException(e);
            }
        }

        public async Task<SecurityResponse> PasswordRecoveryAsync(string idUser, string password)
        {
            return await RecoveryAsync(idUser, password);
        }

        public async Task<SecurityResponse> TokenResetAsync(string idUser)
        {
            return await ResetAsync(idUser);
        }
    }
}

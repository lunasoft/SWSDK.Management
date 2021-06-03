using SW.Helpers;
using System;
using System.Threading.Tasks;

namespace SW.Services.Balance
{
    public class Balance : BalanceService
    {
        public Balance(string url, string token, int proxyPort = 0, string proxy = null)
            : base(url, token, proxy, proxyPort) { }
            
        internal async override Task<BalanceResponse<string>> AddAsync(string idUser, int stamps, string comment)
        {
            var _handler = new BalanceResponseHandler<string>();
            try
            {
                Validation.ValidateHeaderParameters(Url, Token);
                Validation.ValidateGuid(idUser);
                Validation.validateValue(stamps);

                var headers =  GetHeadersAsync();
                var content =  this.RequestBalanceAsync(comment);
                var proxy = Helpers.RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                return await _handler.GetPostResponseAsync(this.Url,
                                $"management/api/balance/{idUser}/add/{stamps}", headers, proxy, content);
            }
            catch (Exception e)
            {
                return _handler.HandleException(e);
            }
        }

        internal async override Task<BalanceResponse<string>> RemoveAsync(string idUser, int stamps, string comment)
        {
            var _handler = new BalanceResponseHandler<string>();
            try
            {
                Validation.ValidateHeaderParameters(Url, Token);
                Validation.ValidateGuid(idUser);
                Validation.validateValue(stamps);

                var headers = GetHeadersAsync();
                var content = this.RequestBalanceAsync(comment);
                var proxy = Helpers.RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                return await _handler.GetPostResponseAsync(this.Url,
                                $"management/api/balance/{idUser}/remove/{stamps}", headers, proxy, content);
            }
            catch (Exception e)
            {
                return _handler.HandleException(e);
            }
        }

        internal async override Task<BalanceResponse<Data>> BalanceAsync(string idUser)
        {
            var _handler = new BalanceResponseHandler<Data>();
            try
            {
                Validation.ValidateHeaderParameters(Url, Token);
                Validation.ValidateGuid(idUser);
             
                var headers = GetHeadersAsync();

                var proxy = Helpers.RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                return await _handler.GetResponseAsync(this.Url,
                                $"management/api/balance/{idUser}", headers, proxy);
            }
            catch (Exception e)
            {
                return _handler.HandleException(e);
            }
        }

        internal async override Task<BalanceResponse<Data>> BalanceTokenAsync()
        {
            var _handler = new BalanceResponseHandler<Data>();
            try
            {
                Validation.ValidateHeaderParameters(Url, Token);

                var headers = GetHeadersAsync();

                var proxy = Helpers.RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                return await _handler.GetResponseAsync(this.Url,
                                $"management/api/balance", headers, proxy);
            }
            catch (Exception e)
            {
                return _handler.HandleException(e);
            }
        }

        public async Task<BalanceResponse<string>> AddStampAsync(string idUser, int stamps, string comment = "Asignación de timbres.")
        {
            return await AddAsync(idUser, stamps, comment);
        }

        public async Task<BalanceResponse<string>> RemoveStampAsync(string idUser, int stamps, string comment = "Eliminacion de timbres.")
        {
            return await RemoveAsync(idUser, stamps, comment);
        }

        public async Task<BalanceResponse<Data>> GetBalanceByIdClienteAsync(string idUser)
        {
            return await BalanceAsync(idUser);
        }

        public async Task<BalanceResponse<Data>> GetBalanceByTokenAsync()
        {
            return await BalanceTokenAsync();
        }
    }
}

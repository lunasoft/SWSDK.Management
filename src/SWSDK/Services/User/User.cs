using SW.Helpers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SW.Services.User
{
    public class User : UserService
    {
        public User(string url, string token, int proxyPort = 0, string proxy = null)
            : base(url, token, proxy, proxyPort) { }

        internal async override Task<UserResponse<object>> CreateAsync<T>(T user)
        {
            var _handler = new UserResponseHandler<object>();
            try
            {
                Validation.ValidateHeaderParameters(Url, Token);
                var content = this.RequestUserAsync<T>(user);
                var headers = GetHeadersAsync();
                var proxy = Helpers.RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                return await _handler.GetPostResponseAsync(this.Url,
                                $"management/api/users", headers, proxy, content);
            }
            catch (Exception e)
            {
                return _handler.HandleException(e);
            }
        }

        internal async override Task<UserResponse<string>> UpdateAsync(UserUpdate user, string idUser)
        {
            var _handler = new UserResponseHandler<string>();
            try
            {
                Validation.ValidateHeaderParameters(Url, Token);
                Validation.ValidateGuid(idUser);
                var content = this.RequestUserAsync<UserUpdate>(user);
                var headers = GetHeadersAsync();
                var proxy = Helpers.RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                return await _handler.GetPutResponseAsync(this.Url,
                                $"management/api/users/{idUser}", headers, proxy, content);
            }
            catch (Exception e)
            {
                return _handler.HandleException(e);
            }
        }

        internal async override Task<UserResponse<List<Data>>> GetAllAsync(int page, int pageSize)
        {
            var _handler = new UserResponseHandler<List<Data>>();
            try
            {
                Validation.ValidateHeaderParameters(Url, Token);
                Validation.validateValue(page);
                Validation.validateValue(page);

                var headers = GetHeadersAsync();
                var proxy = Helpers.RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                return await _handler.GetResponseAsync(this.Url,
                                $"management/api/users?page={page}&pageSize={pageSize}", headers, proxy);
            }
            catch (Exception e)
            {
                return _handler.HandleException(e);
            }
        }

        internal async override Task<UserResponse<Data>> GetByIdAsync(string idUser)
        {
            var _handler = new UserResponseHandler<Data>();
            try
            {
                Validation.ValidateHeaderParameters(Url, Token);
                Validation.ValidateGuid(idUser);
                var headers = GetHeadersAsync();
                var proxy = Helpers.RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                return await _handler.GetResponseAsync(this.Url,
                                $"management/api/users/{idUser}", headers, proxy);
            }
            catch (Exception e)
            {
                return _handler.HandleException(e);
            }
        }

        internal async override Task<UserResponse<Data>> GetByTokenAsync()
        {
            var _handler = new UserResponseHandler<Data>();
            try
            {
                Validation.ValidateHeaderParameters(Url, Token);

                var headers = GetHeadersAsync();
                var proxy = Helpers.RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                return await _handler.GetResponseAsync(this.Url,
                                $"management/api/users/info", headers, proxy);
            }
            catch (Exception e)
            {
                return _handler.HandleException(e);
            }
        }

        internal async override Task<UserResponse<string>> DeleteAsync(string idUser)
        {
            var _handler = new UserResponseHandler<string>();
            try
            {
                Validation.ValidateHeaderParameters(Url, Token);
                Validation.ValidateGuid(idUser);

                var headers = GetHeadersAsync();
                var proxy = Helpers.RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                return await _handler.GetDeleteAsync(this.Url,
                                $"management/api/users/{idUser}", headers, proxy);
            }
            catch (Exception e)
            {
                return _handler.HandleException(e);
            }
        }

        public async Task<UserResponse<object>> CreateStampUSerAsync(UserStamp user)
        {
            return await CreateAsync<UserStamp>(user);
        }

        public async Task<UserResponse<object>> CreateUnlimitUSerAsync(UserUnlimit user)
        {
            return await CreateAsync<UserUnlimit>(user);
        }

        public async Task<UserResponse<string>> DeleteUserAsync(string idUser)
        {
            return await DeleteAsync(idUser);
        }

        public async Task<UserResponse<string>> UpdateUserAsync(UserUpdate user, string idUser)
        {
            return await UpdateAsync(user, idUser);
        }

        public async Task<UserResponse<List<Data>>> GetAllUserAsync(int page = 1, int pageSize = 5)
        {
            return await GetAllAsync(page, pageSize);
        }

        public async Task<UserResponse<Data>> GetByIdUserAsync(string idUser)
        {
            return await GetByIdAsync(idUser);
        }

        public async Task<UserResponse<Data>> GetByTokenUserAsync()
        {
            return await GetByTokenAsync();
        }
    }
}

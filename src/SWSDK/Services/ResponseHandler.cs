using Newtonsoft.Json;
using SW.Entities;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace SW.Services
{
    internal abstract class ResponseHandler<T>
        where T : Response, new()
    {
        public ResponseHandler() { }
        
        public virtual async Task<T> GetPostResponseAsync(string url, string path, Dictionary<string, string> headers, HttpClientHandler proxy, HttpContent content = null)
        {
            try
            {
                using (HttpClient client = new HttpClient(proxy))
                {
                    client.BaseAddress = new Uri(url);
                    foreach (var header in headers)
                    {
                        client.DefaultRequestHeaders.Add(header.Key, header.Value);
                    }
                    var result = await client.PostAsync(path, content);
                    return await TryGetResponseAsync(result);
                }
            }
            catch (HttpRequestException wex)
            {
                return new T()
                {
                    message = wex.Message,
                    status = "error",
                    messageDetail = wex.StackTrace
                };
            }
        }
        
        public virtual async Task<T> GetPutResponseAsync(string url, string path, Dictionary<string, string> headers, HttpClientHandler proxy, HttpContent content = null)
        {
            try
            {
                using (HttpClient client = new HttpClient(proxy))
                {
                    client.BaseAddress = new Uri(url);
                    foreach (var header in headers)
                    {
                        client.DefaultRequestHeaders.Add(header.Key, header.Value);
                    }
                    var result = await client.PutAsync(path, content);
                    return await TryGetResponseAsync(result);
                }
            }
            catch (HttpRequestException wex)
            {
                return new T()
                {
                    message = wex.Message,
                    status = "error",
                    messageDetail = wex.StackTrace
                };
            }
        }  
        
        public virtual async Task<T> GetResponseAsync(string url, string path, Dictionary<string, string> headers, HttpClientHandler proxy)
        {
            try
            {
                using (HttpClient client = new HttpClient(proxy))
                {
                    foreach (var header in headers)
                    {
                        client.DefaultRequestHeaders.Add(header.Key, header.Value);
                    }
                    client.BaseAddress = new Uri(url);
                    var result = await client.GetAsync(path);
                    return await TryGetResponseAsync(result);
                }
            }
            catch (HttpRequestException wex)
            {
                return new T()
                {
                    message = wex.Message,
                    status = "error",
                    messageDetail = wex.StackTrace
                };
            }
        }

        public virtual async Task<T> GetDeleteAsync(string url, string path, Dictionary<string, string> headers, HttpClientHandler proxy)
        {
            try
            {
                using (HttpClient client = new HttpClient(proxy))
                {
                    foreach (var header in headers)
                    {
                        client.DefaultRequestHeaders.Add(header.Key, header.Value);
                    }
                    client.BaseAddress = new Uri(url);
                    var result = await client.DeleteAsync(path);
                    return await TryGetResponseAsync(result);
                }
            }
            catch (HttpRequestException wex)
            {
                return new T()
                {
                    message = wex.Message,
                    status = "error",
                    messageDetail = wex.StackTrace
                };
            }
        }

        public abstract T HandleException(Exception ex);
        
        internal virtual async Task<T> TryGetResponseAsync(HttpResponseMessage response)
        {
            try
            {
                if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.BadRequest)
                {
                    return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
                }
                else
                    return new T()
                    {
                        message = ((int)response.StatusCode).ToString(),
                        status = "error",
                        messageDetail = response.ReasonPhrase
                    };
            }
            catch (Exception)
            {
                return new T()
                {
                    message = ((int)response.StatusCode).ToString(),
                    status = "error",
                    messageDetail = response.ReasonPhrase
                };
            }
        }
    }
}

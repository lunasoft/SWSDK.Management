using System;

namespace SW.Services
{
    public class Services
    {
        private string _token;
        private string _url;
        private string _proxy;
        private int _proxyPort;
        private DateTime _expirationDate;
        private int _timeSession = 2;
        public string Token
        {
            get { return _token; }
        }
        public string Url
        {
            get { return _url; }
        }
        public string Proxy
        {
            get { return _proxy; }
        }
        public int ProxyPort
        {
            get { return _proxyPort; }
        }
        public DateTime ExpirationDate
        {
            get { return _expirationDate;  }
        }
        public Services()
        {

        }
        public Services(string url, string token, string proxy, int proxyPort)
        {
            _url = Helpers.RequestHelper.NormalizeBaseUrl(url); ;
            _token = token;
            _expirationDate = DateTime.Now.AddYears(_timeSession);
            _proxy = proxy;
            _proxyPort = proxyPort;
        }
    }
}

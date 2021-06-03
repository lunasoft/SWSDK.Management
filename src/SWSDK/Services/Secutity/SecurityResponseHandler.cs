using SW.Helpers;
using System;

namespace SW.Services.Security
{
    internal class SecurityResponseHandler : ResponseHandler<SecurityResponse>
    {
        public override SecurityResponse HandleException(Exception ex)
        {
            return ex.Response<SecurityResponse>();
        }
    }
}

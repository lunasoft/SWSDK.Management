using SW.Helpers;
using System;

namespace SW.Services.Balance
{
    internal class BalanceResponseHandler<T> : ResponseHandler<BalanceResponse<T>> 
    {
        public override BalanceResponse<T> HandleException(Exception ex)
        {
            return ex.Response<BalanceResponse<T>>();
        }
    }
}

using SW.Helpers;
using System;

namespace SW.Services.User
{
    internal class UserResponseHandler<T> : ResponseHandler<UserResponse<T>>
    {
        public override UserResponse<T> HandleException(Exception ex)
        {
            return ex.Response<UserResponse<T>>();
        }
    }
}

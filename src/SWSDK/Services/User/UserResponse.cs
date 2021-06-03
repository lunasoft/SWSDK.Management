using Newtonsoft.Json;
using SW.Entities;
using System;
using System.Runtime.Serialization;

namespace SW.Services.User
{
    public  class UserResponse<T> : Response
    {
        public T data { get; set; }
    }
    public class Data
    {
        public int stamps { get; set; }
        public bool unlimited { get; set; }
        public string profileValue { get; set; }
        public string idUsuario { get; set; }
        public string idCliente { get; set; }
        public string nombre { get; set; }
        public string apellidoPaterno { get; set; }
        public string username { get; set; }
        public DateTime fechaUltimoPassword { get; set; }
        public string email { get; set; }
        public bool administrador { get; set; }
        public int profile { get; set; }
        public bool activo { get; set; }
        public DateTime registeredDate { get; set; }
        public bool eliminado { get; set; }
        public string tokenAccess { get; set; }
    }
}

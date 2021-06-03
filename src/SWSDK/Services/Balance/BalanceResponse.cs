using SW.Entities;
using System;
using System.Runtime.Serialization;

namespace SW.Services.Balance
{
    public class BalanceResponse<T> : Response
    {
        public T data { get; set; }
    }

    public class Data
    {
        public Guid idSaldoCliente { get; set; }
        public Guid idClienteUsuario { get; set; }
        public int saldoTimbres { get; set; }
        public int timbresUtilizados { get; set; }
        public DateTime? fechaExpiracion { get; set; }
        public bool unlimited { get; set; }
        public int timbresAsignados { get; set; }
    }
}

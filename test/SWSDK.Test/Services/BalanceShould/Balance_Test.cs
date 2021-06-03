using Xunit;
using SW.Services.Balance;
using Test_SW.Helpers;
using System;

namespace SWSDK.Test.Services.BalanceShould
{
    public class Balance_Test
    {
        private readonly BuildSettings _build;
        private static Guid IdCliente = Guid.Parse("e768f37a-8d55-4888-9934-57480dd081d1");

        public Balance_Test() =>_build = new BuildSettings();

        [Fact]
        public async void OK_AddStamps_Values()
        {
            string data = "1 timbres correctamente agregados al usuario e768f37a-8d55-4888-9934-57480dd081d1";
            Balance balance = new Balance(_build.Url, _build.Token);

            var result = await balance.AddStampAsync(IdCliente.ToString(), 1, "Compra de timbre");
           
            Assert.Equal(result.data, data);
        }

        [Fact]
        public async void Error_AddStamps_Values()
        {
            string message = "Usuario no pertenece al Dealer";
            Balance balance = new Balance(_build.Url, _build.Token);

            var result = await balance.AddStampAsync("474a00ae-576d-4e79-babe-1c276ded66a4", 1, "Compra de timbre");

            Assert.Equal(result.messageDetail, message);
        }

        [Fact]
        public async void OK_RemoveStamps_Values()
        {
            string data =  "1 timbres correctamente removidos al usuario e768f37a-8d55-4888-9934-57480dd081d1";
            Balance balance = new Balance(_build.Url, _build.Token);

            var result = await balance.RemoveStampAsync(IdCliente.ToString(), 1, "Se elimina timbre");

            Assert.Equal(result.data, data);
        }

        [Fact]
        public async void Error_RemoveStamps_Values()
        {
            string message = "Usuario no pertenece al Dealer";
            Balance balance = new Balance(_build.Url, _build.Token);

            var result = await balance.RemoveStampAsync("474a00ae-576d-4e79-babe-1c276ded66a4", 1, "Se elimina timbre");

            Assert.Equal(result.message, message);
        }

        [Fact]
        public async void OK_GetBalanceById_Values()
        {
            Balance balance = new Balance(_build.Url, _build.Token);

            var result = await balance.GetBalanceByIdClienteAsync(IdCliente.ToString());

            Assert.Equal(result.data.idClienteUsuario, IdCliente);
        }

        [Fact]
        public async void OK_GetBalanceByToken_Values()
        {
            string idClienteToken = "e5fd9556-fdf5-4597-8daf-4c73cf3d0d30";
            Balance balance = new Balance(_build.Url, _build.Token);

            var result = await balance.GetBalanceByTokenAsync();

            Assert.Equal(result.data.idClienteUsuario, Guid.Parse(idClienteToken));
        }
    }
}

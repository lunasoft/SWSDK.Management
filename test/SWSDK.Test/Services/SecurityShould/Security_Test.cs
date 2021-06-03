using Xunit;
using SW.Services.Security;
using Test_SW.Helpers;

namespace SWSDK.Test.Services.SecurityShould
{
    public class Security_Test
    {
        private readonly BuildSettings _build;

        public Security_Test() => _build = new BuildSettings();

        [Fact]
        public async void OK_ResetPassword()
        {
            var resultExpect = "Contraseña modificada exitosamente.";
            Security security = new Security(_build.Url, _build.Token);

            var result = await security.PasswordRecoveryAsync("e768f37a-8d55-4888-9934-57480dd081d1", "NewPassword");

            Assert.Equal(result.data, resultExpect);
        }

        [Fact]
        public async void OK_ResetToken()
        {
            var resultExpect = "Token regenerado exitosamente."; 
            Security security = new Security(_build.Url, _build.Token);

            var result = await security.TokenResetAsync("e768f37a-8d55-4888-9934-57480dd081d1");

            Assert.Equal(result.data, resultExpect);
        }

        [Fact]
        public async void NotFound_ResetToken()
        {
            var resultExpect = "Usuario no pertenece al dealer.";
            Security security = new Security(_build.Url, _build.Token);

            var result = await security.TokenResetAsync("e768f37a-8d55-4888-9934-57480dd081d2");

            Assert.Equal(result.messageDetail, resultExpect);
        }

        [Fact]
        public async void NotFound_ResetPassword()
        {
            var resultExpect = "Usuario no pertenece al Dealer.";
            Security security = new Security(_build.Url, _build.Token);

            var result = await security.PasswordRecoveryAsync("e768f37a-8d55-4888-9934-57480dd081d2", "NewPassword");

            Assert.Equal(result.messageDetail, resultExpect);
        }
    }
}
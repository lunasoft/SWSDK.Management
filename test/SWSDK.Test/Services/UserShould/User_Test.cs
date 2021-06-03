using SW.Services.User;
using System;
using Test_SW.Helpers;
using Xunit;

namespace SWSDK.Test.Services.UserShould
{
    public class User_Test
    {
        private readonly BuildSettings _build;

        public User_Test() => _build = new BuildSettings();

        [Fact(Skip = "Activar y desactivar constantemente el usuario")]
        public async void OK_Delete_User()
        {
            User user = new User(_build.Url, _build.Token);
            var result = await user.DeleteUserAsync("8e675107-8250-4e09-885b-61688d90d7b0");
            Assert.Contains("success", result.status);
        }

        [Fact]
        public async void OK_Create_Stamp_User()
        {
            User user = new User(_build.Url, _build.Token);
            var userObj = new UserStamp()
            {
                Email = $"{Guid.NewGuid()}@gmawil.com",
                Name = "demo",
                Password = "swpass",
                RFC = "XIA190128J61",
                Stamps = 10,
            };

            var result = await user.CreateStampUSerAsync(userObj);

            Assert.Contains("success", result.status);
        }

        [Fact]
        public async void OK_UPDATE_User()
        {
            var resultExpect = "Actualizado exitosamente";
            User user = new User(_build.Url, _build.Token);

            UserUpdate userObj = new UserUpdate()
            {
                Name = "demo",
                RFC = "XIA190128J61",
                Unlimited = false,
                Active = true
            };
            var result = await user.UpdateUserAsync(userObj, "e768f37a-8d55-4888-9934-57480dd081d1");

            Assert.Equal(result.data, resultExpect);
        }

        [Fact]
        public async void OK_Create_Unlimit_User()
        {
            User user = new User(_build.Url, _build.Token);
            var userObj = new UserUnlimit()
            {
                Email = $"{Guid.NewGuid()}@gmawil.com",
                Name = "demo",
                Password = "swpass",
                RFC = "XIA190128J61",
                Unlimited = true
            };

            var result = await user.CreateUnlimitUSerAsync(userObj);

            Assert.Contains("success", result.status);
        }

        [Fact]
        public async void OK_GET_By_Id_User()
        {
            var resultExpect = "OTtewwwst1@gmawil.com";
            User user = new User(_build.Url, _build.Token);

            var result = await user.GetByIdUserAsync("e768f37a-8d55-4888-9934-57480dd081d1");

            Assert.Equal(result.data.username, resultExpect);
        }

        [Fact]
        public async void OK_GET_All_User()
        {
            User user = new User(_build.Url, _build.Token);

            var result = await user.GetAllUserAsync(1,50);

            Assert.True(result.data.Count > 0);
        }

        [Fact]
        public async void _GET_Token_User()
        {
            var resultExpect = "userforut@ut.com";
            User user = new User(_build.Url, _build.Token);

            var result = await user.GetByTokenUserAsync();

            Assert.Contains(result.data.email, resultExpect);
        }

        [Fact]
        public async void Unauthorized_GET_Token_User()
        {
            var resultExpect = "Unauthorized";
            User user = new User(_build.Url, _build.Token+"Fake");

            var result = await user.GetByTokenUserAsync();

            Assert.Equal(result.messageDetail, resultExpect);
        }

        [Fact]
        public async void Notfound_UPDATE_User()
        {
            var resultExpect = "No se encuentra registro de usuario";
            User user = new User(_build.Url, _build.Token);
            UserUpdate userObj = new UserUpdate()
            {
                Name = "demo",
                RFC = "XIA190128J61",
                Unlimited = false,
                Active = true
            };

            var result = await user.UpdateUserAsync(userObj, "e768f37a-8d55-4888-9934-57480dd081d2");

            Assert.Equal(result.message, resultExpect);
        }

        [Fact]
        public async void Exist_Create_Stamp_User()
        {
            var resultExpect = "AU1001Usuario ya existe.";
            User user = new User(_build.Url, _build.Token);
            var userObj = new UserStamp()
            {
                Email = "OTtest1@gmawil.com",
                Name = "demo",
                Password = "swpass",
                RFC = "XIA190128J61",
                Stamps = 10,
            };

            var result = await user.CreateStampUSerAsync(userObj);

            Assert.Contains(result.message, resultExpect);
        }

        [Fact]
        public async void Notfound_Delete_User()
        {
            var resultExpect = "No se encuentra registro de usuario";
            User user = new User(_build.Url, _build.Token);

            var result = await user.DeleteUserAsync("e768f37a-8d55-4888-9934-57480dd081d2");

            Assert.Equal(result.message, resultExpect);
        }

        [Fact]
        public async void Notfound_GET_By_Id_User()
        {
            var resultExpect = "No se encuentra registro de usuario";
            User user = new User(_build.Url, _build.Token);

            var result = await user.GetByIdUserAsync("e768f37a-8d55-4888-9934-57480dd081d3");

            Assert.Equal(result.message, resultExpect);
        }
    }
}

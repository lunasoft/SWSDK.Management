using Xunit;
using SW.Helpers;

namespace SWSDK.Test
{
    public class UnitTestMethods
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void NullOrEmpty_String_Values(string value)
        {
           Assert.Throws<ServicesException>(() => Validation.validateValue(value));
        }

        [Theory]
        [InlineData(default(int))]
        [InlineData(0)]
        public void NullOrEmpty_Int_Values(int value)
        {
            Assert.Throws<ServicesException>(() => Validation.validateValue(value));
        }

        [Theory]
        [InlineData("Demo Value")]
        [InlineData("demo2")]
        public void OK_String_Values(string value)
        {
            var exception = Record.Exception(() => Validation.validateValue(value));
            Assert.Null(exception);   
        }

        [Theory]
        [InlineData(10)]
        [InlineData(500000)]
        public void Ok_Int_Values(int value)
        {
            var exception = Record.Exception(() => Validation.validateValue(value));
            Assert.Null(exception);
        }

        [Theory]
        [InlineData("da544de9-fac4-488c-9921-155b969c5688")]
        [InlineData("20cb177b-44d2-442d-a756-db2c4ab56da5")]
        public void Ok_GUID_Values(string value)
        {
            var exception = Record.Exception(() => Validation.ValidateGuid(value));
            Assert.Null(exception);
        }

        [Theory]
        [InlineData("da544de9-fac4-488c-9921-155b969c56881")]
        [InlineData("da544de9-fac4-488c-9921-155b969c56881a")]
        public void Error_GUID_Values(string value)
        {
            Assert.Throws<ServicesException>(() => Validation.ValidateGuid(value));
        }

        [Theory]
        [InlineData("da544de9-fac4-488c-9921-155b969c56881")]
        [InlineData("da544de9-fac4-488c-9921-155b969c56881a")]
        public void Retun_T_Type(string value)
        {
            Assert.Throws<ServicesException>(() => Validation.ValidateGuid(value));
        }
    }
}

using Core.Requests;
using Core.RequestValidations.FluentValidations;

namespace Tests.CoreTests.ValidationTests
{
    public class RegistartionValidatorTests
    {
        [Fact]
        public void Valid_Request_Should_Have_0_Errors()
        {
            var validPassword = "Password123$";

            var request = new RegistrationRequest()
            {
                Email = "lshen20@freeuni.edu.ge",
                Username = "levani",
                Password = validPassword,
                ConfirmedPassword = validPassword,
            };

            var result = new RegistrationValidator().Validate(request);

            Assert.Empty(result.Errors);
        }

        [Theory]
        [InlineData("")]
        [InlineData("bla")]
        [InlineData("@Llekjfa.gmail.com")]
        [InlineData("g.gmail.com")]
        [InlineData("levani@")]
        public void Request_With_Invalid_Email_Should_Fail_To_Validate(string email)
        {
            var validPassword = "Password123$";

            var request = new RegistrationRequest()
            {
                Email = email,
                Password = validPassword,
                ConfirmedPassword = validPassword,
                Username = "levani",
            };

            var result = new RegistrationValidator().Validate(request);

            Assert.NotEmpty(result.Errors);
        }

        [Fact]
        public void Request_With_Empty_Username_Should_Fail_To_Validate()
        {
            var validPassword = "Password123$";

            var request = new RegistrationRequest()
            {
                Email = "lshen20@freeuni.edu.ge",
                Password = validPassword,
                ConfirmedPassword = validPassword,
                Username = "",
            };

            var result = new RegistrationValidator().Validate(request);

            Assert.NotEmpty(result.Errors);
        }

        [Fact]
        public void Request_Should_Fail_To_Validate_When_Passwords_Dont_Match()
        {
            var request = new RegistrationRequest()
            {
                Email = "lshen20@freeuni.edu.ge",
                Password = "Password123#",
                ConfirmedPassword = "Password234#",
                Username = "levani",
            };

            var result = new RegistrationValidator().Validate(request);

            Assert.NotEmpty(result.Errors);
        }

        [Theory]
        [InlineData("")]
        [InlineData("bla")]
        [InlineData("blaasfdfasdfas")]
        [InlineData("BlaBALKSDJwre")]
        [InlineData("levani12314")]
        [InlineData("levani%%#$#@")]
        [InlineData("Le21$#")]
        public void Request_With_Invalid_Password_Should_Fail_To_Validate(string password)
        {
            var request = new RegistrationRequest()
            {
                Email = "lshen20@freeuni.edu.ge",
                Password = password,
                ConfirmedPassword = password,
                Username = "levani",
            };

            var result = new RegistrationValidator().Validate(request);

            Assert.NotEmpty(result.Errors);
        }
    }
}
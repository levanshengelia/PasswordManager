using Core.Requests;
using Core.RequestValidations.FluentValidations;

namespace Tests.CoreTests.ValidationTests
{
    public class LoginValidatorTests
    {
        [Fact]
        public void Request_With_Non_Empty_Fields_Should_Have_0_Errors()
        {
            var request = new LoginRequest()
            {
                Username = "test",
                Password = "test",
            };

            var result = new LoginValidator().Validate(request);

            Assert.Empty(result.Errors);
        }

        [Fact]
        public void Request_With_Empty_Field_Should_Have_Error()
        {
            var validator = new LoginValidator();
            
            var requestWithoutPassword = new LoginRequest()
            {
                Username = "test",
            };

            var result1 = new LoginValidator().Validate(requestWithoutPassword);

            Assert.Single(result1.Errors);
            
            var requestWithoutUsername = new LoginRequest()
            {
                Password = "test",
            };

            var result2 = new LoginValidator().Validate(requestWithoutUsername);

            Assert.Single(result2.Errors);

            var emptyRequest = new LoginRequest();

            var result3 = new LoginValidator().Validate(emptyRequest);

            Assert.Equal(2, result3.Errors.Count);
        }
    }
}

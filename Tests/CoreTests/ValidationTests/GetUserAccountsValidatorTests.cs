using Core.Requests_Handlers;
using Core.Requests_Handlers.Validations.FluentValidations;

namespace Tests.CoreTests.ValidationTests
{
    public class GetUserAccountsValidatorTests
    {
        [Fact]
        public void Request_With_Null_Or_Empty_Token_Should_Fail_To_Validate()
        {
            var requestWithNullToken = new GetUserAccountsRequest()
            {
                Token = null!,
            };

            var result1 = new GetUserAccountsValidator().Validate(requestWithNullToken);

            Assert.NotEmpty(result1.Errors);

            var requestWithEmptyToken = new GetUserAccountsRequest()
            {
                Token = ""
            };

            var result2 = new GetUserAccountsValidator().Validate(requestWithEmptyToken);

            Assert.NotEmpty(result2.Errors);
        }

        [Fact]
        public void Request_With_Non_Empty_Token_Should_Validate_Successfully()
        {
            var request = new GetUserAccountsRequest()
            {
                Token = "TOKEN"
            };

            var result = new GetUserAccountsValidator().Validate(request);

            Assert.Empty(result.Errors);
        }
    }
}

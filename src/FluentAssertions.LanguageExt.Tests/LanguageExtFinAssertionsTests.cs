using LanguageExt;
using LanguageExt.Common;
using Xunit;
using Xunit.Sdk;
using static LanguageExt.Prelude;

namespace FluentAssertions.LanguageExt.Tests
{
    public class LanguageExtFinAssertionsTests
    {
        private static Fin<int> SuccessFin => FinSucc(1);
        private static Fin<int> FailureFin => FinFail<int>("Error msg");
        private static Fin<int> BottomFin => FinFail<int>(default);

        [Fact]
        public void Be_with_expected_Success_returns_expected_result()
        {
            var action = () => SuccessFin.Should().Be(1);

            action.Should().NotThrow();
        }

        [Fact]
        public void Be_with_unexpected_Success_returns_expected_result()
        {
            var action = () => SuccessFin.Should().Be(999);

            action.Should().Throw<XunitException>();
        }

        [Fact]
        public void Be_with_Fail_returns_expected_result()
        {
            var action = () => FailureFin.Should().Be(1);

            action.Should().Throw<XunitException>();
        }

        [Fact]
        public void BeSuccess_with_Success_returns_expected_result()
        {
            var action = () => SuccessFin.Should().BeSuccess();
            
            action.Should().NotThrow();
        }

        [Fact]
        public void BeSuccess_with_Fail_returns_expected_result()
        {
            var action = () => FailureFin.Should().BeSuccess();

            action.Should().Throw<XunitException>();
        }

        [Fact]
        public void BeSuccess_with_Bottom_returns_expected_result()
        {
            var action = () => BottomFin.Should().BeSuccess();

            action.Should().Throw<XunitException>();
        }

        [Fact]
        public void BeSuccess_with_expected_Success_returns_expected_result()
        {
            var action = () => SuccessFin.Should().BeSuccess(s => s.Should().Be(1));

            action.Should().NotThrow();
        }

        [Fact]
        public void BeSuccess_with_unexpected_Success_returns_expected_result()
        {
            var action = () => SuccessFin.Should().BeSuccess(s => s.Should().Be(999));

            action.Should().Throw<XunitException>();
        }

        [Fact]
        public void BeSuccess_with_expected_Success_using_which_returns_expected_result()
        {
            var action = () => SuccessFin.Should().BeSuccess().Which.Should().Be(1);

            action.Should().NotThrow();
        }

        [Fact]
        public void BeSuccess_with_unexpected_Success_using_which_returns_expected_result()
        {
            var action = () => SuccessFin.Should().BeSuccess().Which.Should().Be(999);

            action.Should().Throw<XunitException>();
        }

        [Fact]
        public void BeFail_with_Success_returns_expected_result()
        {
            var action = () => SuccessFin.Should().BeFail();

            action.Should().Throw<XunitException>();
        }

        [Fact]
        public void BeFail_with_Error_returns_expected_result()
        {
            var action = () => FailureFin.Should().BeFail();

            action.Should().NotThrow();
        }

        [Fact]
        public void BeFail_with_expected_Error_returns_expected_result()
        {
            var action = () => FailureFin.Should().BeFail().Which.Message.Should().Be("Error msg");

            action.Should().NotThrow();
        }

        [Fact]
        public void BeFail_with_unexpected_Error_returns_expected_result()
        {
            var action = () => FailureFin.Should().BeFail().Which.Message.Should().Be("Not correct msg");

            action.Should().Throw<XunitException>();
        }

        [Fact]
        public void BeBottom_with_Bottom_returns_expected_result()
        {
            var action = () => BottomFin.Should().BeBottom();

            action.Should().NotThrow();
        }

        [Fact]
        public void BeBottom_with_Success_returns_expected_result()
        {
            var action = () => SuccessFin.Should().BeBottom();

            action.Should().Throw<XunitException>();
        }

        [Fact]
        public void BeBottom_with_Failure_returns_expected_result()
        {
            var action = () => FailureFin.Should().BeBottom();

            action.Should().Throw<XunitException>();
        }

        [Fact]
        public void BeFail_Should_Not_Throw_Missing_Method_Exception()
        {
            var action = () => FinFail<int>(Error.New("")).Should().BeFail();
            action.Should().NotThrow();
        }
    }
}

using LanguageExt;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.LanguageExt.Tests;

public class LanguageExtValidationAssertionsTest
{
    private static Validation<int, string> SuccessResult() => "abc";
    private static Validation<int, string> FailResult() => 123;

    [Fact]
    public void BeFail_with_Fail_returns_expected_result()
    {
        var action = () => FailResult().Should().BeFail();

        action.Should().NotThrow();
    }

    [Fact]
    public void BeFail_with_Success_returns_expected_result()
    {
        var action = () => SuccessResult().Should().BeFail();

        action.Should().Throw<XunitException>();
    }

    [Fact]
    public void BeSuccess_with_Fail_returns_expected_result()
    {
        var action = () => FailResult().Should().BeSuccess();

        action.Should().Throw<XunitException>();
    }

    [Fact]
    public void BeSuccess_with_Success_returns_expected_result()
    {
        var action = () => SuccessResult().Should().BeSuccess();

        action.Should().NotThrow();
    }
}
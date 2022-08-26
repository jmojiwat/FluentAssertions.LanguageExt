using System;
using LanguageExt;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.LanguageExt.Tests;

public class LanguageExtTryAssertionsTest
{
    private static Try<string> SuccessResult() => () => "success";
    private static Try<string> FailResult() => () => throw new Exception();

    [Fact]
    public void BeSuccess_with_Success_returns_expected_result()
    {
        var action = () => SuccessResult().Should().BeSuccess();

        action.Should().NotThrow();
    }

    [Fact]
    public void BeSuccess_with_Exception_returns_expected_result()
    {
        var action = () => FailResult().Should().BeSuccess();

        action.Should().Throw<XunitException>();
    }

    [Fact]
    public void BeSuccess_with_expected_Success_returns_expected_result()
    {
        var action = () => SuccessResult().Should().BeSuccess(s => s.Should().Be("success"));

        action.Should().NotThrow();
    }

    [Fact]
    public void BeSuccess_with_unexpected_Success_returns_expected_result()
    {
        var action = () => SuccessResult().Should().BeSuccess(s => s.Should().Be("fail"));

        action.Should().Throw<XunitException>();
    }

    [Fact]
    public void BeSuccess_with_expected_Success_using_which_returns_expected_result()
    {
        var action = () => SuccessResult().Should().BeSuccess().Which.Should().Be("success");

        action.Should().NotThrow();
    }

    [Fact]
    public void BeSuccess_with_unexpected_Success_using_which_returns_expected_result()
    {
        var action = () => SuccessResult().Should().BeSuccess().Which.Should().Be("fail");

        action.Should().Throw<XunitException>();
    }

    [Fact]
    public void BeFail_with_Success_returns_expected_result()
    {
        var action = () => SuccessResult().Should().BeFail();

        action.Should().Throw<XunitException>();
    }

    [Fact]
    public void BeFail_with_Exception_returns_expected_result()
    {
        var action = () => FailResult().Should().BeFail();

        action.Should().NotThrow();
    }

    [Fact]
    public void BeFail_with_expected_Exception_returns_expected_result()
    {
        var action = () => FailResult().Should().BeFail().Which.Should().BeOfType<Exception>();

        action.Should().NotThrow();
    }

    [Fact]
    public void BeFail_with_unexpected_Exception_returns_expected_result()
    {
        var action = () => FailResult().Should().BeFail().Which.Should().BeOfType<ArgumentException>();

        action.Should().Throw<XunitException>();
    }

    [Fact]
    public void Be_with_expected_Success_returns_expected_result()
    {
        var action = () => SuccessResult().Should().Be("success");

        action.Should().NotThrow();
    }

    [Fact]
    public void Be_with_unexpected_Success_returns_expected_result()
    {
        var action = () => SuccessResult().Should().Be("fail");

        action.Should().Throw<XunitException>();
    }

    [Fact]
    public void Be_with_Fail_returns_expected_result()
    {
        var action = () => FailResult().Should().Be("fail");

        action.Should().Throw<XunitException>();
    }
}
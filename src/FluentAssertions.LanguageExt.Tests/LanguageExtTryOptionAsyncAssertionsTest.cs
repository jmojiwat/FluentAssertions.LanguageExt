using System;
using LanguageExt;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.LanguageExt.Tests;

public class LanguageExtTryOptionAsyncAssertionsTest
{
    private static TryOptionAsync<int> FailResult() => () => throw new Exception();
    private static TryOptionAsync<int> SomeResult() => async () => await Prelude.Some(8).AsTask();
    private static TryOptionAsync<int> NoneResult() => async () => await Option<int>.None.AsTask();

    [Fact]
    public void BeSome_with_Some_returns_expected_result()
    {
        var action = () => SomeResult().Should().BeSome();

        action.Should().NotThrow();
    }

    [Fact]
    public void BeSome_with_None_returns_expected_result()
    {
        var action = () => NoneResult().Should().BeSome();

        action.Should().Throw<XunitException>();
    }

    [Fact]
    public void BeSome_with_Fail_returns_expected_result()
    {
        var action = () => FailResult().Should().BeSome();

        action.Should().Throw<XunitException>();
    }

    [Fact]
    public void BeSome_with_expected_Some_returns_expected_result()
    {
        var action = () => SomeResult().Should().BeSome(s => s.Should().Be(8));

        action.Should().NotThrow();
    }

    [Fact]
    public void BeSome_with_unexpected_Some_returns_expected_result()
    {
        var action = () => SomeResult().Should().BeSome(s => s.Should().Be(4));

        action.Should().Throw<XunitException>();
    }

    [Fact]
    public void BeSome_with_expected_Some_using_which_returns_expected_result()
    {
        var action = () => SomeResult().Should().BeSome().Which.Should().Be(8);

        action.Should().NotThrow();
    }

    [Fact]
    public void BeSome_with_unexpected_Some_using_which_returns_expected_result()
    {
        var action = () => SomeResult().Should().BeSome().Which.Should().Be(4);

        action.Should().Throw<XunitException>();
    }

    [Fact]
    public void BeNone_with_Some_returns_expected_result()
    {
        var action = () => SomeResult().Should().BeNone();

        action.Should().Throw<XunitException>();
    }

    [Fact]
    public void BeNone_with_None_returns_expected_result()
    {
        var action = () => NoneResult().Should().BeNone();

        action.Should().NotThrow();
    }

    [Fact]
    public void BeNone_with_Fail_returns_expected_result()
    {
        var action = () => FailResult().Should().BeNone();

        action.Should().Throw<XunitException>();
    }

    [Fact]
    public void BeNoneOrFail_with_Some_returns_expected_result()
    {
        var action = () => SomeResult().Should().BeNoneOrFail();

        action.Should().Throw<XunitException>();
    }

    [Fact]
    public void BeNoneOrFail_with_None_returns_expected_result()
    {
        var action = () => NoneResult().Should().BeNoneOrFail();

        action.Should().NotThrow();
    }

    [Fact]
    public void BeNoneOrFail_with_Fail_returns_expected_result()
    {
        var action = () => FailResult().Should().BeNoneOrFail();

        action.Should().NotThrow();
    }

    [Fact]
    public void BeFail_with_Some_returns_expected_result()
    {
        var action = () => SomeResult().Should().BeFail();

        action.Should().Throw<XunitException>();
    }

    [Fact]
    public void BeFail_with_None_returns_expected_result()
    {
        var action = () => NoneResult().Should().BeFail();

        action.Should().Throw<XunitException>();
    }

    [Fact]
    public void BeFail_with_Fail_returns_expected_result()
    {
        var action = () => FailResult().Should().BeFail();

        action.Should().NotThrow();
    }

    [Fact]
    public void BeFail_with_expected_Fail_returns_expected_result()
    {
        var action = () => FailResult().Should().BeFail().Which.Should().BeOfType<Exception>();

        action.Should().NotThrow();
    }

    [Fact]
    public void BeFail_with_unexpected_Fail_returns_expected_result()
    {
        var action = () => FailResult().Should().BeFail().Which.Should().BeOfType<ArgumentException>();

        action.Should().Throw<XunitException>();
    }

    [Fact]
    public void Be_with_expected_Some_returns_expected_result()
    {
        var action = () => SomeResult().Should().Be(8);

        action.Should().NotThrow();
    }

    [Fact]
    public void Be_with_unexpected_Some_returns_expected_result()
    {
        var action = () => SomeResult().Should().Be(4);

        action.Should().Throw<XunitException>();
    }

    [Fact]
    public void Be_with_None_returns_expected_result()
    {
        var action = () => NoneResult().Should().Be(8);

        action.Should().Throw<XunitException>();
    }

    [Fact]
    public void Be_with_Fail_returns_expected_result()
    {
        var action = () => FailResult().Should().Be(4);

        action.Should().Throw<XunitException>();
    }
}
using System;
using LanguageExt;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.LanguageExt.Tests;

public class LanguageExtTryOptionAsyncAssertionsTest
{
    private static TryOptionAsync<int> FailResult() => () => throw new Exception();
    private static TryOptionAsync<int> SomeResult() => async () => await Prelude.Some(123).AsTask();
    private static TryOptionAsync<int> NoneResult() => async () => await Option<int>.None.AsTask();

    [Fact]
    public void ShouldBeSome_with_Some_returns_expected_result()
    {
        var action = () => SomeResult().Should().BeSome();

        action.Should().NotThrow();
    }

    [Fact]
    public void ShouldBeSome_with_None_returns_expected_result()
    {
        var action = () => NoneResult().Should().BeSome();

        action.Should().Throw<XunitException>();
    }

    [Fact]
    public void ShouldBeSome_with_Fail_returns_expected_result()
    {
        var action = () => FailResult().Should().BeSome();

        action.Should().Throw<XunitException>();
    }

    [Fact]
    public void ShouldBeNone_with_Some_returns_expected_result()
    {
        var action = () => SomeResult().Should().BeNone();

        action.Should().Throw<XunitException>();
    }

    [Fact]
    public void ShouldBeNone_with_None_returns_expected_result()
    {
        var action = () => NoneResult().Should().BeNone();

        action.Should().NotThrow();
    }

    [Fact]
    public void ShouldBeNone_with_Fail_returns_expected_result()
    {
        var action = () => FailResult().Should().BeNone();

        action.Should().Throw<XunitException>();
    }

    [Fact]
    public void ShouldBeFail_with_Some_returns_expected_result()
    {
        var action = () => SomeResult().Should().BeFail();

        action.Should().Throw<XunitException>();
    }

    [Fact]
    public void ShouldBeFail_with_None_returns_expected_result()
    {
        var action = () => NoneResult().Should().BeFail();

        action.Should().Throw<XunitException>();
    }

    [Fact]
    public void ShouldBeFail_with_Fail_returns_expected_result()
    {
        var action = () => FailResult().Should().BeFail();

        action.Should().NotThrow();
    }
}
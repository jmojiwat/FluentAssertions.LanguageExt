using LanguageExt;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.LanguageExt.Tests;

public class LanguageExtOptionBoolAssertionsTest
{
    private static Option<bool> SomeTrueResult() => Prelude.Some(true);
    private static Option<bool> SomeFalseResult() => Prelude.Some(false);
    private static Option<bool> NoneResult() => Option<bool>.None;

    [Fact]
    public void BeTrue_with_expected_Some_returns_expected_result()
    {
        var action = () => SomeTrueResult().Should().BeTrue();

        action.Should().NotThrow();
    }

    [Fact]
    public void BeTrue_with_unexpected_Some_returns_expected_result()
    {
        var action = () => SomeFalseResult().Should().BeTrue();

        action.Should().Throw<XunitException>();
    }

    [Fact]
    public void BeTrue_with_None_returns_expected_result()
    {
        var action = () => NoneResult().Should().BeNone();

        action.Should().NotThrow();
    }

    [Fact]
    public void BeFalse_with_expected_Some_returns_expected_result()
    {
        var action = () => SomeFalseResult().Should().BeFalse();

        action.Should().NotThrow();
    }

    [Fact]
    public void BeFalse_with_unexpected_Some_returns_expected_result()
    {
        var action = () => SomeTrueResult().Should().BeFalse();

        action.Should().Throw<XunitException>();
    }

    [Fact]
    public void BeFalse_with_None_returns_expected_result()
    {
        var action = () => NoneResult().Should().BeFalse();

        action.Should().Throw<XunitException>();
    }

    [Fact]
    public void BeSome_with_Some_returns_expected_result()
    {
        var action = () => SomeTrueResult().Should().BeSome();

        action.Should().NotThrow();
    }

    [Fact]
    public void BeSome_with_None_returns_expected_result()
    {
        var action = () => NoneResult().Should().BeSome();

        action.Should().Throw<XunitException>();
    }

    [Fact]
    public void BeNone_with_Some_returns_expected_result()
    {
        var action = () => SomeTrueResult().Should().BeNone();

        action.Should().Throw<XunitException>();
    }

    [Fact]
    public void BeNone_with_None_returns_expected_result()
    {
        var action = () => NoneResult().Should().BeNone();

        action.Should().NotThrow();
    }


}
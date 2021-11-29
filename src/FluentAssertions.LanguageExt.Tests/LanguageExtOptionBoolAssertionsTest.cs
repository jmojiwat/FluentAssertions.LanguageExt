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
    public void ShouldBeSomeTrue_with_expected_Some_returns_expected_result()
    {
        var action = () => SomeTrueResult().Should().BeSomeTrue();

        action.Should().NotThrow();
    }

    [Fact]
    public void ShouldBeSomeTrue_with_unexpected_Some_returns_expected_result()
    {
        var action = () => SomeFalseResult().Should().BeSomeTrue();

        action.Should().Throw<XunitException>();
    }

    [Fact]
    public void ShouldBeSomeTrue_with_None_returns_expected_result()
    {
        var action = () => NoneResult().Should().BeNone();

        action.Should().NotThrow();
    }

    [Fact]
    public void ShouldBeSomeFalse_with_expected_Some_returns_expected_result()
    {
        var action = () => SomeFalseResult().Should().BeSomeFalse();

        action.Should().NotThrow();
    }

    [Fact]
    public void ShouldBeSomeFalse_with_unexpected_Some_returns_expected_result()
    {
        var action = () => SomeTrueResult().Should().BeSomeFalse();

        action.Should().Throw<XunitException>();
    }

    [Fact]
    public void ShouldBeSomeFalse_with_None_returns_expected_result()
    {
        var action = () => NoneResult().Should().BeSomeFalse();

        action.Should().Throw<XunitException>();
    }
}
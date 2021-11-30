using LanguageExt;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.LanguageExt.Tests;

public class LanguageExtOptionAsyncBoolAssertionsTest
{
    private static OptionAsync<bool> SomeTrueResult() => Prelude.SomeAsync(true);
    private static OptionAsync<bool> SomeFalseResult() => Prelude.SomeAsync(false);
    private static OptionAsync<bool> NoneResult() => OptionAsync<bool>.None;

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
}
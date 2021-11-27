using LanguageExt;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.LanguageExt.Tests;

public class LanguageExtOptionAsyncAssertionsTest
{
    private static OptionAsync<int> SomeResult() => Prelude.SomeAsync(123);
    private static OptionAsync<int> NoneResult() => OptionAsync<int>.None;

    [Fact]
    public void ShouldBeSome_with_SomeAsync_returns_expected_result()
    {
        var action = () => SomeResult().Should().BeSome();

        action.Should().NotThrow();
    }

    [Fact]
    public void ShouldBeSome_with_NoneAsync_returns_expected_result()
    {
        var action = () => NoneResult().Should().BeSome();

        action.Should().Throw<XunitException>();
    }

    [Fact]
    public void ShouldBeNone_with_SomeAsync_returns_expected_result()
    {
        var action = () => SomeResult().Should().BeNone();

        action.Should().Throw<XunitException>();
    }

    [Fact]
    public void ShouldBeNone_with_NoneAsync_returns_expected_result()
    {
        var action = () => NoneResult().Should().BeNone();

        action.Should().NotThrow();
    }
}
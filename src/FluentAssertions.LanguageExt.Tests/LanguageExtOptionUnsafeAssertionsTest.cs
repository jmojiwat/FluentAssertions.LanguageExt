using LanguageExt;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.LanguageExt.Tests;

public class LanguageExtOptionUnsafeAssertionsTest
{
    private static OptionUnsafe<int> SomeResult() => Prelude.SomeUnsafe(123);
    private static OptionUnsafe<int> NoneResult() => OptionUnsafe<int>.None;

    [Fact]
    public void ShouldBeSome_with_SomeUnsafe_returns_expected_result()
    {
        var action = () => SomeResult().Should().BeSome();

        action.Should().NotThrow();
    }

    [Fact]
    public void ShouldBeSome_with_NoneUnsafe_returns_expected_result()
    {
        var action = () => NoneResult().Should().BeSome();

        action.Should().Throw<XunitException>();
    }

    [Fact]
    public void ShouldBeNone_with_SomeUnsafe_returns_expected_result()
    {
        var action = () => SomeResult().Should().BeNone();

        action.Should().Throw<XunitException>();
    }

    [Fact]
    public void ShouldBeNone_with_NoneUnsafe_returns_expected_result()
    {
        var action = () => NoneResult().Should().BeNone();

        action.Should().NotThrow();
    }

    [Fact]
    public void ShouldContain_with_SomeUnsafe_returns_expected_result()
    {
        var action = () => SomeResult().Should().BeSome(123);

        action.Should().NotThrow();
    }

    [Fact]
    public void ShouldContain_with_unexpected_SomeUnsafe_returns_expected_result()
    {
        var action = () => SomeResult().Should().BeSome(456);

        action.Should().Throw<XunitException>();
    }

    [Fact]
    public void ShouldContain_with_NoneUnsafe_returns_expected_result()
    {
        var action = () => NoneResult().Should().BeSome(123);

        action.Should().Throw<XunitException>();
    }

}
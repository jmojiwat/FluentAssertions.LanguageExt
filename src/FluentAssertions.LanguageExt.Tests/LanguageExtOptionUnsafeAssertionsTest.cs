using LanguageExt;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.LanguageExt.Tests;

public class LanguageExtOptionUnsafeAssertionsTest
{
    private static OptionUnsafe<int> SomeResult() => Prelude.SomeUnsafe(8);
    private static OptionUnsafe<int> NoneResult() => OptionUnsafe<int>.None;

    [Fact]
    public void BeSome_with_SomeUnsafe_returns_expected_result()
    {
        var action = () => SomeResult().Should().BeSome();

        action.Should().NotThrow();
    }

    [Fact]
    public void BeSome_with_NoneUnsafe_returns_expected_result()
    {
        var action = () => NoneResult().Should().BeSome();

        action.Should().Throw<XunitException>();
    }

    [Fact]
    public void BeSome_with_expected_SomeUnsafe_returns_expected_result()
    {
        var action = () => SomeResult().Should().BeSome(s => s.Should().Be(8));

        action.Should().NotThrow();
    }

    [Fact]
    public void BeSome_with_unexpected_SomeUnsafe_returns_expected_result()
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
    public void BeNone_with_SomeUnsafe_returns_expected_result()
    {
        var action = () => SomeResult().Should().BeNone();

        action.Should().Throw<XunitException>();
    }

    [Fact]
    public void BeNone_with_NoneUnsafe_returns_expected_result()
    {
        var action = () => NoneResult().Should().BeNone();

        action.Should().NotThrow();
    }

    [Fact]
    public void Be_with_SomeUnsafe_returns_expected_result()
    {
        var action = () => SomeResult().Should().Be(8);

        action.Should().NotThrow();
    }

    [Fact]
    public void Be_with_unexpected_SomeUnsafe_returns_expected_result()
    {
        var action = () => SomeResult().Should().Be(456);

        action.Should().Throw<XunitException>();
    }

    [Fact]
    public void Be_with_NoneUnsafe_returns_expected_result()
    {
        var action = () => NoneResult().Should().Be(8);

        action.Should().Throw<XunitException>();
    }

}
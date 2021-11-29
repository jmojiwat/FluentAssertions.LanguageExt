using LanguageExt;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.LanguageExt.Tests;

public class LanguageExtEitherUnsafeAssertionsTest
{
    private static EitherUnsafe<int, string> LeftResult() => Prelude.LeftUnsafe(123);
    private static EitherUnsafe<int, string> RightResult() => Prelude.RightUnsafe("abc");

    [Fact]
    public void ShouldBeLeft_with_LeftUnsafe_returns_expected_result()
    {
        var action = () => LeftResult().Should().BeLeft();

        action.Should().NotThrow();
    }

    [Fact]
    public void ShouldBeLeft_with_RightUnsafe_returns_expected_result()
    {
        var action = () => RightResult().Should().BeLeft();

        action.Should().Throw<XunitException>();
    }

    [Fact]
    public void ShouldBeRight_with_LeftUnsafe_returns_expected_result()
    {
        var action = () => LeftResult().Should().BeRight();

        action.Should().Throw<XunitException>();
    }

    [Fact]
    public void ShouldBeRight_with_RightUnsafe_returns_expected_result()
    {
        var action = () => RightResult().Should().BeRight();

        action.Should().NotThrow();
    }

    [Fact]
    public void ShouldContain_with_expected_LeftUnsafe_returns_expected_result()
    {
        var action = () => LeftResult().Should().Be(123);

        action.Should().NotThrow();
    }

    [Fact]
    public void ShouldContain_with_expected_RightUnsafe_returns_expected_result()
    {
        var action = () => RightResult().Should().Be("abc");

        action.Should().NotThrow();
    }

    [Fact]
    public void ShouldContain_with_unexpected_LeftUnsafe_returns_expected_result()
    {
        var action = () => LeftResult().Should().Be(456);

        action.Should().Throw<XunitException>();
    }

    [Fact]
    public void ShouldContain_with_unexpected_RightUnsafe_returns_expected_result()
    {
        var action = () => RightResult().Should().Be("def");

        action.Should().Throw<XunitException>();
    }

}
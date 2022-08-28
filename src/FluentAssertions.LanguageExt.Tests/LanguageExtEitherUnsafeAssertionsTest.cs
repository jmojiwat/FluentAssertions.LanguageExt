using LanguageExt;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.LanguageExt.Tests;

public class LanguageExtEitherUnsafeAssertionsTest
{
    private static EitherUnsafe<int, string> LeftResult() => Prelude.LeftUnsafe(123);
    private static EitherUnsafe<int, string> RightResult() => Prelude.RightUnsafe("abc");

    [Fact]
    public void BeLeft_with_LeftUnsafe_returns_expected_result()
    {
        var action = () => LeftResult().Should().BeLeft();

        action.Should().NotThrow();
    }

    [Fact]
    public void BeLeft_with_RightUnsafe_returns_expected_result()
    {
        var action = () => RightResult().Should().BeLeft();

        action.Should().Throw<XunitException>();
    }

    [Fact]
    public void BeLeft_with_expected_Left_using_which_returns_expected_result()
    {
        var action = () => LeftResult().Should().BeLeft().Which.Should().Be(123);

        action.Should().NotThrow();
    }

    [Fact]
    public void BeLeft_with_unexpected_Left_using_which_returns_expected_result()
    {
        var action = () => LeftResult().Should().BeLeft().Which.Should().Be(456);

        action.Should().Throw<XunitException>();
    }

    [Fact]
    public void BeRight_with_LeftUnsafe_returns_expected_result()
    {
        var action = () => LeftResult().Should().BeRight();

        action.Should().Throw<XunitException>();
    }

    [Fact]
    public void BeRight_with_RightUnsafe_returns_expected_result()
    {
        var action = () => RightResult().Should().BeRight();

        action.Should().NotThrow();
    }

    [Fact]
    public void BeRight_with_expected_Right_using_which_returns_expected_result()
    {
        var action = () => RightResult().Should().BeRight().Which.Should().Be("abc");

        action.Should().NotThrow();
    }

    [Fact]
    public void BeRight_with_unexpected_Right_using_which_returns_expected_result()
    {
        var action = () => RightResult().Should().BeRight().Which.Should().Be("def");

        action.Should().Throw<XunitException>();
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
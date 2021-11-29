using LanguageExt;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.LanguageExt.Tests;

public class LanguageExtEitherAssertionsTest
{
    private static Either<int, string> LeftResult() => Prelude.Left(123);
    private static Either<int, string> RightResult() => Prelude.Right("abc");

    [Fact]
    public void ShouldBeLeft_with_Left_returns_expected_result()
    {
        var action = () => LeftResult().Should().BeLeft();

        action.Should().NotThrow();
    }

    [Fact]
    public void ShouldBeLeft_with_Right_returns_expected_result()
    {
        var action = () => RightResult().Should().BeLeft();

        action.Should().Throw<XunitException>();
    }

    [Fact]
    public void ShouldBeRight_with_Left_returns_expected_result()
    {
        var action = () => LeftResult().Should().BeRight();

        action.Should().Throw<XunitException>();
    }

    [Fact]
    public void ShouldBeRight_with_Right_returns_expected_result()
    {
        var action = () => RightResult().Should().BeRight();

        action.Should().NotThrow();
    }

    [Fact]
    public void ShouldContain_with_expected_Left_returns_expected_result()
    {
        var action = () => LeftResult().Should().Be(123);

        action.Should().NotThrow();
    }

    [Fact]
    public void ShouldContain_with_expected_Right_returns_expected_result()
    {
        var action = () => RightResult().Should().Be("abc");

        action.Should().NotThrow();
    }

    [Fact]
    public void ShouldContain_with_unexpected_Left_returns_expected_result()
    {
        var action = () => LeftResult().Should().Be(456);

        action.Should().Throw<XunitException>();
    }

    [Fact]
    public void ShouldContain_with_unexpected_Right_returns_expected_result()
    {
        var action = () => RightResult().Should().Be("def");

        action.Should().Throw<XunitException>();
    }
}
using LanguageExt;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.LanguageExt.Tests;

public class LanguageExtEitherAssertionsTest
{
    private static Either<int, string> LeftResult() => Prelude.Left(8);
    private static Either<int, string> RightResult() => Prelude.Right("a");

    [Fact]
    public void BeLeft_with_Left_returns_expected_result()
    {
        var action = () => LeftResult().Should().BeLeft();

        action.Should().NotThrow();
    }

    [Fact]
    public void BeLeft_with_expected_Left_returns_expected_result()
    {
        var action = () => LeftResult().Should().BeLeft(p => p.Should().Be(8));

        action.Should().NotThrow();
    }

    [Fact]
    public void BeLeft_with_unexpected_Left_returns_expected_result()
    {
        var action = () => LeftResult().Should().BeLeft(p => p.Should().Be(4));

        action.Should().Throw<XunitException>();
    }

    [Fact]
    public void BeLeft_with_Right_returns_expected_result()
    {
        var action = () => RightResult().Should().BeLeft();

        action.Should().Throw<XunitException>();
    }

    [Fact]
    public void BeRight_with_Right_returns_expected_result()
    {
        var action = () => RightResult().Should().BeRight();

        action.Should().NotThrow();
    }

    [Fact]
    public void BeRight_with_expected_Right_returns_expected_result()
    {
        var action = () => RightResult().Should().BeRight(p => p.Should().Be("a"));

        action.Should().NotThrow();
    }

    [Fact]
    public void BeRight_with_unexpected_Right_returns_expected_result()
    {
        var action = () => RightResult().Should().BeRight(p => p.Should().Be("z"));

        action.Should().Throw<XunitException>();
    }

    [Fact]
    public void BeRight_with_Left_returns_expected_result()
    {
        var action = () => LeftResult().Should().BeRight();

        action.Should().Throw<XunitException>();
    }


    [Fact]
    public void Be_with_expected_Left_returns_expected_result()
    {
        var action = () => LeftResult().Should().Be(8);

        action.Should().NotThrow();
    }

    [Fact]
    public void Be_with_expected_Right_returns_expected_result()
    {
        var action = () => RightResult().Should().Be("a");

        action.Should().NotThrow();
    }

    [Fact]
    public void Be_with_unexpected_Left_returns_expected_result()
    {
        var action = () => LeftResult().Should().Be(4);

        action.Should().Throw<XunitException>();
    }

    [Fact]
    public void Be_with_unexpected_Right_returns_expected_result()
    {
        var action = () => RightResult().Should().Be("z");

        action.Should().Throw<XunitException>();
    }
}
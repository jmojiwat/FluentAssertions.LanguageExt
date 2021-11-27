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
}
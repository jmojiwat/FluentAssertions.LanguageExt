using LanguageExt;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.LanguageExt.Tests;

public class LanguageExtEitherAsyncAssertionsTest
{
    private static EitherAsync<int, string> LeftResult() => 123;
    private static EitherAsync<int, string> RightResult() => "abc";

    [Fact]
    public void ShouldBeLeft_with_LeftAsync_returns_expected_result()
    {
        var action = () => LeftResult().Should().BeLeft();

        action.Should().NotThrow();
    }

    [Fact]
    public void ShouldBeLeft_with_RightAsync_returns_expected_result()
    {
        var action = () => RightResult().Should().BeLeft();

        action.Should().Throw<XunitException>();
    }

    [Fact]
    public void ShouldBeRight_with_LeftAsync_returns_expected_result()
    {
        var action = () => LeftResult().Should().BeRight();

        action.Should().Throw<XunitException>();
    }

    [Fact]
    public void ShouldBeRight_with_RightAsync_returns_expected_result()
    {
        var action = () => RightResult().Should().BeRight();

        action.Should().NotThrow();
    }
}
using LanguageExt;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.LanguageExt.Tests;

public class LanguageExtEitherAsyncAssertionsTest
{
    private static EitherAsync<int, string> LeftResult() => 123;
    private static EitherAsync<int, string> RightResult() => "abc";

    [Fact]
    public void BeLeft_with_LeftAsync_returns_expected_result()
    {
        var action = () => LeftResult().Should().BeLeft();

        action.Should().NotThrow();
    }

    [Fact]
    public void BeLeft_with_expected_LeftAsync_using_which_returns_expected_result()
    {
        var action = () => LeftResult().Should().BeLeft().Which.Should().Be(123);

        action.Should().NotThrow();
    }

    [Fact]
    public void BeLeft_with_unexpected_LeftAsync_using_which_returns_expected_result()
    {
        var action = () => LeftResult().Should().BeLeft().Which.Should().Be(456);

        action.Should().Throw<XunitException>();
    }

    [Fact]
    public void BeLeft_with_RightAsync_returns_expected_result()
    {
        var action = () => RightResult().Should().BeLeft();

        action.Should().Throw<XunitException>();
    }

    [Fact]
    public void BeRight_with_LeftAsync_returns_expected_result()
    {
        var action = () => LeftResult().Should().BeRight();

        action.Should().Throw<XunitException>();
    }

    [Fact]
    public void BeRight_with_RightAsync_returns_expected_result()
    {
        var action = () => RightResult().Should().BeRight();

        action.Should().NotThrow();
    }

    [Fact]
    public void BeRight_with_expected_RightAsync_using_which_returns_expected_result()
    {
        var action = () => RightResult().Should().BeRight().Which.Should().Be("abc");

        action.Should().NotThrow();
    }

    [Fact]
    public void BeRight_with_unexpected_RightAsync_using_which_returns_expected_result()
    {
        var action = () => RightResult().Should().BeRight().Which.Should().Be("def");

        action.Should().Throw<XunitException>();
    }

    [Fact]
    public void ShouldContain_with_expected_LeftAsync_returns_expected_result()
    {
        var action = () => LeftResult().Should().Be(123);

        action.Should().NotThrow();
    }

    [Fact]
    public void ShouldContain_with_expected_RightAsync_returns_expected_result()
    {
        var action = () => RightResult().Should().Be("abc");

        action.Should().NotThrow();
    }

    [Fact]
    public void ShouldContain_with_unexpected_LeftAsync_returns_expected_result()
    {
        var action = () => LeftResult().Should().Be(456);

        action.Should().Throw<XunitException>();
    }

    [Fact]
    public void ShouldContain_with_unexpected_RightAsync_returns_expected_result()
    {
        var action = () => RightResult().Should().Be("def");

        action.Should().Throw<XunitException>();
    }
}
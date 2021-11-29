using LanguageExt;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.LanguageExt.Tests
{
    public class LanguageExtOptionAssertionsTest
    {
        private static Option<int> SomeResult() => Prelude.Some(123);
        private static Option<int> NoneResult() => Option<int>.None;

        [Fact]
        public void ShouldBeSome_with_Some_returns_expected_result()
        {
            var action = () => SomeResult().Should().BeSome();

            action.Should().NotThrow();
        }

        [Fact]
        public void ShouldBeSome_with_None_returns_expected_result()
        {
            var action = () => NoneResult().Should().BeSome();

            action.Should().Throw<XunitException>();
        }

        [Fact]
        public void ShouldBeNone_with_Some_returns_expected_result()
        {
            var action = () => SomeResult().Should().BeNone();

            action.Should().Throw<XunitException>();
        }

        [Fact]
        public void ShouldBeNone_with_None_returns_expected_result()
        {
            var action = () => NoneResult().Should().BeNone();

            action.Should().NotThrow();
        }

        [Fact]
        public void ShouldContain_with_expected_Some_returns_expected_result()
        {
            var action = () => SomeResult().Should().BeSome(123);

            action.Should().NotThrow();
        }

        [Fact]
        public void ShouldContain_with_unexpected_Some_returns_expected_result()
        {
            var action = () => SomeResult().Should().BeSome(456);

            action.Should().Throw<XunitException>();
        }

        [Fact]
        public void ShouldContain_with_None_returns_expected_result()
        {
            var action = () => NoneResult().Should().BeSome(123);

            action.Should().Throw<XunitException>();
        }
    }
}
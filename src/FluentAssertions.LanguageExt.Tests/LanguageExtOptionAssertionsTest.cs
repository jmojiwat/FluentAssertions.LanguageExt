using LanguageExt;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.LanguageExt.Tests
{
    public class LanguageExtOptionAssertionsTest
    {
        private static Option<int> SomeResult() => Prelude.Some(8);
        private static Option<int> NoneResult() => Option<int>.None;

        [Fact]
        public void BeSome_with_Some_returns_expected_result()
        {
            var action = () => SomeResult().Should().BeSome();

            action.Should().NotThrow();
        }

        [Fact]
        public void BeSome_with_None_returns_expected_result()
        {
            var action = () => NoneResult().Should().BeSome();

            action.Should().Throw<XunitException>();
        }

        [Fact]
        public void BeSome_with_expected_Some_returns_expected_result()
        {
            var action = () => SomeResult().Should().BeSome(v => v.Should().Be(8));

            action.Should().NotThrow();
        }

        [Fact]
        public void BeSome_with_unexpected_Some_returns_expected_result()
        {
            var action = () => SomeResult().Should().BeSome(v => v.Should().Be(4));

            action.Should().Throw<XunitException>();
        }

        [Fact]
        public void BeNone_with_Some_returns_expected_result()
        {
            var action = () => SomeResult().Should().BeNone();

            action.Should().Throw<XunitException>();
        }

        [Fact]
        public void BeNone_with_None_returns_expected_result()
        {
            var action = () => NoneResult().Should().BeNone();

            action.Should().NotThrow();
        }

        [Fact]
        public void Be_with_expected_Some_returns_expected_result()
        {
            var action = () => SomeResult().Should().Be(8);

            action.Should().NotThrow();
        }

        [Fact]
        public void Be_with_unexpected_Some_returns_expected_result()
        {
            var action = () => SomeResult().Should().Be(4);

            action.Should().Throw<XunitException>();
        }

        [Fact]
        public void Be_with_None_returns_expected_result()
        {
            var action = () => NoneResult().Should().Be(8);

            action.Should().Throw<XunitException>();
        }
    }
}
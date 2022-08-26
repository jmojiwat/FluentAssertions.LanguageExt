using LanguageExt.ClassInstances;
using LanguageExt;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.LanguageExt.Tests
{
	public class LanguageExtMonoidValidationAssertionsTest
	{
		private static Validation<MSeq<int>, Seq<int>, string> SuccessResult() => "abc";
		private static Validation<MSeq<int>, Seq<int>, string> FailResult() => Prelude.Seq1(123);

		[Fact]
		public void BeFail_with_Fail_returns_expected_result()
		{
			var action = () => FailResult().Should().BeFail();

			action.Should().NotThrow();
		}

		[Fact]
		public void BeFail_with_Success_returns_expected_result()
		{
			var action = () => SuccessResult().Should().BeFail();

			action.Should().Throw<XunitException>();
		}

		[Fact]
		public void BeFail_with_Fail_using_which_returns_expected_result()
		{
			var action = () => FailResult().Should().BeFail().Which.Should().BeEquivalentTo(new[] {123});

			action.Should().NotThrow();
		}

		[Fact]
		public void BeFail_with_unexpected_Fail_using_which_returns_expected_result()
		{
			var action = () => FailResult().Should().BeFail().Which.Should().BeEquivalentTo(new[] {456});

			action.Should().Throw<XunitException>();
		}

		[Fact]
		public void BeSuccess_with_Fail_returns_expected_result()
		{
			var action = () => FailResult().Should().BeSuccess();

			action.Should().Throw<XunitException>();
		}

		[Fact]
		public void BeSuccess_with_Success_returns_expected_result()
		{
			var action = () => SuccessResult().Should().BeSuccess();

			action.Should().NotThrow();
		}

		[Fact]
		public void BeSuccess_with_Success_using_which_returns_expected_result()
		{
			var action = () => SuccessResult().Should().BeSuccess().Which.Should().Be("abc");

			action.Should().NotThrow();
		}

		[Fact]
		public void BeSuccess_with_unexpected_Success_using_which_returns_expected_result()
		{
			var action = () => SuccessResult().Should().BeSuccess().Which.Should().Be("def");

			action.Should().Throw<XunitException>();
		}
	}
}

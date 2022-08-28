using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using LanguageExt;
using LanguageExt.TypeClasses;

namespace FluentAssertions.LanguageExt
{
    public class LanguageExtMonoidValidationAssertions<TMonoidFail, TFail, TSuccess> : ReferenceTypeAssertions<Validation<TMonoidFail, TFail, TSuccess>, LanguageExtMonoidValidationAssertions<TMonoidFail, TFail, TSuccess>> where TMonoidFail : struct, Monoid<TFail>, Eq<TFail>
    {
        public LanguageExtMonoidValidationAssertions(Validation<TMonoidFail, TFail, TSuccess> instance) : base(instance)
        {
        }

        protected override string Identifier => "monoidalvalidation";

        public AndWhichConstraint<LanguageExtMonoidValidationAssertions<TMonoidFail, TFail, TSuccess>, TFail> BeFail(string because = "", params object[] becauseArgs)
        {
            Execute.Assertion
                .BecauseOf(because, becauseArgs)
                .WithExpectation("Expected {context:monoidalvalidation} to be Fail{reason}, ")
                .Given(() => Subject)
                .ForCondition(subject => subject.IsFail)
                .FailWith("but found to be {0}.", Subject);

            return new AndWhichConstraint<LanguageExtMonoidValidationAssertions<TMonoidFail, TFail, TSuccess>, TFail>(this, Subject.FailAsEnumerable());
        }

        public AndWhichConstraint<LanguageExtMonoidValidationAssertions<TMonoidFail, TFail, TSuccess>, TSuccess> BeSuccess(string because = "", params object[] becauseArgs)
        {
            Execute.Assertion
                .BecauseOf(because, becauseArgs)
                .WithExpectation("Expected {context:monoidalvalidation} to be Fail{reason}, ")
                .Given(() => Subject)
                .ForCondition(subject => subject.IsSuccess)
                .FailWith("but found to be {0}.", Subject);

            return new AndWhichConstraint<LanguageExtMonoidValidationAssertions<TMonoidFail, TFail, TSuccess>, TSuccess>(this, Subject.SuccessAsEnumerable());
        }
    }
}
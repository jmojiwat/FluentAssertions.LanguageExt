using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using LanguageExt;
using LanguageExt.TypeClasses;

namespace FluentAssertions.LanguageExt;

public class LanguageExtMonoidValidationAssertions<TMonoidFail, TFail, TSuccess> : ReferenceTypeAssertions<Validation<TMonoidFail, TFail, TSuccess>, LanguageExtMonoidValidationAssertions<TMonoidFail, TFail, TSuccess>> where TMonoidFail : struct, Monoid<TFail>, Eq<TFail>
{
    public LanguageExtMonoidValidationAssertions(Validation<TMonoidFail, TFail, TSuccess> instance) : base(instance)
    {
    }

    protected override string Identifier => "monoidalvalidation";

    public AndConstraint<LanguageExtMonoidValidationAssertions<TMonoidFail, TFail, TSuccess>> BeFail(string because = "", params object[] becauseArgs)
    {
        Execute.Assertion
            .BecauseOf(because, becauseArgs)
            .Given(() => Subject)
            .ForCondition(subject => subject.IsFail)
            .FailWith("Expected {context:monoidalvalidation} to be Fail.");

        return new AndConstraint<LanguageExtMonoidValidationAssertions<TMonoidFail, TFail, TSuccess>>(this);
    }

    public AndConstraint<LanguageExtMonoidValidationAssertions<TMonoidFail, TFail, TSuccess>> BeSuccess(string because = "", params object[] becauseArgs)
    {
        Execute.Assertion
            .BecauseOf(because, becauseArgs)
            .Given(() => Subject)
            .ForCondition(subject => subject.IsSuccess)
            .FailWith("Expected {context:monoidalvalidation} to be Success.");

        return new AndConstraint<LanguageExtMonoidValidationAssertions<TMonoidFail, TFail, TSuccess>>(this);
    }
}
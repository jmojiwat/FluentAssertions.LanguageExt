using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using LanguageExt;

namespace FluentAssertions.LanguageExt;

public class LanguageExtTryAssertions<T> : ReferenceTypeAssertions<Try<T>, LanguageExtTryAssertions<T>>
{
    public LanguageExtTryAssertions(Try<T> instance) : base(instance)
    {
    }

    protected override string Identifier => "try";

    public AndConstraint<LanguageExtTryAssertions<T>> BeFail(string because = "", params object[] becauseArgs)
    {
        Execute.Assertion
            .BecauseOf(because, becauseArgs)
            .WithExpectation("Expected {context:try} to be Fail{reason}, ")
            .Given(() => Subject)
            .ForCondition(subject => subject.IsFail())
            .FailWith("but found to be Fail.");

        return new AndConstraint<LanguageExtTryAssertions<T>>(this);
    }

    public AndConstraint<LanguageExtTryAssertions<T>> BeSuccess(string because = "", params object[] becauseArgs)
    {
        Execute.Assertion
            .BecauseOf(because, becauseArgs)
            .WithExpectation("Expected {context:try} to be Success{reason}, ")
            .Given(() => Subject)
            .ForCondition(subject => subject.IsSucc())
            .FailWith("but found to be Success.");

        return new AndConstraint<LanguageExtTryAssertions<T>>(this);
    }
}
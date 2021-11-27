using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using LanguageExt;

namespace FluentAssertions.LanguageExt;

public class LanguageExtTryOptionAssertions<T> : ReferenceTypeAssertions<TryOption<T>, LanguageExtTryOptionAssertions<T>>
{
    public LanguageExtTryOptionAssertions(TryOption<T> instance) : base(instance)
    {
    }

    protected override string Identifier => "tryoption";

    public AndConstraint<LanguageExtTryOptionAssertions<T>> BeFail(string because = "", params object[] becauseArgs)
    {
        Execute.Assertion
            .BecauseOf(because, becauseArgs)
            .WithExpectation("Expected {context:tryoption} to be Fail{reason}, ")
            .Given(() => Subject)
            .ForCondition(subject => subject.IsFail())
            .FailWith("but found to be Fail.");

        return new AndConstraint<LanguageExtTryOptionAssertions<T>>(this);
    }

    public AndConstraint<LanguageExtTryOptionAssertions<T>> BeSome(string because = "", params object[] becauseArgs)
    {
        Execute.Assertion
            .BecauseOf(because, becauseArgs)
            .Given(() => Subject)
            .ForCondition(subject => subject.IsSome())
            .FailWith("Expected {context:tryoption} to be Some.");

        return new AndConstraint<LanguageExtTryOptionAssertions<T>>(this);
    }

    public AndConstraint<LanguageExtTryOptionAssertions<T>> BeNone(string because = "", params object[] becauseArgs)
    {
        Execute.Assertion
            .BecauseOf(because, becauseArgs)
            .Given(() => Subject)
            .ForCondition(subject => subject.IsNone())
            .FailWith("Expected {context:tryoption} to be None.");

        return new AndConstraint<LanguageExtTryOptionAssertions<T>>(this);
    }

    public AndConstraint<LanguageExtTryOptionAssertions<T>> BeNoneOrFail(string because = "", params object[] becauseArgs)
    {
        Execute.Assertion
            .BecauseOf(because, becauseArgs)
            .Given(() => Subject)
            .ForCondition(subject => subject.IsNoneOrFail())
            .FailWith("Expected {context:tryoption} to be None or Fail.");

        return new AndConstraint<LanguageExtTryOptionAssertions<T>>(this);
    }
}
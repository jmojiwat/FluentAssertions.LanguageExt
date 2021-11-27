using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using LanguageExt;

namespace FluentAssertions.LanguageExt;

public class LanguageExtTryOptionAsyncAssertions<T> : ReferenceTypeAssertions<TryOptionAsync<T>, LanguageExtTryOptionAsyncAssertions<T>>
{
    public LanguageExtTryOptionAsyncAssertions(TryOptionAsync<T> instance) : base(instance)
    {
    }

    protected override string Identifier => "tryoptionasync";

    public AndConstraint<LanguageExtTryOptionAsyncAssertions<T>> BeFail(string because = "", params object[] becauseArgs)
    {
        Execute.Assertion
            .BecauseOf(because, becauseArgs)
            .WithExpectation("Expected {context:tryoptionasync} to be Fail{reason}, ")
            .Given(() => Subject)
            .ForCondition(subject => subject.IsFail().Result)
            .FailWith("but found to be Fail.");

        return new AndConstraint<LanguageExtTryOptionAsyncAssertions<T>>(this);
    }

    public AndConstraint<LanguageExtTryOptionAsyncAssertions<T>> BeSome(string because = "", params object[] becauseArgs)
    {
        Execute.Assertion
            .BecauseOf(because, becauseArgs)
            .Given(() => Subject)
            .ForCondition(subject => subject.IsSome().Result)
            .FailWith("Expected {context:tryoptionasync} to be Some.");

        return new AndConstraint<LanguageExtTryOptionAsyncAssertions<T>>(this);
    }

    public AndConstraint<LanguageExtTryOptionAsyncAssertions<T>> BeNone(string because = "", params object[] becauseArgs)
    {
        Execute.Assertion
            .BecauseOf(because, becauseArgs)
            .Given(() => Subject)
            .ForCondition(subject => subject.IsNone().Result)
            .FailWith("Expected {context:tryoptionasync} to be None.");

        return new AndConstraint<LanguageExtTryOptionAsyncAssertions<T>>(this);
    }

    public AndConstraint<LanguageExtTryOptionAsyncAssertions<T>> BeNoneOrFail(string because = "", params object[] becauseArgs)
    {
        Execute.Assertion
            .BecauseOf(because, becauseArgs)
            .Given(() => Subject)
            .ForCondition(subject => subject.IsNoneOrFail().Result)
            .FailWith("Expected {context:tryoptionasync} to be None or Fail.");

        return new AndConstraint<LanguageExtTryOptionAsyncAssertions<T>>(this);
    }
}
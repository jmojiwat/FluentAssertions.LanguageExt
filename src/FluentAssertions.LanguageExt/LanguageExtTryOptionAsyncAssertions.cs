using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using LanguageExt;
using static Nito.AsyncEx.AsyncContext;

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
            .ForCondition(subject => Run(subject.IsFail))
            .FailWith("but found to be not.");

        return new AndConstraint<LanguageExtTryOptionAsyncAssertions<T>>(this);
    }

    public AndConstraint<LanguageExtTryOptionAsyncAssertions<T>> BeSome(string because = "", params object[] becauseArgs)
    {
        Execute.Assertion
            .BecauseOf(because, becauseArgs)
            .WithExpectation("Expected {context:tryoptionasync} to be Some{reason}, ")
            .Given(() => Subject)
            .ForCondition(subject => Run(subject.IsSome))
            .FailWith("but found to be not.");

        return new AndConstraint<LanguageExtTryOptionAsyncAssertions<T>>(this);
    }

    public AndConstraint<LanguageExtTryOptionAsyncAssertions<T>> BeSome(Action<T> action, string because = "", params object[] becauseArgs)
    {
        BeSome(because, becauseArgs);
        Run(async () => (await Subject()).IfSucc(action));

        return new AndConstraint<LanguageExtTryOptionAsyncAssertions<T>>(this);
    }

    public AndConstraint<LanguageExtTryOptionAsyncAssertions<T>> Be(T expected, string because = "", params object[] becauseArgs)
    {
        Execute.Assertion
            .BecauseOf(because, becauseArgs)
            .WithExpectation("Expected {context:tryoptionasync} to be {0}{reason}, ", expected)
            .Given(() => Subject)
            .ForCondition(subject => Run(subject.IsSome))
            .FailWith("but found to be None.")
            .Then
            .ForCondition(subject => Run(async () => await subject() == expected))
            .FailWith("but found to be not.");

        return new AndConstraint<LanguageExtTryOptionAsyncAssertions<T>>(this);
    }

    public AndConstraint<LanguageExtTryOptionAsyncAssertions<T>> BeNone(string because = "", params object[] becauseArgs)
    {
        Execute.Assertion
            .BecauseOf(because, becauseArgs)
            .WithExpectation("Expected {context:tryoptionasync} to be None{reason}, ")
            .Given(() => Subject)
            .ForCondition(subject => Run(subject.IsNone))
            .FailWith("but found to be not.");

        return new AndConstraint<LanguageExtTryOptionAsyncAssertions<T>>(this);
    }

    public AndConstraint<LanguageExtTryOptionAsyncAssertions<T>> BeNoneOrFail(string because = "", params object[] becauseArgs)
    {
        Execute.Assertion
            .BecauseOf(because, becauseArgs)
            .WithExpectation("Expected {context:tryoptionasync} to be Some or Fail{reason}, ")
            .Given(() => Subject)
            .ForCondition(subject => Run(subject.IsNoneOrFail))
            .FailWith("but found to be not.");

        return new AndConstraint<LanguageExtTryOptionAsyncAssertions<T>>(this);
    }
}
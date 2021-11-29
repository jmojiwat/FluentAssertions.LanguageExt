using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using LanguageExt;
using static Nito.AsyncEx.AsyncContext;

namespace FluentAssertions.LanguageExt;

public class LanguageExtTryAsyncAssertions<T> : ReferenceTypeAssertions<TryAsync<T>, LanguageExtTryAsyncAssertions<T>>
{
    public LanguageExtTryAsyncAssertions(TryAsync<T> instance) : base(instance)
    {
    }

    protected override string Identifier => "tryasync";

    public AndConstraint<LanguageExtTryAsyncAssertions<T>> BeFail(string because = "", params object[] becauseArgs)
    {
        Execute.Assertion
            .BecauseOf(because, becauseArgs)
            .WithExpectation("Expected {context:tryasync} to be Fail{reason}, ")
            .Given(() => Subject)
            .ForCondition(subject => Run(subject.IsFail))
            .FailWith("but found to be Fail.");

        return new AndConstraint<LanguageExtTryAsyncAssertions<T>>(this);
    }

    public AndConstraint<LanguageExtTryAsyncAssertions<T>> BeSuccess(string because = "", params object[] becauseArgs)
    {
        Execute.Assertion
            .BecauseOf(because, becauseArgs)
            .WithExpectation("Expected {context:tryasync} to be Success{reason}, ")
            .Given(() => Subject)
            .ForCondition(subject => Run(subject.IsSucc))
            .FailWith("but found to be Success.");

        return new AndConstraint<LanguageExtTryAsyncAssertions<T>>(this);
    }
}
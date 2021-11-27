using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using LanguageExt;

namespace FluentAssertions.LanguageExt;

public class LanguageExtOptionAsyncAssertions<T> : ReferenceTypeAssertions<OptionAsync<T>, LanguageExtOptionAsyncAssertions<T>>
{
    public LanguageExtOptionAsyncAssertions(OptionAsync<T> instance) : base(instance)
    {
    }

    protected override string Identifier => "optionasync";

    public AndConstraint<LanguageExtOptionAsyncAssertions<T>> BeNone(string because = "", params object[] becauseArgs)
    {
        Execute.Assertion
            .BecauseOf(because, becauseArgs)
            .WithExpectation("Expected {context:optionasync} to be None{reason}, ")
            .Given(() => Subject)
            .ForCondition(subject => subject.IsNone.Result)
            .FailWith("but found to be Some.");

        return new AndConstraint<LanguageExtOptionAsyncAssertions<T>>(this);
    }

    public AndConstraint<LanguageExtOptionAsyncAssertions<T>> BeSome(string because = "", params object[] becauseArgs)
    {
        Execute.Assertion
            .BecauseOf(because, becauseArgs)
            .WithExpectation("Expected {context:option} to be Some{reason}, ")
            .Given(() => Subject)
            .ForCondition(subject => subject.IsSome.Result)
            .FailWith("but found to be None.");

        return new AndConstraint<LanguageExtOptionAsyncAssertions<T>>(this);
    }
}
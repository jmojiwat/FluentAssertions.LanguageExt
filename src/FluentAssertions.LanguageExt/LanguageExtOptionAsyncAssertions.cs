using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using LanguageExt;
using static Nito.AsyncEx.AsyncContext;

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
            .ForCondition(subject => Run(() => subject.IsNone))
            .FailWith("but found to be Some.");

        return new AndConstraint<LanguageExtOptionAsyncAssertions<T>>(this);
    }

    public AndConstraint<LanguageExtOptionAsyncAssertions<T>> BeSome(string because = "", params object[] becauseArgs)
    {
        Execute.Assertion
            .BecauseOf(because, becauseArgs)
            .WithExpectation("Expected {context:optionasync} to be Some{reason}, ")
            .Given(() => Subject)
            .ForCondition(subject => Run(() => subject.IsSome))
            .FailWith("but found to be None.");

        return new AndConstraint<LanguageExtOptionAsyncAssertions<T>>(this);
    }

    public AndConstraint<LanguageExtOptionAsyncAssertions<T>> BeSome(Action<T> action, string because = "", params object[] becauseArgs)
    {
        BeSome(because, becauseArgs);
        Prelude.ignore(Run(async () => await Subject.IfSome(action)));

        return new AndConstraint<LanguageExtOptionAsyncAssertions<T>>(this);
    }

    public AndConstraint<LanguageExtOptionAsyncAssertions<T>> Be(T expected, string because = "", params object[] becauseArgs)
    {
        Execute.Assertion
            .BecauseOf(because, becauseArgs)
            .WithExpectation("Expected {context:optionasync} to be Some {0}{reason}, ", expected)
            .Given(() => Subject)
            .ForCondition(subject => Run(() => subject.IsSome))
            .FailWith("but found to be None.")
            .Then
            .ForCondition(subject => Run(() => subject == expected))
            .FailWith("but found Some {0}.", Subject);

        return new AndConstraint<LanguageExtOptionAsyncAssertions<T>>(this);
    }
}
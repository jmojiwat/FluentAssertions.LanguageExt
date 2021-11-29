using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using LanguageExt;
using static Nito.AsyncEx.AsyncContext;

namespace FluentAssertions.LanguageExt;

public class LanguageExtOptionAsyncBoolAssertions : ReferenceTypeAssertions<OptionAsync<bool>, LanguageExtOptionAsyncBoolAssertions>
{
    public LanguageExtOptionAsyncBoolAssertions(OptionAsync<bool> subject) : base(subject)
    {
    }

    public AndConstraint<LanguageExtOptionAsyncBoolAssertions> BeNone(string because = "", params object[] becauseArgs)
    {
        Execute.Assertion
            .BecauseOf(because, becauseArgs)
            .WithExpectation("Expected {context:optionbool} to be None{reason}, ")
            .Given(() => Subject)
            .ForCondition(subject => Run(() => subject.IsNone))
            .FailWith("but found to be Some.");

        return new AndConstraint<LanguageExtOptionAsyncBoolAssertions>(this);
    }


    public AndConstraint<LanguageExtOptionAsyncBoolAssertions> BeSomeTrue(string because = "", params object[] becauseArgs)
    {
        Execute.Assertion
            .BecauseOf(because, becauseArgs)
            .Given(() => Subject)
            .ForCondition(subject => Run(() => subject.IsSome))
            .FailWith("but found to be None.")
            .Then
            .ForCondition(subject => Run(() => subject == true))
            .FailWith("Expected {context:optionbool} to be Some true.");

        return new AndConstraint<LanguageExtOptionAsyncBoolAssertions>(this);
    }

    public AndConstraint<LanguageExtOptionAsyncBoolAssertions> BeSomeFalse(string because = "", params object[] becauseArgs)
    {
        Execute.Assertion
            .BecauseOf(because, becauseArgs)
            .Given(() => Subject)
            .ForCondition(subject => Run(() => subject.IsSome))
            .FailWith("but found to be None.")
            .Then
            .ForCondition(subject => Run(() => subject == false))
            .FailWith("Expected {context:optionbool} to be Some false.");

        return new AndConstraint<LanguageExtOptionAsyncBoolAssertions>(this);
    }

    protected override string Identifier => "optionbool";
}
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
            .WithExpectation("Expected {context:optionasyncbool} to be None{reason}, ")
            .Given(() => Subject)
            .ForCondition(subject => Run(() => subject.IsNone))
            .FailWith("but found to be Some.");

        return new AndConstraint<LanguageExtOptionAsyncBoolAssertions>(this);
    }

    public AndConstraint<LanguageExtOptionAsyncBoolAssertions> BeSome(string because = "", params object[] becauseArgs)
    {
        Execute.Assertion
            .BecauseOf(because, becauseArgs)
            .WithExpectation("Expected {context:optionasyncbool} to be Some{reason}, ")
            .Given(() => Subject)
            .ForCondition(subject => Run(() => subject.IsSome))
            .FailWith("but found to be None.");

        return new AndConstraint<LanguageExtOptionAsyncBoolAssertions>(this);
    }

    public AndConstraint<LanguageExtOptionAsyncBoolAssertions> BeTrue(string because = "", params object[] becauseArgs)
    {
        Execute.Assertion
            .BecauseOf(because, becauseArgs)
            .WithExpectation("Expected {context:optionasyncbool} to be Some true{reason}, ")
            .Given(() => Subject)
            .ForCondition(subject => Run(() => subject.IsSome))
            .FailWith("but found to be None.")
            .Then
            .ForCondition(subject => Run(() => subject == true))
            .FailWith("but found to be Some false.");

        return new AndConstraint<LanguageExtOptionAsyncBoolAssertions>(this);
    }

    public AndConstraint<LanguageExtOptionAsyncBoolAssertions> BeFalse(string because = "", params object[] becauseArgs)
    {
        Execute.Assertion
            .BecauseOf(because, becauseArgs)
            .WithExpectation("Expected {context:optionasyncbool} to be Some false{reason}, ")
            .Given(() => Subject)
            .ForCondition(subject => Run(() => subject.IsSome))
            .FailWith("but found to be None.")
            .Then
            .ForCondition(subject => Run(() => subject == false))
            .FailWith("but found to be Some true.");

        return new AndConstraint<LanguageExtOptionAsyncBoolAssertions>(this);
    }

    protected override string Identifier => "optionasyncbool";
}
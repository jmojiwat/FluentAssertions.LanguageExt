using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using LanguageExt;

namespace FluentAssertions.LanguageExt;

public class LanguageExtOptionBoolAssertions : ReferenceTypeAssertions<Option<bool>, LanguageExtOptionBoolAssertions>
{
    public LanguageExtOptionBoolAssertions(Option<bool> subject) : base(subject)
    {
    }

    public AndConstraint<LanguageExtOptionBoolAssertions> BeNone(string because = "", params object[] becauseArgs)
    {
        Execute.Assertion
            .BecauseOf(because, becauseArgs)
            .WithExpectation("Expected {context:optionbool} to be None{reason}, ")
            .Given(() => Subject)
            .ForCondition(subject => subject.IsNone)
            .FailWith("but found to be Some.");

        return new AndConstraint<LanguageExtOptionBoolAssertions>(this);
    }

    public AndConstraint<LanguageExtOptionBoolAssertions> BeSome(string because = "", params object[] becauseArgs)
    {
        Execute.Assertion
            .BecauseOf(because, becauseArgs)
            .WithExpectation("Expected {context:optionbool} to be Some{reason}, ")
            .Given(() => Subject)
            .ForCondition(subject => subject.IsSome)
            .FailWith("but found to be None.");

        return new AndConstraint<LanguageExtOptionBoolAssertions>(this);
    }

    public AndConstraint<LanguageExtOptionBoolAssertions> BeTrue(string because = "", params object[] becauseArgs)
    {
        Execute.Assertion
            .BecauseOf(because, becauseArgs)
            .WithExpectation("Expected {context:optionbool} to be Some true{reason}, ")
            .Given(() => Subject)
            .ForCondition(subject => subject.IsSome)
            .FailWith("but found to be None.")
            .Then
            .ForCondition(subject => subject == true)
            .FailWith("but found to be Some false.");

        return new AndConstraint<LanguageExtOptionBoolAssertions>(this);
    }

    public AndConstraint<LanguageExtOptionBoolAssertions> BeFalse(string because = "", params object[] becauseArgs)
    {
        Execute.Assertion
            .BecauseOf(because, becauseArgs)
            .WithExpectation("Expected {context:optionbool} to be Some false{reason}, ")
            .Given(() => Subject)
            .ForCondition(subject => subject.IsSome)
            .FailWith("but found to be None.")
            .Then
            .ForCondition(subject => subject == false)
            .FailWith("but found to be Some true.");

        return new AndConstraint<LanguageExtOptionBoolAssertions>(this);
    }

    protected override string Identifier => "optionbool";
}
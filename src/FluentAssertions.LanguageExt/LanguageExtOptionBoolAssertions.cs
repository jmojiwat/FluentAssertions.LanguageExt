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


    public AndConstraint<LanguageExtOptionBoolAssertions> BeSomeTrue(string because = "", params object[] becauseArgs)
    {
        Execute.Assertion
            .BecauseOf(because, becauseArgs)
            .Given(() => Subject)
            .ForCondition(subject => subject.IsSome)
            .ForCondition(subject => subject.Match(
                    b => b,
                    () => false))
            .FailWith("Expected {context:optionbool} to be Some true.");

        return new AndConstraint<LanguageExtOptionBoolAssertions>(this);
    }

    public AndConstraint<LanguageExtOptionBoolAssertions> BeSomeFalse(string because = "", params object[] becauseArgs)
    {
        Execute.Assertion
            .BecauseOf(because, becauseArgs)
            .Given(() => Subject)
            .ForCondition(subject => subject.IsSome)
            .ForCondition(subject => subject.Match(
                    b => b == false,
                    () => false))
            .FailWith("Expected {context:optionbool} to be Some false.");

        return new AndConstraint<LanguageExtOptionBoolAssertions>(this);
    }

    protected override string Identifier => "optionbool";
}
using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using LanguageExt;

namespace FluentAssertions.LanguageExt;

public class LanguageExtOptionUnsafeAssertions<T> : ReferenceTypeAssertions<OptionUnsafe<T>, LanguageExtOptionUnsafeAssertions<T>>
{
    public LanguageExtOptionUnsafeAssertions(OptionUnsafe<T> instance) : base(instance)
    {
    }

    protected override string Identifier => "optionunsafe";

    public AndConstraint<LanguageExtOptionUnsafeAssertions<T>> BeNone(string because = "", params object[] becauseArgs)
    {
        Execute.Assertion
            .BecauseOf(because, becauseArgs)
            .WithExpectation("Expected {context:optionunsafe} to be None{reason}, ")
            .Given(() => Subject)
            .ForCondition(subject => subject.IsNone)
            .FailWith("but found to be Some.");

        return new AndConstraint<LanguageExtOptionUnsafeAssertions<T>>(this);
    }

    public AndConstraint<LanguageExtOptionUnsafeAssertions<T>> BeSome(string because = "", params object[] becauseArgs)
    {
        Execute.Assertion
            .BecauseOf(because, becauseArgs)
            .WithExpectation("Expected {context:option} to be Some{reason}, ")
            .Given(() => Subject)
            .ForCondition(subject => subject.IsSome)
            .FailWith("but found to be None.");

        return new AndConstraint<LanguageExtOptionUnsafeAssertions<T>>(this);
    }
}
using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using LanguageExt;
using static LanguageExt.Prelude;

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
            .WithExpectation("Expected {context:optionunsafe} to be Some{reason}, ")
            .Given(() => Subject)
            .ForCondition(subject => subject.IsSome)
            .FailWith("but found to be None.");

        return new AndConstraint<LanguageExtOptionUnsafeAssertions<T>>(this);
    }

    public AndConstraint<LanguageExtOptionUnsafeAssertions<T>> BeSome(Action<T> action, string because = "", params object[] becauseArgs)
    {
        BeSome(because, becauseArgs);
        ignore(Subject.IfSomeUnsafe(action));

        return new AndConstraint<LanguageExtOptionUnsafeAssertions<T>>(this);
    }

    public AndConstraint<LanguageExtOptionUnsafeAssertions<T>> Be(T expected, string because = "", params object[] becauseArgs)
    {
        Execute.Assertion
            .BecauseOf(because, becauseArgs)
            .WithExpectation("Expected {context:optionunsafe} to be Some {0}{reason}, ", expected)
            .Given(() => Subject)
            .ForCondition(subject => subject.IsSome)
            .FailWith("but found to be None.")
            .Then
            .ForCondition(subject => subject == expected)
            .FailWith("but found Some {0}.", Subject);

        return new AndConstraint<LanguageExtOptionUnsafeAssertions<T>>(this);
    }
}
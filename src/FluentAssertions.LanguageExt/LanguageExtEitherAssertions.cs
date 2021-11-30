using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using LanguageExt;

namespace FluentAssertions.LanguageExt;

public class LanguageExtEitherAssertions<TL, TR> : ReferenceTypeAssertions<Either<TL, TR>, LanguageExtEitherAssertions<TL, TR>>
{
    public LanguageExtEitherAssertions(Either<TL, TR> instance) : base(instance)
    {
    }

    protected override string Identifier => "either";

    public AndConstraint<LanguageExtEitherAssertions<TL, TR>> BeLeft(string because = "", params object[] becauseArgs)
    {
        Execute.Assertion
            .BecauseOf(because, becauseArgs)
            .WithExpectation("Expected {context:either} to be Left{reason}, ")
            .Given(() => Subject)
            .ForCondition(subject => subject.IsLeft)
            .FailWith("but found to be Right.");

        return new AndConstraint<LanguageExtEitherAssertions<TL, TR>>(this);
    }

    public AndConstraint<LanguageExtEitherAssertions<TL, TR>> BeLeft(Action<TL> action, string because = "", params object[] becauseArgs)
    {
        BeLeft(because, becauseArgs);
        Subject.IfLeft(action);

        return new AndConstraint<LanguageExtEitherAssertions<TL, TR>>(this);
    }

    public AndConstraint<LanguageExtEitherAssertions<TL, TR>> BeRight(string because = "", params object[] becauseArgs)
    {
        Execute.Assertion
            .BecauseOf(because, becauseArgs)
            .WithExpectation("Expected {context:either} to be Right{reason}, ")
            .Given(() => Subject)
            .ForCondition(subject => subject.IsRight)
            .FailWith("but found to be Left.");

        return new AndConstraint<LanguageExtEitherAssertions<TL, TR>>(this);
    }

    public AndConstraint<LanguageExtEitherAssertions<TL, TR>> BeRight(Action<TR> action, string because = "", params object[] becauseArgs)
    {
        BeRight(because, becauseArgs);
        Subject.IfRight(action);

        return new AndConstraint<LanguageExtEitherAssertions<TL, TR>>(this);
    }

    public AndConstraint<LanguageExtEitherAssertions<TL, TR>> BeBottom(string because = "", params object[] becauseArgs)
    {
        Execute.Assertion
            .BecauseOf(because, becauseArgs)
            .WithExpectation("Expected {context:either} to be Bottom{reason}, ")
            .Given(() => Subject)
            .ForCondition(subject => subject.IsBottom)
            .FailWith("but found to be either Left or Right.");

        return new AndConstraint<LanguageExtEitherAssertions<TL, TR>>(this);
    }

    public AndConstraint<LanguageExtEitherAssertions<TL, TR>> Be(TL expected, string because = "", params object[] becauseArgs)
    {
        Execute.Assertion
            .BecauseOf(because, becauseArgs)
            .WithExpectation("Expected {context:either} to be Left {0}{reason}, ", expected)
            .Given(() => Subject)
            .ForCondition(subject => subject.IsLeft)
            .FailWith("but found to be Right")
            .Then
            .ForCondition(subject => subject == expected)
            .FailWith("but found to be Left {0}", Subject);

        return new AndConstraint<LanguageExtEitherAssertions<TL, TR>>(this);
    }

    public AndConstraint<LanguageExtEitherAssertions<TL, TR>> Be(TR expected, string because = "", params object[] becauseArgs)
    {
        Execute.Assertion
            .BecauseOf(because, becauseArgs)
            .WithExpectation("Expected {context:either} to be Right {0}{reason}, ", expected)
            .Given(() => Subject)
            .ForCondition(subject => subject.IsRight)
            .FailWith("but found to be Left")
            .Then
            .ForCondition(subject => subject == expected)
            .FailWith("but found to be Right {0}", Subject);

        return new AndConstraint<LanguageExtEitherAssertions<TL, TR>>(this);
    }
}
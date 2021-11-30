using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using LanguageExt;

namespace FluentAssertions.LanguageExt;

public class LanguageExtEitherUnsafeAssertions<TL, TR> : ReferenceTypeAssertions<EitherUnsafe<TL, TR>, LanguageExtEitherUnsafeAssertions<TL, TR>>
{
    public LanguageExtEitherUnsafeAssertions(EitherUnsafe<TL, TR> instance) : base(instance)
    {
    }

    protected override string Identifier => "eitherunsafe";

    public AndConstraint<LanguageExtEitherUnsafeAssertions<TL, TR>> BeLeft(string because = "", params object[] becauseArgs)
    {
        Execute.Assertion
            .BecauseOf(because, becauseArgs)
            .WithExpectation("Expected {context:eitherunsafe} to be Left{reason}, ")
            .Given(() => Subject)
            .ForCondition(subject => subject.IsLeft)
            .FailWith("but found to be Right.");

        return new AndConstraint<LanguageExtEitherUnsafeAssertions<TL, TR>>(this);
    }

    public AndConstraint<LanguageExtEitherUnsafeAssertions<TL, TR>> BeLeft(Action<TL> action, string because = "", params object[] becauseArgs)
    {
        BeLeft(because, becauseArgs);
        Subject.IfLeftUnsafe(action);

        return new AndConstraint<LanguageExtEitherUnsafeAssertions<TL, TR>>(this);
    }

    public AndConstraint<LanguageExtEitherUnsafeAssertions<TL, TR>> BeRight(string because = "", params object[] becauseArgs)
    {
        Execute.Assertion
            .BecauseOf(because, becauseArgs)
            .WithExpectation("Expected {context:eitherunsafe} to be Right{reason}, ")
            .Given(() => Subject)
            .ForCondition(subject => subject.IsRight)
            .FailWith("but found to be Left.");

        return new AndConstraint<LanguageExtEitherUnsafeAssertions<TL, TR>>(this);
    }

    public AndConstraint<LanguageExtEitherUnsafeAssertions<TL, TR>> BeRight(Action<TR> action, string because = "", params object[] becauseArgs)
    {
        BeRight(because, becauseArgs);
        Subject.IfRightUnsafe(action);

        return new AndConstraint<LanguageExtEitherUnsafeAssertions<TL, TR>>(this);
    }

    public AndConstraint<LanguageExtEitherUnsafeAssertions<TL, TR>> BeBottom(string because = "", params object[] becauseArgs)
    {
        Execute.Assertion
            .BecauseOf(because, becauseArgs)
            .WithExpectation("Expected {context:eitherunsafe} to be Bottom{reason}, ")
            .Given(() => Subject)
            .ForCondition(subject => subject.IsBottom)
            .FailWith("but found to be either Left or Right.");

        return new AndConstraint<LanguageExtEitherUnsafeAssertions<TL, TR>>(this);
    }

    public AndConstraint<LanguageExtEitherUnsafeAssertions<TL, TR>> Be(TL expected, string because = "", params object[] becauseArgs)
    {
        Execute.Assertion
            .BecauseOf(because, becauseArgs)
            .WithExpectation("Expected {context:eitherunsafe} to be Left {0}{reason}, ", expected)
            .Given(() => Subject)
            .ForCondition(subject => subject.IsLeft)
            .FailWith("but found to be Right")
            .Then
            .ForCondition(subject => subject == expected)
            .FailWith("but found to be Left {0}", Subject);

        return new AndConstraint<LanguageExtEitherUnsafeAssertions<TL, TR>>(this);
    }

    public AndConstraint<LanguageExtEitherUnsafeAssertions<TL, TR>> Be(TR expected, string because = "", params object[] becauseArgs)
    {
        Execute.Assertion
            .BecauseOf(because, becauseArgs)
            .WithExpectation("Expected {context:eitherunsafe} to be Right {0}{reason}, ", expected)
            .Given(() => Subject)
            .ForCondition(subject => subject.IsRight)
            .FailWith("but found to be Left")
            .Then
            .ForCondition(subject => subject == expected)
            .FailWith("but found to be Right {0}", Subject);

        return new AndConstraint<LanguageExtEitherUnsafeAssertions<TL, TR>>(this);
    }
}
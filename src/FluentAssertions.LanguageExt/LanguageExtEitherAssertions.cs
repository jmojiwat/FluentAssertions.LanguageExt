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
            .Given(() => Subject)
            .ForCondition(subject => subject.IsLeft)
            .FailWith("Expected {context:either} to be Left.");

        return new AndConstraint<LanguageExtEitherAssertions<TL, TR>>(this);
    }

    public AndConstraint<LanguageExtEitherAssertions<TL, TR>> BeRight(string because = "", params object[] becauseArgs)
    {
        Execute.Assertion
            .BecauseOf(because, becauseArgs)
            .Given(() => Subject)
            .ForCondition(subject => subject.IsRight)
            .FailWith("Expected {context:either} to be Right.");

        return new AndConstraint<LanguageExtEitherAssertions<TL, TR>>(this);
    }

    public AndConstraint<LanguageExtEitherAssertions<TL, TR>> BeBottom(string because = "", params object[] becauseArgs)
    {
        Execute.Assertion
            .BecauseOf(because, becauseArgs)
            .Given(() => Subject)
            .ForCondition(subject => subject.IsBottom)
            .FailWith("Expected {context:either} to be Bottom.");

        return new AndConstraint<LanguageExtEitherAssertions<TL, TR>>(this);
    }
}
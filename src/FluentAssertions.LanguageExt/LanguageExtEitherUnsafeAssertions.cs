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
            .Given(() => Subject)
            .ForCondition(subject => subject.IsLeft)
            .FailWith("Expected {context:eitherunsafe} to be Left.");

        return new AndConstraint<LanguageExtEitherUnsafeAssertions<TL, TR>>(this);
    }

    public AndConstraint<LanguageExtEitherUnsafeAssertions<TL, TR>> BeRight(string because = "", params object[] becauseArgs)
    {
        Execute.Assertion
            .BecauseOf(because, becauseArgs)
            .Given(() => Subject)
            .ForCondition(subject => subject.IsRight)
            .FailWith("Expected {context:eitherunsafe} to be Right.");

        return new AndConstraint<LanguageExtEitherUnsafeAssertions<TL, TR>>(this);
    }

    public AndConstraint<LanguageExtEitherUnsafeAssertions<TL, TR>> BeBottom(string because = "", params object[] becauseArgs)
    {
        Execute.Assertion
            .BecauseOf(because, becauseArgs)
            .Given(() => Subject)
            .ForCondition(subject => subject.IsBottom)
            .FailWith("Expected {context:eitherunsafe} to be Bottom.");

        return new AndConstraint<LanguageExtEitherUnsafeAssertions<TL, TR>>(this);
    }
}
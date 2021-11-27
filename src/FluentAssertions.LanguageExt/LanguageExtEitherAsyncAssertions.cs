using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using LanguageExt;

namespace FluentAssertions.LanguageExt;

public class LanguageExtEitherAsyncAssertions<TL, TR> : ReferenceTypeAssertions<EitherAsync<TL, TR>, LanguageExtEitherAsyncAssertions<TL, TR>>
{
    public LanguageExtEitherAsyncAssertions(EitherAsync<TL, TR> instance) : base(instance)
    {
    }

    protected override string Identifier => "eitherasync";

    public AndConstraint<LanguageExtEitherAsyncAssertions<TL, TR>> BeLeft(string because = "", params object[] becauseArgs)
    {
        Execute.Assertion
            .BecauseOf(because, becauseArgs)
            .Given(() => Subject)
            .ForCondition(subject => subject.IsLeft.Result)
            .FailWith("Expected {context:eitherasync} to be Left.");

        return new AndConstraint<LanguageExtEitherAsyncAssertions<TL, TR>>(this);
    }

    public AndConstraint<LanguageExtEitherAsyncAssertions<TL, TR>> BeRight(string because = "", params object[] becauseArgs)
    {
        Execute.Assertion
            .BecauseOf(because, becauseArgs)
            .Given(() => Subject)
            .ForCondition(subject => subject.IsRight.Result)
            .FailWith("Expected {context:eitherasync} to be Right.");

        return new AndConstraint<LanguageExtEitherAsyncAssertions<TL, TR>>(this);
    }

    public AndConstraint<LanguageExtEitherAsyncAssertions<TL, TR>> BeBottom(string because = "", params object[] becauseArgs)
    {
        Execute.Assertion
            .BecauseOf(because, becauseArgs)
            .Given(() => Subject)
            .ForCondition(subject => subject.IsBottom.Result)
            .FailWith("Expected {context:eitherasync} to be Bottom.");

        return new AndConstraint<LanguageExtEitherAsyncAssertions<TL, TR>>(this);
    }
}
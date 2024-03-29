﻿using System;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using LanguageExt;
using static Nito.AsyncEx.AsyncContext;

namespace FluentAssertions.LanguageExt
{
    public class LanguageExtEitherAsyncAssertions<TL, TR> : ReferenceTypeAssertions<EitherAsync<TL, TR>, LanguageExtEitherAsyncAssertions<TL, TR>>
    {
        public LanguageExtEitherAsyncAssertions(EitherAsync<TL, TR> instance) : base(instance)
        {
        }

        protected override string Identifier => "eitherasync";

        public AndWhichConstraint<LanguageExtEitherAsyncAssertions<TL, TR>, TL> BeLeft(string because = "", params object[] becauseArgs)
        {
            Execute.Assertion
                .BecauseOf(because, becauseArgs)
                .WithExpectation("Expected {context:eitherasync} to be Left{reason}, ")
                .Given(() => Subject)
                .ForCondition(subject => Run(() => subject.IsLeft))
                .FailWith("but found to be Right.");

            return new AndWhichConstraint<LanguageExtEitherAsyncAssertions<TL, TR>, TL>(this, Run(() => Subject.LeftAsEnumerable()));
        }

        public AndConstraint<LanguageExtEitherAsyncAssertions<TL, TR>> BeLeft(Action<TL> action, string because = "", params object[] becauseArgs)
        {
            BeLeft(because, becauseArgs);
            Subject.IfLeft(action);

            return new AndConstraint<LanguageExtEitherAsyncAssertions<TL, TR>>(this);
        }

        public AndWhichConstraint<LanguageExtEitherAsyncAssertions<TL, TR>, TR> BeRight(string because = "", params object[] becauseArgs)
        {
            Execute.Assertion
                .BecauseOf(because, becauseArgs)
                .WithExpectation("Expected {context:eitherasync} to be Right{reason}, ")
                .Given(() => Subject)
                .ForCondition(subject => Run(() => subject.IsRight))
                .FailWith("but found to be Left.");

            return new AndWhichConstraint<LanguageExtEitherAsyncAssertions<TL, TR>, TR>(this, Run(() => Subject.RightAsEnumerable()));
        }

        public AndConstraint<LanguageExtEitherAsyncAssertions<TL, TR>> BeRight(Action<TR> action, string because = "", params object[] becauseArgs)
        {
            BeRight(because, becauseArgs);
            Subject.IfRight(action);

            return new AndConstraint<LanguageExtEitherAsyncAssertions<TL, TR>>(this);
        }

        public AndConstraint<LanguageExtEitherAsyncAssertions<TL, TR>> BeBottom(string because = "", params object[] becauseArgs)
        {
            Execute.Assertion
                .BecauseOf(because, becauseArgs)
                .WithExpectation("Expected {context:eitherasync} to be Bottom{reason}, ")
                .Given(() => Subject)
                .ForCondition(subject => Run(() => subject.IsBottom))
                .FailWith("but found to be either Left or Right.");

            return new AndConstraint<LanguageExtEitherAsyncAssertions<TL, TR>>(this);
        }

        public AndConstraint<LanguageExtEitherAsyncAssertions<TL, TR>> Be(TL expected, string because = "", params object[] becauseArgs)
        {
            Execute.Assertion
                .BecauseOf(because, becauseArgs)
                .WithExpectation("Expected {context:eitherasync} to be Left {0}{reason}, ", expected)
                .Given(() => Subject)
                .ForCondition(subject => Run(() => subject.IsLeft))
                .FailWith("but found to be Right")
                .Then
                .ForCondition(subject => Run(() => subject == expected))
                .FailWith("but found to be Left {0}", Subject);

            return new AndConstraint<LanguageExtEitherAsyncAssertions<TL, TR>>(this);
        }

        public AndConstraint<LanguageExtEitherAsyncAssertions<TL, TR>> Be(TR expected, string because = "", params object[] becauseArgs)
        {
            Execute.Assertion
                .BecauseOf(because, becauseArgs)
                .WithExpectation("Expected {context:eitherasync} to be Right {0}{reason}, ", expected)
                .Given(() => Subject)
                .ForCondition(subject => Run(() => subject.IsRight))
                .FailWith("but found to be Left")
                .Then
                .ForCondition(subject => Run(() => subject == expected))
                .FailWith("but found to be Right {0}", Subject);

            return new AndConstraint<LanguageExtEitherAsyncAssertions<TL, TR>>(this);
        }
    }
}
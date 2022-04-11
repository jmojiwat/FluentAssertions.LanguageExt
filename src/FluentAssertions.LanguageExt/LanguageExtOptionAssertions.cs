using System;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using LanguageExt;

namespace FluentAssertions.LanguageExt
{
    public class LanguageExtOptionAssertions<T> : ReferenceTypeAssertions<Option<T>, LanguageExtOptionAssertions<T>>
    {
        public LanguageExtOptionAssertions(Option<T> instance) : base(instance)
        {
        }

        protected override string Identifier => "option";

        public AndConstraint<LanguageExtOptionAssertions<T>> BeNone(string because = "", params object[] becauseArgs)
        {
            Execute.Assertion
                .BecauseOf(because, becauseArgs)
                .WithExpectation("Expected {context:option} to be None{reason}, ")
                .Given(() => Subject)
                .ForCondition(subject => subject.IsNone)
                .FailWith("but found to be Some.");

            return new AndConstraint<LanguageExtOptionAssertions<T>>(this);
        }

        public AndConstraint<LanguageExtOptionAssertions<T>> BeSome(string because = "", params object[] becauseArgs)
        {
            Execute.Assertion
                .BecauseOf(because, becauseArgs)
                .WithExpectation("Expected {context:option} to be Some{reason}, ")
                .Given(() => Subject)
                .ForCondition(subject => subject.IsSome)
                .FailWith("but found to be None.");

            return new AndConstraint<LanguageExtOptionAssertions<T>>(this);
        }

        public AndConstraint<LanguageExtOptionAssertions<T>> BeSome(Action<T> action, string because = "", params object[] becauseArgs)
        {
            BeSome(because, becauseArgs);
            Subject.IfSome(action);

            return new AndConstraint<LanguageExtOptionAssertions<T>>(this);
        }

        public AndConstraint<LanguageExtOptionAssertions<T>> Be(T expected, string because = "", params object[] becauseArgs)
        {
            Execute.Assertion
                .BecauseOf(because, becauseArgs)
                .WithExpectation("Expected {context:option} to be Some {0}{reason}, ", expected)
                .Given(() => Subject)
                .ForCondition(subject => subject.IsSome)
                .FailWith("but found to be None.")
                .Then
                .ForCondition(subject => subject.Equals(expected))
                .FailWith("but found Some {0}.", Subject);

            return new AndConstraint<LanguageExtOptionAssertions<T>>(this);
        }
    }
}

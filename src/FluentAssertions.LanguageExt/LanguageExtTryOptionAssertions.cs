using System;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using LanguageExt;

namespace FluentAssertions.LanguageExt
{
    public class LanguageExtTryOptionAssertions<T> : ReferenceTypeAssertions<TryOption<T>, LanguageExtTryOptionAssertions<T>>
    {
        public LanguageExtTryOptionAssertions(TryOption<T> instance) : base(instance)
        {
        }

        protected override string Identifier => "tryoption";

        public AndConstraint<LanguageExtTryOptionAssertions<T>> BeFail(string because = "", params object[] becauseArgs)
        {
            Execute.Assertion
                .BecauseOf(because, becauseArgs)
                .WithExpectation("Expected {context:tryoption} to be Fail{reason}, ")
                .Given(() => Subject)
                .ForCondition(subject => subject.IsFail())
                .FailWith("but found to be not.");

            return new AndConstraint<LanguageExtTryOptionAssertions<T>>(this);
        }

        public AndConstraint<LanguageExtTryOptionAssertions<T>> BeSome(string because = "", params object[] becauseArgs)
        {
            Execute.Assertion
                .BecauseOf(because, becauseArgs)
                .WithExpectation("Expected {context:tryoption} to be Some{reason}, ")
                .Given(() => Subject)
                .ForCondition(subject => subject.IsSome())
                .FailWith("but found to be not.");

            return new AndConstraint<LanguageExtTryOptionAssertions<T>>(this);
        }

        public AndConstraint<LanguageExtTryOptionAssertions<T>> BeSome(Action<T> action, string because = "", params object[] becauseArgs)
        {
            BeSome(because, becauseArgs);
            Subject.IfSome(action);

            return new AndConstraint<LanguageExtTryOptionAssertions<T>>(this);
        }

        public AndConstraint<LanguageExtTryOptionAssertions<T>> BeNone(string because = "", params object[] becauseArgs)
        {
            Execute.Assertion
                .BecauseOf(because, becauseArgs)
                .WithExpectation("Expected {context:tryoption} to be None{reason}, ")
                .Given(() => Subject)
                .ForCondition(subject => subject.IsNone())
                .FailWith("but found to be not.");

            return new AndConstraint<LanguageExtTryOptionAssertions<T>>(this);
        }

        public AndConstraint<LanguageExtTryOptionAssertions<T>> Be(T expected, string because = "", params object[] becauseArgs)
        {
            Execute.Assertion
                .BecauseOf(because, becauseArgs)
                .WithExpectation("Expected {context:tryoption} to be {0}{reason}, ", expected)
                .Given(() => Subject)
                .ForCondition(subject => subject.IsSome())
                .FailWith("but found to be None.")
                .Then
                .ForCondition(subject => subject() == expected)
                .FailWith("but found to be {0}.", Subject());

            return new AndConstraint<LanguageExtTryOptionAssertions<T>>(this);
        }

        public AndConstraint<LanguageExtTryOptionAssertions<T>> BeNoneOrFail(string because = "", params object[] becauseArgs)
        {
            Execute.Assertion
                .BecauseOf(because, becauseArgs)
                .WithExpectation("Expected {context:tryoption} to be None or Fail{reason}, ")
                .Given(() => Subject)
                .ForCondition(subject => subject.IsNoneOrFail())
                .FailWith("but found to be not.");

            return new AndConstraint<LanguageExtTryOptionAssertions<T>>(this);
        }
    }
}
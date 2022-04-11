using System;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using LanguageExt;

namespace FluentAssertions.LanguageExt
{
    public class LanguageExtTryAssertions<T> : ReferenceTypeAssertions<Try<T>, LanguageExtTryAssertions<T>>
    {
        public LanguageExtTryAssertions(Try<T> instance) : base(instance)
        {
        }

        protected override string Identifier => "try";

        public AndConstraint<LanguageExtTryAssertions<T>> BeFail(string because = "", params object[] becauseArgs)
        {
            Execute.Assertion
                .BecauseOf(because, becauseArgs)
                .WithExpectation("Expected {context:try} to be Fail{reason}, ")
                .Given(() => Subject)
                .ForCondition(subject => subject.IsFail())
                .FailWith("but found to be not.");

            return new AndConstraint<LanguageExtTryAssertions<T>>(this);
        }

        public AndConstraint<LanguageExtTryAssertions<T>> BeSuccess(string because = "", params object[] becauseArgs)
        {
        

            Execute.Assertion
                .BecauseOf(because, becauseArgs)
                .WithExpectation("Expected {context:try} to be Success{reason}, ")
                .Given(() => Subject)
                .ForCondition(subject => subject.IsSucc())
                .FailWith("but found to be not.");

            return new AndConstraint<LanguageExtTryAssertions<T>>(this);
        }

        public AndConstraint<LanguageExtTryAssertions<T>> BeSuccess(Action<T> action, string because = "", params object[] becauseArgs)
        {
            BeSuccess(because, becauseArgs);
            Prelude.ignore(Subject.IfSucc(action));

            return new AndConstraint<LanguageExtTryAssertions<T>>(this);
        }

        public AndConstraint<LanguageExtTryAssertions<T>> Be(T expected, string because = "", params object[] becauseArgs)
        {
            Execute.Assertion
                .BecauseOf(because, becauseArgs)
                .WithExpectation("Expected {context:try} to be {0}{reason}, ", expected)
                .Given(() => Subject)
                .ForCondition(subject => subject.IsSucc())
                .FailWith("but found to be not.")
                .Then
                .ForCondition(subject => subject() == expected)
                .FailWith("but found to be {0}.", Subject());


            return new AndConstraint<LanguageExtTryAssertions<T>>(this);
        }
    }
}
using System;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using LanguageExt;
using static Nito.AsyncEx.AsyncContext;

namespace FluentAssertions.LanguageExt
{
    public class LanguageExtTryAsyncAssertions<T> : ReferenceTypeAssertions<TryAsync<T>, LanguageExtTryAsyncAssertions<T>>
    {
        public LanguageExtTryAsyncAssertions(TryAsync<T> instance) : base(instance)
        {
        }

        protected override string Identifier => "tryasync";

        public AndConstraint<LanguageExtTryAsyncAssertions<T>> BeFail(string because = "", params object[] becauseArgs)
        {
            Execute.Assertion
                .BecauseOf(because, becauseArgs)
                .WithExpectation("Expected {context:tryasync} to be Fail{reason}, ")
                .Given(() => Subject)
                .ForCondition(subject => Run(subject.IsFail))
                .FailWith("but found to be not.");

            return new AndConstraint<LanguageExtTryAsyncAssertions<T>>(this);
        }

        public AndConstraint<LanguageExtTryAsyncAssertions<T>> BeSuccess(string because = "", params object[] becauseArgs)
        {
            Execute.Assertion
                .BecauseOf(because, becauseArgs)
                .WithExpectation("Expected {context:tryasync} to be Success{reason}, ")
                .Given(() => Subject)
                .ForCondition(subject => Run(subject.IsSucc))
                .FailWith("but found to be not.");

            return new AndConstraint<LanguageExtTryAsyncAssertions<T>>(this);
        }

        public AndConstraint<LanguageExtTryAsyncAssertions<T>> BeSuccess(Action<T> action, string because = "", params object[] becauseArgs)
        {
            BeSuccess(because, becauseArgs);
            Run(async () => (await Subject()).IfSucc(action));

            return new AndConstraint<LanguageExtTryAsyncAssertions<T>>(this);
        }

        public AndConstraint<LanguageExtTryAsyncAssertions<T>> Be(T expected, string because = "", params object[] becauseArgs)
        {
            Execute.Assertion
                .BecauseOf(because, becauseArgs)
                .WithExpectation("Expected {context:tryasync} to be {0}{reason}, ", expected)
                .Given(() => Subject)
                .ForCondition(subject => Run(subject.IsSucc))
                .FailWith("but found to be Fail.")
                .Then
                .ForCondition(subject => Run(async () => (await subject)() == expected))
                .FailWith("but found to be {0}.", Run(async () => (await Subject)()));

            return new AndConstraint<LanguageExtTryAsyncAssertions<T>>(this);
        }

    }
}
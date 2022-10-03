using System;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using LanguageExt;
using LanguageExt.Common;
using static FluentAssertions.LanguageExt.FunctionalAssertionExtensions;

namespace FluentAssertions.LanguageExt
{
    public class LanguageExtFinAssertions<T> : ReferenceTypeAssertions<Fin<T>, LanguageExtFinAssertions<T>>
    {
        public LanguageExtFinAssertions(Fin<T> subject) : base(subject)
        {
        }

        protected override string Identifier => "fin";

        public AndConstraint<LanguageExtFinAssertions<T>> Be(T expected, string because = "", params object[] becauseArgs) => 
            Execute.Assertion
                .BecauseOf(because, becauseArgs)
                .WithExpectation("Expected {context:fin} to be {0}{reason}, ", expected)
                .Given(() => Subject)
                .ForCondition(subject => subject.IsSucc)
                .FailWith("but found to be not.")
                .Then
                .ForCondition(subject => subject == expected)
                .FailWith("but found to be {0}.", (T)Subject)
                .Apply(_ => ContinueAnd(this));

        public AndWhichConstraint<LanguageExtFinAssertions<T>, T> BeSuccess(string because = "", params object[] becauseArgs) =>
            Execute.Assertion
                .BecauseOf(because, becauseArgs)
                .WithExpectation("Expected {context:fin} to be Success{reason}, ")
                .Given(() => Subject)
                .ForCondition(subject => subject.IsSucc)
                .FailWith("but found to be not.")
                .Apply(_ => ContinueWhich(this, (T)Subject));

        public AndConstraint<LanguageExtFinAssertions<T>> BeSuccess(Action<T> action, string because = "", params object[] becauseArgs) =>
            BeSuccess(because, becauseArgs)
                .Apply(a => a.And.Subject.IfSucc(action))
                .Apply(_ => ContinueAnd(this));

        public AndWhichConstraint<LanguageExtFinAssertions<T>, Error> BeFail(string because = "", params object[] becauseArgs) =>
            Execute.Assertion
                .BecauseOf(because, becauseArgs)
                .WithExpectation("Expected {context:fin} to be Fail{reason}, ")
                .Given(() => Subject)
                .ForCondition(subject => subject.IsFail)
                .FailWith("but found to be not.")
                .Apply(_ => ContinueWhich(this, Subject.Match(_ => default, error => error)));

        public AndConstraint<LanguageExtFinAssertions<T>> BeBottom(string because = "", params object[] becauseArgs) =>
            Execute.Assertion
                .BecauseOf(because, becauseArgs)
                .WithExpectation("Expected {context:fin} to be Bottom{reason}, ")
                .Given(() => Subject)
                .ForCondition(subject => subject.IsBottom)
                .FailWith("but found to be not.")
                .Apply(_ => ContinueAnd(this));
    }
}

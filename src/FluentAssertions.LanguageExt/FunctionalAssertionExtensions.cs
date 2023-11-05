namespace FluentAssertions.LanguageExt
{
    internal static class FunctionalAssertionExtensions
    {
        internal static AndWhichConstraint<TParent, TContinuation> ContinueWhich<TParent, TContinuation>(
            TParent originalConstraint, TContinuation continuationValue) => new AndWhichConstraint<TParent, TContinuation>(originalConstraint, continuationValue);

        internal static AndConstraint<TParent> ContinueAnd<TParent>(TParent originalConstraint) => new AndConstraint<TParent>(originalConstraint);
    }
}

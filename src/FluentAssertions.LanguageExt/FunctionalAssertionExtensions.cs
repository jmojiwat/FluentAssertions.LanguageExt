namespace FluentAssertions.LanguageExt
{
    internal static class FunctionalAssertionExtensions
    {
        internal static AndWhichConstraint<TParent, TContinuation> ContinueWhich<TParent, TContinuation>(
            TParent originalConstraint, TContinuation continuationValue) => new(originalConstraint, continuationValue);

        internal static AndConstraint<TParent> ContinueAnd<TParent>(TParent originalConstraint) => new(originalConstraint);
    }
}

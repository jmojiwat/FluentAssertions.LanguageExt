using LanguageExt;
using LanguageExt.TypeClasses;

namespace FluentAssertions.LanguageExt
{
    public static class LanguageExtAssertionsExtensions
    {
        public static LanguageExtOptionAsyncAssertions<T> Should<T>(this OptionAsync<T> instance) => new LanguageExtOptionAsyncAssertions<T>(instance);

        public static LanguageExtEitherAssertions<TL, TR> Should<TL, TR>(this Either<TL, TR> instance) => new LanguageExtEitherAssertions<TL, TR>(instance);

        public static LanguageExtEitherAsyncAssertions<TL, TR> Should<TL, TR>(this EitherAsync<TL, TR> instance) =>
            new LanguageExtEitherAsyncAssertions<TL, TR>(instance);

        public static LanguageExtEitherUnsafeAssertions<TL, TR> Should<TL, TR>(this EitherUnsafe<TL, TR> instance) =>
            new LanguageExtEitherUnsafeAssertions<TL, TR>(instance);

        public static LanguageExtMonoidValidationAssertions<TMonoidalFail, TFail, TSuccess>
            Should<TMonoidalFail, TFail, TSuccess>(this Validation<TMonoidalFail, TFail, TSuccess> instance)
            where TMonoidalFail : struct, Monoid<TFail>, Eq<TFail> =>
            new LanguageExtMonoidValidationAssertions<TMonoidalFail, TFail, TSuccess>(instance);

        public static LanguageExtOptionBoolAssertions Should(this Option<bool> instance) => new LanguageExtOptionBoolAssertions(instance);

        public static LanguageExtOptionAsyncBoolAssertions Should(this OptionAsync<bool> instance) => new LanguageExtOptionAsyncBoolAssertions(instance);

        public static LanguageExtOptionAssertions<T> Should<T>(this Option<T> instance) => new LanguageExtOptionAssertions<T>(instance);
    
        public static LanguageExtOptionUnsafeAssertions<T> Should<T>(this OptionUnsafe<T> instance) => new LanguageExtOptionUnsafeAssertions<T>(instance);

        public static LanguageExtValidationAssertions<TFail, TSuccess> Should<TFail, TSuccess>(
            this Validation<TFail, TSuccess> instance) => new LanguageExtValidationAssertions<TFail, TSuccess>(instance);

        public static LanguageExtTryAssertions<T> Should<T>(this Try<T> instance) => new LanguageExtTryAssertions<T>(instance);

        public static LanguageExtTryAsyncAssertions<T> Should<T>(this TryAsync<T> instance) => new LanguageExtTryAsyncAssertions<T>(instance);

        public static LanguageExtTryOptionAsyncAssertions<T> Should<T>(this TryOptionAsync<T> instance) => new LanguageExtTryOptionAsyncAssertions<T>(instance);

        public static LanguageExtTryOptionAssertions<T> Should<T>(this TryOption<T> instance) => new LanguageExtTryOptionAssertions<T>(instance);

        public static LanguageExtFinAssertions<T> Should<T>(this Fin<T> instance) => new LanguageExtFinAssertions<T>(instance);
    }
}
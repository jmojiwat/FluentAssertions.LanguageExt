## FluentAssertions.LanguageExt

* See [LanguageExt](https://github.com/louthy/language-ext/) C# Functional Programming Language Extensions for more information about functional-programming 'base class library'.
* See [FluentAssertions](https://fluentassertions.com/) for more information about the extensive set of extension methods for unit tests.

## Option, OptionAsync and OptionUnsafe

### Available extension methods

- `BeSome()`
- `BeSome(expected)`
- `BeNone()`

## Either, EitherAsync and EitherUnsafe

### Available extension methods

- `Be(expected)`
- `BeLeft()`
- `BeRight()`
- `BeBottom()`

## Validation

### Available extension methods

- `BeFail()`
- `BeSuccess()`

## Try and TryAsync

### Available extension methods

- `BeFail()`
- `BeSuccess()`

## TryOption and TryAsyncOption

### Available extension methods

- `BeFail()`
- `BeSome()`
- `BeNone()`
- `BeNoneOrFail()`

### Usage

```c#
using FluentAssertions;
using FluentAssertions.LanguageExt;

... 
var option = Prelude.Some(123);
option.Should().BeSome();
```

# FluentAssertions.LanguageExt

* See [LanguageExt](https://github.com/louthy/language-ext/) C# Functional Programming Language Extensions for more information about functional-programming 'base class library'.
* See [FluentAssertions](https://fluentassertions.com/) for more information about the extensive set of extension methods for unit tests.

Special thanks to [@sparerd](https://github.com/sparerd) for the many new features.

## Nuget

```Install-Package FluentAssertions.LanguageExt```

[FluentAssertions.LanguageExt](https://www.nuget.org/packages/FluentAssertions.LanguageExt/)

### Option, OptionAsync and OptionUnsafe

#### Methods

- `BeSome()`
- `BeSome(expected)`
- `BeSome(action)`
- `BeNone()`

#### Example Usage
```c#
using FluentAssertions;
using FluentAssertions.LanguageExt;

... 
var option = Prelude.Some(123);
var optionnone = Option<int>.None;

option.Should().BeSome();
option.Should().BeSome(8);
option.Should().BeSome(s => s.Should().Be(8));
option.Should().BeSome().Which.Should().Be(8);

optionnone.Should().BeNone();
```

### Either, EitherAsync and EitherUnsafe

#### Methods

- `Be(expected)`
- `BeLeft()`
- `BeLeft(action)`
- `BeRight()`
- `BeRight(action)`
- `BeBottom()`

#### Example Usage
```c#
using FluentAssertions;
using FluentAssertions.LanguageExt;

... 
Either<int, string> left = Prelude.Left(8);
Either<int, string> right = Prelude.Right("a");

left.Should().BeLeft();
left.Should().BeLeft(l => l.Should().Be(8));
left.Should().BeLeft().Which.Should().Be(8);
left.Should().Be(8);

right.Should().BeRight();
right.Should().BeRight(r => r.Should().Be("a"));
right.Should().BeRight().Which.Should().Be("a");
right.Should().Be("a");
```

### Validation

#### Breaking Change for 0.3.1

There's a breaking change when using `BeFail()` with the .Which extension.

When using the `BeFail()` assertion on a `Validation<TFail, TSucc>`, the `.Which` extension returns only a single failure instance even though the `Validation` type has a `Seq<TFail>`. This prevents proper assertions on the failures returned from a `Validation` using the `.Which` extension.

This has now been fixed.

The return signature for `BeFail()` has changed from `AndWhichConstraint<LanguageExtValidationAssertions<TFail, TSuccess>, TFail>` to `AndWhichConstraint<LanguageExtValidationAssertions<TFail, TSuccess>, Seq<TFail>>`

#### Methods

- `BeFail()`
- `BeSuccess()`
- `BeSuccess(action)`
- `Be(expected)`

### Try and TryAsync

#### Methods

- `BeFail()`
- `BeSuccess()`

### TryOption and TryAsyncOption

#### Methods

- `BeFail()`
- `BeSome()`
- `BeSome(action)`
- `BeNone()`
- `BeNoneOrFail()`
- `Be(expected)`

### Fin

#### Methods
- `BeSuccess()`
- `BeSuccess(action)`
- `BeFail()`
- `BeBottom()`
- `Be(expected)`

#### Example Usage
```c#
using FluentAssertions;
using FluentAssertions.LanguageExt;

... 
Fin<int> successFin = Prelude.FinSucc(8);
Fin<int> failedFin = Prelude.FinFail<int>("Error message");

successFin.Should().BeSuccess();
successFin.Should().BeSuccess(v => v.Should().Be(8));
successFin.Should().BeSuccess().Which.Should().Be(8);
successFin.Should().Be(8);

failedFin.Should().BeFail();
failedFin.Should().BeFail().Which.Message.Should().Be("Error message");
```

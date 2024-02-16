# CLSS.ExtensionMethods.Object.ToStringFormattedBy

### Problem

[`System.String.Format`](https://docs.microsoft.com/en-us/dotnet/api/system.string.format?view=net-6.0) fulfills its role well in a general context. However, its syntax does not particularly lend itself well to functional-style call chain.

```csharp
using Newtonsoft.Json.Linq;

var queriedNode = JToken.Parse(rawJSON)
  .SelectToken(jsonPath)
  .Value<bool>();
var deprecationLabel = String.Format("This is an deprecated entry? {0}", queriedNode);
```

### Solution

`ToStringFormattedBy` is an extension method created with functional syntax in mind. In your code, it conveys the intent of transforming an object into string form in a particular format more expressively.

```csharp
using CLSS;
using Newtonsoft.Json.Linq;

var deprecationLabel = JToken.Parse(rawJSON)
  .SelectToken(jsonPath)
  .Value<bool>()
  .ToStringFormattedBy("This is an deprecated entry? {0}");
```

The format string taken in by `ToStringFormattedBy` follows the same rules and syntax of [composite formatting](https://docs.microsoft.com/en-us/dotnet/standard/base-types/composite-formatting). Follow that link to learn more.

`ToStringFormattedBy` also takes in trailing variadic arguments. Since the source object calling `ToStringFormattedBy` will replace format item at index 0, trailing arguments following the format string will start at format index 1.

```csharp
using CLSS;

// convert into some kind of subtitles markup
dialogue.ToStringFormattedBy("<color={1}>{2}</color>: {0}", character.ColorCode, character.Name);
```

Optionally, `ToStringFormattedBy` also takes in an [`IFormatProvider`](https://docs.microsoft.com/en-us/dotnet/api/system.iformatprovider?view=net-6.0) if passed in before the format string. This overload also takes in trailing variadic arguments.

```csharp
using CLSS;

today.ToStringFormattedBy(customCultureInfo, "Today is {0}");
```

You can also call `ToStringFormattedBy` on any [`ICollection`](https://docs.microsoft.com/en-us/dotnet/api/system.collections.icollection?view=net-6.0) or [`ICollection<T>`](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.icollection-1?view=net-6.0). The format items in the format string will map to elements in the source array in order of index number. Any trailing variadic argument the overloads for array take in will map to format items starting at the index number equivalent to the source collection's length.

```csharp
using CLSS;

var versionDigits = new int[] { 1, 5, 3 };
var versionString = versionDigits.ToStringFormattedBy("{0}.{1}.{2}"); // "1.5.3"
```

##### This package is a part of the [C# Language Syntactic Sugar suite](https://github.com/tonygiang/CLSS).
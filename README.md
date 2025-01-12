# net9-culture-issues

# Intro
After upgrading our Maui/iOS projects from .NET8 to .NET9 we had some issues/crashes.
After some troubleshooting we found out that the behavior of String.IndexOf() is inconsitent in .NET9, on iOS when running a different culture. Or at least when the culture is set.

# Issue 
String.IndexOf() returns incorrect values.

```
// Should always return -1

var i = "".IndexOf(" ")

// Since it cannot find a space in an empty string it should return -1
```

The above scenario should return -1 on all cultures. On iOS it return 0 after setting cultures.
This lead to problems since the code thinks the string is found.
The Solution is to use the specify the StringComparison type, however this cannot be guaranteed for External libraries!

The above IndexOf is culture specific and translates to 
```
CultureInfo.CurrentCulture.CompareInfo.IndexOf(this, value, startIndex, count, GetCaseCompareOfComparisonCulture(comparisonType))
```

There are probably some culture issues introduced in the .NET 9 update, leading to very inconsistent string behavior when cultures are used on (at least) the iOS platform

# Repro
- Install dotnet 9 ios workload
- Open the solution 'iOSApp1'.
- Run on iPhone 15 or 16 emulator
- The AppDelegate.cs runs the tests and displays the results. -1 is expected like on .NET8 and other platforms, however it returns 0 


# Environment
MacBook Intel Sequoia 15.2
iPhone 15 / 16 emulator
XCode 16.2
Dotnet version 9.0.101
ios workload 18.2.9170/9.0.100 
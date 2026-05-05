# UrlBuilder.Core

UrlBuilder.Core is a lightweight .NET library designed to simplify URL construction with a fluent API. It allows developers to build URLs programmatically.


## Features

* **Fluent Interface**: Easily chain methods to build complex URLs.
* **Separation of Concerns**: Keeps URL logic out of your business components.
* **Fully Tested**: Includes xUnit tests for edge cases.


## Usage

Here's a simple example of how to use UrlBuilder.Core:

```csharp
using UrlBuilder.Core;

string url = new UrlNavigator()
    .SetController("Home")
    .SetAction("Index")
    .setParameter("test", "123")
    .Build();

Console.WriteLine(url); 
// Outputs: /Home/Index?test=123
```

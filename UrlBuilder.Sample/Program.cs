using UrlBuilder.Core;

Console.WriteLine("--- UrlBuilder Sample ---");

// Create an instance of UrlNavigator and use it to build a URLs
var navigator = new UrlNavigator();

// Build a URL to search an employee by id
var payrollUrl = navigator
    .SetController("Financials")
    .SetAction("Payroll")
    .AddParameter("employeeId", "99")
    .Build();

Console.WriteLine($"Payroll URL: {payrollUrl}");

// Build a URL to test special characters in parameters
var searchUrl = navigator
    .SetController("Search")
    .SetAction("Results")
    .AddParameter("query", "C# URL Builder")
    .Build();

Console.WriteLine($"Search URL: {searchUrl}");

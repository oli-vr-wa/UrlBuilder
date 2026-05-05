using UrlBuilder.Core;

namespace UrlBuilder.Tests;

public class UrlNavigatorTests
{
    /// <summary>
    /// This test verifies that the UrlNavigator correctly formats a URL with a controller, action, and multiple parameters. 
    /// It checks that the resulting URL string matches the expected format, including proper encoding of parameter values.
    /// </summary>
    [Fact]
    public void Should_Format_Url_Correctly()
    {
        // Arrange
        var navigator = new UrlNavigator();
            
        // Act
        var url = navigator
            .SetController("Home")
            .SetAction("Index")
            .AddParameter("id", "123")
            .AddParameter("name", "John")
            .Build();

        // Assert
        Assert.Equal("/Home/Index?id=123&name=John", url);
    }

    /// <summary>
    /// This test verifies that the UrlNavigator can handle cases where no parameters are added. It checks that the resulting URL string is correctly formatted with just the controller and action, without any query parameters.
    /// </summary>
    [Fact]
    public void Should_Handle_Empty_Parameters()
    {
        // Arrange
        var navigator = new UrlNavigator();
            
        // Act
        var url = navigator
            .SetController("Home")
            .SetAction("Index")
            .Build();

        // Assert
        Assert.Equal("/Home/Index", url);
    }

    /// <summary>
    /// This test verifies that the UrlNavigator correctly encodes special characters in parameter values. It checks that the resulting URL string contains the properly encoded parameter values.
    /// </summary>
    [Fact]
    public void Should_Handle_Special_Characters_In_Parameters()
    {
        // Arrange
        var navigator = new UrlNavigator();
            
        // Act
        var url = navigator
            .SetController("Home")
            .SetAction("Index")
            .AddParameter("name", "John Doe")
            .AddParameter("city", "New York")
            .Build();

        // Assert
        Assert.Equal("/Home/Index?name=John%20Doe&city=New%20York", url);
    }

    /// <summary>
    /// This test verifies that the UrlNavigator correctly overrides existing parameters when the same parameter key is added multiple times. 
    /// It checks that the resulting URL string contains the last value provided for the parameter key, confirming that the previous value was overridden as expected.
    /// </summary>
    [Fact]
    public void Should_Override_Existing_Parameters()
    {
        // Arrange
        var navigator = new UrlNavigator();
            
        // Act
        var url = navigator
            .SetController("Home")
            .SetAction("Index")
            .AddParameter("id", "123")
            .AddParameter("id", "456") // This should override the previous "id" parameter
            .Build();

        // Assert
        Assert.Equal("/Home/Index?id=456", url);
    }

    /// <summary>
    /// This test verifies that the UrlNavigator throws an InvalidOperationException when either the controller or action is not set before 
    /// building the URL.
    /// </summary>
    [Fact]
    public void Should_Throw_Exception_If_Controller_Or_Action_Is_Missing()
    {
        // Arrange
        var navigator = new UrlNavigator();
            
        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => navigator.Build());
    }
}

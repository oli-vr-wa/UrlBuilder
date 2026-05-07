namespace UrlBuilder.Core;

/// <summary>
/// This class allows you to fluently set the controller, action, and parameters, and then build the final URL string.
/// </summary>
public class UrlNavigator
{    
    /// <summary>
    /// The controller for the URL. This is typically the name of the controller in your MVC application that you want to navigate to.
    /// </summary>
    private string _controller = string.Empty;

    /// <summary>
    /// The action for the URL. This is typically the method name in the controller that you want to navigate to.
    /// </summary>
    private string _action = string.Empty;

    /// <summary>
    /// A dictionary to hold the parameters for the URL. The key is the parameter name and the value is the parameter value.
    /// </summary>
    private readonly Dictionary<string, string> _parameters = [];

    /// <summary>
    /// Sets the controller for the URL. This method returns the UrlNavigator instance to allow for method chaining.
    /// </summary>
    /// <param name="controller">The controller for the URL.</param>
    /// <returns></returns>
    public UrlNavigator SetController(string controller)
    {
        _controller = controller;
        return this;
    }

    /// <summary>
    /// Sets the action for the URL. This method returns the UrlNavigator instance to allow for method chaining.
    /// </summary>
    /// <param name="action">The action for the URL.</param>
    /// <returns></returns>
    public UrlNavigator SetAction(string action)
    {
        _action = action;
        return this;
    }

    /// <summary>
    /// Adds a parameter to the URL. This method returns the UrlNavigator instance to allow for method chaining.
    /// </summary>
    /// <param name="key">The name of the parameter.</param>
    /// <param name="value">The value of the parameter.</param>
    /// <returns></returns>
    public UrlNavigator AddParameter(string key, string value)
    {
        // Format to ensure that special characters in the parameter values are properly encoded for use in a URL.
        value = Uri.EscapeDataString(value);        

        // If the parameter already exists, it will be overridden with the new value.        
        _parameters[key] = value;
        return this;
    }

    /// <summary>
    /// Builds the final URL string based on the set controller, action, and parameters.
    /// </summary>
    /// <returns>The final URL string.</returns>
    public string Build()
    {
        // Ensure that both controller and action are set before building the URL.
        if (string.IsNullOrEmpty(_controller) || string.IsNullOrEmpty(_action))
        {
            throw new InvalidOperationException("Controller and Action must be set.");
        }

        var url = $"/{_controller}/{_action}";

        // If there are any parameters, append them as a query string to the URL.
        if (_parameters.Any())
        {
            var queryString = string.Join("&", _parameters.Select(p => $"{p.Key}={p.Value}"));
            url += $"?{queryString}";
        }
        
        return url;
    }
}

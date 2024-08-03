using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


public class T2Model : PageModel
{
    // requires using Microsoft.Extensions.Configuration;
    private readonly IConfiguration Configuration;
    private readonly ILogger _logger;


    public T2Model(IConfiguration configuration, ILogger<TestModel> logger)
    {
        Configuration = configuration;
        _logger = logger;
    }

    public ContentResult OnGet()
    {
        _logger.LogInformation("LogInformation T2Model.OnGet executed");
        _logger.LogWarning("LogWarning T2Model.OnGet executed");
        _logger.LogError("T2Model.OnGet executed");
        var MyFloatValue = Configuration["MyFloat"];
        var title = Configuration["Position:Title"];
        var name = Configuration["Position:Name"];
        var defaultLogLevel = Configuration["Logging:LogLevel:Default"];


        return Content($" HELLOE MyFloat value: {MyFloatValue} \n" +
                       $"Title: {title} \n" +
                       $"Name: {name} \n" +
                       $"Default Log Level: {defaultLogLevel}");
    }
}


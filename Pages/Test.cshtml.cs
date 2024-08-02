using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


public class TestModel : PageModel
{
    private readonly IConfiguration Configuration;
    private readonly ILogger _logger;


    public TestModel(IConfiguration configuration, ILogger<TestModel> logger)
    {
        Configuration = configuration;
        _logger = logger;   
    }

    public ContentResult OnGet()
    {
        _logger.LogInformation("TestModel.OnGet executed before exception");
        throw new Exception("This is a simulated error.");
    }
}


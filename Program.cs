var builder = WebApplication.CreateBuilder(args);

var myFloat = builder.Configuration.GetValue<float>("MyFloat");

float myDiv = 0.0f;

builder.Services.AddRazorPages();

var app = builder.Build();
app.Logger.LogError("myFloat: {KeyOne}", myFloat);
app.Logger.LogInformation("myDiv: {KeyOne}", myDiv);

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

if (myFloat == 0)
{
    app.Logger.LogError("Throwing DivideByZeroException");
    throw new DivideByZeroException("Attempted to divide by zero.");
}
else
    myDiv = 1 / myFloat;


app.UseHttpsRedirection();
app.UseDefaultFiles(); // Servers HTML files without .html

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.Map("/map1", HandleMapTest1);

app.MapGet("/2", () => { 
    app.Logger.LogError("Throwing NotImplementedException in /2");
    throw new NotImplementedException(); 
});

app.Run();


static void HandleMapTest1(IApplicationBuilder app)
{
    app.Run(async context =>
    {
        throw new NotImplementedException();

        await context.Response.WriteAsync("Map Test 1");

    });

}
var builder = WebApplication.CreateBuilder(args);
// Add services to the container
builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssemblies(typeof(Program).Assembly);
});

var app = builder.Build();

//configure the http request pipelines 
app.MapCarter();

app.Run();

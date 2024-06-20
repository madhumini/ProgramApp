using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Fluent;
using ProgramCreatorApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add Cosmos DB as a service
builder.Services.AddSingleton<CosmosClient>(InitializeCosmosClientInstance(builder.Configuration.GetSection("CosmosDb")));

// Register services
builder.Services.AddScoped<IProgramService, ProgramService>();
builder.Services.AddScoped<ICandidateService, CandidateService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

static CosmosClient InitializeCosmosClientInstance(IConfigurationSection configurationSection)
{
    string account = configurationSection.GetSection("Account")?.Value;
    string key = configurationSection.GetSection("Key")?.Value;
    string databaseName = configurationSection.GetSection("Database")?.Value;

    if (string.IsNullOrEmpty(account) || string.IsNullOrEmpty(key) || string.IsNullOrEmpty(databaseName))
    {
        throw new ArgumentException("Invalid Cosmos DB configuration. Ensure Account, Key, and Database are configured.");
    }

    CosmosClientBuilder clientBuilder = new CosmosClientBuilder(account, key);
    CosmosClient client = clientBuilder
        .WithConnectionModeDirect()
        .Build();

    return client;
}

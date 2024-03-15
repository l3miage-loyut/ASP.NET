using GameStore.Api.Data;
using GameStore.Api.Endpoints;
using GameStore.Api.Repositories;

var builder = WebApplication.CreateBuilder(args);
// builder.Services.AddSingleton<IGamesRepository, InMemGamesRepository>();
// builder.Services.AddScoped<IGamesRepository, EntityFrameworkGamesRepository>();

// var connString = builder.Configuration.GetConnectionString("GameStoreContext");
// builder.Services.AddSqlServer<GameStoreContext>(connString);
builder.Services.AddRepositories(builder.Configuration);

var app = builder.Build();
await app.Services.InitialzeDbAsync();

app.MapGamesEndpoints();

app.Run();

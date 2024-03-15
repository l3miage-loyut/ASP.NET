using GameStore.Api.Dtos;
using GameStore.Api.Entities;

namespace GameStore.Api.Endpoints;

public static class GamesEndpoints
{

    const string GetGameEndpointName = "GetGame";

    public static RouteGroupBuilder MapGamesEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/games")
                          .WithParameterValidation();

        group.MapGet("/", async (IGamesRepository repository) => (await repository.GetAllAsync()).Select(game => game.AsDto()));

        group.MapGet("/{id}", async (IGamesRepository repository, int id) =>
        {
            Game? game = await repository.GetAsync(id);

            return game is null ? Results.NotFound() : Results.Ok(game.AsDto());
        })
        .WithName(GetGameEndpointName);

        group.MapPost("/", async (IGamesRepository repository, CreateGameDto gameDto) =>
        {
            Game game = new()
            {
                Name = gameDto.Name,
                Genre = gameDto.Genre,
                Price = gameDto.Price,
                ReleaseDate = gameDto.ReleaseDate,
                ImageUri = gameDto.ImageUri
            };

            await repository.CreateAsync(game);

            return Results.CreatedAtRoute(GetGameEndpointName, new { id = game.Id }, game);
        });

        group.MapPut("/{id}", async (IGamesRepository repository, int id, UpdateGameDto updatedGameDto) =>
        {
            Game? existGame = await repository.GetAsync(id);
            if (existGame is null)
            {
                return Results.NotFound();
            }

            existGame.Name = updatedGameDto.Name;
            existGame.Genre = updatedGameDto.Genre;
            existGame.Price = updatedGameDto.Price;
            existGame.ReleaseDate = updatedGameDto.ReleaseDate;
            existGame.ImageUri = updatedGameDto.ImageUri;

            await repository.UpdateAsync(existGame);

            return Results.NoContent();
        });

        group.MapDelete("/{id}", async (IGamesRepository repository, int id) =>
        {
            Game? game = await repository.GetAsync(id);
            if (game is not null)
            {
                await repository.DeleteAsync(id);
            }

            return Results.NoContent();
        });

        return group;
    }
}
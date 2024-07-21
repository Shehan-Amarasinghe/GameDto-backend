using System.Formats.Asn1;
using WebApplication1;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

const string GetGameEndpointName = "GetGame";

List<GameDto> games = [
    new (
        1,
        "Street Fighter II",
        "Fighting",
        "23.99",
        new DateOnly(1992, 7, 15)),
    new (
        2,
        "Final Fanstasy XIV",
        "Roleplaying",
        "18.99",
        new DateOnly(2010, 9, 30))
];

// Get /games
app.MapGet("games", () => games);

// GET /games/1
app.MapGet("games/{id}", (int id) => { 
     GameDto? game = games.Find(game => game.Id == id);

     return game is null ? Results.NotFound() : Results.Ok(game);
  })
  .WithName(GetGameEndpointName);

// POST /games
app.MapPost("games", (CreateGameDto newGame) => {
   GameDto game = new(
        games.Count + 1,
        newGame.Name,
        newGame.Genre,
        newGame.Price,
        newGame.ReleaseDate);

        games.Add(game); 

        return Results.CreatedAtRoute(GetGameEndpointName, new {id = game.Id}, game);
});


// PUT /games
app.MapPut("games/{id}", (int id, UpdateGameDto updatedgame) => {
  var index = games.FindIndex(game => game.Id == id);
  
  games[index] = new GameDto(
    id, 
    updatedgame.Name,
    updatedgame.Genre,
    updatedgame.Price,
    updatedgame.ReleaseDate
    );

    return Results.NoContent();
});

// DELETE /games
app.MapDelete("games/{id}", (int id) => {
  games.RemoveAll(game => game.Id == id);

  return Results.NoContent();
});



app.Run();

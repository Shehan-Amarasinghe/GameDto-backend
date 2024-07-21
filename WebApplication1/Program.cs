using System.Formats.Asn1;
using WebApplication1;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<GameDto> games = [
    new (
        1,
        "Street Fighter II",
        "Fighting",
        "cdb",
        new DateOnly(1992, 7, 15)),
    new (
        2,
        "Final Fanstasy XIV",
        "Roleplaying",
        "abc",
        new DateOnly(2010, 9, 30))
];

// Get /games
app.MapGet("games", () => games);

// GET /games/1
app.MapGet("games/{id}", (int id) => games.Find(game => game.Id == id));

//POST
app.Run();

namespace WebApplication1;

public record class CreateGameDto(
    int Id,
    string Name,
    string Genre,
    string Price,
    DateOnly ReleaseDate
);


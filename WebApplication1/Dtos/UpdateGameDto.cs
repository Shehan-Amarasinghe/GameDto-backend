namespace WebApplication1;

public record class UpdateGameDto(
    int Id,
    string Name,
    string Genre,
    string Price,
    DateOnly ReleaseDate
);

namespace TaekwondoCompetition.Application.Responses;

public record UserResponse(
    int Id,
    string Role,
    string Email
);
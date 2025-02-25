namespace TaekwondoCompetition.Application.Responses;

public record AuthResponse(
    string Token,
    UserResponse User
);
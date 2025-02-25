namespace TaekwondoCompetition.Application.Requests;

public record LoginRequest(
    string Email,
    string Password
);
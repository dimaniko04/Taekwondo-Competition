using TaekwondoCompetition.Core.Enums;

namespace TaekwondoCompetition.Application.Requests;

public record RegisterRequest(
    string Email,
    string Password,
    string FirstName,
    string LastName,
    DateTime BirthDate,
    Sex Sex);
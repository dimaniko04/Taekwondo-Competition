using System.Net;

namespace TaekwondoCompetition.Core.Errors;

public sealed record AppError(HttpStatusCode Code, string Message)
{
    public static readonly AppError None = new(HttpStatusCode.OK, string.Empty);
}
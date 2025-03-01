using System.Net;
using TaekwondoCompetition.Core.Errors;

namespace TaekwondoCompetition.Core.Errors;

public static class Errors
{
    public static class Authentication
    {
        public static readonly AppError UserNotFound = new(HttpStatusCode.NotFound, "User not found");
        public static readonly AppError InvalidCredentials = new(HttpStatusCode.BadRequest, "Invalid user credentials");
    }
}
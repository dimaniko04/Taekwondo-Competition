using TaekwondoCompetition.Core.Errors;
using TaekwondoCompetition.Core.Result;

namespace TaekwondoCompetition.API.Extensions;

internal static class ResultExtensions
{
    public static R Match<T, R>(
        this Result<T> result,
        Func<R> onSuccess,
        Func<AppError, R> onError)
    {
        return result.IsSuccess
            ? onSuccess()
            : onError(result.Error);
    }
}
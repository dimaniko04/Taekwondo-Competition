using TaekwondoCompetition.Application.Interfaces.Persistence.Services;

namespace TaekwondoCompetition.Persistence.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime Now => DateTime.UtcNow;
}
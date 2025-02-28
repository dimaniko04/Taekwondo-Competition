namespace TaekwondoCompetition.Application.Interfaces.Persistence.Services;

public interface IDateTimeProvider
{
    DateTime Now { get; }
}
using TaekwondoCompetition.Core.Entities.Common;

namespace TaekwondoCompetition.Core.Entities;

public class Competition : BaseEntity
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateTime StartDate { get; set; }
    public int Duration { get; set; } = 1;
}
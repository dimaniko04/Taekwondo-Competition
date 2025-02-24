using TaekwondoCompetition.Core.Entities.Common;

namespace TaekwondoCompetition.Core.Entities;

class Club : BaseEntity
{
    public string Name { get; set; } = null!;
    public string Address { get; set; } = null!;
}
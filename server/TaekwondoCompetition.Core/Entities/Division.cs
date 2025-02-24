using TaekwondoCompetition.Core.Entities.Common;
using TaekwondoCompetition.Core.Enums;

namespace TaekwondoCompetition.Core.Entities;

class Division : BaseEntity
{
    public string Name { get; set; } = null!;
    public Sex Sex { get; set; }
    public int MinWeight { get; set; }
    public int MaxWeight { get; set; }
    public int MinAge { get; set; }
    public int MaxAge { get; set; }
}
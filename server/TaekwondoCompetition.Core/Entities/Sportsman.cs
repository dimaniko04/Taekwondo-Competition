using TaekwondoCompetition.Core.Entities.Common;
using TaekwondoCompetition.Core.Enums;

namespace TaekwondoCompetition.Core.Entities;

class Sportsman : BaseEntity
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public DateTime BirthDate { get; set; }
    public Sex Sex { get; set; } = Sex.M;
    public int ClubId { get; set; }

    public Club Club { get; set; } = null!;
}
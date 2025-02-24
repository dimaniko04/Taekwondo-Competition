using TaekwondoCompetition.Core.Entities.Common;

namespace TaekwondoCompetition.Core.Entities;

public class User : BaseEntity
{
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Token { get; set; } = null!;
    public int RoleId { get; set; }

    public Role Role { get; set; } = null!;
}
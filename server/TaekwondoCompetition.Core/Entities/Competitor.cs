namespace TaekwondoCompetition.Core.Entities;

class Competitor
{
    public int SportsmanId { get; set; }
    public int CompetitionId { get; set; }
    public int LapNum { get; set; }
    public int WeightingResult { get; set; }
}
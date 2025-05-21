namespace osrs_toolbox
{
    public class CompetitionParticipation
    {
        public int playerId { get; set; }
        public int competitionId { get; set; }
        public string? teamName { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public Player player { get; set; }
        public ParticipationInfo progress { get; set; }
        public ParticipationInfo levels { get; set; }
    }
}
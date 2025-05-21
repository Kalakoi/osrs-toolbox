namespace osrs_toolbox
{
    public class Snapshot
    {
        public int id { get; set; }
        public int playerId { get; set; }
        public string createdAt { get; set; }
        public string importedAt { get; set; }
        public SnapshotData data { get; set; }
    }
}

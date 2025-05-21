namespace osrs_toolbox
{
    public class Player
    {
        public int id { get; set; }
        public string username { get; set; }
        public string displayName { get; set; }
        public string type { get; set; }
        public string build { get; set; }
        public string status { get; set; }
        public string country { get; set; }
        public bool patron { get; set; }
        public int exp { get; set; }
        public double ehp { get; set; }
        public double ehb { get; set; }
        public double ttm { get; set; }
        public double tt200m { get; set; }
        public string registeredAt { get; set; }
        public string updatedAt { get; set; }
        public string lastChangedAt { get; set; }
        public string lastImportedAt { get; set; }
        public Snapshot? latestSnapshot { get; set; }
        public string[]? annotations { get; set; }
        public int? combatLevel { get; set; }
        public object? archive { get; set; }
    }
}

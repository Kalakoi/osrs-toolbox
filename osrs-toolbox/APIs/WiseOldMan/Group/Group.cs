namespace osrs_toolbox
{
    public class Group
    {
        public int id { get; set; }
        public string name { get; set; }
        public string clanChat { get; set; }
        public string description { get; set; }
        public int homeworld { get; set; }
        public bool verified { get; set; }
        public bool patron { get; set; }
        public bool visible { get; set; }
        public object profileImage { get; set; }
        public object bannerImage { get; set; }
        public int score { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public GroupMembership[]? memberships { get; set; }
        public GroupLinks? socialLinks { get; set; }
        public object[]? roleOrders { get; set; }
        public int memberCount { get; set; }
    }
}

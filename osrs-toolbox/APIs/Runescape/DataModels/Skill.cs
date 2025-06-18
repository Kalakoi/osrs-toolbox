namespace osrs_toolbox
{
    public class Skill : IPlayerInfoProperty
    {
        public string Name { get; set; }
        public int Rank { get; set; }
        public int Level { get; set; }
        public int Experience { get; set; }
    }
}
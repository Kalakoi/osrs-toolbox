﻿namespace osrs_toolbox
{
    public class GroupMembership
    {
        public int playerId { get; set; }
        public int groupId { get; set; }
        public string role { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public Player player { get; set; }
    }
}
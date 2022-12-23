using System.Collections.Generic;

namespace MageStudy.DataEntities
{
    public class LeaderboardEntityData
    {
        public int Page { get; set; }
        public bool IsLast { get; set; }
        public List<LeaderboardEntityData> Data { get; set; }
    }
}
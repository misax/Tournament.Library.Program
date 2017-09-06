using System.Collections.Generic;
using System.Security.AccessControl;

namespace Tournament.Library.Models
{
    public class Matchup
    {
        public int Id { get; set; }
        public List<MatchupEntry> Entries { get; set; } = new List<MatchupEntry>();
        public Team Winner { get; set; }
        public int MatchupRounds { get; set; }

    }
}
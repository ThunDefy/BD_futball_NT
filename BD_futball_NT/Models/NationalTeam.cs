using System;
using System.Collections.Generic;

namespace BD_futball_NT.Models
{
    public partial class NationalTeam
    {
        public NationalTeam()
        {
            MatchIdNteam1Navigations = new HashSet<Match>();
            MatchIdNteam2Navigations = new HashSet<Match>();
            Players = new HashSet<Player>();
        }

        public long IdNteam { get; set; }
        public string NteamName { get; set; } = null!;
        public string NteamCountry { get; set; }
        public long? DateOfFoundation { get; set; }
        public string Coach { get; set; }
        public string Captain { get; set; }
        public string Confederation { get; set; }

        public virtual ICollection<Match> MatchIdNteam1Navigations { get; set; }
        public virtual ICollection<Match> MatchIdNteam2Navigations { get; set; }
        public virtual ICollection<Player> Players { get; set; }
    }
}

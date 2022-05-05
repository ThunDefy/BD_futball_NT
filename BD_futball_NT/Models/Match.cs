using System;
using System.Collections.Generic;

namespace BD_futball_NT.Models
{
    public partial class Match
    {
        public Match()
        {
            Statistics = new HashSet<Statistic>();
        }

        public long IdMatch { get; set; }
        public long IdTournament { get; set; }
        public string MatchDate { get; set; } = null!;
        public long IdNteam1 { get; set; }
        public long IdNteam2 { get; set; }
        public long? Nteam1Score { get; set; }
        public long? Nteam2Score { get; set; }

        public virtual NationalTeam IdNteam1Navigation { get; set; } = null!;
        public virtual NationalTeam IdNteam2Navigation { get; set; } = null!;
        public virtual Tournament IdTournamentNavigation { get; set; } = null!;
        public virtual ICollection<Statistic> Statistics { get; set; }
    }
}

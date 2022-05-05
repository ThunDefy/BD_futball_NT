using System;
using System.Collections.Generic;

namespace BD_futball_NT.Models
{
    public partial class Tournament
    {
        public Tournament()
        {
            Matches = new HashSet<Match>();
            Statistics = new HashSet<Statistic>();
        }

        public long IdTournament { get; set; }
        public string TournamentName { get; set; } = null!;
        public string? TournamentCountry { get; set; }
        public string? StartDate { get; set; }
        public string? EndDate { get; set; }

        public virtual ICollection<Match> Matches { get; set; }
        public virtual ICollection<Statistic> Statistics { get; set; }
    }
}

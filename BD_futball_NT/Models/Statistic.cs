using System;
using System.Collections.Generic;

namespace BD_futball_NT.Models
{
    public partial class Statistic
    {
        public long IdStatistic { get; set; }
        public long IdPlayer { get; set; }
        public long IdTournament { get; set; }
        public long IdMatch { get; set; }
        public long? Shots { get; set; }
        public long? ShotsOt { get; set; }
        public long? KeyPasses { get; set; }
        public long? Pa { get; set; }
        public long? AerialsWon { get; set; }
        public long? Touches { get; set; }
        public long? Rating { get; set; }
        public long? Ycards { get; set; }
        public long? Rcards { get; set; }
        public long? Goals { get; set; }

        public virtual Match IdMatchNavigation { get; set; } = null!;
        public virtual Player IdPlayerNavigation { get; set; } = null!;
        public virtual Tournament IdTournamentNavigation { get; set; } = null!;
    }
}

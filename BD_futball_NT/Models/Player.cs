using System;
using System.Collections.Generic;

namespace BD_futball_NT.Models
{
    public partial class Player
    {
        public Player()
        {
            Statistics = new HashSet<Statistic>();
        }
        public Player(long id)
        {
            IdPlayer = id;
        }

        public long IdPlayer { get; set; }
        public long IdNteam { get; set; }
        public long? PlayerNum { get; set; }
        public string PlayerName { get; set; }
        public long? PlayerAge { get; set; }
        public long? PlayerHeight { get; set; }
        public long? PlayerWeight { get; set; }
        public string? Positions { get; set; }

        public object? this[string property]
        {
            get
            {
                switch (property)
                {
                    case "IdPlayer": return IdPlayer;
                    case "IdNteam": return IdNteam;
                    case "PlayerNum": return PlayerNum;
                    case "PlayerAge": return PlayerAge;
                    case "PlayerHeight": return PlayerHeight;
                    case "PlayerWeight": return PlayerWeight;
                    case "Positions": return Positions;

                }
                return null;
            }
        }

        public virtual NationalTeam IdNteamNavigation { get; set; } = null!;
        public virtual ICollection<Statistic> Statistics { get; set; }
    }
}

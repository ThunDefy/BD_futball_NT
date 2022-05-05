using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BD_futball_NT.Models
{
    public partial class Futball_NTContext : DbContext
    {
        public Futball_NTContext()
        {
        }

        public Futball_NTContext(DbContextOptions<Futball_NTContext> options)
            : base(options)
        {
        }
        private string Path = @"Assets\Futball_NT.db";
        public virtual DbSet<Match> Matches { get; set; } = null!;
        public virtual DbSet<NationalTeam> NationalTeams { get; set; } = null!;
        public virtual DbSet<Player> Players { get; set; } = null!;
        public virtual DbSet<Statistic> Statistics { get; set; } = null!;
        public virtual DbSet<Tournament> Tournaments { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string directoryPath = Directory.GetCurrentDirectory();
                directoryPath = directoryPath.Remove(directoryPath.LastIndexOf("bin"));
                Path = directoryPath + Path;
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlite("Data Source=" + Path);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Match>(entity =>
            {
                entity.HasKey(e => e.IdMatch);

                entity.ToTable("Match");

                entity.HasIndex(e => e.IdMatch, "IX_Match_Id_Match")
                    .IsUnique();

                entity.Property(e => e.IdMatch)
                    .ValueGeneratedNever()
                    .HasColumnName("Id_Match");

                entity.Property(e => e.IdNteam1).HasColumnName("Id_NTeam1");

                entity.Property(e => e.IdNteam2).HasColumnName("Id_NTeam2");

                entity.Property(e => e.IdTournament).HasColumnName("Id_Tournament");

                entity.Property(e => e.MatchDate).HasColumnType("DATE");

                entity.Property(e => e.Nteam1Score)
                    .HasColumnType("INTEGER (3)")
                    .HasColumnName("NTeam1_Score")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Nteam2Score)
                    .HasColumnType("INTEGER (3)")
                    .HasColumnName("NTeam2_Score")
                    .HasDefaultValueSql("0");

                entity.HasOne(d => d.IdNteam1Navigation)
                    .WithMany(p => p.MatchIdNteam1Navigations)
                    .HasForeignKey(d => d.IdNteam1)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.IdNteam2Navigation)
                    .WithMany(p => p.MatchIdNteam2Navigations)
                    .HasForeignKey(d => d.IdNteam2)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.IdTournamentNavigation)
                    .WithMany(p => p.Matches)
                    .HasForeignKey(d => d.IdTournament)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<NationalTeam>(entity =>
            {
                entity.HasKey(e => e.IdNteam);

                entity.ToTable("National_team");

                entity.HasIndex(e => e.IdNteam, "IX_National_team_Id_NTeam")
                    .IsUnique();

                entity.Property(e => e.IdNteam)
                    .ValueGeneratedNever()
                    .HasColumnName("Id_NTeam");

                entity.Property(e => e.Captain).HasColumnType("STRING (100)");

                entity.Property(e => e.Coach).HasColumnType("STRING (100)");

                entity.Property(e => e.Confederation).HasColumnType("STRING (150)");

                entity.Property(e => e.DateOfFoundation).HasColumnType("INTEGER (4)");

                entity.Property(e => e.NteamCountry)
                    .HasColumnType("STRING (100)")
                    .HasColumnName("NTeamCountry");

                entity.Property(e => e.NteamName)
                    .HasColumnType("STRING (100)")
                    .HasColumnName("NTeamName");
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.HasKey(e => e.IdPlayer);

                entity.ToTable("Player");

                entity.HasIndex(e => e.IdPlayer, "IX_Player_Id_Player")
                    .IsUnique();

                entity.Property(e => e.IdPlayer)
                    .ValueGeneratedNever()
                    .HasColumnName("Id_Player");

                entity.Property(e => e.IdNteam).HasColumnName("Id_NTeam");

                entity.Property(e => e.PlayerAge).HasColumnType("INTEGER (3)");

                entity.Property(e => e.PlayerHeight).HasColumnType("INTEGER (3, 2)");

                entity.Property(e => e.PlayerName).HasColumnType("STRING (100)");

                entity.Property(e => e.PlayerNum).HasColumnType("INTEGER (10)");

                entity.Property(e => e.PlayerWeight).HasColumnType("INTEGER (3)");

                entity.Property(e => e.Positions).HasColumnType("STRING (150)");

                entity.HasOne(d => d.IdNteamNavigation)
                    .WithMany(p => p.Players)
                    .HasForeignKey(d => d.IdNteam)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Statistic>(entity =>
            {
                entity.HasKey(e => e.IdStatistic);

                entity.ToTable("Statistic");

                entity.HasIndex(e => e.IdStatistic, "IX_Statistic_Id_Statistic")
                    .IsUnique();

                entity.Property(e => e.IdStatistic)
                    .ValueGeneratedNever()
                    .HasColumnName("Id_Statistic");

                entity.Property(e => e.AerialsWon).HasColumnType("INTEGER (3)");

                entity.Property(e => e.Goals).HasColumnType("INTEGER (3)");

                entity.Property(e => e.IdMatch).HasColumnName("Id_Match");

                entity.Property(e => e.IdPlayer).HasColumnName("Id_Player");

                entity.Property(e => e.IdTournament).HasColumnName("Id_Tournament");

                entity.Property(e => e.KeyPasses).HasColumnType("INTEGER (3)");

                entity.Property(e => e.Pa)
                    .HasColumnType("INTEGER (3)")
                    .HasColumnName("PA%");

                entity.Property(e => e.Rating).HasColumnType("INTEGER (3, 2)");

                entity.Property(e => e.Rcards)
                    .HasColumnType("INTEGER (3)")
                    .HasColumnName("RCards");

                entity.Property(e => e.Shots).HasColumnType("INTEGER (3)");

                entity.Property(e => e.ShotsOt)
                    .HasColumnType("INTEGER (3)")
                    .HasColumnName("ShotsOT");

                entity.Property(e => e.Touches).HasColumnType("INTEGER (3)");

                entity.Property(e => e.Ycards)
                    .HasColumnType("INTEGER (3)")
                    .HasColumnName("YCards");

                entity.HasOne(d => d.IdMatchNavigation)
                    .WithMany(p => p.Statistics)
                    .HasForeignKey(d => d.IdMatch)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.IdPlayerNavigation)
                    .WithMany(p => p.Statistics)
                    .HasForeignKey(d => d.IdPlayer)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.IdTournamentNavigation)
                    .WithMany(p => p.Statistics)
                    .HasForeignKey(d => d.IdTournament)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Tournament>(entity =>
            {
                entity.HasKey(e => e.IdTournament);

                entity.ToTable("Tournament");

                entity.HasIndex(e => e.IdTournament, "IX_Tournament_Id_Tournament")
                    .IsUnique();

                entity.Property(e => e.IdTournament)
                    .ValueGeneratedNever()
                    .HasColumnName("Id_Tournament");

                entity.Property(e => e.EndDate).HasColumnType("DATE");

                entity.Property(e => e.StartDate).HasColumnType("DATE");

                entity.Property(e => e.TournamentCountry).HasColumnType("STRING (100)");

                entity.Property(e => e.TournamentName).HasColumnType("STRING (100)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

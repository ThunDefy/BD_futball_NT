using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reactive;
using Microsoft.Data.Sqlite;
using System.IO;
using System;
using System.Reactive.Linq;
using System.Collections.ObjectModel;
using ReactiveUI;
using BD_futball_NT.Models;

namespace BD_futball_NT.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ObservableCollection<Player> players;
        private ObservableCollection<Tournament> tournaments;
        private ObservableCollection<NationalTeam> nationalTeams;
        private ObservableCollection<Match> matches;
        private ObservableCollection<Statistic> statistics;
        private ObservableCollection<Table> tables;
        ViewModelBase chosenTable;

        public MainWindowViewModel()
        {

            tables = new ObservableCollection<Table>();
            var DB = new Futball_NTContext();

            players = new ObservableCollection<Player>(DB.Players);
            tournaments = new ObservableCollection<Tournament>(DB.Tournaments);
            nationalTeams = new ObservableCollection<NationalTeam>(DB.NationalTeams);
            matches = new ObservableCollection<Match>(DB.Matches);
            statistics = new ObservableCollection<Statistic>(DB.Statistics);

            tables.Add(new Table("Players"));
            tables.Add(new Table("Matches"));
            tables.Add(new Table("Tournaments"));
            tables.Add(new Table("Statistics"));
            tables.Add(new Table("NationalTeams"));
        }

        public ObservableCollection<Player> Players
        {
            get => players;
            set { this.RaiseAndSetIfChanged(ref players, value); }
        }
        public ObservableCollection<Tournament> Tournaments
        {
            get => tournaments;
            set { this.RaiseAndSetIfChanged(ref tournaments, value); }
        }
        public ObservableCollection<NationalTeam> NationalTeams
        {
            get => nationalTeams;
            set { this.RaiseAndSetIfChanged(ref nationalTeams, value); }
        }
        public ObservableCollection<Match> Matches
        {
            get => matches;
            set { this.RaiseAndSetIfChanged(ref matches, value); }
        }
        public ObservableCollection<Statistic> Statistics
        {
            get => statistics;
            set { this.RaiseAndSetIfChanged(ref statistics, value); }
        }
/*        public ObservableCollection<Table> Tables
        {
            get => tables;
            set { this.RaiseAndSetIfChanged(ref tables, value); }
        }*/

        public ViewModelBase ChosenTable
        {
            get => chosenTable;
            set => this.RaiseAndSetIfChanged(ref chosenTable, value);
        }

        public void OpenPlayersTable()
        {
          ChosenTable = new PlayersViewModel(players);
        }
        public void OpenMatchesTable()
        {
            ChosenTable = new MatchesViewModel(matches);
        }
        public void OpenNationalTeamsTable()
        {
            ChosenTable = new NationalTeamsViewModel(nationalTeams);
        }
        public void OpenTournamentsTable()
        {
            ChosenTable = new TournamentViewModel(tournaments);
        }
        public void OpenStatisticsTable()
        {
            ChosenTable = new StatisticViewModel(statistics);
        }
        public void OpenRequestMakerView()
        {
            ChosenTable = new RequestMakerViewModel();
        }
    }
}

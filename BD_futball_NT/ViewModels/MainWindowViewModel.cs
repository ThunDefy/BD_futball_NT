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

        private ObservableCollection<string> FindProperties(string entityName, List<string> properties)
        {
            ObservableCollection<string> result = new ObservableCollection<string>();
            for (int i = 0; i < properties.Count(); i++)
            {
                if (properties[i].IndexOf("EntityType:" + entityName) != -1)
                {
                    try
                    {
                        i++;
                        while (properties[i].IndexOf("(") != -1 && i < properties.Count())
                        {
                            result.Add(properties[i].Remove(properties[i].IndexOf("(")));
                            i++;
                        }
                        return result;
                    }
                    catch
                    {
                        return result;
                    }
                }
            }
            return result;
        }

        private int tablesInd;
        private int rowInd;
        public int TablesInd
        {
            get => tablesInd;
            set { this.RaiseAndSetIfChanged(ref tablesInd, value); }
        }
        public int RowInd
        {
            get => rowInd;
            set { this.RaiseAndSetIfChanged(ref rowInd, value); }
        }

        public MainWindowViewModel()
        {

            tables = new ObservableCollection<Table>();
            var DB = new Futball_NTContext();

      
            /*string tableInfo = DB.Model.ToDebugString();
            tableInfo = tableInfo.Replace(" ", "");
            string[] splitTableInfo = tableInfo.Split("\r\n");
            List<string> properties = new List<string>(splitTableInfo.Where(str => str.IndexOf("Entity") != 1));*/

            players = new ObservableCollection<Player>(DB.Players);
            tournaments = new ObservableCollection<Tournament>(DB.Tournaments);
            nationalTeams = new ObservableCollection<NationalTeam>(DB.NationalTeams);
            matches = new ObservableCollection<Match>(DB.Matches);
            statistics = new ObservableCollection<Statistic>(DB.Statistics);

            TablesInd = 0;
            AddItm = ReactiveCommand.Create(() => Add());
            DelItm = ReactiveCommand.Create(() => Del());

            /*tables.Add(new Table("Players", new PlayersViewModel(players), FindProperties("Player", properties)));
            tables.Add(new Table("Matches"));
            tables.Add(new Table("Tournaments"));
            tables.Add(new Table("Statistics"));
            tables.Add(new Table("NationalTeams"));*/
        }

        
        public ReactiveCommand<Unit, int> AddItm { get; }
        public ReactiveCommand<Unit, int> DelItm { get; }

        private int Add()
        {
            switch (TablesInd)
            {
                case 0: players.Add(new Player(players.Count + 2)); break;
                case 1: tournaments.Add(new Tournament(tournaments.Count + 1)); break;
                case 2: nationalTeams.Add(new NationalTeam(nationalTeams.Count + 1)); break;
                case 3: matches.Add(new Match(matches.Count + 1)); break;
                case 4: statistics.Add(new Statistic(statistics.Count + 1)); break;
            }
            return 0;
        }
        private int Del()
        {
            switch (TablesInd)
            {
                case 0: players.RemoveAt(RowInd); break;
                case 1: tournaments.RemoveAt(RowInd); break;
                case 2: nationalTeams.RemoveAt(RowInd); break;
                case 3: matches.RemoveAt(RowInd); break;
                case 4: statistics.RemoveAt(RowInd); break;

            }
            return 0;
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
            TablesInd = 0;
            ChosenTable = new PlayersViewModel(players);
        }
        public void OpenMatchesTable()
        {
            TablesInd = 3;
            ChosenTable = new MatchesViewModel(matches);
        }
        public void OpenNationalTeamsTable()
        {
            TablesInd = 2;
            ChosenTable = new NationalTeamsViewModel(nationalTeams);
        }
        public void OpenTournamentsTable()
        {
            TablesInd = 1;
            ChosenTable = new TournamentViewModel(tournaments);
        }
        public void OpenStatisticsTable()
        {
            TablesInd = 4;
            ChosenTable = new StatisticViewModel(statistics);
        }
        public void OpenRequestMakerView()
        {
            ChosenTable = new RequestMakerViewModel();
        }

    }
}

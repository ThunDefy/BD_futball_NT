using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reactive;
using Microsoft.Data.Sqlite;
using System.IO;
using System.Data.SQLite;
using System;
using System.Reactive.Linq;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using ReactiveUI;
using BD_futball_NT.Models;

namespace BD_futball_NT.ViewModels
{
    public class TablesViewModel : ViewModelBase
    {

        private ObservableCollection<Player> players;
        private ObservableCollection<Tournament> tournaments;
        private ObservableCollection<NationalTeam> nationalTeams;
        private ObservableCollection<Match> matches;
        private ObservableCollection<Statistic> statistics;
        private ObservableCollection<Table> tablles;

        ViewModelBase chosenTable;



        private SQLiteConnection sql_con;
        private DataSet tables;
        public DataView dtView;
        private List<string> strReq;

        public List<string> StrReq
        {
            get => strReq;
            set => this.RaiseAndSetIfChanged(ref strReq, value);
        }
        public DataView DtView
        {
            get => dtView;
            set { this.RaiseAndSetIfChanged(ref dtView, value); }
        }
        int selectRow;
        bool isTableChosen;
        public bool IsTableChosen
        {
            get => isTableChosen;
            set { this.RaiseAndSetIfChanged(ref isTableChosen, value); }
        }

        public int currentTableIndex;
        public int CurrentTableIndex
        {
            get => currentTableIndex;
            set
            {
                IsTableChosen = value < 0 ? false : true;
                this.RaiseAndSetIfChanged(ref currentTableIndex, value);
            }
        }
        public int SelectRow
        {
            get => selectRow;
            private set => this.RaiseAndSetIfChanged(ref selectRow, value);
        }

        public DataSet Tables
        {
            get => tables;
            private set => this.RaiseAndSetIfChanged(ref tables, value);
        }
        //public ObservableCollection<TabModel> Tabs { get; set; }

        public TablesViewModel()
        {
            tablles = new ObservableCollection<Table>();
            var DB = new Futball_NTContext();

            AddItm = ReactiveCommand.Create(() => Add());
            DelItm = ReactiveCommand.Create(() => Del());

            players = new ObservableCollection<Player>(DB.Players);
            tournaments = new ObservableCollection<Tournament>(DB.Tournaments);
            nationalTeams = new ObservableCollection<NationalTeam>(DB.NationalTeams);
            matches = new ObservableCollection<Match>(DB.Matches);
            statistics = new ObservableCollection<Statistic>(DB.Statistics);

            tablles.Add(new Table("Players"));
            tablles.Add(new Table("Matches"));
            tablles.Add(new Table("Tournaments"));
            tablles.Add(new Table("Statistics"));
            tablles.Add(new Table("NationalTeams"));


            string sql = "SELECT name FROM sqlite_master WHERE type=\"table\" ORDER BY 1";
            string connectionStr = "Data Source=Futball_NT.db;Mode=ReadWrite";

            using (sql_con = new SQLiteConnection(connectionStr))
            {
                sql_con.Open();
                SQLiteCommand command = new SQLiteCommand(sql, sql_con);
                DataTable tablesNames = new DataTable();
                using (SQLiteDataReader reader = command.ExecuteReader())
                {

                    tablesNames.Load(reader);
                    tables = new DataSet();
                    string subsql = "SELECT * FROM ";
                    foreach (DataRow row in tablesNames.Rows)
                    {
                        string name = row.ItemArray[0].ToString();
                        if (name == "sqlite_sequence") continue;
                        SQLiteCommand sqlTab = new SQLiteCommand(subsql + name, sql_con);
                        DataTable table = new DataTable();
                        table.Load(sqlTab.ExecuteReader());
                        tables.Tables.Add(table);
                    }
                }
            }
            CurrentTableIndex = -1;
        }


        public void OnSave()
        {
            string connectionStr = "Data Source=Futball_NT.db;Mode=Write";

            using (sql_con = new SQLiteConnection(connectionStr))
            {
                for (int i = 0; i < tables.Tables.Count; i++)
                {

                    try
                    {
                        SQLiteDataAdapter adapter = new SQLiteDataAdapter("SELECT * FROM " + tables.Tables[i].TableName, sql_con);

                        SQLiteCommandBuilder commandBuilder = new SQLiteCommandBuilder(adapter);
                        adapter.Update(tables.Tables[i]);

                    }
                    catch (SqlException ex)
                    {
                        Debug.WriteLine(ex.Message);
                    }

                }
                tables.AcceptChanges();
            }
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

        public void OpenReqWind(DataSet tables)
        {
            var vm = new RequestMakerViewModel(Tables, StrReq);
            Observable.Merge(vm.Send)
                .Take(1)
                .Subscribe(msg =>
                {
                    if (msg != null)
                    {
                        StrReq = msg;
                    }

                    CurrentTableIndex = -1;
                }
                );
            ChosenTable = vm;
        }

        ~TablesViewModel()
        {
            sql_con.Close();
        }
    }
}

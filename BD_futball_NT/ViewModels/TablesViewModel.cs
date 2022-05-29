using System.Collections.Generic;
using System.Reactive;
using System.Data.SQLite;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using ReactiveUI;

namespace BD_futball_NT.ViewModels
{
    public class TablesViewModel : ViewModelBase
    {
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

        public TablesViewModel()
        {

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

        public void AddRow()
        {
            DataRow row = tables.Tables[currentTableIndex].NewRow();
            List<object> arr = new List<object>();
            tables.Tables[currentTableIndex].Rows.Add(row);
        }
        public void DeleteRow()
        {
            tables.Tables[currentTableIndex].Rows[selectRow].Delete();
        }

        public ViewModelBase ChosenTable
        {
            get => chosenTable;
            set => this.RaiseAndSetIfChanged(ref chosenTable, value);
        }

        
        ~TablesViewModel()
        {
            sql_con.Close();
        }
    }
}

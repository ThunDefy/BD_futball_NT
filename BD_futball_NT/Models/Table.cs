using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BD_futball_NT.ViewModels
{
    public class Table
    {
        private string tableName;
        private ViewModelBase tableView;
        public Dictionary<string, List<object?>> TableValues { get; }
        public ObservableCollection<string> Properties { get; set; }
        public ViewModelBase TableView{ get{return tableView;}set{tableView = value;}}
        public Table(string _name, ViewModelBase _tableView, ObservableCollection<string> _Properties)
        {
            tableName = _name;
            Properties = _Properties;
            tableView = _tableView;
            TableValues = new Dictionary<string, List<object?>>();
            var a = TableView.GetTable();
            dynamic table = TableView.GetTable();

            foreach (string prop in Properties)
                {
                    TableValues.Add(prop, new List<object?>() { tableName + ": " + prop });
                }
                for (int i = 0; i < TableValues.Count; i++)
                {
                    foreach (string prop in Properties)
                    {
                        for (int j = 0; j < table.Count; j++)
                        {
                            TableValues[prop].Add(table[j][prop]);
                        }
                    }
                }
            }

        public string TableName
        {
            get{return tableName;}
            set{tableName = value;}
        }

    }
}

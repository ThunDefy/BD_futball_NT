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
        public Table(string _name)
        {
            tableName = _name;
        }

        public string TableName
        {
            get{return tableName;}
            set{tableName = value;}
        }

    }
}

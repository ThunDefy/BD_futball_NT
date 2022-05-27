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
    public class MainWindowViewModel : ViewModelBase
    {
        ViewModelBase content;
        ViewModelBase Content
        {
            get => content;
            set => this.RaiseAndSetIfChanged(ref content, value);
        }

        public TablesViewModel mainTabWind { get; }
        public MainWindowViewModel()
        {
            mainTabWind = new TablesViewModel();
            Content = mainTabWind;
        }


        


    }
    
}

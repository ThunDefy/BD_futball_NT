using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using ReactiveUI;
using System.Reactive;
using System.Windows;
using Microsoft.Data.Sqlite;
using System.IO;
using System;
using BD_futball_NT.Models;

namespace BD_futball_NT.ViewModels
{
    public class PlayersViewModel : ViewModelBase
    {
        private ObservableCollection<Player> players;
        public PlayersViewModel(ObservableCollection<Player> _players)
        {
            Players = _players;
        }

        public ObservableCollection<Player> Players
        {
            get
            {
                return players;
            }
            set
            {
                players = value;
            }
        }
    }
}

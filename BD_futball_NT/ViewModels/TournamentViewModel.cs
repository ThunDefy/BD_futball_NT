using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BD_futball_NT.Models;

namespace BD_futball_NT.ViewModels
{
    public class TournamentViewModel : ViewModelBase
    {
        private ObservableCollection<Tournament> tournaments;
        public TournamentViewModel(ObservableCollection<Tournament> tournaments)
        {
            Tournaments = tournaments;
        }

        public ObservableCollection<Tournament> Tournaments
        {
            get
            {
                return tournaments;
            }
            set
            {
                tournaments = value;
            }
        }
    }
}

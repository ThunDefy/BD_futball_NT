using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BD_futball_NT.Models;

namespace BD_futball_NT.ViewModels
{
    public class MatchesViewModel : ViewModelBase
    {
        private ObservableCollection<Match> matches;
        public MatchesViewModel(ObservableCollection<Match> matches)
        {
            Matches = matches;
        }

        public ObservableCollection<Match> Matches
        {
            get
            {
                return matches;
            }
            set
            {
                matches = value;
            }
        }
    }
}

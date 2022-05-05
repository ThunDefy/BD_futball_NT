using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BD_futball_NT.Models;

namespace BD_futball_NT.ViewModels
{
    public class NationalTeamsViewModel : ViewModelBase
    {
        private ObservableCollection<NationalTeam> nationalTeams;
        public NationalTeamsViewModel(ObservableCollection<NationalTeam> _nationalTeams)
        {
            NationalTeams = _nationalTeams;
        }

        public ObservableCollection<NationalTeam> NationalTeams
        {
            get
            {
                return nationalTeams;
            }
            set
            {
                nationalTeams = value;
            }
        }
    }
}

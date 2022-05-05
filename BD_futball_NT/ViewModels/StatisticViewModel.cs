using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BD_futball_NT.Models;

namespace BD_futball_NT.ViewModels
{
    public class StatisticViewModel : ViewModelBase
    {
        private ObservableCollection<Statistic> statistics;
        public StatisticViewModel(ObservableCollection<Statistic> statistics)
        {
            Statistics = statistics;
        }

        public ObservableCollection<Statistic> Statistics
        {
            get
            {
                return statistics;
            }
            set
            {
                statistics = value;
            }
        }
    }
}

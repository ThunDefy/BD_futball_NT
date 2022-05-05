using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using ReactiveUI;
using BD_futball_NT.Models;

namespace BD_futball_NT.ViewModels
{

    public class RequestMakerViewModel : ViewModelBase
    {
        private ObservableCollection<Table> tables;

        public RequestMakerViewModel()
        {

        }

        public ObservableCollection<Table> Tables
        {
            get => tables;
            set
            {
                this.RaiseAndSetIfChanged(ref tables, value);
            }
        }

    }
}

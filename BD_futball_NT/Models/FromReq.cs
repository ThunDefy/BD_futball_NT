using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
namespace BD_futball_NT.Models
{
    public class FromReq : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public FromReq()
        {
            TableInd = 0;
        }

        private int tableInd;
        public int TableInd
        {
            get => tableInd;
            set { tableInd = value; NotifyPropertyChanged(); }
        }
    }
}

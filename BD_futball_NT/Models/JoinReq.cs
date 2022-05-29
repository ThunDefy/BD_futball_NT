using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BD_futball_NT.Models
{
    public class JoinReq : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public JoinReq()
        {
            TableInd = 0;
        }

        private int atrIndFirst, atrIndSec, tableInd;
        public int TableInd
        {
            get => tableInd;
            set { tableInd = value; NotifyPropertyChanged(); }
        }
        public int AtrIndFirst
        {
            get => atrIndFirst;
            set { atrIndFirst = value; NotifyPropertyChanged(); }
        }
        public int AtrIndSec
        {
            get => atrIndSec;
            set { atrIndSec = value; NotifyPropertyChanged(); }
        }

    }
}
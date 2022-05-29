using System.Linq;
using System;
using System.Reactive.Linq;
using System.Data;
using ReactiveUI;

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

        public TablesViewModel main { get; }
        public MainWindowViewModel()
        {
            main = new TablesViewModel();
            Content = main;
        }


        public void OpenReqWind(DataSet tables)
        {
            var vm = new RequestMakerViewModel(main.Tables, main.StrReq);
            Observable.Merge(vm.Send)
                .Take(1)
                .Subscribe(msg =>
                {
                    if (msg != null)
                    {
                        main.StrReq = msg;
                    }
                    Content = main;
                    main.CurrentTableIndex = -1;
                }
                );
            Content = vm;
        }
    }    
}

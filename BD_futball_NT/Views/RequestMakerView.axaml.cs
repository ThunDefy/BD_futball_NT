using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using BD_futball_NT.ViewModels;
using System.Collections.ObjectModel;

namespace BD_futball_NT.Views
{
    public partial class RequestMakerView : UserControl
    {

        public RequestMakerView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private void ChangeWhere(object sender, SelectionChangedEventArgs e)
        {
            var combo = sender as ComboBox;
            var context = this.DataContext as RequestMakerViewModel;
            if (context != null)
            {
                if (combo.SelectedIndex + 1 > context.ReqNames.Count)
                    context.WhPr.WhereAtr = new ObservableCollection<string>(context.atributes[combo.SelectedIndex - context.ReqNames.Count]);
                else context.WhPr.WhereAtr = new ObservableCollection<string>(context.atributes[0]);
            }

           
        }

        private void ChangeGroup(object sender, SelectionChangedEventArgs e)
        {
            var combo = sender as ComboBox;
            var context = this.DataContext as RequestMakerViewModel;
            if (context != null)
                context.WhPr.GroupTb = new ObservableCollection<string>(context.atributes[combo.SelectedIndex]);
            
        }

        private void ChangeJoin(object sender, SelectionChangedEventArgs e)
        {
            var combo = sender as ComboBox;
            var context = this.DataContext as RequestMakerViewModel;
            if (context != null)
                context.JoinAtr = new ObservableCollection<string>(context.atributes[combo.SelectedIndex]);

        }

    }
}

using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace BD_futball_NT.Views
{
    public partial class StatisticView : UserControl
    {
        public StatisticView()
        {
            InitializeComponent();
        }

        private void DeleteExtraColumn(object control, DataGridAutoGeneratingColumnEventArgs args)
        {
            if (args.PropertyName == "IdTournamentNavigation" || args.PropertyName == "IdMatchNavigation" || args.PropertyName == "IdPlayerNavigation")
            {
                args.Cancel = true;
            }
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}

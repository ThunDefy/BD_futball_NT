using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace BD_futball_NT.Views
{
    public partial class MatchesView : UserControl
    {
        public MatchesView()
        {
            InitializeComponent();
        }
        private void DeleteExtraColumn(object control, DataGridAutoGeneratingColumnEventArgs args)
        {
            if (args.PropertyName == "IdNteam1Navigation" || args.PropertyName == "IdNteam2Navigation" || args.PropertyName == "IdTournamentNavigation" || args.PropertyName == "Statistics")
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

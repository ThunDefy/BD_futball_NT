using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace BD_futball_NT.Views
{
    public partial class TournamentView : UserControl
    {
        public TournamentView()
        {
            InitializeComponent();
        }
        private void DeleteExtraColumn(object control, DataGridAutoGeneratingColumnEventArgs args)
        {
            if (args.PropertyName == "Matches" || args.PropertyName == "MatchIdNteam2Navigations" || args.PropertyName == "Statistics")
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

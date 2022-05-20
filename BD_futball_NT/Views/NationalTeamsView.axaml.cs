using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace BD_futball_NT.Views
{
    public partial class NationalTeamsView : UserControl
    {
        public NationalTeamsView()
        {
            InitializeComponent();
        }
        private void DeleteExtraColumn(object control, DataGridAutoGeneratingColumnEventArgs args)
        {
            if (args.PropertyName == "MatchIdNteam1Navigations" || args.PropertyName == "MatchIdNteam2Navigations" || args.PropertyName == "Players") 
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

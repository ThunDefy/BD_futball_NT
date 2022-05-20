using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace BD_futball_NT.Views
{
    public partial class PlayersView : UserControl
    {
        public PlayersView()
        {
            InitializeComponent();
        }

        private void DeleteExtraColumn(object control, DataGridAutoGeneratingColumnEventArgs args)
        {
            if (args.PropertyName == "Item" || args.PropertyName == "IdNteamNavigation" || args.PropertyName == "Statistics")
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

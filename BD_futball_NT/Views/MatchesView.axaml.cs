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

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}

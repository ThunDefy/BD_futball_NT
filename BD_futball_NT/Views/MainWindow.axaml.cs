using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace BD_futball_NT.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

    }
}

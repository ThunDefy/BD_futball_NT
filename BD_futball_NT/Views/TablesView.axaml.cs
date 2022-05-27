using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using BD_futball_NT.ViewModels;
using Avalonia.Interactivity;
using Avalonia.ReactiveUI;
using ReactiveUI;
using Avalonia.Data;
using System.Data;
using System;


namespace BD_futball_NT.Views
{
    public partial class TablesView : UserControl
    {
        public TablesView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
       
       
        
    }
}

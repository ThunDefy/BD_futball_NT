using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using BD_futball_NT.ViewModels;
using Avalonia.Interactivity;
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
            dGrid.CellEditEnding += OnCellEditEnd;
        }
        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
            dGrid = this.FindControl<global::Avalonia.Controls.DataGrid>("dGrid");
        }

        private void OnCellEditEnd(object sender, DataGridCellEditEndingEventArgs args)
        {
            if (args.EditAction != DataGridEditAction.Commit) return;

            DataGrid dataGrid = sender as DataGrid;
            string index = args.Column.Header as string;
            string? a = (args.EditingElement as TextBox).Text;

            DataRowCollection rows = dataGrid.Items as DataRowCollection;
            try
            {
                rows[dataGrid.SelectedIndex].BeginEdit();
                rows[dataGrid.SelectedIndex][index] = a;
                rows[dataGrid.SelectedIndex].EndEdit();
            }
            catch (Exception)
            {

            }
        }
        public void OnSelect(object sender, SelectionChangedEventArgs args)
        {
            if (args.AddedItems.Count == 0) return;
            DataTable table = args.AddedItems[0] as DataTable;
            if (table != null)
            {
                var context = DataContext as TablesViewModel;

                ChangeTable(table);
            }

        }
        void ChangeTable(DataTable table)
        {
            int i = 0;

            int Index = i;
            for (int ind = dGrid.Columns.Count - 1; ind >= 0; ind--)
            {
                dGrid.Columns.RemoveAt(ind);
            }
            /* dGrid.Columns.Clear();*/
            dGrid.Items = table.Rows;
            foreach (DataColumn col in table.Columns)
            {
                dGrid.Columns.Add(new DataGridTextColumn
                {
                    Header = col.ColumnName,
                    Binding = new Binding($"ItemArray[{i++}]"),
                    IsReadOnly = false
                });
            }

        }

        public void OnAddRowButtonClick(object sender, RoutedEventArgs args)
        {
            var context = DataContext as TablesViewModel;

            context.AddRow();

            ChangeTable(context.Tables.Tables[context.currentTableIndex]);

        }
        public void OnSaveClick(object sender, RoutedEventArgs args)
        {
            var context = DataContext as TablesViewModel;

            context.OnSave();

            ChangeTable(context.Tables.Tables[context.currentTableIndex]);

        }
        public void OnDelRowButtonClick(object sender, RoutedEventArgs args)
        {
            var context = DataContext as TablesViewModel;
            context.DeleteRow();
            ChangeTable(context.Tables.Tables[context.currentTableIndex]);
        }
    }
}
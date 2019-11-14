using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Microsoft.EntityFrameworkCore;

namespace SchoolApp.Windows
{
    static class DataGridExtensions
    {
        public static void AddButtonColumn(this DataGrid grid, string content, RoutedEventHandler handler)
        {
            var buttonTemplate = new FrameworkElementFactory(typeof(Button));

            buttonTemplate.SetValue(Button.ContentProperty, content);
            buttonTemplate.SetBinding(Button.IsEnabledProperty, new Binding("Status"));

            buttonTemplate.AddHandler(
                Button.ClickEvent,
                new RoutedEventHandler(handler)
            );

            grid.Columns.Add(
                new DataGridTemplateColumn()
                {
                    Header = content,
                    CellTemplate = new DataTemplate() { VisualTree = buttonTemplate }
                }
            );
        }

        public static void BindSet<T>(this DataGrid grid, DbSet<T> set) where T : class
        {
            grid.ItemsSource = set.Local.ToObservableCollection();
        }
    }
}
using System.Windows;

namespace SchoolApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static SchoolDbContext Context { get; } = new SchoolDbContext();
    }
}

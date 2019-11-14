using System.Windows;
using SchoolApp.Windows;

namespace SchoolApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(SchoolDbContext context)
        {
            InitializeComponent();
        }

        private void OpenStudentWindowButton_Click(object sender, RoutedEventArgs e)
        {
            StudentWindow sw = new StudentWindow();

            sw.Show();
        }

        private void OpenCourseWindowButton_Click(object sender, RoutedEventArgs e)
        {
            CourseWindow cw = new CourseWindow();

            cw.Show();
        }
    }
}

using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore;
using SchoolApp.Windows.Student_Windows;

namespace SchoolApp.Windows
{
    /// <summary>
    /// Interaction logic for StudentWindow.xaml
    /// </summary>
    public partial class CourseWindow : Window
    {
        private readonly SchoolDbContext _context;

        public CourseWindow()
        {
            InitializeComponent();

            _context = App.Context;
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await _context.Courses.LoadAsync();

            this.CoursesGrid.AddButtonColumn("Edit", EditCourse);
            this.CoursesGrid.AddButtonColumn("Delete", DeleteCourse);

            this.CoursesGrid.BindLocal(_context.Courses);
        }

        private void EditCourse(object sender, RoutedEventArgs e)
        {
            Course course = this.CoursesGrid.CurrentCell.Item as Course;

            if (course == null)
            {
                MessageBox.Show("There is no course to edit.");

                return;
            }

            EditCoursePage ecp = new EditCoursePage(course, this.CoursesGrid);

            ecp.Show();
        }

        private async void DeleteCourse(object sender, RoutedEventArgs e)
        {
            Course course = this.CoursesGrid.CurrentCell.Item as Course;

            if (course == null)
            {
                MessageBox.Show("There is no course to delete.");

                return;
            }

            _context.Courses.Remove(course);

            await _context.SaveChangesAsync();

            MessageBox.Show("Course is removed successfully.");

            this.CoursesGrid.BindLocal(_context.Courses);
        }

        private void StudentsGrid_OnAutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            PropertyDescriptor propertyDescriptor = (PropertyDescriptor) e.PropertyDescriptor;

            e.Column.Header = propertyDescriptor.DisplayName;

            if (propertyDescriptor.DisplayName == "Id")
            {
                e.Cancel = true;
            }
        }

        private void AddStudent_Click(object sender, RoutedEventArgs e)
        {
            AddCoursePage acp = new AddCoursePage(this.CoursesGrid);

            acp.Show();
        }
    }
}

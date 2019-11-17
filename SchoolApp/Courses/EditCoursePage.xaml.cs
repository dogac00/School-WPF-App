using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.EntityFrameworkCore;

namespace SchoolApp.Windows.Student_Windows
{
    /// <summary>
    /// Interaction logic for AddStudent.xaml
    /// </summary>
    public partial class EditCoursePage : Window
    {
        private readonly Course _course;
        private readonly SchoolDbContext _context;
        private readonly DataGrid _grid;

        public EditCoursePage(Course course, DataGrid grid)
        {
            InitializeComponent();

            _course = course;
            _context = App.Context;
            _grid = grid;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.CourseCodeTextBox.Text = _course.Code;
            this.CourseCreditTextBox.Text = _course.Credit.ToString();
            this.CourseQuotaTextBox.Text = _course.Quota.ToString();
        }

        private async void EditStudentButton_Click(object sender, RoutedEventArgs e)
        {
            int credit, quota;

            if (!int.TryParse(this.CourseCreditTextBox.Text, out credit) ||
                !int.TryParse(this.CourseQuotaTextBox.Text, out quota))
            {
                MessageBox.Show("Please enter valid values.");

                return;
            }

            _course.Code = this.CourseCodeTextBox.Text;
            _course.Credit = credit;
            _course.Quota = quota;

            _context.Courses.Update(_course);

            await _context.SaveChangesAsync();

            MessageBox.Show("Course is edited successfully.");

            LoadCourses();
        }

        private async void LoadCourses()
        {
            await _context.Courses.LoadAsync();

            this._grid.ItemsSource = await _context.Courses.ToListAsync();
        }
    }
}

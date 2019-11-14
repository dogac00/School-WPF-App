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
    public partial class AddCoursePage : Window
    {
        private readonly DataGrid _grid;
        private readonly SchoolDbContext _context;

        public AddCoursePage(DataGrid grid)
        {
            InitializeComponent();

            this._grid = grid;
            this._context = App.Context;
        }

        private async void AddStudentButton_Click(object sender, RoutedEventArgs e)
        {
            Course course;

            try
            {
                course = new Course
                {
                    Code = this.CourseCodeTextBox.Text,
                    Credit = int.Parse(this.CourseCreditTextBox.Text),
                    Quota = int.Parse(this.CourseQuotaTextBox.Text)
                };
            }
            catch
            {
                MessageBox.Show("Please enter valid values for course. (Credit and Quota must be a number)");

                return;
            }

            await _context.AddAsync(course);

            await _context.SaveChangesAsync();

            MessageBox.Show("Course is added successfully.");

            _grid.ItemsSource = await _context.Courses.ToListAsync();
        }
    }
}

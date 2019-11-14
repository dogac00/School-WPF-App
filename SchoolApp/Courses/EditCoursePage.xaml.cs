﻿using System;
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
            Course course = new Course();

            try
            {
                course.Code = this.CourseCodeTextBox.Text;
                course.Credit = int.Parse(this.CourseCreditTextBox.Text);
                course.Quota = int.Parse(this.CourseQuotaTextBox.Text);
            }
            catch
            {
                MessageBox.Show("Please enter valid values.");

                return;
            }

            _context.Courses.Update(course);

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

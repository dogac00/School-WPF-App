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
    public partial class AddStudentPage : Window
    {
        private readonly DataGrid _grid;
        private readonly SchoolDbContext _context;

        public AddStudentPage(DataGrid grid)
        {
            InitializeComponent();

            this._grid = grid;
            this._context = App.Context;
        }

        private async void AddStudentButton_Click(object sender, RoutedEventArgs e)
        {
            Student student = new Student
            {
                BirthDate = this.StudentBirthDate.DisplayDate,
                Name = this.StudentNameTextBox.Text,
                StudentId = this.StudentIdTextBox.Text
            };

            await _context.AddAsync(student);

            await _context.SaveChangesAsync();

            MessageBox.Show("Student is added successfully.");

            _grid.ItemsSource = await _context.Students.ToListAsync();
        }
    }
}

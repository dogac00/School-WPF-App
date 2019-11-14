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

namespace SchoolApp.Windows.Student_Windows
{
    /// <summary>
    /// Interaction logic for AddStudent.xaml
    /// </summary>
    public partial class EditStudentPage : Window
    {
        private readonly Student _student;
        private readonly SchoolDbContext _context;

        public EditStudentPage(Student student)
        {
            InitializeComponent();

            _student = student;
            _context = App.Context;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.StudentNameTextBox.Text = _student.Name;
            this.StudentIdTextBox.Text = _student.StudentId;
            this.StudentDateTextBox.SelectedDate = _student.BirthDate;
        }

        private async void EditStudentButton_Click(object sender, RoutedEventArgs e)
        {
            _student.Name = this.StudentNameTextBox.Text;
            _student.StudentId = this.StudentIdTextBox.Text;
            _student.BirthDate = this.StudentDateTextBox.SelectedDate.GetValueOrDefault(DateTime.Now);

            App.Context.Students.Update(_student);

            await App.Context.SaveChangesAsync();
        }
    }
}

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Desktop_UI_Sachi.Models;
using Desktop_UI_Sachi.Views;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Media.Imaging;

namespace Desktop_UI_Sachi.ViewModels
{
    public class StudentsViewModel : ObservableObject
    {
        private Student? _selectedStudent;

        public ObservableCollection<Student> Students { get; set; }

        public Student SelectedStudent
        {
            get { return _selectedStudent; }
            set
            {
                if (_selectedStudent != null)
                {
                    _selectedStudent.PropertyChanged -= SelectedStudent_PropertyChanged;
                }

                SetProperty(ref _selectedStudent, value);
                EditStudentCommand.NotifyCanExecuteChanged();
                DeleteStudentCommand.NotifyCanExecuteChanged();

                if (_selectedStudent != null)
                {
                    _selectedStudent.PropertyChanged += SelectedStudent_PropertyChanged;
                }
            }
        }

        public RelayCommand AddStudentCommand { get; }
        public RelayCommand EditStudentCommand { get; }
        public RelayCommand DeleteStudentCommand { get; }

        public StudentsViewModel()
        {
            Students = new ObservableCollection<Student>
            {
                new Student("Sachitha", "S Weerasingha", "EG/2020/4267", "/Images/1.png", new DateTime(1999, 11, 17), 3.43),
                new Student("Sample", "User", "EG/20XX/XXXX", "/Images/2.png", new DateTime(2000, 1, 1), 3.8)
            };

            AddStudentCommand = new RelayCommand(AddStudent);
            EditStudentCommand = new RelayCommand(EditStudent, () => SelectedStudent != null);
            DeleteStudentCommand = new RelayCommand(DeleteStudent, () => SelectedStudent != null);
        }

        private void AddStudent()
        {
            var newStudent = new Student("", "", "EG/20XX/XXXX", "", DateTime.Now.AddYears(-25), 0.0);
            var addEditWindow = new AddEditStudentView(newStudent);
            var result = addEditWindow.ShowDialog();

            if (result.HasValue && result.Value && !string.IsNullOrWhiteSpace(newStudent.FirstName))
            {
                Students.Add(newStudent);
            }
        }

        private void EditStudent()
        {
            var addEditWindow = new AddEditStudentView(SelectedStudent);
            addEditWindow.ShowDialog();
        }

        private void DeleteStudent()
        {
            Students.Remove(SelectedStudent);
        }

        private void SelectedStudent_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Student.ImageThumbnail))
            {
                OnPropertyChanged(nameof(SelectedStudent));
            }
        }
    }
}

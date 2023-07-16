using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Windows.Media.Imaging;

namespace Desktop_UI_Sachi.Models
{
    public class Student : ObservableObject
    {
        private string _firstName;
        private string _lastName;
        private string _indexNumber;
        private string _imageThumbnail;
        private DateTime _dateOfBirth;
        private double _gpa;

        public string FirstName
        {
            get { return _firstName; }
            set { SetProperty(ref _firstName, value); }
        }

        public string LastName
        {
            get { return _lastName; }
            set { SetProperty(ref _lastName, value); }
        }

        public string IndexNumber
        {
            get { return _indexNumber; }
            set { SetProperty(ref _indexNumber, value); }
        }

        public string ImageThumbnail
        {
            get { return _imageThumbnail; }
            set { SetProperty(ref _imageThumbnail, value); }
        }

        public DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            set { SetProperty(ref _dateOfBirth, value); }
        }

        public double GPA
        {
            get { return _gpa; }
            set { SetProperty(ref _gpa, value); }
        }

        public Student(string firstName, string lastName, string indexNumber, string imageThumbnail, DateTime dateOfBirth, double gpa)
        {
            FirstName = firstName;
            LastName = lastName;
            IndexNumber = indexNumber;
            ImageThumbnail = imageThumbnail;
            DateOfBirth = dateOfBirth;
            GPA = gpa;
        }
    }
}

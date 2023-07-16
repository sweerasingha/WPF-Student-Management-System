using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Desktop_UI_Sachi.Models;
using Microsoft.Win32;
using System;
using System.Windows.Media.Imaging;

namespace Desktop_UI_Sachi.ViewModels
{
    public class AddEditStudentViewModel : ObservableObject
    {
        public Student Student { get; set; }
        public RelayCommand SaveCommand { get; }
        public RelayCommand CancelCommand { get; }
        public RelayCommand BrowseImageCommand { get; }

        public Action<bool> CloseAction { get; set; }


        public AddEditStudentViewModel(Student student)
        {
            Student = student;

            SaveCommand = new RelayCommand(Save);
            CancelCommand = new RelayCommand(Cancel);
            BrowseImageCommand = new RelayCommand(BrowseImage);
        }
        private void BrowseImage()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp",
                Multiselect = false
            };

            if (openFileDialog.ShowDialog() == true)
            {
                Student.ImageThumbnail = openFileDialog.FileName;
            }
        }

        private void Save()
        {
            CloseAction?.Invoke(true);
        }


        private void Cancel()
        {
            CloseAction?.Invoke(false);
        }

    }
}


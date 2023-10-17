using FoodSystem.Models;
using FoodSystem.Services;
using FoodSystem.ViewModels.Base;
using FoodSystem.ViewModels.Classroom;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FoodSystem.ViewModels.Student
{
    internal class StudentViewModel : BaseVM
    {
        public ObservableCollection<StudentModel> Students { get; set; }
        private StudentModel _currentStudent;
        public StudentModel CurrentStudent
        {
            get => _currentStudent;
            set{
                if (_currentStudent == value) return;
                _currentStudent = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddStudentCommand
        {
            get
            {
                return new DelegateCommand((obj) =>
                {
                    NavigationService.Add(new StudentEditViewModel(NavigationService, OnEditStudent));
                });
            }
        }
        public ICommand EditStudentCommand
        {
            get
            {
                return new DelegateCommand((obj) =>
                {
                    NavigationService.Add(new StudentEditViewModel(NavigationService, OnEditStudent, CurrentStudent));
                },
                (obj) => CurrentStudent != null
                );
            }
        }
        public ICommand RemoveStudentCommand
        {
            get
            {
                return new DelegateCommand((obj) =>
                {
                    Students.Remove(CurrentStudent);
                },
                (obj) => CurrentStudent != null
                );
            }
        }

        private void OnEditStudent(StudentModel obj)
        {
            if (obj.Id == Guid.Empty)
            {
                obj.Id = Guid.NewGuid();
                Students.Add(obj);
            }
            else
            {
                var student = Students.FirstOrDefault(x => x.Id == obj.Id);
                if (student == null) return;
                student.Name = obj.Name;
                student.Classroom = obj.Classroom;
            }
            CurrentStudent = null;
        }

        public StudentViewModel(NavigationService navigationService) : base(navigationService)
        {
            Students = new ObservableCollection<StudentModel>(StudentModel.All);
        }

    }
}

using FoodSystem.Models;
using FoodSystem.Services;
using FoodSystem.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FoodSystem.ViewModels.Student
{
    internal class StudentEditViewModel : BaseVM
    {
        private readonly Action<StudentModel> _callback;
        public ICommand CancelCommand
        {
            get
            {
                return new DelegateCommand((obj) =>
                {
                    NavigationService.Back();
                });
            }
        }
        public ICommand OkCommand
        {
            get
            {
                return new DelegateCommand((obj) =>
                {
                    _callback?.Invoke(new StudentModel
                    {
                        Id = _studentId,
                        Name = Name,
                        Classroom = Classroom
                    });
                    NavigationService.Back();
                });
            }
        }


        public ObservableCollection<ClassroomModel> Classrooms { get; set; }

        private Guid _studentId = Guid.Empty;

        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                if (_name == value) return;
                _name = value;
                OnPropertyChanged();
            }
        }

        private ClassroomModel _classroom;
        public ClassroomModel Classroom
        {
            get => _classroom;
            set
            {
                if (_classroom == value) return;
                _classroom = value;
                OnPropertyChanged();
            }
        }

        public StudentEditViewModel(NavigationService navigationService, Action<StudentModel> callback, StudentModel student = null) : base(navigationService)
        {
            Classrooms = new ObservableCollection<ClassroomModel>(ClassroomModel.All);
            _callback = callback;
            if (student != null)
            {
                _studentId = student.Id;
                Name = student.Name;
                Classroom = student.Classroom;
            }
        }
    }
}

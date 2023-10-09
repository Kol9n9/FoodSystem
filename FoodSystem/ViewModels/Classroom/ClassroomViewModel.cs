using FoodSystem.Models;
using FoodSystem.Services;
using FoodSystem.ViewModels.Base;
using FoodSystem.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FoodSystem.ViewModels.Classroom
{
    internal class ClassroomViewModel : BaseVM
    {
        private ClassroomModel _currentClassroom;
        public ClassroomModel CurrentClassroom
        {
            get => _currentClassroom;
            set
            {
                if (_currentClassroom == value) return;
                _currentClassroom = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<ClassroomModel> Classrooms { get; set; }
        public ICommand AddClassroomCommand
        {
            get
            {
                return new DelegateCommand((obj) =>
                {
                    NavigationService.Add(new ClassroomEditViewModel(NavigationService, OnEditClassroom));
                });
            }
        }
        public ICommand EditClassroomCommand
        {
            get
            {
                return new DelegateCommand((obj) =>
                {
                    NavigationService.Add(new ClassroomEditViewModel(NavigationService, OnEditClassroom, CurrentClassroom));
                },
                (obj) => CurrentClassroom != null
                );
            }
        }
        public ICommand RemoveClassroomCommand
        {
            get
            {
                return new DelegateCommand((obj) =>
                {
                    Classrooms.Remove(CurrentClassroom);
                },
                (obj) => CurrentClassroom != null
                );
            }
        }

        private void OnEditClassroom(ClassroomModel obj)
        {
            if (obj.Id == Guid.Empty)
            {
                obj.Id = Guid.NewGuid();
                Classrooms.Add(obj);
            }
            else
            {
                var classroom = Classrooms.FirstOrDefault(x => x.Id == obj.Id);
                if (classroom == null) return;
                classroom.Name = obj.Name;
            }
            CurrentClassroom = null;
        }
        public ClassroomViewModel(NavigationService navigationService) : base(navigationService)
        {
            Classrooms = new ObservableCollection<ClassroomModel>(ClassroomModel.All);
            NavigationService.Add(this);
        }
    }
}

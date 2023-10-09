using FoodSystem.Models;
using FoodSystem.Services;
using FoodSystem.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FoodSystem.ViewModels.Classroom
{
    internal class ClassroomEditViewModel : BaseVM
    {
        private readonly Action<ClassroomModel> _callback;
        private readonly ClassroomModel _classroom;
        private Guid _classroomId = Guid.Empty;
        #region Команды
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
                    _callback?.Invoke(new ClassroomModel
                    {
                        Id = _classroomId,
                        Name = Name
                    });
                    NavigationService.Back();
                });
            }
        }
        #endregion
        #region Свойства
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
        #endregion
        public ClassroomEditViewModel(NavigationService navigationService, Action<ClassroomModel> callback, ClassroomModel classroom = null) : base(navigationService)
        {
            _callback = callback;
            _classroom = classroom;
            if(classroom != null)
            {
                _classroomId = classroom.Id;
                Name = classroom.Name;
            }
        }
    }
}

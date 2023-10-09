using FoodSystem.Models;
using FoodSystem.Services;
using FoodSystem.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FoodSystem.ViewModels.User
{
    internal class UserEditViewModel : BaseVM
    {
        private readonly Action<UserModel> _callback;
        private readonly UserModel _user;
        private Guid _userId = Guid.Empty;
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
                    _callback?.Invoke(new UserModel
                    {
                        Id = _userId,
                        Name = Name,
                        Password = Password
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
        private string _password;
        public string Password
        {
            get => _password;
            set
            {
                if (_password == value) return;
                _password = value;
                OnPropertyChanged();
            }
        }
        #endregion
        public UserEditViewModel(NavigationService navigationService, Action<UserModel> callback, UserModel user = null) : base(navigationService)
        {
            _callback = callback;
            _user = user;
            if (_user != null)
            {
                _userId = _user.Id;
                _name = _user.Name;
                _password = _user.Password;
            }
        }
    }
}

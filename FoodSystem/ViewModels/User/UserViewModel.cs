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

namespace FoodSystem.ViewModels.User
{
    internal class UserViewModel : BaseVM
    {
        private UserModel _currentUser;
        public UserModel CurrentUser
        {
            get => _currentUser;
            set
            {
                if (_currentUser == value) return;
                _currentUser = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<UserModel> Users { get; set; }
        public ICommand AddUserCommand
        {
            get
            {
                return new DelegateCommand((obj) =>
                {
                    NavigationService.Add(new UserEditViewModel(NavigationService, OnEditUser));
                });
            }
        }
        public ICommand EditUserCommand
        {
            get
            {
                return new DelegateCommand((obj) =>
                {
                    NavigationService.Add(new UserEditViewModel(NavigationService, OnEditUser, CurrentUser));
                },
                (obj) => CurrentUser != null
                );
            }
        }
        public ICommand RemoveUserCommand
        {
            get
            {
                return new DelegateCommand((obj) =>
                {
                    Users.Remove(CurrentUser);
                },
                (obj) => CurrentUser != null
                );
            }
        }

        private void OnEditUser(UserModel obj)
        {
            if (obj.Id == Guid.Empty)
            {
                obj.Id = Guid.NewGuid();
                Users.Add(obj);
            }
            else
            {
                var user = Users.FirstOrDefault(x => x.Id == obj.Id);
                if (user == null) return;
                user.Name = obj.Name;
                user.Password = obj.Password;
            }
            CurrentUser = null;
        }

        public UserViewModel(NavigationService navigationService) : base(navigationService)
        {
            Users = new ObservableCollection<UserModel>(UserModel.All);
            navigationService.Add(this);
        }
    }
}

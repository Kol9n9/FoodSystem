using FoodSystem.Services;
using FoodSystem.ViewModels.Base;
using FoodSystem.ViewModels.Classroom;
using FoodSystem.ViewModels.User;
using System.Windows.Input;

namespace FoodSystem.ViewModels
{
    internal class ApplicationViewModel : BaseVM
    {
        #region Имя приложения
        private string _applicationName = "Система питания";
        public string ApplicationName { 
            get => _applicationName; 
            set
            {
                if(value == _applicationName) return;
                _applicationName = value;
                OnPropertyChanged();
            }
        }
        #endregion
        #region Текущий Page

        private object _currentViewModel;
        public object CurrentViewModel
        {
            get { return NavigationService.Current(); }
            set { 
                if(value == _currentViewModel) return;
                NavigationService.Add(value as BaseVM);
                OnPropertyChanged(); 
            }
        }


        public ICommand ChangePage
        {
            get
            {
                return new DelegateCommand((pageName) =>
                {
                    BaseVM viewModel = pageName switch
                    {
                        "AboutPage" => new AboutViewModel(NavigationService),
                        "UserPage" => new UserViewModel(NavigationService),
                        "ClassroomPage" => new ClassroomViewModel(NavigationService),
                        _ => null
                    }; ;

                    if (viewModel != null)
                    {
                        CurrentViewModel = viewModel;
                    }
                });
            }
        }

        #endregion
        public ApplicationViewModel() : base(new NavigationService())
        {
            NavigationService.ChangedCurrentView += () =>
            {
                OnPropertyChanged(nameof(CurrentViewModel));
                //CurrentViewModel = _navigationService.Current();
            };
            NavigationService.Add(new AboutViewModel(NavigationService));
            
        }
    }
}

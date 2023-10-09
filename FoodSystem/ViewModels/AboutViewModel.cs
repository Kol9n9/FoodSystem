using FoodSystem.Services;
using FoodSystem.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSystem.ViewModels
{
    internal class AboutViewModel : BaseVM
    {
        public AboutViewModel(NavigationService navigationService) : base(navigationService) { }
        private string _version = "0.0.1";
        public string Version {
            get => _version;
            set
            {
                if (_version == value) return;
                _version = value;
                OnPropertyChanged();
            }
        }
    }
}

using FoodSystem.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FoodSystem.ViewModels.Base
{
    internal abstract class BaseVM : INotifyPropertyChanged
    {
        protected NavigationService NavigationService { get; }
        public BaseVM(NavigationService navigationService)
        {
            NavigationService = navigationService;
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}

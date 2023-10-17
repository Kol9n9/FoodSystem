using FoodSystem.Models;
using FoodSystem.Services;
using FoodSystem.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSystem.ViewModels.Price
{
    internal class PriceViewModel : BaseVM
    {
        public ObservableCollection<PriceModel> Prices { get; set; }

        public PriceViewModel(NavigationService navigationService) : base(navigationService)
        {
            Prices = new ObservableCollection<PriceModel>(PriceModel.All);
        }

    }
}

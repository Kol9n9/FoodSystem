using FoodSystem.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSystem.Services
{
    internal class NavigationService
    {
        private readonly Stack<BaseVM> _views = new Stack<BaseVM>();
        public Action ChangedCurrentView;
        public NavigationService() { }
        public void Add(BaseVM vm)
        {
            _views.Push(vm);
            OnChangedCurrentView();
        }
        public BaseVM Current()
        {
            return _views.Peek();
        }
        public void Back()
        {
            _views.Pop();
            OnChangedCurrentView();
        }
        private void OnChangedCurrentView()
        {
            ChangedCurrentView?.Invoke();
        }
    }
}

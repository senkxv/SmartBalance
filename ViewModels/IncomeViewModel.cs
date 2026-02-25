using SmartBalance.Models;
using SmartBalance.ViewModels.Base;

namespace SmartBalance.ViewModels
{
    internal class IncomeViewModel : ViewModelBase
    {
        private IncomeModel income = new();
        public IncomeModel Income
        {
            get => income;
            set 
            { 
                income = value; 
                OnPropertyChanged();
            }
        }
    }
}

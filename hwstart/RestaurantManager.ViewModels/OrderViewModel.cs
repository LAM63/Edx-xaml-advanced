using System.Collections.Generic;
using RestaurantManager.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Windows.UI.Popups;
using System;
using System.Linq;



namespace RestaurantManager.ViewModels
{
    public class OrderViewModel : ViewModel
    {

        public OrderViewModel()
        {
            AddOrderCommand = new DelegateCommand<object>(AddOrder);
            SubmitOrderCommand = new DelegateCommand<object>(SubmitOrder);
        }

        protected override void OnDataLoaded()
        {
            this.MenuItems = base.Repository.StandardMenuItems;
            this.CurrentlySelectedMenuItems = new ObservableCollection<MenuItem>();
            this._table = base.Repository.Tables.First();
            this.SpecialRequests = "";        
        }

        private List<MenuItem> _menuItems;

        public List<MenuItem> MenuItems
        {
            get { return _menuItems; }

            set
            {
                if (value != _menuItems)
                {
                    _menuItems = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private ObservableCollection<MenuItem> _currentlySelectedMenuItems;

        public ObservableCollection<MenuItem>  CurrentlySelectedMenuItems
        {
            get { return this._currentlySelectedMenuItems; }

            set
            {
                if (value != _currentlySelectedMenuItems)
                {
                    _currentlySelectedMenuItems = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private Table _table;
        private string _specialRequests;

        public string SpecialRequests
        {
            get { return this._specialRequests; }
            set
            {
                this._specialRequests = value;
                this.NotifyPropertyChanged();
            }
        }

        public ICommand AddOrderCommand { get; private set; }        
        public ICommand SubmitOrderCommand { get; private set; }

        private async void AddOrder(object parameter)
        {
            if (parameter is MenuItem)
            {
                CurrentlySelectedMenuItems.Add((MenuItem)parameter);
            }
            else await new MessageDialog("No selection has been made from the Menu").ShowAsync();
        }

        private async void SubmitOrder(object parameter)
        {
            if (CurrentlySelectedMenuItems.Count() != 0)
            {
                base.Repository.Orders.Add(
                new Order
                {
                    Items = this.CurrentlySelectedMenuItems.ToList<MenuItem>(),
                    SpecialRequests = this.SpecialRequests,
                    Table = this._table,
                });
                ClearOrder();
                await new MessageDialog("Your Order has been submitted.").ShowAsync();
                
            }
            else await new MessageDialog("Please first add a selection from the Menu").ShowAsync();
        }

        private void ClearOrder()
        {
            this.CurrentlySelectedMenuItems.Clear();
            this.SpecialRequests = "";            
        }

    }
}

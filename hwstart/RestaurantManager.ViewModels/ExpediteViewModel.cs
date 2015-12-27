using System.Collections.Generic;
using RestaurantManager.Models;

namespace RestaurantManager.ViewModels
{
    public class ExpediteViewModel : ViewModel
    {
        protected override void OnDataLoaded()
        {
            OrderItems = base.Repository.Orders;
        }
        private List<Order> _orderItems;
        public List<Order> OrderItems
        {
            get { return this._orderItems; }
            set
            {
                if (value != _orderItems)
                {
                    _orderItems = value;
                    NotifyPropertyChanged();
                }
            }
        }
    }
}

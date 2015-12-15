using System.Collections.Generic;

namespace RestaurantManager.Models
{
    public class ExpediteDataManager : DataManager
    {
        protected override void OnDataLoaded()
        {
            OrderItems = Repository.Orders;
        }
        private List<Order> _orderItems;
        public List<Order> OrderItems
        {
            get { return base.Repository.Orders; }
            set
            {
                if (value != _orderItems)
                {
                    _orderItems = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}

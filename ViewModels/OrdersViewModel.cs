using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OnlineStore
{
    internal class OrdersViewModel : INotifyPropertyChanged
    {
        private User _user;
        private ObservableCollection<Order> _orders;
        private string _email;
        private string _phoneNumber;
        private string _address;
        public string OrderStatus
        {
            get
            {
                return "В обработке";
            }
        }
        public User User
        {
            get { return _user; }
            set
            {
                _user = value;
                OnPropertyChanged("User");
            }
        }

        public ObservableCollection<Order> Orders
        {
            get { return _orders; }
            set
            {
                _orders = value;
                OnPropertyChanged("Orders");
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged("Email");
            }
        }

        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                _phoneNumber = value;
                OnPropertyChanged("PhoneNumber");
            }
        }

        public string Address
        {
            get { return _address; }
            set
            {
                _address = value;
                OnPropertyChanged("Address");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public OrdersViewModel(User user)
        {
            User = user;
            Orders = new ObservableCollection<Order>(GetOrdersFromDatabase());
            Email = user.Email;
            PhoneNumber = user.PhoneNumber;
            Address = user.Address;
        }

        public OrdersViewModel()
        {
        }
        private IEnumerable<Order> GetOrdersFromDatabase()
        {
            using (var context = new OnlineHorseStoreReview())
            {
                if (User.RoleId == 1)
                {
                    return context.Orders
                    .Include("OrderItems")
                    .ToList();
                }
                else
                {
                    return context.Orders
                    .Include("OrderItems")
                    .Where(o => o.UserId == User.UserId)
                    .ToList();
                }
            }
        }


        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

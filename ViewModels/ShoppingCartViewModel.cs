using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace OnlineStore
{
    public class ShoppingCartViewModel : INotifyPropertyChanged
    {
        private User _user;
        private ObservableCollection<ShoppingCart> _cartItems;
        public ICommand PayCommand { get; private set; }
        public ICommand RemoveFromCartCommand { get; private set; }
        public ICommand OpenProductProfileCommand { get; private set; }

        public User User
        {
            get { return _user; }
            set
            {
                _user = value;
                OnPropertyChanged("User");
            }
        }

        public ObservableCollection<ShoppingCart> CartItems
        {
            get { return _cartItems; }
            set
            {
                _cartItems = value;
                OnPropertyChanged("CartItems");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public ShoppingCartViewModel(User user)
        {
            User = user;
            PayCommand = new RelayCommand(Pay, CanPay);
            CartItems = new ObservableCollection<ShoppingCart>(GetCartItemsFromDatabase());
            RemoveFromCartCommand = new RelayCommand(RemoveFromCart);
            OpenProductProfileCommand = new RelayCommand(OpenProductProfile);
        }

        public ShoppingCartViewModel()
        {
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private void Pay(object parameter)
        {
            if (string.IsNullOrEmpty(User.Address) || string.IsNullOrEmpty(User.PhoneNumber))
            {
                MessageBox.Show("Пожалуйста, укажите свой адрес и номер телефона в профиле перед оплатой.");
            }
            else
            {
                decimal totalAmount = 0;

                using (var context = new OnlineHorseStoreReview())
                {
                    var userInDb = context.Users.FirstOrDefault(u => u.UserId == User.UserId);

                    var orderItems = CartItems.Select(ci => new OrderItem
                    {
                        Horse = context.Horses.FirstOrDefault(g => g.HorseId == ci.Horse.HorseId),
                        Quantity = ci.Quantity
                    }).ToList();

                    totalAmount = orderItems.Sum(oi => oi.Horse.Price * oi.Quantity);

                    var order = new Order
                    {
                        OrderDate = DateTime.Now,
                        User = userInDb,
                        OrderItems = orderItems
                    };

                    context.Orders.Add(order);
                    context.SaveChanges();
                }

                using (var context = new OnlineHorseStoreReview())
                {
                    var itemsInDb = context.ShoppingCarts.Where(i => i.UserId == User.UserId);

                    context.ShoppingCarts.RemoveRange(itemsInDb);
                    context.SaveChanges();

                    CartItems.Clear();
                }
                MessageBox.Show($"Заказ оформлен! Общая сумма заказа: {totalAmount}");
            }
        }

        private bool CanPay(object parameter)
        {
            return CartItems.Any();
        }

        private IEnumerable<ShoppingCart> GetCartItemsFromDatabase()
        {
            using (var context = new OnlineHorseStoreReview())
            {
                return context.ShoppingCarts
                    .Include("Horse")
                    .Where(i => i.UserId == User.UserId)
                    .ToList();
            }
        }
        private void RemoveFromCart(object parameter)
        {
            if (parameter is ShoppingCart cartItem)
            {
                using (var context = new OnlineHorseStoreReview())
                {
                    var itemInDb = context.ShoppingCarts.FirstOrDefault(i => i.ShoppingCartId == cartItem.ShoppingCartId);

                    if (itemInDb != null)
                    {
                        context.ShoppingCarts.Remove(itemInDb);
                        context.SaveChanges();

                        CartItems = new ObservableCollection<ShoppingCart>(GetCartItemsFromDatabase());
                    }
                }
            }
        }

        private void OpenProductProfile(object parameter)
        {
            if (parameter is ShoppingCart cartItem)
            {
                var productProfileWindow = new ProductProfileWindow(cartItem.Horse, User);
                productProfileWindow.ShowDialog();
            }
        }

    }
}

using Microsoft.Win32;
using OnlineStore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace OnlineStore
{
    public class MainCatalogViewModel : INotifyPropertyChanged
    {
        private string _selectedSortOption;
        private string _selectedFilterOption;
        private User _user;
        public MainCatalog _view;
        public Window Window { get; set; }
        private ObservableCollection<Horse> _products;
        private ObservableCollection<Horse> _originalProducts;
        public List<string> Brands { get; private set; }
        public List<string> Models { get; private set; }
        public ICommand ResetCommand { get; private set; }
        public ICommand SortCommand { get; private set; }
        public ICommand FilterCommand { get; private set; }
        public ICommand RemoveHorseCommand { get; private set; }
        public ICommand AddHorseCommand { get; private set; }
        public ICommand OpenProductProfileCommand { get; private set; }
        public ICommand OpenShoppingCartCommand { get; private set; }
        public ICommand OpenFavoriteHorseCommand { get; private set; }
        public ICommand OpenUserProfileCommand { get; private set; }
        public ICommand OpenOrdersCommand { get; private set; }
        public bool IsAdmin
        {
            get { return User.RoleId == 1; }
        }
        public string SelectedSortOption
        {
            get { return _selectedSortOption; }
            set
            {
                _selectedSortOption = value;
                OnPropertyChanged("SelectedSortOption");
                SortCommand.Execute(null);
            }
        }

        public string SelectedFilterOption
        {
            get { return _selectedFilterOption; }
            set
            {
                _selectedFilterOption = value;
                OnPropertyChanged("SelectedFilterOption");
                FilterCommand.Execute(null);
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
        public ObservableCollection<Horse> Products
        {
            get { return _products; }
            set
            {
                _products = value;
                OnPropertyChanged("Products");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public MainCatalogViewModel()
        {
            Products = new ObservableCollection<Horse>(GetProductsFromDatabase());
            _originalProducts = new ObservableCollection<Horse>(GetProductsFromDatabase());
            Products = new ObservableCollection<Horse>(_originalProducts);
            AddHorseCommand = new RelayCommand(AddHorse);
            RemoveHorseCommand = new RelayCommand(RemoveHorse);
            OpenProductProfileCommand = new RelayCommand(OpenProductProfile);
            OpenShoppingCartCommand = new RelayCommand(OpenShoppingCart);
            OpenFavoriteHorseCommand = new RelayCommand(OpenFavoriteHorses);
            OpenUserProfileCommand = new RelayCommand(OpenUserProfile);
            OpenOrdersCommand = new RelayCommand(OpenOrders);
            SortCommand = new RelayCommand(Sort);
            FilterCommand = new RelayCommand(Filter);
            ResetCommand = new RelayCommand(Reset);
            Brands = GetBrandsFromDatabase();
            Models = GetModelsFromDatabase();
        }
        public MainCatalogViewModel(User user) : this()
        {
            User = user;
        }
        private void OpenUserProfile(object parameter)
        {
            var userProfileWindow = new UserProfileWindow(User);
            userProfileWindow.ShowDialog();
        }
        private void OpenFavoriteHorses(object parameter)
        {
            var favoriteHorsesWindow = new FavoriteHorseWindow(User);
            favoriteHorsesWindow.ShowDialog();
        }
        private void OpenShoppingCart(object parameter)
        {
            var shoppingCartWindow = new ShoppingCartWindow(User);
            shoppingCartWindow.ShowDialog();
        }
        private void OpenOrders(object parameter)
        {
            var ordersWindow = new OrdersWindow(User);
            ordersWindow.ShowDialog();
        }
        private void AddHorse(object parameter)
        {
            var addHorsesWindow = new AddHorseWindow();
            addHorsesWindow.ShowDialog();
            Products = new ObservableCollection<Horse>(GetProductsFromDatabase());
        }
        private void OpenProductProfile(object parameter)
        {
            if (parameter is Horse horse)
            {
                var productProfileWindow = new ProductProfileWindow(horse, User);
                productProfileWindow.ShowDialog();
            }
        }
        public Visibility AddHorseVisibility
        {
            get { return User.RoleId == 1 ? Visibility.Visible : Visibility.Collapsed; }
        }

        public Visibility RemoveHorseVisibility
        {
            get { return User.RoleId == 1 ? Visibility.Visible : Visibility.Collapsed; }
        }
        private void Reset(object parameter)
        {
            Products = new ObservableCollection<Horse>(_originalProducts);
        }
        private List<string> GetBrandsFromDatabase()
        {
            using (var context = new OnlineHorseStoreReview())
            {
                return context.Horses.Select(g => g.Brand).Distinct().ToList();
            }
        }
        private List<string> GetModelsFromDatabase()
        {
            using (var context = new OnlineHorseStoreReview())
            {
                return context.Horses.Select(g => g.Model).Distinct().ToList();
            }
        }
        private void Sort(object parameter)
        {
            string sortOption = parameter as string;
            if (sortOption == "PriceAscending")
            {
                Products = new ObservableCollection<Horse>(Products.OrderBy(g => g.Price));
            }
            else if (sortOption == "PriceDescending")
            {
                Products = new ObservableCollection<Horse>(Products.OrderByDescending(g => g.Price));
            }
        }
        private void Filter(object parameter)
        {
            string filterOption = parameter as string;
            if (Brands.Contains(filterOption))
            {
                Products = new ObservableCollection<Horse>(_originalProducts.Where(g => g.Brand == filterOption));
            }
            else if (Models.Contains(filterOption))
            {
                Products = new ObservableCollection<Horse>(_originalProducts.Where(g => g.Model == filterOption));
            }
        }
        private void RemoveHorse(object parameter)
        {
            if (parameter is Horse horse)
            {
                using (var context = new OnlineHorseStoreReview())
                {
                    var horseInDb = context.Horses.FirstOrDefault(g => g.HorseId == horse.HorseId);

                    if (horseInDb != null)
                    {
                        context.Horses.Remove(horseInDb);
                        context.SaveChanges();

                        Products = new ObservableCollection<Horse>(GetProductsFromDatabase());
                    }
                }
            }
        }
        public void UpdateUserProfile()
        {
            using (var context = new OnlineHorseStoreReview())
            {
                var userInDb = context.Users.FirstOrDefault(u => u.UserId == User.UserId);

                if (userInDb != null)
                {
                    userInDb.Address = User.Address;
                    context.SaveChanges();
                }
            }
        }
        private IEnumerable<Horse> GetProductsFromDatabase()
        {
            using (var context = new OnlineHorseStoreReview())
            {
                return context.Horses.ToList();
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

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
    public class FavouriteHorseViewModel : INotifyPropertyChanged
    {
        private User _user;
        private ObservableCollection<FavouriteHorse> _favoriteHorses;

        public ICommand RemoveFromFavoritesCommand { get; private set; }
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

        public ObservableCollection<FavouriteHorse> FavoriteHorses
        {
            get { return _favoriteHorses; }
            set
            {
                _favoriteHorses = value;
                OnPropertyChanged("FavoriteHorses");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public FavouriteHorseViewModel(User user)
        {
            User = user;
            FavoriteHorses = new ObservableCollection<FavouriteHorse>(GetFavoriteHorsesFromDatabase());
            RemoveFromFavoritesCommand = new RelayCommand(RemoveFromFavorites);
            OpenProductProfileCommand = new RelayCommand(OpenProductProfile);
        }

        public FavouriteHorseViewModel()
        {
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private IEnumerable<FavouriteHorse> GetFavoriteHorsesFromDatabase()
        {
            using (var context = new OnlineHorseStoreReview())
            {
                return context.FavoriteHorses
                    .Include("Horse")
                    .Where(i => i.User.UserId == User.UserId)
                    .ToList();
            }
        }

        private void RemoveFromFavorites(object parameter)
        {
            if (parameter is FavouriteHorse favHorse)
            {
                using (var context = new OnlineHorseStoreReview())
                {
                    var itemInDb = context.FavoriteHorses.FirstOrDefault(i => i.FavouriteHorseId == favHorse.FavouriteHorseId);

                    if (itemInDb != null)
                    {
                        context.FavoriteHorses.Remove(itemInDb);
                        context.SaveChanges();

                        FavoriteHorses = new ObservableCollection<FavouriteHorse>(GetFavoriteHorsesFromDatabase());
                    }
                }
            }
        }

        private void OpenProductProfile(object parameter)
        {
            if (parameter is FavouriteHorse favHorse)
            {
                var productProfileWindow = new ProductProfileWindow(favHorse.Horse, User);
                productProfileWindow.ShowDialog();
            }
        }
    }
}

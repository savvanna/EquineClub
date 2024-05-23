using Microsoft.Win32;
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
    public class ProductProfileViewModel : INotifyPropertyChanged
    {
        private Horse _horse;
        private User _user;
        private string _newComment;
        public ICommand AddToCartCommand { get; private set; }
        public ICommand AddToFavoritesCommand { get; private set; }
        public ICommand AddCommentCommand { get; private set; }
        public ICommand DeleteCommentCommand { get; private set; }
        private ObservableCollection<HorseReview> _horseReviews;
        public ObservableCollection<HorseReview> HorseReviews
        {
            get { return _horseReviews; }
            set
            {
                _horseReviews = value;
                OnPropertyChanged("HorseReviews");
            }
        }
        public string NewComment
        {
            get { return _newComment; }
            set
            {
                _newComment = value;
                OnPropertyChanged("NewComment");
            }
        }

        public Horse Horse
        {
            get { return _horse; }
            set
            {
                _horse = value;
                OnPropertyChanged("Horse");
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

        public event PropertyChangedEventHandler PropertyChanged;

        public ProductProfileViewModel(Horse horse, User user)
        {
            Horse = horse;
            User = user;
            AddToCartCommand = new RelayCommand(AddToCart);
            AddToFavoritesCommand = new RelayCommand(AddToFavorites);
            AddCommentCommand = new RelayCommand(AddComment);
            DeleteCommentCommand = new RelayCommand(DeleteComment);
            HorseReviews = new ObservableCollection<HorseReview>(GetHorseReviewsFromDB());
        }
        public ProductProfileViewModel(Horse horse)
        {
            Horse = horse;
        }

        public ProductProfileViewModel()
        {
        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void DeleteComment(object parameter)
        {
            if (parameter is HorseReview reviewToDelete)
            {
                using (var context = new OnlineHorseStoreReview())
                {
                    var reviewInDb = context.HorseReviews.FirstOrDefault(r => r.HorseReviewId == reviewToDelete.HorseReviewId);
                    if (reviewInDb != null)
                    {
                        if (reviewInDb.UserId != User.UserId)
                        {
                            MessageBox.Show("Вы можете удалить только свой комментарий!");
                            return;
                        }

                        context.HorseReviews.Remove(reviewInDb);
                        context.SaveChanges();

                        HorseReviews.Remove(reviewToDelete);
                        MessageBox.Show("Комментарий успешно удален!");
                    }
                }
            }
        }
        private void AddComment(object parameter)
        {
            if (string.IsNullOrWhiteSpace(NewComment))
            {
                MessageBox.Show("Комментарий не может быть пустым.");
                return;
            }
            using (var context = new OnlineHorseStoreReview())
            {
                var horseInDb = context.Horses.FirstOrDefault(g => g.HorseId == Horse.HorseId);
                var userInDb = context.Users.FirstOrDefault(u => u.UserId == User.UserId);
                if (horseInDb != null && userInDb != null)
                {
                    var review = new HorseReview
                    {
                        Content = NewComment,
                        Horse = horseInDb,
                        User = userInDb
                    };

                    context.HorseReviews.Add(review);
                    context.SaveChanges();

                    HorseReviews.Add(review);
                    MessageBox.Show("Комментарий успешно добавлен!");
                    NewComment = string.Empty;
                }
            }
        }
        private IEnumerable<HorseReview> GetHorseReviewsFromDB()
        {
            using (var context = new OnlineHorseStoreReview())
            {
                return context.HorseReviews
                    .Include("User") 
                    .Where(gr => gr.HorseId == Horse.HorseId)
                    .ToList();
            }
        }

        private void AddToFavorites(object parameter)
        {
            using (var context = new OnlineHorseStoreReview())
            {
                var existingItem = context.FavoriteHorses.FirstOrDefault(i => i.HorseId == Horse.HorseId && i.UserId == User.UserId);

                if (existingItem == null)
                {
                    var existingUser = context.Users.Find(User.UserId);
                    var existingHorse = context.Horses.Find(Horse.HorseId);

                    var favoriteItem = new FavouriteHorse
                    {
                        User = existingUser,
                        Horse = existingHorse
                    };
                    context.FavoriteHorses.Add(favoriteItem);
                    context.SaveChanges();
                    MessageBox.Show("Лошадь успешно добавлена в избранное!");
                }
                else
                {
                    MessageBox.Show("Эта лошадь уже есть в вашем избранном!");
                }
            }
        }
        private void AddToCart(object parameter)
        {
            using (var context = new OnlineHorseStoreReview())
            {
                var userInDb = context.Users.FirstOrDefault(u => u.UserId == User.UserId);
                var horseInDb = context.Horses.FirstOrDefault(g => g.HorseId == Horse.HorseId);

                if (userInDb != null && horseInDb != null)
                {
                    var existingItem = context.ShoppingCarts.FirstOrDefault(i => i.HorseId == horseInDb.HorseId && i.UserId == userInDb.UserId);

                    if (existingItem != null)
                    {
                        existingItem.Quantity++;
                    }
                    else
                    {
                        var cartItem = new ShoppingCart
                        {
                            User = userInDb,
                            Horse = horseInDb,
                            Quantity = 1
                        };
                        context.ShoppingCarts.Add(cartItem);
                    }
                    context.SaveChanges();
                    MessageBox.Show("Лошадь успешно добавлена в корзину!");
                }
            }
        }
    }
}

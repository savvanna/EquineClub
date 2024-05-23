using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace OnlineStore
{
    public partial class UserProfileViewModel : INotifyPropertyChanged
    {
        private User _user;
        public ICommand ShowUserProfileCommand { get; private set; }
        public ICommand UpdateAddressCommand { get; private set; }
        public ICommand UpdatePhoneNumberCommand { get; private set; }
        public ICommand UpdateProfileImageCommand { get; private set; }
        public User User
        {
            get { return _user; }
            set
            {
                if (_user != value)
                {
                    _user = value;
                    OnPropertyChanged("User");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public UserProfileViewModel(User user)
        {
            User = user;
            UpdateAddressCommand = new RelayCommand(UpdateAddress);
            UpdatePhoneNumberCommand = new RelayCommand(UpdatePhoneNumber);
            UpdateProfileImageCommand = new RelayCommand(UpdateProfileImage);
        }
        public UserProfileViewModel()
        {
        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private void UpdatePhoneNumber(object obj)
        {
            var phoneNumberRegex = new Regex(@"^\+?(\d[\d-. ]+)?(\([\d-. ]+\))?[\d-. ]+\d$");
            if (!phoneNumberRegex.IsMatch(User.PhoneNumber))
            {
                MessageBox.Show("Номер телефона недействителен.");
                return;
            }

            using (var context = new OnlineHorseStoreReview())
            {
                var userInDb = context.Users.FirstOrDefault(u => u.UserId == User.UserId);
                if (userInDb != null)
                {
                    userInDb.PhoneNumber = User.PhoneNumber;
                    context.SaveChanges();
                    MessageBox.Show("Номер телефона успешно обновлен!");
                }
            }
        }

        private void UpdateAddress(object obj)
        {
            using (var context = new OnlineHorseStoreReview())
            {
                var userInDb = context.Users.FirstOrDefault(u => u.UserId == User.UserId);
                if (userInDb != null)
                {
                    userInDb.Address = User.Address;
                    context.SaveChanges();
                    MessageBox.Show("Адрес успешно обновлен!");
                }
            }
        }
        private void UpdateProfileImage(object obj)
        {
            if (obj is string imagePath)
            {
                User.ImagePath = imagePath;
                using (var context = new OnlineHorseStoreReview())
                {
                    var userInDb = context.Users.FirstOrDefault(u => u.UserId == User.UserId);
                    if (userInDb != null)
                    {
                        userInDb.ImagePath = User.ImagePath;
                        context.SaveChanges();
                        MessageBox.Show("Изображение профиля успешно обновлено!");
                    }
                }
            }
        }

    }
}

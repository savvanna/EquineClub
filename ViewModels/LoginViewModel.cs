using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using OnlineStore;
using System.Data.Entity;
using System.Security.Cryptography;

namespace OnlineStore
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public Window Window { get; set; }
        private string _username;
        private string _password;

        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                OnPropertyChanged("Username");
                CommandManager.InvalidateRequerySuggested();
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged("Password");
                CommandManager.InvalidateRequerySuggested();
            }
        }

        public ICommand LoginCommand { get; private set; }

        public LoginViewModel()
        {
            LoginCommand = new RelayCommand(Login, CanLogin);
        }

        private bool CanLogin(object parameter)
        {
            return !string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Password);
        }
        private async void Login(object parameter)
        {
            using (var db = new OnlineHorseStoreReview())
            {
                var user = await db.Users.FirstOrDefaultAsync(u => u.Username == Username);
                if (user != null)
                {
                    using (SHA256 sha256Hash = SHA256.Create())
                    {
                        byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(Password));
                        StringBuilder builder = new StringBuilder();
                        for (int i = 0; i < bytes.Length; i++)
                        {
                            builder.Append(bytes[i].ToString("x2"));
                        }
                        Password = builder.ToString();
                    }
                    if (user.Password == Password)
                    {
                        var mainCatalogWindow = new MainCatalog(user);
                        Application.Current.MainWindow = mainCatalogWindow;
                        Application.Current.MainWindow.Show();
                        Window.Close();
                    }
                    else
                    {
                        MessageBox.Show("Неверное имя пользователя или пароль.");
                    }
                }
                else
                {
                    MessageBox.Show("Неверное имя пользователя или пароль.");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}

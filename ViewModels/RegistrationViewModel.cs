using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using OnlineStore;
using System.Text.RegularExpressions;
using System.Security.Cryptography;

namespace OnlineStore
{
    public class RegistrationViewModel : INotifyPropertyChanged
    {
        public Window Window { get; set; }
        private string _username;
        private string _password;
        private string _email;
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
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged("Email");
                CommandManager.InvalidateRequerySuggested();
            }
        }
        public ICommand RegisterCommand { get; private set; }
        public RegistrationView _view;
        public RegistrationViewModel(RegistrationView view)
        {
            _view = view;
            RegisterCommand = new RelayCommand(Register, CanRegister);
        }
        private bool CanRegister(object parameter)
        {
            return !string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Password) && !string.IsNullOrWhiteSpace(Email);
        }
        private void Register(object parameter)
        {
            var passwordRegex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$");
            if (!passwordRegex.IsMatch(Password))
            {
                MessageBox.Show("Пароль должен содержать как минимум одну заглавную букву, одну строчную букву, одну цифру и быть не менее 8 символов.");
                return;
            }
            using (var db = new OnlineHorseStoreReview())
            {
                var existingUser = db.Users.FirstOrDefault(u => u.Username == Username || u.Email == Email);
                if (existingUser != null)
                {
                    MessageBox.Show("Пользователь с таким именем или email уже существует.");
                    return;
                }
                try
                {
                    var addr = new System.Net.Mail.MailAddress(Email);
                    if (addr.Address != Email)
                    {
                        MessageBox.Show("Неверный адрес электронной почты.");
                        return;
                    }
                }
                catch
                {
                    MessageBox.Show("Неверный адрес электронной почты.");
                    return;
                }
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

                var user = new User
                {
                    Username = Username,
                    Password = Password,
                    Email = Email,
                    RoleId = 2
                };
                db.Users.Add(user);
                db.SaveChanges();

                var mainCatalogWindow = new MainCatalog(user);
                mainCatalogWindow.Show();
                _view.Close();

                MessageBox.Show("Регистрация прошла успешно!");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

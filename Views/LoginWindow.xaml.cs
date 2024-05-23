using OnlineStore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace OnlineStore
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            var viewModel = new LoginViewModel();
            viewModel.Window = this; 
            this.DataContext = viewModel;

            string cursorDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\cursor\\design_cursors\\pointer.cur";
            var Cursor = new Cursor(cursorDirectory);
            this.Cursor = Cursor;
        }

        public LoginWindow(User user)
        {
            InitializeComponent();
        }
        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext != null)
            {
                var pBox = sender as PasswordBox;
                ((dynamic)DataContext).Password = pBox.Password;
            }
        }
        private void LoginWindow_Closed(object sender, EventArgs e)
        {
            var mainCatalogWindow = new MainCatalog();
            Application.Current.MainWindow = mainCatalogWindow;
            Application.Current.MainWindow.Show();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            RegistrationView registationWindow = new RegistrationView();
            registationWindow.Show();
            Close();
        }
    }
}

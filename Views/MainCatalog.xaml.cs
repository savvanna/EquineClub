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
    public partial class MainCatalog : Window
    {
        public MainCatalog()
        {
            InitializeComponent();
            this.DataContext = new MainCatalogViewModel();
            string cursorDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\cursor\\design_cursors\\pointer.cur";
            var Cursor = new Cursor(cursorDirectory);
            this.Cursor = Cursor;
        }
        public MainCatalog(User user)
        {
            InitializeComponent();
            this.DataContext = new MainCatalogViewModel(user);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RegistrationView registrationWindow = new RegistrationView();
            registrationWindow.Show();
            Close();
        }
    }
}

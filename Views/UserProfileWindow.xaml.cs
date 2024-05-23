using Microsoft.Win32;
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
    public partial class UserProfileWindow : Window
    {
        public UserProfileWindow()
        {
            InitializeComponent();
            this.DataContext = new UserProfileViewModel();
            string cursorDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\cursor\\design_cursors\\pointer.cur";
            var Cursor = new Cursor(cursorDirectory);
            this.Cursor = Cursor;
        }
        public UserProfileWindow(User user)
        {
            InitializeComponent();
            this.DataContext = new UserProfileViewModel(user);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg;*.jpg;*.bmp)|*.png;*.jpeg;*.jpg;*.bmp|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                string imagePath = openFileDialog.FileName;
                var viewModel = (UserProfileViewModel)DataContext;
                viewModel.User.ImagePath = imagePath;
                using (var context = new OnlineHorseStoreReview())
                {
                    var userInDb = context.Users.FirstOrDefault(u => u.UserId == viewModel.User.UserId);
                    if (userInDb != null)
                    {
                        userInDb.ImagePath = viewModel.User.ImagePath;
                        context.SaveChanges();
                        MessageBox.Show("Изображение профиля успешно обновлено!");
                    }
                }
                ImageBrush newImageBrush = new ImageBrush();
                newImageBrush.ImageSource = new BitmapImage(new Uri(imagePath));
                ProfileImage.Fill = newImageBrush;
            }
        }

    }
}

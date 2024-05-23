using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Shapes;
using Path = System.IO.Path;
using System.Windows.Input;

namespace OnlineStore
{
    public partial class AddHorseWindow : Window
    {
        public AddHorseWindow()
        {
            InitializeComponent();
            var viewModel = new AddHorseViewModel();
            viewModel.Window = this;
            this.DataContext = viewModel;

            string cursorDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\cursor\\design_cursors\\pointer.cur";
            var Cursor = new Cursor(cursorDirectory);
            this.Cursor = Cursor;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                ((AddHorseViewModel)this.DataContext).ImagePath = openFileDialog.FileName;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace OnlineStore
{
    public class AddHorseViewModel : INotifyPropertyChanged
    {
        public Window Window { get; set; }
        private string _brand;
        private string _model;
        private decimal _price;
        private string _imagePath;

        public string Brand
        {
            get { return _brand; }
            set
            {
                _brand = value;
                OnPropertyChanged("Brand");
            }
        }

        public string Model
        {
            get { return _model; }
            set
            {
                _model = value;
                OnPropertyChanged("Model");
            }
        }

        public decimal Price
        {
            get { return _price; }
            set
            {
                _price = value;
                OnPropertyChanged("Price");
            }
        }

        public string ImagePath
        {
            get { return _imagePath; }
            set
            {
                _imagePath = value;
                OnPropertyChanged("ImagePath");
            }
        }

        public ICommand AddHorseCommand { get; private set; }

        public AddHorseViewModel()
        {
            AddHorseCommand = new RelayCommand(AddHorse);
        }

        private void AddHorse(object parameter)
        {
            if (string.IsNullOrWhiteSpace(this.Brand) ||
                string.IsNullOrWhiteSpace(this.Model) ||
                this.Price <= 0 ||
                string.IsNullOrWhiteSpace(this.ImagePath))
            {
                MessageBox.Show("Все поля должны быть заполнены!");
                return;
            }

            using (var db = new OnlineHorseStoreReview())
            {
                var horse = new Horse
                {
                    Brand = this.Brand,
                    Model = this.Model,
                    Price = this.Price,
                    ImagePath = this.ImagePath
                };
                db.Horses.Add(horse);
                db.SaveChanges();
            }

            MessageBox.Show("Лошадь успешно добавлена!");

            Window.Close();
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

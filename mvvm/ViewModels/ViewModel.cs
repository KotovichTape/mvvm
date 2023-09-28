using mvvm.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace mvvm.ViewModels
{
    class ViewModel : INotifyPropertyChanged
    {
        private Model model;
        public ViewModel() 
        {
            model = new Model();
        }

        public string[] ModelFiles
        {
            get
            {
                return model.Files;
            }
            set { model.Files = value; OnPropertyChanged(nameof(ModelFiles)); }
        }
        public ImageSource ModelPath
        {
            get
            {
                return model.Path;
            }
            set
            {
                model.Path = value; OnPropertyChanged(nameof(ModelPath));
            }
        }

        public string Name
        {
            get
            {
                return model.Name;
            }
            set
            {
                model.Name = value; OnPropertyChanged(nameof(Name));
            }
        }

        public void GetImage(int i)
        {
            ModelPath = (new ImageSourceConverter().ConvertFromString(ModelFiles[i]) as ImageSource);
            Name = (ModelFiles[i].Split("\\").Last().Split(".").First());
        }


        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

using Microsoft.WindowsAPICodePack.Dialogs;
using mvvm.ViewModels;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace mvvm
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ViewModel VM;
        int index = 0;
        public MainWindow()
        {
            VM = new ViewModel();
            InitializeComponent();
            this.DataContext = VM;
        }

        private void OpenFolders(object sender, ExecutedRoutedEventArgs e)
        {
            var dialog = new CommonOpenFileDialog()
            {
                IsFolderPicker = true
            };
            var res = dialog.ShowDialog();
            if (res == CommonFileDialogResult.Ok)
            {
                string[] files = Directory.GetFiles(dialog.FileName);
                List<string> data = new List<string>();

                foreach ( string file in files )
                {
                    if(file.Contains(".jpg") || file.Contains(".png"))
                        data.Add(file);
                }

                VM.ModelFiles = data.ToArray();
                VM.GetImage(index);
            }
        }

        private void GetNextImage(object sender, ExecutedRoutedEventArgs e)
        {
            index++;
            if(index <= VM.ModelFiles.Length-1)
            {
                this.DataContext = null;
                VM.GetImage(index);
                this.DataContext = VM;
            }
            else
            {
                index--;
            }
        }

        private void GetPrevImage(object sender, ExecutedRoutedEventArgs e)
        {
            index--;
            if (index >= 0)
            {
                this.DataContext = null;
                VM.GetImage(index);
                this.DataContext = VM;
            }
            else
            {
                index++;
            }
        }
    }
}

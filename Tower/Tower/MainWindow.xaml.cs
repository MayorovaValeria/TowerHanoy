using System;
using System.Collections.Generic;
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

namespace Tower
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Panel fromTower = null;
        Brush noActive = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
        Brush Active = new SolidColorBrush(Color.FromArgb(128, 0xCC, 0xCC, 0xCC));


        public MainWindow()
        {
            InitializeComponent();
        }


        private void tossdisk_GotFocus(object sender, MouseEventArgs e)
        {
            if (!(sender is Panel))
                return;
            var toTower = (Panel)sender;
            if (fromTower == null)
            {
                if (toTower.Children.Count > 0)
                {
                    fromTower = (Panel)sender;
                    fromTower.Background = Active;
                }
            }
            else if (toTower == fromTower)
            {
                fromTower.Background = noActive;
                fromTower = null;
            }
            else
            {
                var disk = fromTower.Children[fromTower.Children.Count - 1];
                if (toTower.Children.Count == 0 || (disk as Shape).Width < (toTower.Children[toTower.Children.Count - 1] as Shape).Width)
                {
                    fromTower.Children.Remove(disk);
                    toTower.Children.Add(disk);
                    fromTower.Background = noActive;
                    fromTower = null;
                }
                else
                {
                    MessageBox.Show("Неверный ход!");
                }
            }
        }


    }
}

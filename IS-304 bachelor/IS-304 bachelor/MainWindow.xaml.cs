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
using Microsoft.Maps.MapControl.WPF;


 

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {   
        public MainWindow()
        {
            InitializeComponent();
            myMap.MouseDoubleClick += map_MouseDoubleClick;
            
            
        }

        private void map_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            // TODO
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
            myMap.Center = new Location(58.1453, 7.9571, 0.0000);
            myMap.ZoomLevel = 9.0;
        }


        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private  void SearchTextBox_Search(object sender, TextChangedEventArgs e)
        {
           
            
        }

        private void SearchTextBox_TextChanged(object sender, RoutedEventArgs e)
        {
            
        }


        private void SearchTextBox_LostFocus(object sender, System.EventArgs e)
	{
       
	}

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Docs.GetDatabase();         


        }
    }
}

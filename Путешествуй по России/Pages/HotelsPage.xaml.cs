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

namespace Путешествуй_по_России.Pages
{
    /// <summary>
    /// Логика взаимодействия для HotelsPage.xaml
    /// </summary>
    public partial class HotelsPage : Page
    {
        private int _currentPage = 1;
        private int _maxPage = 0;

        public HotelsPage()
        {
            InitializeComponent();
            UpdateHotels();
        }

        private void UpdateHotels()
        {
            try
            {
                DgHotels.ItemsSource = ToursEntities.GetContext().Hotel.ToList();
                _maxPage = Convert.ToInt32(Math.Ceiling(ToursEntities.GetContext().Hotel.ToList().Count * 1.0 / 10));
                var listHotels = ToursEntities.GetContext().Hotel.ToList().Skip((_currentPage -1) * 10).Take(10).ToList();


            }
            catch
            {
                
            }
        }
        private void BtnDeleteHotel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnNextPage_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnLastPage_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnPrevPage_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnFirstPage_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

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
    /// Логика взаимодействия для ToursPage.xaml
    /// </summary>
    public partial class ToursPage : Page
    {
        private List<Tour> _tours=new List<Tour>();
        public ToursPage()
        {
            InitializeComponent();
            CheckActual.IsChecked = true;
            _tours = ToursEntities.GetContext().Tour.ToList();
            UpdateTours();
            ComboTypes.ItemsSource = ToursEntities.GetContext().Type.ToList();

        }

        private void UpdateTours()
        {
            
            if (CheckActual.IsChecked==true) {
                _tours = _tours.OrderBy(tour => tour.Name).Where(tour => tour.IsActual).ToList();
            }
            if (TbName.Text != "")
            {
                _tours = _tours.Where(tour=>tour.Name.ToLower().Contains(TbName.Text.ToLower())).ToList();
            }
            if (TbDescription.Text != "")
            {
                _tours = _tours.Where(tour => tour.Description.ToLower().Contains(TbDescription.Text.ToLower())).ToList();
            }

            LvTours.ItemsSource =_tours;
        }

        private void ComboTypes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _tours= ToursEntities.GetContext().Tour.ToList();
            UpdateTours();
        }

        private void CheckActual_Checked(object sender, RoutedEventArgs e)
        {
            _tours = ToursEntities.GetContext().Tour.ToList();
            UpdateTours();
        }

        private void CheckActual_Unchecked(object sender, RoutedEventArgs e)
        {
            _tours = ToursEntities.GetContext().Tour.ToList();
            UpdateTours();
        }

        private void BtnSortToHigh_Click(object sender, RoutedEventArgs e)
        {
            LvTours.ItemsSource = _tours.OrderBy(p=>p.Price).ToList();
        }

        private void BtnSortToLow_Click(object sender, RoutedEventArgs e)
        {
            LvTours.ItemsSource = _tours.OrderByDescending(p => p.Price).ToList();
        }

        private void TbName_TextChanged(object sender, TextChangedEventArgs e)
        {
            _tours = ToursEntities.GetContext().Tour.ToList();
            UpdateTours();
        }

        private void TbDescription_TextChanged(object sender, TextChangedEventArgs e)
        {
            _tours = ToursEntities.GetContext().Tour.ToList();
            UpdateTours();
        }
    }
}

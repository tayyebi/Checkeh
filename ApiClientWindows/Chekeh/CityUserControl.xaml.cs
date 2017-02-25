using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

namespace Chekeh
{
    /// <summary>
    /// Interaction logic for CityUserControl.xaml
    /// </summary>
    public partial class CityUserControl : UserControl
    {
        public CityUserControl()
        {
            InitializeComponent();
        }

        public string CityName { get; set; }
        public Guid Id { get; set; }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            label_Title.Content = CityName;
        }

        private void button_Details_Click(object sender, RoutedEventArgs e)
        {
            new CityDetails { CityName = CityName, Id = Id }.ShowDialog();
        }

        private void button_Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var request = WebRequest.Create(About.Server + "Cities/" + Id.ToString());
                request.Method = "DELETE";
                var response = (HttpWebResponse)request.GetResponse();
                Visibility = Visibility.Hidden;
            }
            catch {
                MessageBox.Show("خطا در اعلام درخواست به سرور");
            }
        }
    }
}

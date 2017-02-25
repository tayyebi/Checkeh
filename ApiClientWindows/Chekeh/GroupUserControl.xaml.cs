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
    /// Interaction logic for GroupUserControl.xaml
    /// </summary>
    public partial class GroupUserControl : UserControl
    {
        public string GroupName { get; set; }
        public Guid Id { get; set; }

        public GroupUserControl()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            label_Title.Content = GroupName;
        }

        private void button_Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var request = WebRequest.Create(About.Server + "Groups/" + Id.ToString());
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

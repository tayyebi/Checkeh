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
using System.Windows.Shapes;

namespace Chekeh
{
    /// <summary>
    /// Interaction logic for UserDetails.xaml
    /// </summary>
    public partial class UserDetails : Window
    {
        public UserDetails()
        {
            InitializeComponent();
        }
        public Guid UserId { get; set; }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    client.Encoding = Encoding.UTF8;

                    string data = client.DownloadString(About.Server + "Owner/" + UserId);
                    data = data.Remove(data.Length - 1);
                    data = data.Substring(1, data.Length - 1);

                    foreach (string column in data.Split(new string[] { "," }, StringSplitOptions.None))
                    {
                        string[] item = column.Split(':');

                        item[0] = item[0].Remove(item[0].Length - 1);
                        item[0] = item[0].Substring(1, item[0].Length - 1);

                        item[1] = item[1].Remove(item[1].Length - 1);
                        item[1] = item[1].Substring(1, item[1].Length - 1);

                        if (item[0] == "Username")
                            label_Username.Content = item[1];
                        else if (item[0] == "FirstName")
                            label_FirstName.Content += item[1];
                        else if (item[0] == "LastName")
                            label_LastName.Content += item[1];
                        else if (item[0] == "NationalCode")
                            label_NationalCode.Content += item[1];
                        else if (item[0] == "Address")
                            label_Address.Content += item[1];
                        else if (item[0] == "PostalCode")
                            label_PostalCode.Content += item[1];
                        else if (item[0] == "PhoneNumber")
                            label_PhoneNumber.Content += item[1];
                    }
                }
            }
            catch
            {
                MessageBox.Show("خطا در دریافت اطلاعات");
                this.Close();
            }
        }

        private void button_Chat_Click(object sender, RoutedEventArgs e)
        {
            new AdminChat { ReciverId = UserId }.ShowDialog();
        }
    }
}
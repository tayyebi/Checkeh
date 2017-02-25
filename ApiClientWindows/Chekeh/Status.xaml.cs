using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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
    /// Interaction logic for Status.xaml
    /// </summary>
    public partial class Status : UserControl
    {
        public Guid OwnerId { get; set; }
        public string Username { get; set; }

        public Status()
        {
            InitializeComponent();
        }
        public void done()
        {
            button_accept.IsEnabled = button_details.IsEnabled = button_drop.IsEnabled = false;
            label_username.Content = "انجام شد";
        }

        public void SendStatus(string Status)
        {
            using (WebClient client = new WebClient())
            {
                client.Encoding = Encoding.UTF8;

                NameValueCollection nvc = new NameValueCollection();
                nvc["Status"] = Status;
                client.UploadValues(About.Server + "OwnerStatus/" + OwnerId, nvc);
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            label_username.Content = Username;
        }

        private void button_details_Click(object sender, RoutedEventArgs e)
        {
            new UserDetails { UserId = OwnerId }.Show();

        }

        private void button_drop_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SendStatus("NotConfirmed");
                done();
            }
            catch { MessageBox.Show("اعلام خطا از طرف سرور"); }

        }

        private void button_accept_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SendStatus("Confirmed");
                done();
            }
            catch { MessageBox.Show("اعلام خطا از طرف سرور"); }
        }
    }
}
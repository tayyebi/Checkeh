using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button_Login_Click(object sender, RoutedEventArgs e)
        {
            textbox_Username.IsEnabled = textbox_Password.IsEnabled = false;
            try
            {
                using (WebClient client = new WebClient())
                {
                    client.Encoding = Encoding.UTF8;

                    string userType = client.DownloadString(About.Server + "Login?" + "Username=" + textbox_Username.Text + "&Password=" + textbox_Password.Password).Replace("\"", null);
                    if (userType == "owner")
                    {
                        About.Username = textbox_Username.Text;
                        About.Status = client.DownloadString(About.Server + "AdminOwner/" + textbox_Username.Text).Replace("\"", null);
                            About.Identifier = client.DownloadString(About.Server + "HumanIdentifier/" + About.Username).Replace("\"", null);

                        Main mw = new Main();
                        mw.Show();
                        this.Close();

                        using (WebClient client2 = new WebClient())
                        {
                            client.Encoding = Encoding.UTF8;
                            About.Identifier = client.DownloadString(About.Server + "HumanIdentifier/" + About.Username).Replace("\"", null);
                        }
                    }
                    else if (userType == "admin")
                    {
                        About.Username = textbox_Username.Text;
                        About.Status = null;
                        About.Password = textbox_Password.Password;
                            About.Identifier = client.DownloadString(About.Server + "HumanIdentifier/" + About.Username).Replace("\"", null);
                    

                        new AdminMain { }.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("نام کاربری یا کلمه عبور معتبر نیست. آیا پیشتر ثبت نام کرده اید؟");
                    }
                }
            }
            catch {
                MessageBox.Show("ارتباط با سرور برقرار نیست");
            }
            textbox_Username.IsEnabled = textbox_Password.IsEnabled = true;
        }

        private void button_Register_Click(object sender, RoutedEventArgs e)
        {
            ((Window)(new Register { })).Show();
            this.Close();
        }
    }
}
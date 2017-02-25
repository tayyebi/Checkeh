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
using System.Windows.Shapes;

namespace Chekeh
{
    /// <summary>
    /// Interaction logic for Reigster.xaml
    /// </summary>
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
        }

        private void button_Regsiter_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (textbox_Password.Password == textbox_ConfirmPass.Password)
                {
                    using (WebClient client = new WebClient())
                    {
                        client.Encoding = Encoding.UTF8;

                        NameValueCollection data = new NameValueCollection();
                        data["Username"] = textbox_Username.Text;
                        data["Password"] = textbox_Password.Password;
                        data["FirstName"] = textbox_FirstName.Text;
                        data["LastName"] = textbox_LastName.Text;
                        data["NationalCode"] = textbox_NationalCode.Text;
                        data["Address"] = new TextRange(textbox_Address.Document.ContentStart, textbox_Address.Document.ContentEnd).Text;
                        data["PostalCode"] = textbox_PostalCode.Text;
                        data["PhoneNumber"] = textbox_PhoneNumber.Text;
                        string response = Encoding.UTF8.GetString(client.UploadValues(About.Server + "Owner", data));

                        About.Username = textbox_Username.Text;
                        About.Status = "NotConfirmed";

                        new AdminMain { }.Show();
                        this.Close();
                    }

                }
                else
                {
                    MessageBox.Show("کلمه عبور با تکرار آن همخوانی ندارد");
                }
            }
            catch
            {
                MessageBox.Show("ارتباط با سرور برقرار نیست");
            }
        }
    }
}
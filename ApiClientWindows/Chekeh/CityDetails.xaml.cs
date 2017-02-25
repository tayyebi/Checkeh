using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for CityDetails.xaml
    /// </summary>
    public partial class CityDetails : Window
    {
        public CityDetails()
        {
            InitializeComponent();
        }
        public Guid Id { get; set; }
        public string CityName { get; set; }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            textbox_Name.Text = CityName;
        }

        private void button_Update_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                WebRequest request = WebRequest.Create(About.Server + "Cities/" + Id.ToString());
                request.Method = "PUT";
                string postData = "Name=" + textbox_Name.Text;
                byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = byteArray.Length;
                Stream dataStream = request.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();
                WebResponse response = request.GetResponse();
                // Console.WriteLine(((HttpWebResponse)response).StatusDescription);
                dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();
                // Console.WriteLine(responseFromServer);
                reader.Close();
                dataStream.Close();
                response.Close();
                AdminMain.CityGotFocus = 0;
                MessageBox.Show("به روز رسانی انجام شد");
            }
            catch
            {
                MessageBox.Show("پاسخ مناسب از سرور دریافت نشد");
            }
        }
    }
}

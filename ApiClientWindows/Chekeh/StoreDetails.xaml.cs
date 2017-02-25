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
    /// Interaction logic for StoreDetails.xaml
    /// </summary>
    public partial class StoreDetails : Window
    {
        public StoreDetails()
        {
            InitializeComponent();
        }

        public Guid Id { get; set; }

        private void button_Updte_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                WebRequest request = WebRequest.Create(About.Server + "Stores/" + Id.ToString());
                request.Method = "PUT";
                string postData = "Name=" + textBox_Name.Text + "&Address=" + textBox_Address.Text + "&postalCode=" + textBox_PostalCode.Text + "&CityId=" + ((ComboBoxItem)comboBox.SelectedItem).Tag.ToString() + "&OwnerId=" + About.Identifier;
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
                MessageBox.Show("عملیات با موفقیت انجام شد");

            }
            catch
            {
                MessageBox.Show("پاسخ مناسب از سرور دریافت نشد");
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                using (WebClient client_City = new WebClient())
                {
                    client_City.Encoding = Encoding.UTF8;
                    string data1 = client_City.DownloadString(About.Server + "Cities");
                    data1 = data1.Remove(data1.Length - 2);
                    data1 = data1.Substring(2, data1.Length - 2);

                    comboBox.Items.Clear();

                    foreach (var row in data1.Split(new string[] { "},{" }, StringSplitOptions.None))
                    {
                        ComboBoxItem cityComboItem = new ComboBoxItem();

                        foreach (var column in row.Split(','))
                        {
                            string[] values = column.Split(':');

                            values[0] = values[0].Remove(values[0].Length - 1);
                            values[0] = values[0].Substring(1, values[0].Length - 1);

                            values[1] = values[1].Remove(values[1].Length - 1);
                            values[1] = values[1].Substring(1, values[1].Length - 1);

                            if (values[0] == "Name")
                            {
                                cityComboItem.Content = values[1];
                            }
                            else if (values[0] == "Id")
                            {
                                cityComboItem.Tag = new Guid(values[1]);
                            }

                        }
                        comboBox.Items.Add(cityComboItem);

                    }

                    using (WebClient client = new WebClient())
                    {
                        client.Encoding = Encoding.UTF8;

                        string data2 = client.DownloadString(About.Server + "Store/" + Id.ToString());
                        data2 = data2.Remove(data2.Length - 1);
                        data2 = data2.Substring(1, data2.Length - 1);

                        foreach (string item in data2.Split(new string[] { "," }, StringSplitOptions.None))
                        {
                            string column = item;
                            column = column.Remove(column.Length - 1);
                            column = column.Substring(1, column.Length - 1);

                            string[] field = column.Split(new string[] { "\":\"" }, StringSplitOptions.None);

                            if (field[0] == "StoreName")
                                textBox_Name.Text = field[1];
                            else if (field[0] == "StorePostalCode")
                                textBox_PostalCode.Text = field[1];
                            else if (field[0] == "StoreAddress")
                                textBox_Address.Text = field[1];
                        }

                    }
                }
                Main.StoreGotFocus = 0;
            }
            catch {
                MessageBox.Show("خطا در دریافت اطلاعات از سرور");
                this.Close();
            }

        }
    }
}
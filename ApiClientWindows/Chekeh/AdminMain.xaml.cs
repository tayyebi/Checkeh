using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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
    /// Interaction logic for AdminMain.xaml
    /// </summary>
    public partial class AdminMain : Window
    {
        public AdminMain()
        {
            InitializeComponent();
        }

        static int GroupGotFocus = 0;
        static public int CityGotFocus = 0;
        static int ProductGotFocus = 0;

        private void AdminMainWindow_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void TabItem_Loaded(object sender, RoutedEventArgs e)
        {
            status_notconfirmed_list.Children.Clear();

            try
            {
                using (WebClient client_notconfirmed = new WebClient())
                {
                    client_notconfirmed.Encoding = Encoding.UTF8;

                    string Data_notconfirmed = client_notconfirmed.DownloadString(About.Server + "OwnerStatus");
                    Data_notconfirmed = Data_notconfirmed.Remove(Data_notconfirmed.Length - 2);
                    Data_notconfirmed = Data_notconfirmed.Substring(2, Data_notconfirmed.Length - 2);

                    foreach (var row in Data_notconfirmed.Split(new string[] { "},{" }, StringSplitOptions.None))
                    {

                        string Username = String.Empty;
                        Guid Identifier = new Guid();

                        foreach (var column in row.Split(','))
                        {
                            string[] values = column.Split(':');

                            values[0] = values[0].Remove(values[0].Length - 1);
                            values[0] = values[0].Substring(1, values[0].Length - 1);

                            values[1] = values[1].Remove(values[1].Length - 1);
                            values[1] = values[1].Substring(1, values[1].Length - 1);

                            if (values[0] == "Username")
                                Username = values[1];
                            else if (values[0] == "Id")
                                Identifier = new Guid(values[1]);
                        }
                        status_notconfirmed_list.Children.Add(new Status { Username = Username, OwnerId = Identifier });
                    }

                }
            }
            catch
            {
                MessageBox.Show("خطا در دریافت اطلاعات از سرور");
            }
        }

        private void Status_Confirmed_Loaded(object sender, RoutedEventArgs e)
        {
            status_confirmed_list.Children.Clear();
            try
            {
                using (WebClient client_confirmed = new WebClient())
                {
                    client_confirmed.Encoding = Encoding.UTF8;

                    string Data_confirmed = client_confirmed.DownloadString(About.Server + "OwnerStatus/Confirmed");
                    Data_confirmed = Data_confirmed.Remove(Data_confirmed.Length - 2);
                    Data_confirmed = Data_confirmed.Substring(2, Data_confirmed.Length - 2);

                    foreach (var row in Data_confirmed.Split(new string[] { "},{" }, StringSplitOptions.None))
                    {

                        string Username = String.Empty;
                        Guid Identifier = new Guid();

                        foreach (var column in row.Split(','))
                        {
                            string[] values = column.Split(':');

                            values[0] = values[0].Remove(values[0].Length - 1);
                            values[0] = values[0].Substring(1, values[0].Length - 1);

                            values[1] = values[1].Remove(values[1].Length - 1);
                            values[1] = values[1].Substring(1, values[1].Length - 1);

                            if (values[0] == "Username")
                                Username = values[1];
                            else if (values[0] == "Id")
                                Identifier = new Guid(values[1]);
                        }
                        status_confirmed_list.Children.Add(new Status { Username = Username, OwnerId = Identifier });
                    }
                }
            }
            catch
            {
                MessageBox.Show("خطا در دریافت اطلاعات از سرور");
            }
        }

        private void button_GroupCreate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    client.Encoding = Encoding.UTF8;
                    NameValueCollection nvc = new NameValueCollection();
                    nvc["Name"] = textbox_Group.Text;
                    string response = Encoding.UTF8.GetString(client.UploadValues(About.Server + "Groups", nvc));
                    MessageBox.Show("عملیات با موفقیت انجام شد");
                   textbox_Group.Text = String.Empty;
                    GetGroups();
                }
            }
            catch { }
        }
        public void GetProducts()
        {
            try
            {
                using (WebClient client = new WebClient())
                {

                    client.Encoding = Encoding.UTF8;

                    string data = client.DownloadString(About.Server + "Products");
                    data = data.Remove(data.Length - 2);
                    data = data.Substring(2, data.Length - 2);

                    ProductList.Children.Clear();

                    foreach (var row in data.Split(new string[] { "},{" }, StringSplitOptions.None))
                    {
                        ProductUserControl productUserControl = new ProductUserControl();

                        foreach (var column in row.Split(','))
                        {
                            string[] values = column.Split(':');

                            values[0] = values[0].Remove(values[0].Length - 1);
                            values[0] = values[0].Substring(1, values[0].Length - 1);

                            values[1] = values[1].Remove(values[1].Length - 1);
                            values[1] = values[1].Substring(1, values[1].Length - 1);

                            if (values[0] == "ProductName")
                            {
                                productUserControl.ProductName = values[1];
                            }
                            else if (values[0] == "ProductId")
                            {
                                productUserControl.Id = new Guid(values[1]);
                            }

                        }
                        ProductList.Children.Add(productUserControl);
                    }
                }
            }
            catch
            {
                MessageBox.Show("خطا در دریافت اطلاعات از سرور");

            }
        }
        public void GetGroups()
        {
            try
            {
                using (WebClient client = new WebClient())
                {

                    client.Encoding = Encoding.UTF8;

                    string data = client.DownloadString(About.Server + "Groups");
                    data = data.Remove(data.Length - 2);
                    data = data.Substring(2, data.Length - 2);

                    GroupList.Children.Clear();
                    comboBox_ProductCombo.Items.Clear();

                    foreach (var row in data.Split(new string[] { "},{" }, StringSplitOptions.None))
                    {
                        GroupUserControl groupUserControl = new GroupUserControl();
                        ComboBoxItem comboItem = new ComboBoxItem();

                        foreach (var column in row.Split(','))
                        {
                            string[] values = column.Split(':');

                            values[0] = values[0].Remove(values[0].Length - 1);
                            values[0] = values[0].Substring(1, values[0].Length - 1);

                            values[1] = values[1].Remove(values[1].Length - 1);
                            values[1] = values[1].Substring(1, values[1].Length - 1);

                            if (values[0] == "Name")
                            {
                                groupUserControl.GroupName = values[1];
                                comboItem.Content = values[1];
                            }
                            else if (values[0] == "Id")
                            {
                                groupUserControl.Id = new Guid(values[1]);
                                comboItem.Tag = values[1];
                            }

                        }
                        comboBox_ProductCombo.Items.Add(comboItem);
                        GroupList.Children.Add(groupUserControl);
                    }
                }
            }
            catch
            {
                MessageBox.Show("خطا در دریافت اطلاعات از سرور");

            }
        }

        private void Groups_GotFocus(object sender, RoutedEventArgs e)
        {
            if (GroupGotFocus < 1)
            {
                GetGroups();
                GroupGotFocus++;
            }
        }

        private void button_CreateProduct_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    client.Encoding = Encoding.UTF8;

                    NameValueCollection nvc = new NameValueCollection();
                    nvc["Name"] = textbox_Product.Text;
                    nvc["Description"] = textbox_Description.Text;
                    nvc["GroupId"] = ((ComboBoxItem)comboBox_ProductCombo.SelectedItem).Tag.ToString();
                    client.UploadValues(About.Server + "Products", nvc);
                    MessageBox.Show("عملیات با موفقیت انجام شد");
                    textbox_Product.Text = textbox_Description.Text = String.Empty;
                    GetGroups();
                    GetProducts();
                }
            }
            catch
            {
                MessageBox.Show("ارتباط با سرور برقرار نیست");
            }
        }

        private void Products_GotFocus(object sender, RoutedEventArgs e)
        {
            if (GroupGotFocus < 1)
            {
                GetGroups();
                GroupGotFocus++;
            }
            if (ProductGotFocus < 1)
            {
                GetProducts();
                ProductGotFocus++;
            }
        }

        public void GetCities()
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    client.Encoding = Encoding.UTF8;
                    string data = client.DownloadString(About.Server + "Cities");
                    data = data.Remove(data.Length - 2);
                    data = data.Substring(2, data.Length - 2);

                    CityList.Children.Clear();

                    foreach (var row in data.Split(new string[] { "},{" }, StringSplitOptions.None))
                    {
                        CityUserControl cityUserControl = new CityUserControl();

                        foreach (var column in row.Split(','))
                        {
                            string[] values = column.Split(':');

                            values[0] = values[0].Remove(values[0].Length - 1);
                            values[0] = values[0].Substring(1, values[0].Length - 1);

                            values[1] = values[1].Remove(values[1].Length - 1);
                            values[1] = values[1].Substring(1, values[1].Length - 1);

                            if (values[0] == "Name")
                            {
                                cityUserControl.CityName = values[1];
                            }
                            else if (values[0] == "Id")
                            {
                                cityUserControl.Id = new Guid(values[1]);
                            }

                        }
                        CityList.Children.Add(cityUserControl);
                    }
                }
            }
            catch
            {
                MessageBox.Show("ارتباط با سرور برقرار نیست");
            }
        }

        private void button_CityCreate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                WebRequest request = WebRequest.Create(About.Server + "Cities");
                request.Method = "POST";
                string postData = "Name=" + textbox_City.Text;
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
                textbox_City.Text= String.Empty;
                GetCities();
            }
            catch
            {
                MessageBox.Show("پاسخ مناسب از سرور دریافت نشد");
            }
        }

        private void Cities_GotFocus(object sender, RoutedEventArgs e)
        {
            if (CityGotFocus < 1)
            {
                GetCities();
                CityGotFocus++;
            }
        }
    }
}
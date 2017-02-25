using Microsoft.Win32;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Chekeh
{
    public partial class Main : Window
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                thisChat.SenderId = new Guid(About.Identifier);


                if (About.Status == "NotConfirmed")
                {
                    label_Status.Content = "در انتظار تائید مدیر سیستم";
                }
                else if (About.Status == "Confirmed")
                {
                    Partner.IsEnabled = false;
                    Store.IsEnabled = Product.IsEnabled = true;
                    label_Status.Content = "کاربر توسط هوش انسانی تائید شده است؛ از افتخار همکاری با شما خرسندیم";
                }
            }
            catch
            {
                MessageBox.Show("ارتباط با سرور برقرار نیست");
            }
        }
        private void button_Update_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (textbox_Password.Password == textbox_ConfirmPass.Password)
                {
                    WebRequest request = WebRequest.Create(About.Server + "Owner/" + About.Identifier);
                    request.Method = "PUT";
                    string postData =
                          "Username=" + textbox_Username.Text +
                          "&FirstName=" + textbox_FirstName.Text +
                          "&LastName=" + textbox_LastName.Text +
                          "&NationalCode=" + textbox_NationalCode.Text +
                          "&Address=" + textbox_Address1.Text +
                          "&PostalCode=" + textbox_PostalCode1.Text +
                          "&PhoneNumber=" + textbox_PhoneNumber.Text +
                          "&Password=" + textbox_Password.Password;
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
                    MessageBox.Show("به روز رسانی انجام شد");
                }

                else
                {
                    MessageBox.Show("کلمه عبور با تکرار آن همخوانی ندارد");
                }
            }
            catch (Exception g)
            {
                MessageBox.Show("پاسخ مناسب از سرور دریافت نشد");
            }
        }

        int CountsGotFocused = 0;
        static public string ImagePath = null;

        private void Profile_GotFocus(object sender, RoutedEventArgs e)
        {
            if (CountsGotFocused < 1) // Lazy load on first focus
            {
                try
                {
                    using (WebClient client = new WebClient())
                    {
                        client.Encoding = Encoding.UTF8;

                        string data = client.DownloadString(About.Server + "Owner/" + About.Identifier);
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
                                textbox_Username.Text = item[1];
                            else if (item[0] == "FirstName")
                                textbox_FirstName.Text = item[1];
                            else if (item[0] == "LastName")
                                textbox_LastName.Text = item[1];
                            else if (item[0] == "NationalCode")
                                textbox_NationalCode.Text = item[1];
                            else if (item[0] == "Address")
                                textbox_Address1.Text = item[1];
                            else if (item[0] == "PostalCode")
                                textbox_PostalCode1.Text = item[1];
                            else if (item[0] == "PhoneNumber")
                                textbox_PhoneNumber.Text = item[1];

                            Image_Profile.Source = new BitmapImage(new Uri(About.Server + "Human_Image/" + About.Identifier));
                        }
                    }
                    CountsGotFocused++;
                }
                catch
                {
                    MessageBox.Show("اطلاعات دریافت نشده اند و یا نا معتبر تشخیص داده شده اند");
                }
            }
        }

        private void button_Image_Click(object sender, RoutedEventArgs e)
        {

            Stream checkStream = null;
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Multiselect = false;
            openFileDialog.Filter = "تصاویر|*.bmp;*.jpg;*.png";
            if ((bool)openFileDialog.ShowDialog())
            {
                try
                {
                    if ((checkStream = openFileDialog.OpenFile()) != null)
                    {
                        ImagePath = openFileDialog.FileName;
                        Image_Profile.Source = new BitmapImage(new Uri(openFileDialog.FileName, UriKind.RelativeOrAbsolute));
                    }
                }
                catch
                {
                    MessageBox.Show("خطا: فایل ارسال شده قابل خواندن نیست");
                }
            }
        }

        private void button_Delete_Click(object sender, RoutedEventArgs e)
        {
            ImagePath = null;
            Image_Profile.Source = null;
        }
        public void GetStores()
        {
            try
            {
                using (WebClient client_City = new WebClient())
                {
                    client_City.Encoding = Encoding.UTF8;
                    string data = client_City.DownloadString(About.Server + "Cities");
                    data = data.Remove(data.Length - 2);
                    data = data.Substring(2, data.Length - 2);

                    comboBox_City.Items.Clear();

                    foreach (var row in data.Split(new string[] { "},{" }, StringSplitOptions.None))
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
                        comboBox_City.Items.Add(cityComboItem);

                    }
                }



                using (WebClient client_stores = new WebClient())
                {
                    client_stores.Encoding = Encoding.UTF8;
                    string data = client_stores.DownloadString(About.Server + "Stores/" + About.Identifier);

                    data = data.Remove(data.Length - 2);
                    data = data.Substring(2, data.Length - 2);

                    storesList.Children.Clear();
                    comboBox_Store1.Items.Clear();
                    comboBox_Store2.Items.Clear();




                    foreach (var row in data.Split(new string[] { "},{" }, StringSplitOptions.None))
                    {

                        StoreUserControl storeUserControl = new StoreUserControl();
                        ComboBoxItem storeComboItem1 = new ComboBoxItem();


                        foreach (var column in row.Split(','))
                        {
                            string[] values = column.Split(':');

                            values[0] = values[0].Remove(values[0].Length - 1);
                            values[0] = values[0].Substring(1, values[0].Length - 1);

                            values[1] = values[1].Remove(values[1].Length - 1);
                            values[1] = values[1].Substring(1, values[1].Length - 1);

                            if (values[0] == "StoreName")
                            {
                                storeComboItem1.Content = values[1];
                                storeUserControl.StoreName = values[1];
                            }
                            else if (values[0] == "StoreId")
                            {
                                storeUserControl.StoreId = new Guid(values[1]);
                                storeComboItem1.Tag = values[1];
                            }

                        }
                        ComboBoxItem storeComboItem2 = new ComboBoxItem { Tag = storeComboItem1.Tag, Content = storeComboItem1.Content };

                        comboBox_Store1.Items.Add(storeComboItem1);
                        comboBox_Store2.Items.Add(storeComboItem2);
                        storesList.Children.Add(storeUserControl);

                    }

                }

            }
            catch
            {
                MessageBox.Show("خطا در دریافت اطلاعات");
            }
        }
        public static int StoreGotFocus = 0;
        private void Store_GotFocus(object sender, RoutedEventArgs e)
        {
            if (StoreGotFocus < 1)
            {
                GetStores();
                StoreGotFocus++;
            }
        }

        int ProductsGotFocus = 0;
        private void Product_GotFocus(object sender, RoutedEventArgs e)
        {
            if (StoreGotFocus < 1)
            {
                GetStores();
                StoreGotFocus++;
            }
            if (ProductsGotFocus < 1)
            {

                ProductsGotFocus++;
            }
        }

        private void button_Store_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                WebRequest request = WebRequest.Create(About.Server + "Stores");
                request.Method = "POST";
                string postData = "Name=" + textbox_Store.Text + "&Address=" + textbox_Address2.Text + "&postalCode=" + textBox_PostalCode2.Text + "&CityId=" + ((ComboBoxItem)comboBox_City.SelectedItem).Tag.ToString() + "&OwnerId=" + About.Identifier;
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
                textbox_Address2.Text = textbox_Store.Text = String.Empty;
                GetStores();
            }
            catch
            {
                MessageBox.Show("پاسخ مناسب از سرور دریافت نشد");
            }

        }

        private void Partner_GotFocus(object sender, RoutedEventArgs e)
        {
            if (StoreGotFocus < 1)
            {
                GetStores();
                StoreGotFocus++;
            }
        }

        private void comboBox_Store1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    client.Encoding = Encoding.UTF8;

                    string data = client.DownloadString(About.Server + "StoreProduct/" + ((ComboBoxItem)comboBox_Store1.SelectedItem).Tag.ToString());
                    data = data.Remove(data.Length - 2);
                    data = data.Substring(2, data.Length - 2);

                    ProductsList.Children.Clear();



                    foreach (var row in data.Split(new string[] { "},{" }, StringSplitOptions.None))
                    {

                        PossessingUserControl possessingUserControl = new PossessingUserControl();
                        possessingUserControl.StoreId = new Guid(((ComboBoxItem)comboBox_Store1.SelectedItem).Tag.ToString());


                        foreach (var column in row.Split(','))
                        {
                            string[] values = column.Split(':');

                            values[0] = values[0].Remove(values[0].Length - 1);
                            values[0] = values[0].Substring(1, values[0].Length - 1);

                            values[1] = values[1].Remove(values[1].Length - 1);
                            values[1] = values[1].Substring(1, values[1].Length - 1);

                            if (values[0] == "ProductId")
                            {
                                possessingUserControl.ProductId = new Guid(values[1]);
                            }
                            else if (values[0] == "ProductName")
                            {
                                possessingUserControl.ProductName = values[1];
                            }
                            else if (values[0] == "Available")
                            {
                                possessingUserControl.Possess = Convert.ToBoolean(values[1]);
                            }

                        }
                        ProductsList.Children.Add(possessingUserControl);
                    }
                }
            }
            catch
            {
                MessageBox.Show("خطا در برقراری ارتباط یا سرور");
            }
        }
    }
}
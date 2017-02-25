using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Chekeh
{
    /// <summary>
    /// Interaction logic for ProductDetails.xaml
    /// </summary>
    public partial class ProductDetails : Window
    {
        public Guid ProductId { get; set; }

        public ProductDetails()
        {
            InitializeComponent();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                using (WebClient client = new WebClient())
                {

                    client.Encoding = Encoding.UTF8;

                    string data = client.DownloadString(About.Server + "Groups");
                    data = data.Remove(data.Length - 2);
                    data = data.Substring(2, data.Length - 2);


                    comboBox_Group.Items.Clear();

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
                        comboBox_Group.Items.Add(comboItem);

                        data = client.DownloadString(About.Server + "Products/" + ProductId);
                        data = data.Remove(data.Length - 1);
                        data = data.Substring(1, data.Length - 1);

                        foreach (string column in data.Split(new string[] { "," }, StringSplitOptions.None))
                        {
                            string[] item = column.Split(':');

                            item[0] = item[0].Remove(item[0].Length - 1);
                            item[0] = item[0].Substring(1, item[0].Length - 1);

                            item[1] = item[1].Remove(item[1].Length - 1);
                            item[1] = item[1].Substring(1, item[1].Length - 1);

                            if (item[0] == "ProductName")
                                textbox_Name.Text = item[1];
                            else if (item[0] == "ProductDescription")
                                textbox_Description.Text = item[1];
                        }
                    }
                }
            }
            catch
            {
                System.Windows.MessageBox.Show("خطا در دریافت اطلاعات از سرور");
                Close();
            }
        }


        private string path;

        private void button_Choose_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".png";
            dlg.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                path = dlg.FileName;
                button_Choose.Content = "تصویر انتخاب شد";
            }
        }

        private async void button_Submit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                byte[] data = File.ReadAllBytes(path);

                HttpClient httpClient = new HttpClient();
                MultipartFormDataContent form = new MultipartFormDataContent();

                form.Add(new StringContent(textbox_Name.Text), "Name");
                form.Add(new StringContent(((ComboBoxItem)comboBox_Group.SelectedItem).Tag.ToString()), "GroupId");
                form.Add(new StringContent(textbox_Description.Text), "Description");
                form.Add(new ByteArrayContent(data, 0, data.Count()), "Image", "PostedImageFile");
                HttpResponseMessage response = await httpClient.PutAsync(About.Server + "Products/" + ProductId, form);

                System.Windows.MessageBox.Show("عملیات با موفقیت انجام شد");
                Close();
            }
            catch {
                System.Windows.MessageBox.Show("خطا در برقراری ارتباط با سرور");
            }
        }

    }
}
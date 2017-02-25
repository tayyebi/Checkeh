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
    /// Interaction logic for Chat.xaml
    /// </summary>
    public partial class ChatUserControl : UserControl
    {
        public ChatUserControl()
        {
            InitializeComponent();
        }

        public Guid ReciverId { get; set; }
        public Guid SenderId { get; set; }

        public void refresh()
        {
            stackpanel_Main.Children.Clear();
            using (WebClient client = new WebClient())
            {
                client.Encoding = Encoding.UTF8;

                try
                {
                    string Content = String.Empty;

                        Content = client.DownloadString(About.Server + "FeedBack/" + SenderId);

                    Content = Content.Remove(Content.Length - 2);
                    Content = Content.Substring(2, Content.Length - 2);

                    foreach (var row in Content.Split(new string[] { "},{" }, StringSplitOptions.None))
                    {
                        string text = String.Empty;
                        bool IsSender = false;
                        foreach (var column in row.Split(','))
                        {

                            string[] values = column.Split(':');

                            values[0] = values[0].Remove(values[0].Length - 1);
                            values[0] = values[0].Substring(1, values[0].Length - 1);

                            try
                            {
                                Convert.ToInt32(values[1]);
                            }
                            catch
                            {
                                values[1] = values[1].Remove(values[1].Length - 1);
                                values[1] = values[1].Substring(1, values[1].Length - 1);
                            }
                            if (values[0] == "SenderId")
                            {
                                if (values[1] == SenderId.ToString())
                                {
                                    IsSender = true;
                                }
                            }
                            else if (values[0] == "Value")
                            {
                                text += values[1];
                            }
                        }
                        stackpanel_Main.Children.Add(new Dialogue { Content = text, IsSender = IsSender });
                    }
                }
                catch
                {
                    stackpanel_Main.Children.Add(new Label { Content = "هیچ پیامی دریافت نشد" });
                }
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            refresh();
        }

        private void button_Send_Click(object sender, RoutedEventArgs e)
        {
            using (WebClient client = new WebClient())
            {
                client.Encoding = Encoding.UTF8;

                try
                {
                    NameValueCollection nvc = new NameValueCollection();
                    nvc["Value"] = textbox_Value.Text;

                        nvc["ReciverId"] = ReciverId.ToString();
            
                    string response = Encoding.UTF8.GetString(client.UploadValues(About.Server + "FeedBack/" + SenderId.ToString(), nvc));
                    refresh();
                    textbox_Value.Text = String.Empty;
                }
                catch {
                    MessageBox.Show("ارتباط با سرور برقرار نیست.");
                }
            }
        }
    }
}
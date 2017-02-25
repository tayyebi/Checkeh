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
    /// Interaction logic for PossessingUserControl.xaml
    /// </summary>
    public partial class PossessingUserControl : UserControl
    {
        public Guid ProductId { get; set; }
        public Guid StoreId { get; set; }
        public string ProductName { get; set; }
        public bool Possess { get; set; }


        public PossessingUserControl()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (Possess)
            {
                button_Possess.Content = "موجود است";
                button_Possess.ToolTip = "برای اعلام موجود نبود کالا کلیک کنید";
            }
            else if (!Possess)
            {
                button_Possess.Content = "موجود نیست";
                button_Possess.ToolTip = "برای اعلام موجود بودن کالا کلیک کنید";
            }
            label_Title.Content = ProductName;
        }

        private void button_Possess_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    NameValueCollection nvc = new NameValueCollection();
                    nvc["ProductId"] = ProductId.ToString();
                    nvc["StoreId"] = StoreId.ToString();

                    if (Possess)
                    {
                        nvc["Possess"] = "False";
                        client.UploadValues(About.Server + "StoreProduct", nvc);

                        button_Possess.Content = "موجود نیست";
                        button_Possess.ToolTip = "برای اعلام موجود نبود کالا کلیک کنید";
                        Possess = false;
                    }
                    else if (!Possess)
                    { 
                        nvc["Possess"] = "True";
                        client.UploadValues(About.Server + "StoreProduct", nvc);

                        button_Possess.Content = "موجود است";
                        button_Possess.ToolTip = "برای اعلام موجود بودن کالا کلیک کنید";
                        Possess = true;
                    }
                }
            }
            catch
            {
                MessageBox.Show("خطا در برقراری ارتباط با سرور");
            }
        }
    }
}
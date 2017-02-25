using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaction logic for Dialogue.xaml
    /// </summary>
    public partial class Dialogue : UserControl
    {
        public Dialogue()
        {
            InitializeComponent();
        }
        public bool IsSender { get; set; }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (!IsSender)
                this.Content = "پاسخ: " + this.Content;
            else
                this.Content = "شما: " + this.Content;
            label_Text.Content = this.Content;
        }
    }
}

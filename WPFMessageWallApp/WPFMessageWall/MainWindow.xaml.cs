using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace WPFMessageWall
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
      string message = "";   
        public MainWindow()
        {
            InitializeComponent();

            messageText.Tag = message;
        }

        private void addMessage_Click(object sender, RoutedEventArgs e)
        {
            message = $"Hi {firtName} {lastName}";
            
        }
    }
}

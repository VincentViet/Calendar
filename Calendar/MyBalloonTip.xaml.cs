using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calendar
{
    /// <summary>
    /// Interaction logic for MyBalloonTip.xaml
    /// </summary>
    public partial class MyBalloonTip : UserControl
    {
        private string _content;
        private MainWindow _ownerWindow;


        public MyBalloonTip()
        {
            InitializeComponent();
        }

        public string Content
        {
            get => _content;
            set
            {
                _content = value;
                NotifyContent.Text = _content;
            }
        }

        public MainWindow OwnerWindow { get => _ownerWindow; set => _ownerWindow = value; }

        private void UserControl_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            OwnerWindow.Show();
        }
    }
}

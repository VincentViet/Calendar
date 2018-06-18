using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;


namespace Calendar
{
    /// <summary>
    /// Interaction logic for Event.xaml
    /// </summary>
    public partial class Event : UserControl
    {
        private MainWindow _owner;
        private SolidColorBrush _myGreyBrush = Application.Current.FindResource("MyGrey") as SolidColorBrush;
        

        public event EventHandler DoubleClick;
        public MainWindow Owner
        {
            get => _owner;
            set => _owner = value;
        }

        public Event()
        {
            InitializeComponent();
        }

        private void EditButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (_owner != null)
            {
                _owner.EditCommand_Executed(this);
            }

        }

        private void DeleteButton_OnClick(object sender, RoutedEventArgs e)
        {

            if (_owner != null)
            {
                _owner.DeleteCommand_Executed(this);
            }
        }

        private void Title_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DoubleClick?.Invoke(this, e);
        }

        private void Event_OnMouseEnter(object sender, MouseEventArgs e)
        {
            Background = _myGreyBrush;
            TitleLabel.Foreground = Brushes.White;
        }

        private void Event_OnMouseLeave(object sender, MouseEventArgs e)
        {

            Background = Brushes.White;
            TitleLabel.Foreground = _myGreyBrush;
        }
    }
}

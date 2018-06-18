using System.Windows;
using System.Windows.Controls;



namespace Calendar
{
    /// <summary>
    /// Interaction logic for SetReminder.xaml
    /// </summary>
    public partial class SetReminder : Window
    {
        public SetReminder()
        {
            InitializeComponent();

            Slider.Value = Properties.Settings.Default.TimeReminder;
            TextBoxSlider.Text = ((int) Slider.Value).ToString();
            Slider.ToolTip = ((int)Slider.Value).ToString();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            if (Owner != null)
            {
                Owner.Opacity = 1;
                Hide();
            }
        }

        private void Slider_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (TextBoxSlider != null)
            {
                Slider.ToolTip = ((int)Slider.Value).ToString();
                TextBoxSlider.Text = ((int)Slider.Value).ToString("");
            }
        }

        private void TextBoxSlider_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            int value;
            if (int.TryParse(TextBoxSlider.Text, out value))
            {
                if (Slider != null)
                {
                    Slider.Value = value;
                }
            }
        }
    }
}

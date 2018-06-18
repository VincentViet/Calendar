using System.Windows.Input;

namespace Calendar
{
    public class CustomCommand
    {
        public static readonly RoutedUICommand QuitCommand = new RoutedUICommand("Quit", "Quit", typeof(CustomCommand));
        public static readonly RoutedUICommand EditCommand = new RoutedUICommand("Edit", "Edit", typeof(CustomCommand));
        public static readonly RoutedUICommand DeleteCommand = new RoutedUICommand("Delete", "Delete", typeof(CustomCommand));
        public static readonly RoutedUICommand ShowCommand = new RoutedUICommand("Show", "Show", typeof(CustomCommand));
    }
}

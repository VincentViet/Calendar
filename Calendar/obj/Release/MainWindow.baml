   M S B A M L   `   `   `  ���� C  ?Calendar, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:CalendarCalendar      Calendar.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     (localclr-namespace:Calendar     V RMaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  -     � Title$  Calendar��$
��1280��$	��800�� � WindowStartupLocation$ CenterScreen=� � WindowStyle$
 None=� � 
ResizeMode$ NoResize=�   MaterialDesignBody#���   $��Regular"�$��13(�&   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�   TextRenderingMode$
 Auto=�  MaterialDesignPaper#���    MaterialDesignFont#���  .���  � RowDefinitions �� $��0.08* ��� $��0.92* �.+�� $��0��.+�(  "MaterialDesignThemes.Wpf.ColorZone  -   $��
ControlBar��   Mode$ Light=�$��16q�.��]� .+��� $��Right=� �� Orientation$ 
Horizontal=�.+��� -   $��MinimizeButton��$��0,0,10,0q�.��'  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=null]]	   Kind$	 WindowMinimize=��� -   $��CloseWindowButton��.��  $	 WindowClose=��� $
��Left=�$ 
Horizontal=�.+��� -   $��
HomeButton��$��30��$��30�� * &MaterialDesignFloatingActionDarkButton#��[ 
 � ToolTip$
 Return Today��.��  $	 HomeOutline=�$��24��$��24���� $��Center=�$��16 0 0 0q�$��Azhor Calendar��$
��Bold"�� $��1��
������� � ColumnDefinitions �� $
��0.7* ��� $
��0.3* �.+�� $��0��  MyWhite#��[ .+��  �� $��0.15* ��� $
��0.2* ��� $
��0.5* ��� $��0.15* �.+��� -    ��Name$ Clock��  NavigateButton#��[ $��0��#��[  
 MyGrey#��[ $��50(�$A
 ;Click here to reset clock after you change you system clock���� -   $ CurrYearButton��$��1��$�� ��#��[ $��40(�#��[ #��[ � $��2�� �� $
��0.1* ��� $
��0.8* ��� $
��0.1* �.+�� $��0��.+��� -   $ 
PrevButton��$
��auto��$
 
Prev-month��.��  $��50��$��50��$	 ArrowLeftBoldCircle=�   Calendar.CalendarTable  -	     Name$ CalendarTable��   Calendar.CalendarTable   SelectedDateChange$( "CalendarTable_OnSelectedDateChange��$��1��� $��2��.+��� -
   $ 
NextButton��$
��auto��$
 
Next Month��.��  $��50��$��50��$	 ArrowRightBoldCircle=�� $��3��.+��� -    , (MaterialDesignFloatingActionAccentButton#��[ $
 Set Reminder��.��  $	 Alarm=�$��24��$��24��� $��1��  MyBlack#��[  �� $��0.15* ��� $��0.75* ��� $
��0.1* �.+�� $��0�� �� $
��0.8* ��� $
��0.2* �.+���  	 MyLabelStyle#��[	 #��[ $��Events�� 
 MyOrange#��[
 $��70(�d� -   $��NotifyToggleButton��$��1�� * &MaterialDesignSwitchAccentToggleButton#��[ $&
  Turn on/off notify functionality���� -    ��Name$ 	EventGrid��$ Vertical=�$��1���� -   $��2��#��[ $
 	Add Event��.��  $
	 Plus=�$��24��$��24��
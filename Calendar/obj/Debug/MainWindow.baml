   M S B A M L   `   `   `  ����C  ?Calendar, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:CalendarCalendar  5   	       Calendar.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:Calendar     5   	   V RMaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5          � Title$  Calendar��5   	   $
��1280��6   $	��800��6'    � WindowStartupLocation$ CenterScreen=�5	   	    � WindowStyle$
 None=�5
   	    � 
ResizeMode$ NoResize=�5   	      MaterialDesignBody#���   5   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	   .��5      �  � RowDefinitions 5   
   �� 5      $��0.08* �6   6-   �� 5      $��0.92* �6   6-   .+�5    
   � $��0��6   .+�5"      (  "MaterialDesignThemes.Wpf.ColorZone  -   5        $��
ControlBar��5#         Mode$ Light=�5%      $��16q�5&      .��5'      ]� .+�5(      �� $��Right=�5)       �� Orientation$ 
Horizontal=�5*      .+�5+      �� -   5        $��MinimizeButton��5-      $��0,0,10,0q�5,      .��5/      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=null]]	   Kind$	 WindowMinimize=�66   50      �� 52      -   5        $��CloseWindowButton��53      .��55        $	 WindowClose=�66   56      57      �� 59      $
��Left=�5:      $ 
Horizontal=�5;      .+�5<      �� -   5        $��
HomeButton��5>      $��30��5?      $��30��5@       * &MaterialDesignFloatingActionDarkButton#��[ 5A      
 � ToolTip$
 Return Today��5B      .��5C        $	 HomeOutline=�5D   !   $��24��5E   !   $��24��5F   !   5G      �� 5I      $��Center=�5J      $��16 0 0 0q�5K      $��Azhor Calendar��6/   $
��Bold"�5L      5M      5N      5O      5Q      � 5S   
   $��1��6   
������� � ColumnDefinitions 5U      �� 5V      $
��0.7* �6#   �� 5W      $
��0.3* �6#   .+�5[      � $��0��6     MyWhite#��[ 5\      .+�5]      �  5^      �� 5_      $��0.15* �6(   �� 5`      $
��0.2* �6(   �� 5a      $
��0.5* �6(   �� 5b      $��0.15* �6(   .+�5f      �� -   5         ��Name$ Clock��5f        NavigateButton#��[ 5g   !   $��0��5h   !   #��[ 5i   !    
 MyGrey#��[ 5j   !   $��50(�5k   !   $A
 ;Click here to reset clock after you change you system clock��5l      5m      �� 5o      -   5        $ CurrYearButton��5o      $��1��5p   !   $�� ��5q   $   #��[ 5r   $   $��40(�5s   $   #��[ 5t   $   #��[ 5v   !   5w       � 5z      $��2��6    5{      �� 5|      $
��0.1* �6/   �� 5}      $
��0.8* �6/   �� 5~      $
��0.1* �6/   .+�5�      � $��0��6   .+�5�      �� -   5        $ 
PrevButton��5�   !   $
��auto��5�   !   $
 
Prev-month��5�   !   .��5�   "     $��50��5�   %   $��50��5�   %   $	 ArrowLeftBoldCircle=�5�   %   5�      5�         Calendar.CalendarTable  5�      -	   5          Name$ CalendarTable��5�   .      Calendar.CalendarTable   SelectedDateChange$( "CalendarTable_OnSelectedDateChange��5�   *   $��1��5�   *   5�   *   � 5�      $��2��6   .+�5�      �� -
   5        $ 
NextButton��5�   !   $
��auto��5�   !   $
 
Next Month��5�   !   .��5�   "     $��50��5�   %   $��50��5�   %   $	 ArrowRightBoldCircle=�5�   %   5�      5�      5�      � 5�      $��3��6   .+�5�      �� -   5         , (MaterialDesignFloatingActionAccentButton#��[ 5�      $
 Set Reminder��5�      .��5�        $	 Alarm=�5�   !   $��24��5�   !   $��24��5�   !   5�      5�      5�      5�      � 5�      $��1��6     MyBlack#��[ 5�       5�      �� 5�      $��0.15* �6$   �� 5�      $��0.75* �6$   �� 5�      $
��0.1* �6$   .+�5�      � $��0��6    5�      �� 5�      $
��0.8* �6+   �� 5�      $
��0.2* �6+   .+�5�      ��  	 MyLabelStyle#��[	 6   #��[ 5�      $��Events��5�       
 MyOrange#��[
 5�      $��70(�5�      6,   d� 5�      -   5        $��NotifyToggleButton��5�      $��1��5�       * &MaterialDesignSwitchAccentToggleButton#��[ 5�      $&
  Turn on/off notify functionality��5�      5�      �� 5�      -   5         ��Name$ 	EventGrid��5�      $ Vertical=�5�      $��1��5�      5�      �� 5�      -   5        $��2��5�      #��[ 5�      $
 	Add Event��5�      .��5�        $
	 Plus=�5�      $��24��5�      $��24��5�      5�      5�      5      5     5     
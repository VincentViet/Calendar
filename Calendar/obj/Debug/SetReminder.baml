   M S B A M L   `   `   `  ����  Calendar    Calendar.SetReminder   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   V RMaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$   ��5   	   $	��200��6   $	��600��6    � WindowStartupLocation$ CenterOwner=�5   	    � WindowStyle$
 None=�5	   	    � 
ResizeMode$ NoResize=�5
   	    � ShowInTaskbar .     MaterialDesignBody#���   5   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	   .��5      �  � RowDefinitions 5   
   �� 5      $
��0.2* �6   �� 5      $
��0.8* �6   .+�5   
   �� $
��Bold"�6   $��Remider��5      $��30(�5      $
��Left=�5      �� 5!   
   -   5         ��Name$ Slider��5!      $��1��6!   $��20��5"      	 � Maximum$	 60Q�5#      
 �� TickFrequency$
 5Q�5%       � Minimum$ 1Q�5&      $	��280��5'       � ToolTip$" MaterialDesignDiscreteSlider��5(      �� 5+   
   -   5         ��Name$ TextBoxSlider��5+      $��1��5,      $��40��5-      $��40��5.      $��251,90,309,30q�5/      $��Center=�50      $��Center=�51      $��20(�52      $��Ubuntu)�53      $�� ��54      55      �� 57   
   $��1��6   $��40��58      $��310,90,186,30q�59      $��	Minute(s)��5:      $��20(�5;      $��Ubuntu)�5<      $��Center=�5=      $��Center=�5>      �� 5@   
   -   5        $��0��5@      $��OK��5A      $��
514,0,10,0q�6   5B      5C      5D      
   M S B A M L   `   `   `  ����  Calendar    Calendar.ChangeTimeWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   V RMaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � WindowStyle$
  None=�5   	    � 
ResizeMode$ NoResize=�5   	   $��464.545��5	   	   $	��240��5
   	    � WindowStartupLocation$ CenterOwner=�5   	    � ShowInTaskbar .     MaterialDesignBody#���   5   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	   .��5      �  � RowDefinitions 5   
   �� 5      $
��0.2* �6   �� 5      $
��0.6* �6   �� 5      $
��0.2* �6   .+�5   
   �� $��0��6   $
��Left=�5        MyLabelStyle#��[ 5       $��25(�5!      $
��Goto��5"      �� 5'   
   -   5         ��Name$ MonthSelection��5'      $��1��5(      $��40��5)      $	��200��5*      $��Center=�5+      $��Center=�5,      $��Ubuntu)�5-      $��20(�5.      $��10,50,255,54q�6!   .@�5/      �� $��January��6   6/   �� 50      $��February��6   60   �� 51      $��March��6   6-   �� 52      $��April��6   6-   �� 53      $	��May��6   6+   �� 54      $
��June��6   6,   �� 55      $
��July��6   6,   �� 56      $��August��6   6.   �� 57      $��	September��6   61   �� 58      $��October��6   6/   �� 59      $��November��6   60   �� 5:      $��December��6   60   5;      �� 5=   
   -   5        $ YearSelection��5=      $��1��5>      $��40��5?      $	��200��5@      $��Center=�5A      $��Center=�5B      $��Ubuntu)�5C      $��20(�5D      $��255,50,10,54q�6!   �� 5H   
   -   5         ��Name$ OkButton��5H      $��OK��5I      $��Arial)�5J      $��2��5K      $��0,10,0,0q�5L   *   $
��Auto��6<   5N      5O      
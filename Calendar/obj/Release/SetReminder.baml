   M S B A M L   `   `   `  ����   Calendar    Calendar.SetReminder   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     V RMaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes    � Title$   ��$	��200��$	��600�� � WindowStartupLocation$ CenterOwner=� � WindowStyle$
 None=� � 
ResizeMode$ NoResize=� � ShowInTaskbar .     MaterialDesignBody#���   $��Regular"�$��13(�&   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�   TextRenderingMode$
 Auto=�  MaterialDesignPaper#���    MaterialDesignFont#���  .���  � RowDefinitions �� $
��0.2* ��� $
��0.8* �.+��� $
��Bold"�$��Remider��$��30(�$
��Left=��� -    ��Name$ Slider��$��1��$��20��	 � Maximum$	 60Q�
 �� TickFrequency$
 5Q� � Minimum$ 1Q�$	��280�� � ToolTip$" MaterialDesignDiscreteSlider���� -    ��Name$ TextBoxSlider��$��1��$��40��$��40��$��251,90,309,30q�$��Center=�$��Center=�$��20(�$��Ubuntu)�$�� ���� $��1��$��40��$��310,90,186,30q�$��	Minute(s)��$��20(�$��Ubuntu)�$��Center=�$��Center=��� -   $��0��$��OK��$��
514,0,10,0q�
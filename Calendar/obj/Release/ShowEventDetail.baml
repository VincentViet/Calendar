   M S B A M L   `   `   `  ����   Calendar    Calendar.ShowEventDetail   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006       � Title$  ShowEventDetail��$	��450��$	��800�� � WindowStartupLocation$ CenterOwner=� � WindowStyle$
 None=� � 
ResizeMode$ NoResize=� � ShowInTaskbar .  .���  � RowDefinitions �� $
��0.2* ��� $
��0.8* �.+��� -    ��Name$ Title��   MyLabelStyle#��[  $�� ��$��50(�$
��Left=�$��0���� -   $ 	StartTime��#��[  $�� ��$��30(�$
��Left=�$��1��$��60��$��
0,10,0,290q�
��������� -   $ EndTime��#��[  $�� ��$��30(�$
��Left=�$��1��$��60��$��
0,70,0,230q�
��������� #��[  $��Detail: ��$��30(�$
��Left=�$��1��$��60��
�������$��0,130,0,170q��� -    ��Name$ Detail��$
��Wrap=� �� TextAlignment$
 Left=�$��1��$��	0,195,0,0q�$�� ��$��20(�$��Ubuntu)�	 �� Padding$	 10q��� -   
 ��Name$
 CloseButton��$��0��$��Close��$��30(�$��677,10,10,10q�$
��Auto��
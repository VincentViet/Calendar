   M S B A M L   `   `   `  ����  Calendar    Calendar.ShowEventDetail   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     � Title$  ShowEventDetail��5   	   $	��450��5   	   $	��800��5	   	    � WindowStartupLocation$ CenterOwner=�5
   	    � WindowStyle$
 None=�5   	    � 
ResizeMode$ NoResize=�5   	    � ShowInTaskbar .  .��5      �  � RowDefinitions 5   
   �� 5      $
��0.2* �6   �� 5      $
��0.8* �6   .+�5   
   �� -   5         ��Name$ Title��5         MyLabelStyle#��[  5      $�� ��5      $��50(�5      $
��Left=�5      $��0��5      �� 5   
   -   5        $ 	StartTime��5      #��[  5      $�� ��5      $��30(�5      $
��Left=�5      $��1��5      $��60��5       $��
0,10,0,290q�6   
�������5!      �� 5#   
   -   5        $ EndTime��5#      #��[  5$      $�� ��5%      $��30(�5&      $
��Left=�5'      $��1��5(      $��60��5)      $��
0,70,0,230q�6   
�������5*      �� 5,   
   #��[  6   $��Detail: ��5-      $��30(�5.      $
��Left=�5/      $��1��50      $��60��51      
�������$��0,130,0,170q�52   #   �� 54   
   -   5         ��Name$ Detail��54      $
��Wrap=�6$    �� TextAlignment$
 Left=�55      $��1��56      $��	0,195,0,0q�57      $�� ��58      $��20(�59      $��Ubuntu)�5:      	 �� Padding$	 10q�5;      �� 5=   
   -   5        
 ��Name$
 CloseButton��5=      $��0��5>      $��Close��5?      $��30(�5@      $��677,10,10,10q�6   $
��Auto��5A   -   5B      5C      
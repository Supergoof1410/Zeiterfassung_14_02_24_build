   M S B A M L   `   `   `  ����L  HZeiterfassung_WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Zeiterfassung_WPFZeiterfassung_WPF  5   	   (    "Zeiterfassung_WPF.Monatsuebersicht   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:Zeiterfassung_WPF     5   	   -   5          �Name$  monthSummary��5   	    � Title$ Monatsübersicht��5	   	   $
��Auto��5
   	   $
��Auto��5   	    � WindowStartupLocation$ CenterScreen=�5   	    � WindowState$ Normal=�5   	    � Icon$ /icons8-schedule-100.png��5   	    � 
ResizeMode$ 	CanResize=�5   	    � 	Resources 5       �� Source�� 5   
   $% Resources/calendarResource.xaml?�6   %    .��5      ]� .+�5   
   �� $��Bottom=�6   $
��Left=�5      $��Center=�5      $
��Auto��5      $
��Auto��5      .@�5      �� -   5         ��Name$ status��5      $��Status: ��5      5      � 5   
   $	��Top=�6   	 � RowDefinitions	 5      �� 5      $��* �6    .+�5       � 
 � ShowGridLines$

 True��6   $��0��5!      $
��Auto��5"      $
��Auto��5#       � ColumnDefinitions 5$      �� 5%      $	��200 �6'   �� 5&      $��* �6'   .+�5(      � $��0��6   
���/���$��Center=�5*      $	��Top=�5+      $
 False��5,      	 5-      �� 5.      $
��Auto �6(   �� 5/      $
��Auto �6(   �� 50      $
��Auto �6(   .+�52      �� -   5        $ actualMonth��52      $��Center=�53      $��Center=�54      $��1��55      $��0��56      $
��Auto��57      $��22(�59      ��58      �� *	MonthName+59      �� 5:      -   5        $ summary��5:      $��Center=�5;      $��Center=�5<      $��1��5=      $��1��5>      $
��Auto��5?      
�������$��Gesamt (Monat)��5A      $��22(�5B      �� 5C      -   5        $ SummaryHourMonth��5C      $��Center=�5D      $��Center=�5E      $��1��5F      $��2��5G      $
��Auto��5H      $��22(�5J      ��5I      �� *SummaryMonth+5J      5K      � 5L      $��1��6   $
��Left=�5M      $	��Top=�5N      .+�5O      �� $
��Auto=�6#   $
��Auto=�5P   #   $
��True��5Q   #   $��1��5R   #   .��5T      � -   5         �Name$ calendar��5T      $
 False��5U      .+�5V      �� -   5        $��
icCalendar��5V   +   ��5W   "   �� 5X   &   .R�5Y   *   A�  A�Name$ CalendarGrid��66    A� Columns$ 7��5Z   6    A� FirstColumn 5[   6   ��  �� Path$ 	ColumnCal�5\   '   ��5^   "   �� 5_   &   .R�5`   *   �� 
���   �$��0q�5a   1   ._�5b   .   � $
 days��63   $
 False��5c   3    5d   2   �� 5e   6   $	��150 �6G   	 5g   2   �� 5h   6   $��30 �6D   �� 5i   6   $��30 �6D   �� 5j   6   $��30 �6D   .+�5l   2   ��  ��Name$	 Day��6<   $��0��5m   <    �� TextAlignment$ Center=�5n   <   $
��Wrap=�5o   <   
���   ��� 5q   6   $��16(�5r   <   $��Center=�5s   <   $��Center=�5t   <   ��5q   <   �� *	DayName+��5u   <   �� *
Background+6b   � 5v   2   $��1��67    5w   6   �� 5x   :   $��75 �6K   �� 5y   :   $��75 �6K   .+�5{   6   �� $ Coming��6@   $��0��5|   @   $ Center=�5}   @   $
��Wrap=�5~   @   ��5   @   �� *
Background+�� 5�   ;   $��16(�5�   A   $��Center=�5�   A   $��Center=�5�   A   
���   ���5�   A   �� *
TextComing+5�   A   6X   �� 5�   6   $ Going��6@   $��1��5�   @   $ Center=�5�   @   $
��Wrap=�5�   @   ��5�   @   �� *
Background+�� 5�   6   $��16(�5�   <   $��Center=�5�   <   $��Center=�5�   <   
���   ���5�   <   �� *	TextGoing+5�   <   6S   5�   3   �� 5�   2   $ DiffTime��6<   $��3��5�   <   $ Center=�5�   <   $
��Wrap=�5�   <   ��5�   <   �� *
Background+�� 5�   6   $��16(�5�   <   $��Center=�5�   <   $��Center=�5�   <   
���   ���5�   <   �� *TextSummary+5�   <   6S   5�   /   5�   +   5�   '   5�      5�      5�      5�      5�      5�      5�      5�      
   M S B A M L   `   `   `  ����U  QZeiterfassung_Anleiter_WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:Zeiterfassung_Anleiter_WPF.Person!Zeiterfassung_Anleiter_WPF.Person  5   	   0    *Zeiterfassung_Anleiter_WPF.TimeManagerMain   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Bperson/clr-namespace:Zeiterfassung_Anleiter_WPF.Person     5   	     � Title$  Zeiterfassung Anleiter��5   	    � WindowStartupLocation$ CenterScreen=�5	   	    � WindowState$ 	Maximized=�5
   	   $	��682��5   	   $	��636��5   	    � 	Resources 5       �� Source�� 5   
   $- 'pack://application:,,,/ComingGoing.xaml?�6   %    .��5      ]� $
��Auto��6   $
��Auto��5      .+�5   
   o� $	��Top=�6   $��20��5      $
��Auto��5      .@�5      m� $��
Teilnehmer��6   .@�5      m� $��Info...��6   �� 5      m� 5      -   5        $��Hinzufügen...��5      5      m� 5      $��Bearbeiten...��6   m� 5      $��Löschen��6   5      m� 5      $
��Info��6   .@�5      m� -   5        $��Über...��5      5      5       5!      �� 5"   
   $��Bottom=�6   $
��Auto��5#      $
��Auto��5$      $
��Left=�5%      $��Center=�5&      .@�5'      �� -   5         ��Name$ 	StatusBar��5'      $��Status: ��5(      $��12(�5)      $��0,0,0,0q�5*      5+      � 5,   
   $	��Top=�6   $
��Auto��5-      $
��Auto��5.      .+�5/      �  � RowDefinitions 50      �� 51      $
��Auto �6$   �� 52      $	��500 �6$   .+�54      &   System.Windows.Controls.DataGrid  -   5          Name$ attendeesList��54      $y�Visible=�55       %� IsVirtualizing$ False��56      $��0,20,0,0q�57      $��1��58      	   AutoGenerateColumns$	 False��59      
   FrozenColumnCount$
 4��5:      $   HorizontalScrollBarVisibility$
 Auto=�5;      "   VerticalScrollBarVisibility$
 Auto=�5<         EnableRowVirtualization$ False��5=      !   EnableColumnVirtualization$ False��5>         CanUserAddRows$ False��5?         Columns 5C      0  *System.Windows.Controls.DataGridTextColumn  5D      ,  &System.Windows.Controls.DataGridColumn   Header$	 Nr.��6-      
Visibility$ Visible=�5F   -   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5E   -   �� *
AttendeeID+5F   -     5G      $
 Name��6-   $ Visible=�5I   -    5H   -   �� *
Lastname+5I   -     5J      $ Vorname��6-   $ Visible=�5L   -    5K   -   �� *	Firstname+5L   -     5M      $ Passwort��6-   $ Visible=�5O   -    5N   -   �� *
Password+5O   -   5Q      � 5R      $��0��6   $��0,20,0,0q�5S       � ColumnDefinitions 5T      �� 5U      $
��Auto �6+   �� 5V      $
��Auto �6+   �� 5W      $
��Auto �6+   .+�5Y      �� -   5        $ labelActualMonth��5Y      $
��Left=�5Z      $	��Top=�5[      $��0��5\      $��Februar 2024��5]      $��10,0,0,0q�5^      $
��Auto��5_      $��16(�5`      $
��Bold"�5a      $	��Top=�5b      �� 5c      -   5         ��Name$ 
ViewReload��5c      $
��Left=�5d      $��1��5e      $��20,0,0,0q�5f      $��Aktualisieren��5g      5h      �� 5i      -   5        $ MonthPayback��5i      $
��Left=�5j      $��2��5k      $��20,0,0,0q�5l      $��Monatsabschluß��5m      5n      5o      5p      5q      5r      
   M S B A M L   `   `   `  ����G  CEverydayning, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:EverydayningEverydayning  5   	       Everydayning.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Everydayning     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��600��6)    � 
ResizeMode$ NoResize=�5	   	   .��5
      � -   5         �Name$ gr��5
   *      grid#���   6    � ContextMenu 5   
   �� 5      -   5         ��Name$ cm��5      .@�5      m� -   5        $	��asd��5      6(   m� 5      -   5        $	��asd��5      6(   m� 5      -   5        $	��asd��5      6(   m� 5      -   5        $	��asd��5      6(   m� 5      -   5        $	��asd��5      6(   5      .+�5   
   (  "System.Windows.Controls.DatePicker  -   5          Name$ datka��5         FirstDayOfWeek$ Monday=�6$      SelectedDateFormat$ Short=�6<      SelectedDate 
2023-04-046W   $��24��6q   $	��Top=�6}   $��10q�6�   	   DisplayDate$	 
2023-04-04��6�     
datepicker#���  6�   &   System.Windows.Controls.DataGrid  5   
   -	   5        
  Name$
 dg��5      $��
10,39,0,44q�6   $
��Left=�63   $	��393��6N     datagrid#���  6�   �� 5   
     l1#���  6   $��	0,54,59,0q�6/   $	��Top=�6B   $��Right=�6Z   $��75��6v    	 label#���  6�   �� 5   
   -
   5         ��Name$	 tb1��5   4     textbox#���  6   $��	0,80,10,0q�6A    �� TextWrapping$
 Wrap=�6T   $	��Top=�6h   $��18��6�   $��Right=�6�   $	��169��6�   �� 5   
     l2#���  6   $��
0,103,59,0q�6/   $	��Top=�6C   $��Right=�6[   $��71��6w   #���  6�   �� 5   
   -   5         ��Name$	 cb2��5      $��
0,134,10,0q�6    $	��Top=�64   $��Right=�6L   $	��169��6h     combobox#���  6t   �� 5   
   -   5          b1#���  5      $��
0,161,10,0q�60   $��20��6D   $	��Top=�6P   $��Right=�6h   $	��169��6�    
	 button#��� 	 6�   �� 5   
    
 l3#��� 
 6   $��
0,197,55,0q�6/   $��Right=�6C   $��80��6_   $��26��6j   $	��Top=�6v   #���  6�   �� 5   
   -   5        $	 tb3��5      $��
0,0,10,188q�6   $
 Wrap=�63   $��Right=�6G   $	��169��6c   $��18��6o   $��Bottom=�6{   �� 5   
   -   5          b4#���  5      $��	0,0,10,10q�60   $��Right=�6C   $	��169��6_   $��20��6k   $��Bottom=�6w   #��� 	 6�   �� 5   
   -   5          b3#���  5      $��	0,0,10,35q�60   $��Right=�6C   $	��169��6_   $��20��6k   $��Bottom=�6w   #��� 	 6�   �� 5   
   -   5          b2#���  5      $��	0,0,10,60q�60   $��Right=�6C   $	��169��6_   $��20��6k   $��Bottom=�6w   #��� 	 6�   �� 5    
     l4#���  6   $
��Left=�6/   $��	245,0,0,7q�6J   $��41��6]   $��26��6h   $��Bottom=�6t   #���  6�   �� 5!   
   -   5         ��Name$
 cena��5!      $��0��6   $
��Left=�6*   $��	284,0,0,7q�6E   $��26��6X   $��Bottom=�6d   #���  6   5"      5#      
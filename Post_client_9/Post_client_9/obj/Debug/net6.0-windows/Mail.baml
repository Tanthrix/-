   M S B A M L   `   `   `  ����H  DPost_client_9, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Post_client_9Post_client_9  5   	       Post_client_9.Mail   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a9m1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   'localclr-namespace:Post_client_9  5   	   -   5          � Title$
  Mail��5	   	   $	��500��6   $	��800��6#   $	��800��6/   $	��500��6>   .��5      �  � RowDefinitions 5   
   �� 5      $
��225* �6   �� 5      $	��17* �6    � ColumnDefinitions 5   
   �� 5      $	��77* �6   �� 5      $
��129* �6   �� 5      $
��594* �6   .+�5   
    � -   5          �Name$ frame��5      $��2��6     � NavigationUIVisibility$ Hidden=�6/   $��2��6O     � Source 6`   �� � 5   
    � Orientation$ Vertical=�6   $	��Top=�6+   $��Right=�6C   $��1��6_   .+�5      �� -   5        $��Обновить��5      6(   �� 5      -   5        $��INBOX��5      6%   �� 5      -   5        $��Спам��5      6$   �� 5      -   5        $��Отправленные��5      6,   �� 5      -   5        $��Корзина��5      6'   �� 5      -   5        $��Черновики��5      6)   5      �� 5   
   -	   5        $��Написать��5      $��0,2,0,0q�6$   $��1��65   $��2��6Y   �� 5   
   -
   5        $��
Выйти��5      $	��Top=�68   $��0,0,2,0q�6P   $��Right=�6a   $��75��6}   5       5!      
   M S B A M L   `   `   `  ����D  @Messanger, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Messanger	Messanger  5   	       Messanger.chat_admin   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Messanger     5   	   -   5          � Title$  
chat_admin��5   	   $	��450��6   $	��800��6)   .��5	      �  � RowDefinitions 5
   
   �� 5      $�� 0.25* �6   �� 5      $��2* �6   �� 5      $
��0.3* �6    � ColumnDefinitions 5   
   �� 5      �� 5      $
��0.3* �6   .+�5   
   �� -   5         ��Name$ MsgLB��5      $��1��6!   �� 5   
   -   5        $ UsersLB��5      $��1��6#   $��2��60   �� 5   
   -   5        $ LogsLB��5      �� 5   
   -   5         ��Name$ SendBTN��5      $��1��6"   $��2��62   $
��Send��6?   $
��36px(�6N   $��Medium"�6^   6r   �� 5   
   -   5         ��Name$ MsgTB��5      $��2��6!   $��message��6.   $
��24px(�6=   $��Light"�6M    �� TextWrapping$
 Wrap=�6`   �� 5   
   -   5        $ ExitBTN��5      $��1��6"   $��
Leave chat��62   $
��24px(�6G   $��Medium"�6W   6k   5      5      
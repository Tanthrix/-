   M S B A M L   `   `   `  ����H  DPost_client_9, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Post_client_9Post_client_9  5          Post_client_9.WriteMail   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:Post_client_9     5      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a9m1http://materialdesigninxaml.net/winfx/xaml/themes  61     N� Title$  	WriteMail��5	      .��5
      �  � ColumnDefinitions 5   
   �� 5      �� 5      $��3* �6    � RowDefinitions 5   
   �� 5      $	��78* �6   �� 5      $	��97* �6   �� 5      $
��409* �6   .+�5   
   c� $��0,10,0,0q�6   $��1��6$   $��2��61   $��65��6E   $	��Top=�6Q   .@�5      �� $��ApplicationCommands.Cut��6   ��67   0  *MaterialDesignThemes.Wpf.PackIconExtension     Kind$ 
ContentCut=��� 5      $��ApplicationCommands.Copy��6   ��68     $ ContentCopy=��� 5      $��ApplicationCommands.Paste��6   ��69     $ ContentPaste=��� 5      �� 5      $��ApplicationCommands.Undo��6   ��68     $
 Undo=��� 5      $��ApplicationCommands.Redo��6   ��68     $
 Redo=��� 5      �� 5      $&�� EditingCommands.IncreaseFontSize��6   $
��A↑��6@   $��15(�6N   �� 5      $&�� EditingCommands.DecreaseFontSize��6   $
��A↓��6@   $��15(�6M   �� 5      �� 5      $ ��EditingCommands.ToggleBold��6   ��6:     $ 
FormatBold=��� 5       $"��EditingCommands.ToggleItalic��6   ��6<     $ FormatItalic=��� 5!      $%��EditingCommands.ToggleUnderline��6   ��6?     $ FormatUnderline=��� 5"      �� 5#      -   5        ��5#        $ Color=�67   c� 5$      -   5        $	��bar��5$      $y�Hidden=�6!   .@�5%      �� -   5         ��Name$ color��5%      $��75��6)   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ hexadecimal��64   $��Center=�6T   $��Center=�6v   �� 5&      -   5        $	��✓��5&      $��15(�6%   63   5'      5(      �� 5)   
   -   5         ��Name$	 rtb��5)      $��2��6#   $��2��60   $��
10,8,10,48q�6E   � 5*   
   -   5         �Name$ wp��5*       � Orientation$ 
Horizontal=�6    	 � 	ItemWidth$		 200��69   
 � 
ItemHeight$
 44��6I   $��2��6Y   $��	55,4,45,0q�6m   $��72��6�   $	��Top=�6�   .+�5+      �� -   5        $ text_2��5+       �� TextWrapping$
 Wrap=�6&   $�� ��6:   $ Кому��6B   ���#FFF �� TextAlignment$ Center=�6m   ���#000$��2q�6�   �� 5,      -   5        $ text_3��5,      $
 Wrap=�6&   $�� ��6:   $ Тема��6B   ���#FFF$ Center=�6m   ���#000$��2q�6�   5-      �� 5.   
   -	   5        $��1��5.      $��2��6!   $��Отпавить��62   $��Center=�6E   $��2��6b   $	��250��6o   $��Bottom=�6|   $��32��6�   6�   5/      50      
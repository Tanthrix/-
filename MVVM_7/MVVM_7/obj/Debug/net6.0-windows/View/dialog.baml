   M S B A M L   `   `   `  ����A  =MVVM_7, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:MVVM_7.ViewMVVM_7.View  5   	       MVVM_7.View.dialog   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5   	   %localclr-namespace:MVVM_7.View  5   	     � Title$  dialog��5	   	   $	��200��6   $	��200��6%   $	��200��61   $	��200��6A   $	��200��6Q   $	��200��6`    J� CommandBindings 5
      )  #System.Windows.Input.CommandBinding  5   
   -   5        #  System.Windows.SystemCommands   MinimizeWindowCommand   Command# Z 5      6k   .��5      � .+�5   
   �� $��Добавить��6   $��	70,92,0,0q�6$   $
��Left=�67   $��60��6R   $��20��6]   $	��Top=�6i   *  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5      +  %Microsoft.Xaml.Behaviors.EventTrigger  5         	EventName$ Click��6!   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5      2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command 6,   �� *Next+4  .Microsoft.Xaml.Behaviors.Core.CallMethodAction  5         
MethodName$
 Hide��6)   	   TargetObject	 6;   �� 
 �� RelativeSource
 ��  �� Mode$ FindAncestor=� �� AncestorType
 Window5      5      �� 5   
   -   5         ��Name$ tb��5      $��
10,55,10,0q�6    �� TextWrapping$
 Wrap=�62   $��18��6F   $	��Top=�6R   ��6j   �� *
New_type+�� 5   
   $,��&Название нового типа��6   $��0,29,0,0q�6/   $��26��6A   $	��Top=�6M   $��Center=�6e   $	��180��6�   $��Center=�6�   5      5      
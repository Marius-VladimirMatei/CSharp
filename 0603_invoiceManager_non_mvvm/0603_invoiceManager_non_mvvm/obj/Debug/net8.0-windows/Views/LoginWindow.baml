   M S B A M L   `   `   `  ����   0603_invoiceManager_non_mvvm5    /_0603_invoiceManager_non_mvvm.Views.LoginWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Login��5   	   $	��400��5   	   $	��250��6    � 
ResizeMode$ NoResize=�5   	    � WindowStartupLocation$ CenterScreen=�5   	   .��5	      � $��20q�6    � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��0��6!   $��Center=�61   $��	Username:��6L   �� 5   
   -   5         ��Name$ usernameTextBox��5      $��0��5      $��1��6   $	��5,2q�6/   �� 5   
   $��1��6   $��0��6!   $��Center=�61   $��	Password:��6L   G� 5   
   -   5         G�Name$ passwordBox��5      $��1��5      $��1��6#   $	��5,2q�63   �� 5    
   -   5         ��Name$ loginButton��5       $��2��5!      $��1��6   $��5,15,0,0q�6.   $��75��6@   $��Login��5"       �� 	IsDefault$
 True��5#      5$      5%      
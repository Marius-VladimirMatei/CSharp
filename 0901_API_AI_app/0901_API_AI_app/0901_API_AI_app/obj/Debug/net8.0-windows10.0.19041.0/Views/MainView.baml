   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5   	   K G_0901_API_AI_app, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:_0901_API_AI_app.Models_0901_API_AI_app.Models 5   	   %   _0901_API_AI_app.Views.MainView   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   6sys&clr-namespace:System;assembly=mscorlib     5   	   7local%clr-namespace:_0901_API_AI_app.Models     5   	     � Title$  OpenAI Chat Assistant��5   	   $	��600��5   	   $	��900��5   	    � WindowStartupLocation$ CenterScreen=�5	   	    J� InputBindings 5      �� 5   
   
 �� Key$ Enter��6    �� Command 6!   �� *SendTextCommand+��5      �� 5   
    �� 
StartPoint$	 0,0&�6    �� EndPoint$	 0,1&�6/   .��5      �  � Color$ #1e1e1e��6    � Offset$	 0.0Q�6+   � 5      $ #2a2a2a��6   $	 1.0Q�6+   5      .��5      � $��10q�6   	 � RowDefinitions	 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� 
 �� Orientation$
 
Horizontal=�6   $��Center=�6.   $��0,0,0,10q�6K   .+�5      A� $��32��6   $��32��6!   ��5       �� 5!       �� Color$ 
LightGreen��6&   5#      �� 5$      $��OpenAI Chat Assistant��6   $��28(�5%      $
��Bold"�5&      
�������$��10,0,0,0q�5(      5)      �� 5,   
   $��1��6   ���#252526 �� CornerRadius$ 12��5.       �� Padding$ 10q�5/      ���#3c3c3c$��1q�51      ._�52      �� $
��Auto=�6   .��53      �� ��6   �� *ChatHistory+��54      �� 55       �� 
TargetType" ��6     �� Triggers 56      �� 57   "    �� Binding 6.   �� *ChatHistory.Count+ �� Value 06T   .a�58   &   ��  �� Property � y� �� Value$ 	Collapsed=�6C   59   #   5;      ��5=      �� 5>      .R�5?      �� 5@      ��5B      �� 5C       �� DataType)  #_0901_API_AI_app.Models.ChatMessage"  6'   .R�5D      �� $ 10q�6%   $��5q�62   $ 8��6=   ��5E   "   �� 5F   &   " ��6,   .�5G   *   ��  � �� �#2a2a2a6G   �� 5H   *    � ��$
 Left=�6P    5I   *   �� 5J   .    6:   �� *Role+ �� FallbackValue$ 	Assistant�� User6l   .a�5K   2   ��  � �� �#4CAF506O   �� 5L   2    � ��$ Right=�6X   5M   /   5O   '   ._�5Q   "   �� 
�������$
��Wrap=�5S   ,   $��16(�5T   ,   $��5,2,5,2q�5U   ,   ��5Q   ,   �� *	Content+$ [no content]��5U   ,   5V      5W      5Y      5Z      5[      �� 5^   
   $��2��6   ���#2a2a2a$ 8��63   $ 10q�6D   $��0,10,0,0q�6Q   ._�5_      ]� .+�5`      � $
��Left=�6   $
��Auto��6-   $��0,0,10,0q�6:   .+�5a      �� -   5         ��Name$ InputTextBox��5a      $��16(�5c      
����������#3a3a3a$��0q�5f      $��10q�5g      $��40��5h      $��Center=�5i       �� AcceptsReturn$ False��5j       �� TextWrapping$
 Wrap=�5k      ��5b      �� *	InputText+ �� UpdateSourceTrigger$ PropertyChanged=�5k      �� 5n      $��Ask something...��6    ���#888$��16(�5p        �� Padding$ 10q�5q        J� IsHitTestVisible$ False��5r       $��Center=�5s       $
��Wrap=�5t       ��5u      �� 5v      " ��6$   .�5w   "   ��  � y�$ 	Collapsed=�6?    5x   "   �� 5y   &    62   �� *Text+ �� ElementName$ InputTextBox��  6e   .a�5z   *   ��  � y�$ Visible=�6G   5{   '   5}      5      5�      �� 5�      $
��Send��6   $��16(�5�      
���   �
��� � �$
��10 5q�5�      $	��100��5�      $��40��5�      $��Right=�5�       � Cursor$
 Hand��5�      $��0q�5�      ��5�      �� *SendTextCommand+��5�      �� 5�      " ��6    .�5�      ��  � ��
 � � �6;   �� 5�       � ��
 �����6;   �� 5�       �@�Cursor$
 Hand��67    5�      P� 5�   "    P� Property �@J�IsMouseOver P� Value$
 True��6A   . �5�   &   ��  � �� �#0064006C   5�   #   5�      5�      5�      5�      5�      5�      
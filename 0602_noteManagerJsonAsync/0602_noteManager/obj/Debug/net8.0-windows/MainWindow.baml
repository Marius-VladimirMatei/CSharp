   M S B A M L   `   `   `  ����  0602_noteManager"    _0602_noteManager.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Notes Manager��5   	   $	��450��6   $	��800��6,   .��5      � $��10q�6    � RowDefinitions 5	   
   �� 5
      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $��2* �6   �� 5      $��1* �6   .+�5   
   �� $��0��6   $��0��6"   $��	0,0,10,10q�62   .+�5      �� $��Title:��6   $
��Bold"�6&   �� 5      -   5         ��Name$ TitleTextBox��5      �� 5      $��Content:��6   $
��Bold"�6(   $��0,10,0,0q�6:   �� 5      -   5        $ ContentTextBox��5      $��80��6.    �� TextWrapping$
 Wrap=�6:    �� AcceptsReturn$
 True��6N   5      �� 5   
   $��0��6   $��1��6"    �� Orientation$ Vertical=�62   $��Stretch=�6I   .+�5       �� -   5         ��Name$ 	AddButton��5       $��Add Note��6(   $��0,0,0,5q�6;   6L   �� 5!      -   5        $ DeleteButton��5!      $��Delete Selected��6+   $��0,0,0,5q�6E   6V   �� 5"      -   5        $ RefreshButton��5"      $��Display all notes��6,   6H   5#      �� 5&   
   -   5         ��Name$ NotesListBox��5&      $��2��6(   $��2��65   �� 5)   
   -   5        	 ��Name$	 StatusTextBlock��5)      $��3��5*      $��2��6   $��Italic$�5+      
�������$��0,10,0,0q�5,      5-      5.      
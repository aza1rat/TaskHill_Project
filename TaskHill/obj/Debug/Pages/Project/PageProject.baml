   M S B A M L   `   `   `  ����C  ?TaskHill, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:TaskHill.PagesTaskHill.Pages  5           TaskHill.Pages.PageProject   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:TaskHill.Pages     5        N� Title$  PageProject��5	      .��5      �� $��10q�6    �� CornerRadius$ 30��6"   
�������._�5   
   �  � ColumnDefinitions 5      �� 5      $��4* �6#   �� 5      $��1* �6#    � RowDefinitions 5      �� 5      $
��0.5* �6    �� 5      $
��0.3* �6    �� 5      $��1* �6    �� 5      $
��0.3* �6    .+�5      �� -   5        $��/Resources/arrow.png��5      $
��Left=�62   $��50��6M   $��50��6X   6d   �� 5      -   5         ��Name$ ImageProjectLogotype��5   1   $��0��6   $��1��6!   $��Right=�6O   $��	0,10,40,0q�6k   $	��128��6~   $	��128��6�   $"��/Resources/avatarProfile.png��6�   6�   �� 5      -   5         ��Name$ ButtonChangeProjectLogo��5   2   $��1��6   $��1��6"   $��10,15,20,15q�6S   $��16(�6h      mySecondaryBtn#��[  6v   $+��%Изображение профиля��6�   �� 5      -   5         ��Name$ TextBoxProjectName��5   3   $��1��6   $��0��6#   $
��Left=�6O   $��24(�6j   $	��750��6x     myTB#��[ 6�   $��20,15q�6�   
 � Tag$% Название проекта��6�    � Cursor$ IBeam��6�   �� 5      -   5        	 ��Name$	 TextBoxProjectDescription��5   7   $��2��6   $��0��6'   $
��Left=�6Z   $	��750��6u   $	��250��6�   $��24(�6�   $��20,15q�6�   
 �� AcceptsReturn
 .  �� 
AcceptsTab .  �� 	IsEnabled . 5      �� 5      -   5        $ TextBoxProjectCode��5   3   $��3��6   $��0��6#   $
��Left=�6O   #��[ 6j   $��24(�6�   $	��400��6�   $ Код проекта��6�   $��20,15q�6�   �� 5      -   5        $ ButtonProjectAdd��5   2   $��3��6   $��1��6"   $��Добавить��6L   $��24(�6_    	 myBtn#��[ 6m   $��10,15,20,15q�6�   $
 Hand��6�   6�   5       5!      5"      
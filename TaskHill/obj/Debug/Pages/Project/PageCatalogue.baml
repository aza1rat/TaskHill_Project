   M S B A M L   `   `   `  ����C  ?TaskHill, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:TaskHill.PagesTaskHill.Pages  5      #clr-namespace:TaskHillTaskHill  62   "    TaskHill.Pages.PageCatalogue   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:TaskHill.Pages     5      +taskhillclr-namespace:TaskHill     62     N� Title$  PageCatalogue��5	      .��5      �  � RowDefinitions 5   
   �� 5      $
��1.5* �6   �� 5      $��1* �6   �� 5      $��4* �6   �� 5      $
��4.5* �6   .+�5   
   �� $��0��6   $��Я участвую��6!   $��Segoe UI Semibold)�63   $��32(�6R   $
��Left=�6`   $��Center=�6{   � 5   
   $��1��6    � ColumnDefinitions 5      �� 5      �� 5      �� 5      �� 5      .+�5      �� $��0��6   $��Категория:��6(   $��24(�6:   $
��Left=�6H   $��Center=�6c   �� 5      -   5         ��Name$ ComboBoxCategory��5      $��1��62   $��24(�6B      ComboBoxFlatStyle#��[  6�   5      �� 5      -   5         ��Name$ ButtonAddProject��5      $��3��6/   $��Добавить��6?   $��24(�6R    	 myBtn#��[ 6`    � Cursor$
 Hand��6   6�   5      �� 5    
   ���#FAFBFC$��2��6&   �� 5!   
   -   5         ��Name$ ListViewProject��5!      $��2��6,    �� SelectionMode$ Single=�69   
������ ��5"      �� 5#       �� 
TargetType" ��6   .�5$      �� 	 �� Property	 � ��
 �� Value
 5%      �� 5&       �� 
TargetType" ��6.   .R�5'   "   � $��	10,0,10,0q�6'   .+�5(   &      TaskHill.ProjectControl     TaskHill.ProjectControl   ProjectChanged! ProjectControl_ProjectChanged6W      ProjectDrop ProjectControl_ProjectDrop6�   $	��240��6>   $	��180��6J   6�   5)   #   5*      5,      5-      ��5/      �� 50      .R�51      �  � Orientation$ 
Horizontal=�6    $
��Left=�69   $��Center=�6T   52      ��54      �� 55      .R�56      � $��	10,0,10,0q�6   .+�57        $	��240��62   $	��180��6>   58      59      5;      5<      5=      
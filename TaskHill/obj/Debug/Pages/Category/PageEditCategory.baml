   M S B A M L   `   `   `  ����C  ?TaskHill, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:TaskHill.PagesTaskHill.Pages  5      %    TaskHill.Pages.PageEditCategory   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:TaskHill.Pages     5        N� Title$  PageEditCategory��5	      .��5      �  � ColumnDefinitions 5   
   �� 5      $��1* �6   �� 5      $��3* �6    � RowDefinitions 5   
   �� 5      $��1* �6   �� 5      $��2* �6   �� 5      $
��0.5* �6   �� 5      $��3* �6   .+�5   
   �� $��0��6   $��0��6!   $��10(�61   $ ��Имя категории:��6?   �� 5   
   -   5         ��Name$ TextBoxCategoryName��5      $��0��6/   $��1��6<   �� 5   
   $��1��6   $��0��6!   $*��$Описание категории:��61   �� 5   
   -   5        $  TextBoxCategoryDescription��5      $��1��66   $��1��6C   $��10(�6T   � 5   
   $��2��6   $��0��6    5      �� 5      �� 5      .+�5      �� -   5         ��Name$ ButtonCategoryChanging��5      $��0��65   $��Добавить��6E    	  myBtn#��[  6}    � Cursor$
 Hand��6�   �� 5       -   5        $ ButtonCategoryCancel��5       $��1��63   $��Отмена��6C   $y�Hidden=�6T   6h   5!      &   System.Windows.Controls.DataGrid  5"   
   -   5          Name$ DataGridCategory��5"      $��3��6-   $��2��6:      CanUserReorderColumns .     CanUserSortColumns .  	   AutoGenerateColumns	 .  
   SelectionMode$
 Single=�5#         SelectionUnit$ FullRow=�6*      
IsReadOnly .    Columns 5$      0  *System.Windows.Controls.DataGridTextColumn  5%      ,  &System.Windows.Controls.DataGridColumn   Header$ Категория��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 1* 68   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6C   �� *Name+  5&      $ Описание��6%   $ 2* 67    6B   �� *Description+5  /System.Windows.Controls.DataGridHyperlinkColumn  5'      $ Изменение��6*   $
 0.5* 6=    6J   �� *Id+   ElementStyle 5(      �� 5)       �� 
TargetType" ��6    .�5*      -   5        5+      5-        5.      $ Удаление��6*   $
 0.5* 6<    6I   �� *Id+ 5/      �� 50      " ��6    .�51      -   5        52      54      56      57      58      
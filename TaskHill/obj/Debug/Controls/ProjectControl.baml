   M S B A M L   `   `   `  ����C  ?TaskHill, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:TaskHillTaskHill  5          TaskHill.ProjectControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      >d2http://schemas.microsoft.com/expression/blend/2008    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      (localclr-namespace:TaskHill     5      .��5	      �� -   5          ��Name$  BorderProject��5	      
������� �� CornerRadius$ 10��67   $��4��6I   $	��0.2q�6Z   
����iA�._�5
   
   � $��20q�6    � RowDefinitions 5      �� 5      $��* �6    �� 5      $��1* �6    �� 5      $��3* �6    �� 5      $��1* �6     � ColumnDefinitions 5      �� 5      .+�5      � $��0��6   $��0��6     5      �� 5      $��25 �6'   �� 5      .+�5      �� $��1��6   $��10,0,0,0q�6,   $��Segoe UI Semibold)�6>   $��12(�6]   $��WordEllipsis=�6k    �� TextAlignment$
 Left=�6�   $��Center=�6�   }�. ��6�   �� *ProjectName+5      �� 5      $��0��6   ��6(   �� *ProjectLogotype+5      �� 5       $��1��6   $��	35,3,10,3q�6%   $��10(�68   $��Segoe UI Semilight)�6F   $
��Wrap=�6f   $��WordEllipsis=�6z   }�. ��6�   �� *ProjectDescription+�� 5!      -   5        $��3��5!      $��24��6"   $��24��6-   $��Right=�69   
������ 
������ $	��...��6�    � ContextMenu 5"      �� 5#      .@�5$      m� -   5        $��MenuItemChange��5$   #   $��Изменить��69   
 � Tag 6h   �� *ProjectCode+m� 5%      -   5        $��MenuItemDelete��5%   #   $��Удалить��69    6g   �� *ProjectCode+5&      5(      5)      5*      ��5+      �� 5,   
    �� 
TargetType   TaskHill.ProjectControl"  6    �� Triggers 5-      P� 5.      	 P� Property	 �@J�IsMouseOver
 P� Value
 . . �5/      ��  �� Property � �� �� Value$ 2q�68   50      52      54      
   M S B A M L   `   `   `  ����C  ?TaskHill, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:TaskHill.ControlsTaskHill.Controls  5      #    TaskHill.Controls.TaskControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:TaskHill.Controls     5      .��5
      �� -   5          ��Name$  
BorderTask��5
      
������� �� CornerRadius$ 3��64   $	��0.8q�6E   
�������._�5   
   �  � ColumnDefinitions 5      �� 5      $��1* �6#   �� 5      $��2* �6#   �� 5      $��2* �6#   �� 5      $
��1.5* �6#   �� 5      $
��0.5* �6#   .+�5      �� $��0��6   $��Задача��6(   $��Center=�66   $��Center=�6Q   $��WordEllipsis=�6n   $
��10,0q�6�   �� 5      $��1��6   $��Center=�6D   $
��Left=�6_   $��WordEllipsis=�6z   $
��10,0q�6�   ��6(   �� *
NameOfTask+6�   �� 5      -   5         ��Name$ ComboBoxTaskStatus��5   '   $��3��6   $��10,10q�6C      ComboBoxFlatStyle#��[  6R   ��6}   �� *
Categories+6�   �� 5      -   5        $��4��5      $"��/Resources/avatarProfile.png��6$   
 � Tag 6J   �� *TaskId+6a   5      5      5      
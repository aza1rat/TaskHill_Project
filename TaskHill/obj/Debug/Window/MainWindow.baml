   M S B A M L   `   `   `  ����C  ?TaskHill, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:TaskHillTaskHill  5   	       TaskHill.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:TaskHill     5   	     � Title$  Авторизация��5   	   $	��720��6   $
��1280��6*   $	��600��5	   	   $	��800��6   
����iA� � WindowStartupLocation$ CenterScreen=�5   	   .��5      �  � ColumnDefinitions 5   
   �� 5      $
��2.5* �6   �� 5      $��5* �6   �� 5      $
��2.5* �6    � RowDefinitions 5   
   �� 5      $��1* �6   �� 5      $��8* �6   �� 5      $��1* �6   .+�5   
   �� $��1��6   $��1��6$   
������� �� RadiusX$ 20��6>    �� RadiusY$ 20��6K    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 30Q�6#      Color$
 Gray��63   	   ShadowDepth$	 0Q�6@   5       � 5   
   -   5        
  �Name$
 FrameAuthorization��5        � NavigationUIVisibility$ Hidden=�6,   $��1��6L   $��1��6\     � Source$1 +\Pages\Authorization\PageAuthorization.xaml?�6i   5      5       5"      
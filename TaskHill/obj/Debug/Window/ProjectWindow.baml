   M S B A M L   `   `   `  ����C  ?TaskHill, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:TaskHillTaskHill  5   	       TaskHill.ProjectWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:TaskHill     5   	     � Icon$  /Resources/logo.ico��5   	    � Title$ TaskHill��5	   	   $	��720��6   $
��1280��6'   .��5
      �  � Cursor$
 Hand��6    � RowDefinitions 5   
   �� 5      $��1* �6   �� 5      $��9* �6   .+�5   
   �� $��0��6   
�������$��	0 0 0 0.5q�61    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 5Q�6#      	Direction$	 315Q�62      Opacity$	 0.5Q�6B      ShadowDepth$ 5Q�6P   5       � 5   
   -   5        	  �Name$	 	UpperMenu��5      $��0��6#   
  � NavigationUIVisibility$
 Hidden=�60     � Source$' !\Pages\Project\PageUpperMenu.xaml?�6P    � 5   
   -   5        $	 	FrameRoot��5      $��1��6#   $
 Hidden=�60   $' !\Pages\Project\PageCatalogue.xaml?�6P   � 5   
   -   5         �Name$ 	FlowPanel��5      $��0��6"   $��2��6/   $y�	Collapsed=�6@   .+�5      �� -   5        
���   � J� Opacity$	 0.5Q�5   %   63    � 5      -   5        $	 FrameProjectAdd��5      $
 Hidden=�6-   $��100,80,100,80q�6N   5      5      5      
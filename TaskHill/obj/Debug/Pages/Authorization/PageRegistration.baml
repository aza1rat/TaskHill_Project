   M S B A M L   `   `   `  ����C  ?TaskHill, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:TaskHill.PagesTaskHill.Pages  5      %    TaskHill.Pages.PageRegistration   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:TaskHill.Pages     5        N� Title$  PageRegistration��5	      .��5      �  � ColumnDefinitions 5   
   �� 5      $��1* �6   �� 5      $��8* �6   �� 5      $��1* �6    � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      .+�5   
   �� -   5         ��Name$ ImageBackToLogin��5      $��/Resources/arrow.png��6*   $��25��6H   $��25��6S   6_   � 5   
   $��0��6   $��1��6    5      �� 5      $
��0.5* �6#   �� 5      $��2* �6#   �� 5      $��1* �6#   .+�5!      �� $��0��6   $��/Resources/logo.png��6$   �� 5"      $��1��6   $��Регистрация��6(   $��32(�6;   $
��Left=�6I   $��Center=�6d   $��Segoe UI Light)�6   5#      �� 5$   
   -   5         ��Name$ TextBoxUserEmail��5$      $��1��6,   $��1��6<   $��0,25,0,0q�6I   $��15(�6[   
 � Tag$ Email��6i      myTB#���   6u    � Cursor$ IBeam��6�   �� 5%   
   -   5        $ TextBoxUserLogin��5%      $��1��6,   $��2��6<   $��0,25,0,0q�6I   $��15(�6[   $ 
Логин��6i   #���   6u   $ IBeam��6�   G� 5&   
   -   5         G�Name$ TextBoxUserPassword��5&      $��1��63   $��3��6C   $��0,25,0,0q�6P   $��15(�6b   $ Пароль��6p     myPB#���  6�   G� 5'   
   -   5        $ TextBoxUserPassword2��5'      $��1��64   $��4��6D   $��0,25,0,0q�6Q   $��15(�6c   $% Повторите пароль��6q   #���  6�   $ IBeam��6�   �� 5(   
   -   5         ��Name$ ButtonToKeepRegistration��5(      $��1��63   $��5��6C   $3��-Продолжить регистрацию >��6P   $��0,25,0,0q�6s   $��16(�6�    	 myBtn#��[ 6�   $
 Hand��6�   �� 5)   
   -   5        $ ButtonNewRegister��5)      $��1��6,   $��6��6<   $*��$Зарегистрироваться��6I   $��	0,15,0,10q�6f   $��16(�6y     mySecondaryBtn#��[ 6�   5*      5+      
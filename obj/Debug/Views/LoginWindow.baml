   M S B A M L   `   `   `  ����F  BOnlineStore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:OnlineStoreOnlineStore  5   	       OnlineStore.LoginWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:OnlineStore     5   	     � WindowStartupLocation$  CenterScreen=�5	   	    � Title$ LoginWindow��5
   	   $	��350��6   $	��400��6*    � 	Resources 5       �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius��%L  '��       �� 5   
   " ��6   .�5      ��  � ��$	 100��6&   �� 5       � ��$ 0,0,0,10q�6'   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   #��z��6K   $��1q�6w   $ 10��6�   ._�5      �� $��Center=�6/   $��Center=�6L   5      5      5      5      5      .��5      � ���#242128.+�5   
   �� -   5        $��
LoginPanel��5      $��
96,30,0,10q�6'   $��Center=�6;   $	��248��6X   .+�5      �� $��Вход��6   $��18(�6$   $
��Bold"�62   
�������$
��Exo2)�6W    �� TextAlignment$ Center=�6i   �� 5      $��Center=�6   $	��200��66   .+�5      �� $=��7Введите ваше имя пользователя��6   
�������$��5,0,0,0q�6S   �� 5      -   5        $��UsernameTextBox��5      $	��200��61   
���������6@   �� *
Username+	 �� UpdateSourceTrigger$	 PropertyChanged=�6   5       �� 5!      $��Center=�6   $	��200��66   .+�5"      �� $(��"Введите ваш пароль��6   
�������$��5,0,0,0q�6H   G� 5#      -   5        $��PasswordBox��5#      $	��200��61   
�������6n   5$      �� 5%      $��
Войти��6   $	��200��6%   $��0,0,0,5q�64   
��� ���
�������$
��Bold"�6�   $��23��6�   $	��190��6�   ��6E   �� *LoginCommand+6�   �� 5&      -   5        $7��1Перейти к окну регистрации��5&      $	��200��6:   $��0,0,0,5q�6I   
��� ���
�������$
��Bold"�6�   $��25��6�   $	��194��6�   5'      5(      5*      
   M S B A M L   `   `   `  ����F  BOnlineStore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:OnlineStoreOnlineStore  5   	   "    OnlineStore.RegistrationView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:OnlineStore     5   	     � WindowStartupLocation$  CenterScreen=�5	   	    � Title$ 
EquineClub��5
   	   $	��300��6   $	��400��6)    � 	Resources 5       �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius��%L  '��       �� 5   
   " ��6   .�5      ��  � ��$	 100��6&   �� 5       � ��$ 0,0,0,10q�6'   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   #��z��6K   $��1q�6w   $ 10��6�   ._�5      �� $��Center=�6/   $��Center=�6L   5      5      5      5      5      .��5      � ���#242128.+�5   
   �� -   5        $��RegistrationPanel��5      $��
96,30,0,10q�6.   $
��Left=�6B   $	��248��6]   .+�5      �� $��Регистрация��6   $��18(�6+   $
��Bold"�69   
�������$
��Exo2)�6^    �� TextAlignment$ Center=�6p   �� 5      $��Center=�6   $	��200��66   .+�5      �� $=��7Введите ваше имя пользователя��6   
�������$��5,0,0,0q�6S   �� 5      -   5        	 ��Name$	 UsernameTextBox��5      $	��200��63   
���������6B   �� *
Username+
 �� UpdateSourceTrigger$
 PropertyChanged=�6�   5       �� 5!      $��Center=�6   $	��200��66   .+�5"      �� $(��"Введите ваш пароль��6   
�������$��5,0,0,0q�6H   G� 5#      -   5         G�Name$ PasswordBox��5#      $	��200��63   
�������6p   5$      �� 5%      $��Center=�6   $	��200��66   .+�5&      �� $!��Введите ваш email��6   
�������$��5,0,0,0q�6G   $	��223��6X   �� 5'      -   5        $	 EmailTextBox��5'      $	��200��60   
���������6?   �� *Email+$
 PropertyChanged=�6{   5(      �� 5)      $��Регистрация��6   $	��200��6+   $��0,0,0,5q�6:   $	��200��6K   
��� ���
�������$
��Bold"�6�   ��6W   �� *RegisterCommand+6�   �� 5*      -   5        $��
Войти��5*      $	��200��6G   $��0,0,0,5q�6V   $	��200��6g   
��� ���
�������$
��Bold"�6�   5+      5,      5-      
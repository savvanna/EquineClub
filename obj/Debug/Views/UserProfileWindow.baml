   M S B A M L   `   `   `  ����F  BOnlineStore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:OnlineStoreOnlineStore  5   	   #    OnlineStore.UserProfileWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:OnlineStore     5   	     � WindowStartupLocation$  CenterScreen=�5	   	    � Title$ UserProfileWindow��5
   	   $	��450��6#   $	��500��60    � 	Resources 5       �� 
TargetType �� Property �� Value��%�   '��       �� 5   
   " ��6   .�5      ��  � ��$	 200��6&   �� 5       � ��$ 50��6'   �� 5       � ��$
 0,10q�6'   �� 5       � ��
 � ���6+   �� 5       � ��
 �����6+   5      5      .��5      � ���#242128.+�5   
   �� -   5        $��ProfilePanel��5      $��1��6)   $��Center=�66   .+�5      A� -   5        $��ProfileImage��5      $	��100��6*   $	��100��66   ��5      �� 5       �� ImageSource 6!   �� *User.ImagePath+5      �� 5      $-��'Профиль пользователя��6   $
��Bold"�64   $��20(�6F   
�������6T   �� 5      $&�� Имя пользователя:��6   
�������61   �� 5      
���������6   �� *User.Username+��5      }�  }� Location$ 	Underline=�6%   5!      �� 5"      $��Email:��6   
�������6&   �� 5#      
���������6   �� *
User.Email+64   �� 5$      $��Адрес:��6   
�������6&   �� 5%       �� Orientation$ 
Horizontal=�6   .+�5&      �� $	��200��6]   $��5q�6i   ��6   �� *User.Address+	 �� UpdateSourceTrigger$	 PropertyChanged=�6i   �� 5'      $��Сохранить��6   $��10,0,0,0q�6V   $��30��6h   $	��150��6t   ��6-   �� *UpdateAddressCommand+6t   5(      �� 5)      $"��Номер телефона:��6   
�������6/   �� 5*      $ 
Horizontal=�6   .+�5+      �� $	��200��6a   $��5q�6m   ��6   �� *User.PhoneNumber+$	 PropertyChanged=�6m   �� 5,      $��Сохранить��6   $��10,0,0,0q�6Z   $��30��6l   $	��150��6x   ��6-   �� *UpdatePhoneNumberCommand+6x   5-      �� 5.      $ Vertical=�6   $��0,10,0,0q�60   .+�5/      �� -   5        $.��(Обновить фото профиля��5/      $��5q�69   $��30��6D   $	��200��6P   6\   50      51      52      54      
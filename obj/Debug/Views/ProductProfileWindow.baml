   M S B A M L   `   `   `  ����F  BOnlineStore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:OnlineStoreOnlineStore  5   	   &     OnlineStore.ProductProfileWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:OnlineStore     5   	     � WindowStartupLocation$  CenterScreen=�5	   	    � Title$ ProductProfileWindow��5
   	   $	��450��6&   $	��400��63    � 	Resources 5       �� 
TargetType �� Property �� Value��%�   '��       �� 5   
   " ��6   .�5      ��  � ��$	 200��6&   �� 5       � ��$ 50��6'   �� 5       � ��$
 0,10q�6'   �� 5       � ��
 � ���6+   �� 5       � ��
 �����6+   5      5      .��5      � ���#242128.+�5   
   �� $��Disabled=�6   $
��Auto=�6@   $
��Auto��6c   .��5      �� $��Center=�6   .+�5      �� $	��200��6;   $��10q�6H   ��6   �� *Horse.ImagePath+6H   �� 5      $
��Bold"�69   $��20(�6K   
�������$��10q�6l    �� TextAlignment$ Center=�6x   ��6   �� *Horse.Brand+6x   �� 5      
�������$��10q�6L   $ Center=�6X   ��6   �� *Horse.Model+6X   �� 5      
�������$��10q�6L   $ Center=�6X   ��6   �� *Horse.Price+6X   �� 5      $(��"Добавить в корзину��6   $��30��6[   $	��150��6g   $��10q�6s   ��66   �� *AddToCartCommand+6s   �� 5      $,��&Добавить в избранное��6   $��30��6b   $	��150��6n   $��10q�6z   ��68   �� *AddToFavoritesCommand+6z   �� 5      $��30��6[   $	��150��6g   $��10q�6s   ��6   �� *
NewComment+ �� UpdateSourceTrigger$ PropertyChanged=�6s   �� 5      $-��'Добавить комментарий��6   $��30��6^   $	��150��6j   $��10q�6v   ��68   �� *AddCommentCommand+6v   �� 5       $��Простой��6    d� 	IsChecked$
 TrueY�6-   
�������$��Center=�6Q   $��Center=�6n   �� 5!      $
��Auto=�6   .��5"      �� $��10q�6H   ��6#   �� *HorseReviews+��5#      �� 5$      .R�5%   "   ]� ��. .+�5&   &   �� $��50��6N   $��50��6Z   $��0,0,10,0q�6e   $
��Left=�6w   ��6,   �� *User.ImagePath+6w   �� 5'   &   $��Center=�6I   $
��Wrap=�6d   
���������60   �� *	Content+6x   �� 5(   &   $+��%Удалить комментарий��6-   $��Right=�5+      
��� ���
�������$��8(�5.      $��2q�5/      $	��100��50      $��20��51      $��0q�52      ��5)      �� *" DataContext.DeleteCommentCommand+	 �� RelativeSource	 �� 
 �� AncestorType$
 ItemsControlL���5*      �� ��53   *   �� 54   .    �� 
TargetType" ��6>   .R�55   2   �� #��z��69   ._�56   6   �� $��Center=�6G   $��Center=�6d   57   3   58   /   5:   '   5;   #   5<      5>      5?      5@      5A      5B      5D      
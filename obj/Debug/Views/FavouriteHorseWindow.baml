   M S B A M L   `   `   `  ����F  BOnlineStore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:OnlineStoreOnlineStore  5   	   %    OnlineStore.FavoriteHorseWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:OnlineStore     5   	     � WindowStartupLocation$  CenterScreen=�5	   	    � Title$ FavoriteHorses��5
   	   $	��450��6    $	��800��6-    � 	Resources 5       �� 
TargetType �� Property �� Value��%�   '��       �� 5   
   " ��6   .�5      ��  � ��$	 200��6&   �� 5       � ��$ 50��6'   �� 5       � ��$
 0,10q�6'   �� 5       � ��
 � ���6+   �� 5       � ��
 �����6+   5      5      .��5      � ���#242128 � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��1��6   
����=H�$��1q�6:    �� CornerRadius$ 10��6N    �� Padding$ 10q�6`   $��10q�6m   ._�5      �� .��5      �� -   5        $��FavoritesListView��5      ���#242128��68   �� *FavoriteHorses+��5      �� 5      .R�5      � 	 � Orientation$	 
Horizontal=�6(   5       ��5"      �� 5#      .R�5$      �� 
����=H�$��1q�6A   $ 10��6U   $ 10q�6g   $��10q�6t   $	��220��6�   ._�5%   "   �� 
 �� Orientation$
 Vertical=�6-   .+�5&   &   �� $	��100��6O   ��6,   �� *Horse.ImagePath+6O   �� 5'   &    �� TextAlignment$ Center=�6M   $
��Bold"�6d   
���������60   �� *Horse.Brand+6v   �� 5(   &   $ Center=�6M   
���������60   �� *Horse.Model+6d   �� 5)   &   $ Center=�6M   
���������60   �� *Horse.Price+6d   �� 5*   &   $��Удалить��6-   ��6?   �� *(&DataContext.RemoveFromFavoritesCommand+ �� RelativeSource ��  �� AncestorType$ ItemsControlL���6�   �� �� 5+   &   $��Подробнее��6-   ��6A   �� *'%DataContext.OpenProductProfileCommand+ �� $ ItemsControlL���6�   �� 5,   #   5-      5.      50      51      52      53      55      
   M S B A M L   `   `   `  ����F  BOnlineStore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:OnlineStoreOnlineStore  5   	       OnlineStore.MainCatalog   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:OnlineStore     5   	     � WindowStartupLocation$  CenterScreen=�5	   	    � Title$ MainCatalog��5
   	   $	��450��6   $	��700��6*    � 	Resources 5       �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius��%  '��       '�� �    �� 5   
   " ��6   .�5      ��  � ��$	 200��6&   �� 5       � ��$ 50��6'   �� 5       � ��$
 0,10q�6'   �� 5       � ��
 � ���6+   �� 5       � ��
 �����6+   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   #��z��6K   $��1q�6w   $ 10��6�   ._�5      �� $��Center=�6/   $��Center=�6L   5      5      5      5      �� 5   
   " ��6   .�5      ��  � ��
 �����6+   5      5      .��5       ]� ���#242128.+�5!   
   �� $
��Left=�6   $	��200��6(   $��0,0,10,0q�64   ���#242128.@�5"      ��  J� InputBindings 5#      d� 5$      	 d� MouseAction$	 	LeftClicke�6#   
 �� Command
 6;   �� *OpenUserProfileCommand+.��5%   -   Профиль5'      �� 5(       5)      d� 5*      $	 	LeftClicke�6#   
 6;   �� *OpenShoppingCartCommand+.��5+   -   
Брони5-      �� 5.       5/      d� 50      $	 	LeftClicke�6#   
 6;   �� *OpenFavoriteHorseCommand+.��51   -   Избранное53      �� 54       55      d� 56      $	 	LeftClicke�6#   
 6;   �� *OpenOrdersCommand+.��57   -   Заказы59      �� 5:      $#��Добавить лошадь��6   $	��Top=�6S   ��6/   �� *AddHorseCommand+y�6h   �� *AddHorseVisibility+�� 5;      -   5        $��
Выход��5;      $	��Top=�6:   5<      � 5=   
    � RowDefinitions 5?      �� 5@      $
��Auto �6    �� 5A      $��* �6    .+�5D      �� $��Моя подпись��6    d� 	IsChecked$
 TrueY�6-   o� 5H      .@�5I      m� $��Сортировать��6   .@�5J      m� $*��$По возрастанию цены��6    m� CommandParameter$ PriceAscending��6\    m� Command 6<   �� *SortCommand+6\   m� 5K      $$��По убыванию цены��6   $ PriceDescending��6Y    69   �� *SortCommand+6Y   5L      m� 5M      $��Фильтровать��6   .@�5N      m� $��
Бренд��6   .@�5O      �� ��6'   �� *Brands+��5P      �� 5Q   "   .R�5R   &   m� ��6/   ��  6B   �� *DataContext.FilterCommand+ �� RelativeSource ��  �� AncestorType$
 MenuL� 6�   �� 5S   #   5U      5V      m� 5W      $��Модель��6   .@�5X      �� ��6'   �� *Models+��5Y      �� 5Z   "   .R�5[   &   m� ��6/   ��  6B   �� *DataContext.FilterCommand+ �� $
 MenuL� 6�   �� 5\   #   5^      5_      5`      m� 5a      $��
Сброс��6    6*   �� *ResetCommand+5b      �� 5c      $��1��6   .��5d      �� -   5        $��ProductListView��5d      $��1��6W   ���#242128��66   �� *
Products+��5e      �� 5f      .R�5g      �  � Orientation$ 
Horizontal=�6(   5h      ��5j      �� 5k      .R�5l      �� 
����=H�$��1q�6A   $ 10��6U    �� Padding$ 10q�6g   $��10q�6t   $	��220��6�   ._�5m   "   ��  �� Orientation$ Vertical=�6-   .+�5n   &   �� $	��100��6I   ��6,   �� *	ImagePath+6I   �� 5o   &    �� TextAlignment$ Center=�6G   $
��Bold"�6^   
���������60   �� *Brand+6p   �� 5p   &   $ Center=�6G   
���������60   �� *Model+6^   �� 5q   &   $ Center=�6G   
���������60   �� *Price+6^   �� 5r   &   $��Удалить��6-   ��6?   �� * DataContext.RemoveHorseCommand+ �� $ ItemsControlL���6�   �� y�6�   �� *#!DataContext.RemoveHorseVisibility+ �� $ ItemsControlL��� 5s   &   $��Подробнее��6-   ��6A   �� *'%DataContext.OpenProductProfileCommand+ �� $ ItemsControlL���6�   �� 5t   #   5u      5v      5x      5y      5z      5{      5~      
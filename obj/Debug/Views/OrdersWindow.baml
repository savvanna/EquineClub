   M S B A M L   `   `   `  ����F  BOnlineStore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:OnlineStoreOnlineStore  5   	       OnlineStore.OrdersWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:OnlineStore     5   	     � WindowStartupLocation$  CenterScreen=�5	   	    � Title$ OrdersWindow��5
   	   $	��450��6   $	��800��6+   .��5      � 
�������.+�5   
   �� $��	20,0,20,0q�62   
���������6   �� *Orders+ �� View 5      �� 5      .P�5      �� $��ID заказа��6%    �� DisplayMemberBinding 68   �� *	OrderId+ �� HeaderTemplate 5      �� 5      .R�5   "   �� $��ID заказа��6,   
����=H�$
��Bold"�6X   5      5      �� 5      $��Дата заказа��6%    6:   �� *	OrderDate+ 5      �� 5      .R�5   "   �� $��Дата заказа��6,   
����=H�$
��Bold"�6Z   5      5      �� 5      $��Статус заказа��6%    5      �� 5      .R�5    "   �� $��Статус заказа��6,   
����=H�$
��Bold"�6\   5!       �� CellTemplate 5#      �� 5$      .R�5%   "   �� $��В обработке��6,   
��� � �$
��Bold"�6R   5&      5(      5)      5+      5,      5-      
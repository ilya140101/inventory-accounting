   M S B A M L   `   `   `  ����O  Kinventory accounting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:inventory_accountinginventory_accounting  5   	   ,    &inventory_accounting.SelectingQuantity   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:inventory_accounting     5   	   -   5          � Title$+  %Выберите количество��5   	   $	��350��6%   $	��400��62    � 
ResizeMode$ NoResize=�6>    � WindowStartupLocation$ CenterScreen=�6T   $��18(�6y   .��5	      � .+�5
   
   � $	��145��6   $��Center=�6   $��Center=�6;   $	��300��6V   $��60,87,34,89q�6b   .+�5      �� $
��Left=�6   $��	10,10,0,0q�63   $
��Wrap=�6F   $��Количество:��6Z   $	��Top=�6m   $��25��6�   $	��102��6�   �� 5      $
��Left=�6   $��	10,40,0,0q�63   $
��Wrap=�6F   $��	Цена:��6Z   $	��Top=�6g   $��25��6   $��87��6�   �� 5      -   5         ��Name$ Discount_text��5      $
��Left=�6/   $��	10,70,0,0q�6J   $
��Wrap=�6]   $��Скидка:��6q   $	��Top=�6�   $��25��6�   $��87��6�   �� 5      -   5        $ 	Summ_text��5      $
��Left=�6+   $��
10,110,0,0q�6F   $
��Wrap=�6Z   $��Сумма:��6n   $	��Top=�6|   $��25��6�   $��87��6�   �� 5      -   5        $ 	SalePrice��5      $
��Left=�6+   $��
170,40,0,0q�6F   $
��Wrap=�6Z   $�� ��6n   $	��Top=�6v   $��25��6�   $	��120��6�   �� 5      -   5         ��Name$ Count��5      $
��Left=�6P   $��25��6k   $��
170,10,0,0q�6w    �� TextWrapping$
 Wrap=�6�   $��1��6�   $	��Top=�6�   $	��120��6�   6�   �� 5      -   5        $ Discount��5      $
��Left=�6S   $��25��6n   $��
170,70,0,0q�6z   $
 Wrap=�6�   $��0��6�   $	��Top=�6�   $	��120��6�   6�   �� 5      -   5        $
 Summ��5      $
��Left=�6O   $��170,110,0,0q�6j   $
 Wrap=�6   $�� ��6�   $	��Top=�6�   $��25��6�   $	��120��6�   6�   5      � 5   
   $��Center=�6   $��65��6,   $	��Top=�68   $	��274��6P   $��	0,237,0,0q�6\    J� RenderTransformOrigin$ 	0.5,0.338&�6o   .+�5      �� -   5         ��Name$ OK��5      $��OK��6!   $
��Left=�6.   $	��Top=�6I   $��75��6a   $��
101,21,0,0q�6l   6�   �� 5      -	   5        $��Отмена��5      $
��Left=�6&   $	��Top=�6A   $��75��6Y   $��
189,21,0,0q�6d   6x   5      �� 5   
   -
   5        $
 Name��5      $��Center=�6"   $��0,37,0,0q�6?   $��WrapWithOverflow=�6Q   $�� ��6q   $	��Top=�6y   $
��auto��6�   5      5      
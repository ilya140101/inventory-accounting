   M S B A M L   `   `   `  ����O  Kinventory accounting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:inventory_accountinginventory_accounting  5      ;"clr-namespace:inventory_accountinginventory_accounting  6?   #    inventory_accounting.BigTable   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:inventory_accounting     5      5local1"clr-namespace:inventory_accounting     6?   .��5	      �   � RowDefinitions  5
   
   �� 5      $��8* �6   �� 5      $��2* �6   .+�5   
       inventory_accounting.Table  -   5          Name$ table��5   ^   $��0��6   $��Stretch=�6$   $��Stretch=�6B   $��0,10,0,0q�6m   6�   �� 5   
   -   5         ��Name$ 	selection��5      $��1��6   $��Подбор��61   $
��Left=�6B   $��	30,0,0,25q�6]   $��Center=�6p   $��98��6�   $��38��6�   $��18(�6�   �� 5   
   -   5        $
 exit��5      $��1��6   $��Записать��6,   $
��Left=�6?   $��
211,0,0,25q�6Z   $��Center=�6n   $��98��6�   $��38��6�   $��18(�6�   6�   � 5   
   $��1��6   $��Center=�6   $��Right=�67   $��61��6S   $	��230��6a   .+�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $
��Wrap=�6   $
��auto��60   $
��auto��6=   $��Сумма:��6K   $��18(�6Z   �� 5      -   5         ��Name$ Summ_TextBlock��5      $
��Wrap=�64   $
��auto��6H   $
��auto��6U   $�� ��6c   $��18(�6k   �� 5      $
��Wrap=�6   $
��auto��61   $
��auto��6>   $�� руб.��6L   $��18(�6Y   5      5      5      5      
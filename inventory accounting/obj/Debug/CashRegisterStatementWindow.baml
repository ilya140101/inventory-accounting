   M S B A M L   `   `   `  ����O  Kinventory accounting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:inventory_accountinginventory_accounting  5   	   6    0inventory_accounting.CashRegisterStatementWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:inventory_accounting     5   	     � Title$(  "Ведомость по кассе��5   	   .��5	      �  � RowDefinitions 5
   
   �� 5      �� 5      $
��Auto �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ table��5      ���#FFFBDB   AutoGenerateColumns .  $��30,30,30,30q�6S   $��18(�6h      SelectionMode$ Single=�6v      
IsReadOnly .    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Дата��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto 6S   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 63   �� *
DateString+6S     5      $' !Начальный остаток��6%   $ * 6c   
   
Foreground
 �#7776bc   
FontWeight$
 Bold"�6�   	 6@   �� *InitialBalance+6�     5      $ Приход��6%   $ * 6R   
 �#00A6A6$
 Bold"�6q   	 66   �� *	Arrival+6q     5      $ Расход��6%   $ * 6U   
 �#FF674D$
 Bold"�6t   	 65   �� *Expenditure+6t     5      $% Конечный Остаток��6%   $ * 6`   
 �#7776bc$
 Bold"�6   	 6?   �� *FinalBalance+6      RowHeaderStyle 5      �� 5       �� 
TargetType:  4System.Windows.Controls.Primitives.DataGridRowHeader"  6   .�5      ��  �� Property � �� �� Value$ 0��6.   5       � 	Resources 5      *  $System.Windows.Controls.DataGridCell �� Triggers P� Property P� Value��%�   '        �� 5      "  6   .�5      ��  � �� �#FFFBDB63   -   5         5       P� 5!       �@ 
IsSelected . . �5"      ��  � �� �#CCDAFF6;   �� 5#       � ��
 �   �6;   5$      5&      5'      5(      5*      5+      
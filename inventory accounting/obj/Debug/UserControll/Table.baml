   M S B A M L   `   `   `  ����O  Kinventory accounting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:inventory_accountinginventory_accounting  5           inventory_accounting.Table   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:inventory_accounting     5      .��5	      �   � RowDefinitions  5
   
   �� 5      �� 5      $
��Auto �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ table��5         AutoGenerateColumns .  $��
30,20,30,0q�6?   $��18(�6S      SelectionMode$ Single=�6a      
IsReadOnly .    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Код��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6K   -   5        
dgCode��1  +System.Windows.Controls.DataGridBoundColumn   Binding 5   2   �� *Code+6X     5      $ Наименование��6%   $
 Auto 6T   -   5        
dgName�� 5   ;   �� *Name+6a     5      $ Остатки��6%   $ * 6S   -   5        
dgQuantity�� 5   6   �� *
Quantity+6]     5      $ Закупка��6%   $ * 6X   -   5        dgPurchasePrice�� 5   6   �� *PurchasePrice+6b     5      $ Розница��6%   $ * 6T   -   5        dgSalePrice�� 5   6   �� *	SalePrice+6^     5      $ Без скидки��6%   $ * 6R   -   5        
dgSumm�� 5   9   �� *Summ+6\     5      $ Скидка��6%   $ * 6R   -   5        
dgDiscount�� 5   5   �� *
Discount+6\     5      $ Сумма(Закуп.)��6%   $ * 6]   -	   5        dgSummPurchase�� 5   <   �� *SummPurchase+6g     5      $ 
Сумма��6%   $ * 6U   -
   5        dgSummDiscount�� 5   4   �� *SummDiscount+6_   	   RowHeaderStyle	 5      �� 5      
 �� 
TargetType:  4System.Windows.Controls.Primitives.DataGridRowHeader"
  6   .�5      ��  �� Property � �� �� Value$ 0��6.   5       � 	Resources 5      *  $System.Windows.Controls.DataGridCell �� Triggers P� Property P� Value��%�   '        �� 5       "
  6   .�5!      -   5         5#      P� 5$       �@ 
IsSelected . . �5%      ��  � �� �#CCDAFF6;   �� 5&       � ��
 �   �6;   5'      5)      5*      5+      �� 5,   
   $��1��6   $��30,10q�6"    �� Orientation$ 
Horizontal=�61   .+�5-      �� -   5         ��Name$ 	find_code��5-      $��Код��6*   $��18(�6f   ��65   �� *ActualWidth+ �� ElementName$ dgCode��6�   �� 5.      -   5        $ 	find_name��5.      $��Наименование��6*   $��18(�6o   ��6>   �� *ActualWidth+$ dgName��6�   �� 5/      -   5        $ find_quantity��5/      $��Количество��6.   $��18(�6u   ��6@   �� *ActualWidth+$ 
dgQuantity��6�   �� 50      -   5        $ find_purchasePrice��50      $��Закупка��63   $��18(�6|   ��6B   �� *ActualWidth+$ dgPurchasePrice��6�   �� 51      -   5        $ find_salePrice��51      $��Розница��6/   $��18(�6t   ��6>   �� *ActualWidth+$ dgSalePrice��6�   �� 52      -   5        $ 	find_Summ��52      $��Без скидки��6*   $��18(�6m   ��6<   �� *ActualWidth+$ dgSumm��6�   �� 53      -   5        $ find_Discount��53      $��Скидка��6.   $��18(�6q   ��6<   �� *ActualWidth+$ 
dgDiscount��6�   �� 54      -   5        $ find_SummPurchase��54      $��Сумма(Закуп.)��62   $��18(�6�   ��6G   �� *ActualWidth+$ dgSummPurchase��6�   �� 55      -   5        $ find_SummDiscount��55      $��
Сумма��62   $��18(�6x   ��6?   �� *ActualWidth+$ dgSummDiscount��6�   56      57      58      
   M S B A M L   `   `   `  ����O  Kinventory accounting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:inventory_accountinginventory_accounting  5   	   &     inventory_accounting.ReportTable   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:inventory_accounting     5   	     � Title$2  ,Общий журнал документов��5   	   $��18(�6*   .��5	      �  � RowDefinitions 5
   
   �� 5      �� 5      $
��Auto �6   .+�5   
   o� -   5         o�Name$
 Menu��5      $��25��6   $	��Top=�6)   $��15(�6A   .@�5      m� -   5        $0��*Создать новый документ��5      67   m� 5      -   5         m�Name$ DateIntervalItem��5      $��Интервал��61   6C   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ table��5         AutoGenerateColumns .  $��30,30,30,92q�6>   $��18(�6S      SelectionMode$ Single=�6a      
IsReadOnly .    Columns 5      4  .System.Windows.Controls.DataGridTemplateColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 30 6)   
   
IsReadOnly
 .    CellTemplate 5      �� 5      .R�5      �� ��6$   �� *Image+5      5      0  *System.Windows.Controls.DataGridTextColumn  5         Header$ Документ��6%   $	 * 6\   -   5        dgReportType��1  +System.Windows.Controls.DataGridBoundColumn   Binding 5   7   �� *ReportTypeString+6f     5      $ Дата��6%   $	 * 6R   -   5        
dgDate�� 5   3   �� *
DateString+6\     5      $ 
Сумма��6%   $	 * 6M   -   5        
dgSumm�� 5   4   �� *Summ+6W      RowHeaderStyle 5      �� 5        �� 
TargetType:  4System.Windows.Controls.Primitives.DataGridRowHeader"  6   .�5!      ��  �� Property � �� �� Value$ 0��6.   5"       � 	Resources 5$      *  $System.Windows.Controls.DataGridCell �� Triggers P� Property P� Value��%�   '        �� 5%      "  6   .�5&      -   5         5)      P� 5*       �@ 
IsSelected . . �5+      ��  � �� �#CCDAFF6;   �� 5,       � ��
 �   �6;   5-      5/      50      51      �� 52   
   -	   5        $��Закрыть��52      $
��Left=�6#   $��	30,0,0,20q�6>   $��Bottom=�6Q   $	��144��6l   $��58��6x   6�   55      56      
   M S B A M L   `   `   `  ����N  JFestivalManager.App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:FestivalManager.App.ViewModelsFestivalManager.App.ViewModels  5      )    #FestivalManager.App.Views.BandsView   5      \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3b+http://schemas.microsoft.com/xaml/behaviors  5      =
viewModels,clr-namespace:FestivalManager.App.ViewModels  5         Base#��[  5      .��5      �   � RowDefinitions  5   
   �� 5      $
��Auto �6   �� 5      $	��10* �6   �� 5      $��10 �6   .+�5   
   � $��0��6   $��20, 20, 20, 10q�5       � ColumnDefinitions 5      �� 5      $	��250 �6#   �� 5      $��* �6#   .+�5      �� $��0��6   $��BANDS OVERVIEW��5      $��30(�5        	TitleFont#��[ 5         DarkSecondary#��[ 5!      $
��Left=�5"      $��Bottom=�5#      �� 5%      -   5        $��AddGroupButton��5'      $��1��5%      $
��Left=�5&        BasicButton#��[ 5(      $��0,2,0,0q�5*      ��5)      �� *AddBandCommand+.��5+      ��  �� Orientation$ 
Horizontal=�6   .+�5,      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ PlusBold=�6.   �� 5-      $��Add Band��6    5.      5/      51      &   System.Windows.Controls.DataGrid  53   
   -   5          Name$ BandsDataGrid��53      $��1��54         CanUserResizeColumns$
 True��55      $��20, 10, 20, 20q�56      $��Stretch=�57      $��Stretch=�58         AutoGenerateColumns$ False��5:         ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 5;      ��59      ��  �� Path$ Bands�	   Columns	 5<      0  *System.Windows.Controls.DataGridTextColumn  5=      ,  &System.Windows.Controls.DataGridColumn
   Header$

 Name��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 63   �� *Name+  5>      $
 Genre��6%    64   �� *Genre+  5?      $

 Info��6%    63   �� *Info+*  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5A      +  %Microsoft.Xaml.Behaviors.EventTrigger  5B         	EventName$ SelectionChanged��6!   *	  $Microsoft.Xaml.Behaviors.TriggerBase 	  Actions. 5C      2
  ,Microsoft.Xaml.Behaviors.InvokeCommandAction
   
  Command 6,   �� *BandSelectedCommand+ 
  CommandParameter 5D   ,   ��  �� ElementName$ BandsDataGrid��$ SelectedItem�5E      5G      5I      5K      
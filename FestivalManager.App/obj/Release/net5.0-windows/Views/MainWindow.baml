   M S B A M L   `   `   `  ���� N  JFestivalManager.App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:FestivalManager.App.ViewModelsFestivalManager.App.ViewModels  *    $FestivalManager.App.Views.MainWindow   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  <	ViewModel,clr-namespace:FestivalManager.App.ViewModels  $	��800��$	��600��$	��600��$
��1024��  � WindowStyle$
  None=� � WindowStartupLocation$ CenterScreen=� � AllowsTransparency$
 True��
������  � 
ResizeMode$ CanResizeWithGrip=� � Title$ Festival Manager�� � WindowState �� *CurrentWindowState+ � 	Resources  �� 
TargetType   GridMain �� Property	 �� Value
 �� Triggers �� Binding �� ElementName �� Path �� UpdateSourceTrigger �� Value��%�   &	        �� " ��.���  � ��$		 180 �
 ��  �� $ 
MenuToggle��$ 	IsChecked�$ PropertyChanged=� True.a���  � ��$	 60 �.���  � ColumnDefinitions �� -    ��Name$ SidebarColumn��#��[  �� $��* � � RowDefinitions �� $��60 ��� �� $��15 �.+��� $��1��$��0��  	Secondary#��[ �� $��2��$��2��$��0��  
DarkAccent#��[ � $��0��$��0��$��2��  Gradient#��[  �� $��* ��� $
��50px ��� $
��50px ��� $
��50px � �� $
��40px ��� $��* �.+��� $��FestivalManager��$��0��$��2��$��0��  Base#��[ $��20(�  	TitleFont#��[ $��Center=�$
��Left=�$��
40,0, 0, 0q��� $��1��$
��40px��$��0��  ControlButton#��[ ���� *MinimizeCommand+.��'  !MaterialDesignThemes.Wpf.PackIcon     Kind$ WindowMinimize=�$��Center=�$��Center=��� $��0��$
��40px��$��2��#��[ ���� *MaximizeCommand+.��  $��Center=�$��Center=� �� *
IconMaxMin+�� $��0��$
��40px��$��3��#��[ ���� *CloseWindowCommand+.��  $ 	CloseBold=�$��Center=�$��Center=�� $��1��$��0�� �� $��* ��� $��50 �.+��� -    ��Name$
 Menu��$��0��.+�	�   MainMenuButton#��[  d� 	IsChecked$
 TrueY����� *HomeViewCommand+.��� .+�  $ ChartScatterPlotHexbin=�$��
0, 2, 0, 0q��� $��Overview��  
ButtonText#��[ 	� #��[ ���� *BandsViewCommand+.��� .+�  $ MicrophoneVariant=�$��
0, 2, 0, 0q��� $��Bands��#��[ 	� #��[ ���� *StagesViewCommand+.��� .+�  $ GuitarElectric=�$��
0, 2, 0, 0q��� $��Stages��#��[ 	� #��[ ���� *ProgramViewCommand+.��� .+�  $ ViewDashboardVariant=�$��
0, 2, 0, 0q��� $��Program��#��[ d� -    d�Name$ 
MenuToggle��$��1��$ FalseY����� " d� 	 FlatToggleButton �� BasedOn# [	 
 P�  P� Property �@d�	IsChecked P� Value$ FalseY�. ���  � ��	   $ ArrowCollapseLeft=�$��Center=�$��Center=�P�  �@d�	IsChecked$
 TrueY�. ���  � ��	   $
 Menu=�$��Center=�$��Center=��� $��1��$��1��#��[ ���� *CurrentView+
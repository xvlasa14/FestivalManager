   M S B A M L   `   `   `  ����N  JFestivalManager.App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:FestivalManager.App.ViewModelsFestivalManager.App.ViewModels  5   	   *    $FestivalManager.App.Views.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   <	ViewModel,clr-namespace:FestivalManager.App.ViewModels  5   	   $	��800��5	   	   $	��600��5
   	   $	��600��5   	   $
��1024��5   	     � WindowStyle$
  None=�5   	    � WindowStartupLocation$ CenterScreen=�5   	    � AllowsTransparency$
 True��5   	   
������  � 
ResizeMode$ CanResizeWithGrip=�5   	    � Title$ Festival Manager��5   	    � WindowState 5   	   �� *CurrentWindowState+ � DataContext 5      2  ,FestivalManager.App.ViewModels.MainViewModel  5   
    � 	Resources 5       �� 
TargetType   GridMain	 �� Property
 �� Value �� Triggers �� Binding �� ElementName �� Path �� UpdateSourceTrigger �� Value��%�   &	        �� 5   
   " ��6   .�5      �� 	 � ��$	
 180 �5       5      �� 5        6   �� $ 
MenuToggle��$ 	IsChecked�$ PropertyChanged=� True5!      .a�5"      �� 	 � ��$
 60 �5#      5$      5&      5'      .��5*      �  � ColumnDefinitions 5+   
   �� 5,      -   5         ��Name$ SidebarColumn��5-      #��[  5,      5-      �� 5.      $��* �6    � RowDefinitions 50   
   �� 51      $��60 �6   �� 52      �� 53      $��15 �6   .+�57   
   �� $��1��6   $��0��58        	Secondary#��[ 59      �� 5:   
   $��2��6   $��2��5;      $��0��5<        
DarkAccent#��[ 5=      � 5@   
   $��0��6   $��0��5A      $��2��5B        Gradient#��[ 5C       5E      �� 5F      $��* �6#   �� 5G      $
��50px �6#   �� 5H      $
��50px �6#   �� 5I      $
��50px �6#    5L      �� 5M      $
��40px �6    �� 5N      $��* �6    .+�5R      �� $��FestivalManager��6   $��0��5S      $��2��5T      $��0��5U        Base#��[ 5V      $��20(�5W        	TitleFont#��[ 5X      $��Center=�5Y      $
��Left=�5Z      $��
40,0, 0, 0q�5[      �� 5^      $��1��6   $
��40px��6%   $��0��5_        ControlButton#��[ 5`      ��5a      �� *MinimizeCommand+.��5b      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ WindowMinimize=�6*   $��Center=�5c   *   $��Center=�5d   *   5e      �� 5g      $��0��6   $
��40px��6"   $��2��5h      #��[ 5i      ��5j      �� *MaximizeCommand+.��5k        $��Center=�5l   *   $��Center=�5m   *    5k   *   �� *
IconMaxMin+5m   *   5n      �� 5p      $��0��6   $
��40px��6"   $��3��5q      #��[ 5r      ��5s      �� *CloseWindowCommand+.��5t        $ 	CloseBold=�6*   $��Center=�5u   *   $��Center=�5v   *   5w      5y      � 5|   
   $��1��6   $��0��5}       5~      �� 5      $��* �6    �� 5�      $��50 �6    .+�5�      �� -   5         ��Name$
 Menu��5�      $��0��5�      .+�5�      	�   MainMenuButton#��[ 6    d� 	IsChecked$
 TrueY�5�      ��5�      �� *HomeViewCommand+.��5�      � .+�5�        $ ChartScatterPlotHexbin=�62   $��
0, 2, 0, 0q�5�   2   �� 5�      $��Overview��6$     
ButtonText#��[ 5�   $   5�      5�      	� 5�      #��[ 6   ��5�      �� *BandsViewCommand+.��5�      � .+�5�        $ MicrophoneVariant=�62   $��
0, 2, 0, 0q�5�   2   �� 5�      $��Bands��6$   #��[ 5�   $   5�      5�      	� 5�      #��[ 6   ��5�      �� *StagesViewCommand+.��5�      � .+�5�        $ GuitarElectric=�62   $��
0, 2, 0, 0q�5�   2   �� 5�      $��Stages��6$   #��[ 5�   $   5�      5�      	� 5�      #��[ 6   ��5�      �� *ProgramViewCommand+.��5�      � .+�5�        $ ViewDashboardVariant=�62   $��
0, 2, 0, 0q�5�   2   �� 5�      $��Program��6$   #��[ 5�   $   5�      5�      5�      d� 5�      -   5         d�Name$ 
MenuToggle��5�      $��1��5�      $ FalseY�5�      ��5�      �� 5�      " d�6    	 FlatToggleButton �� BasedOn# [	 5�       5�      P� 5�       P� Property �@d�	IsChecked P� Value$ FalseY�5�   &   . �5�   "   �� 	 � ��
 5�   &     5�   *   $ ArrowCollapseLeft=�6B   $��Center=�5�   B   $��Center=�5�   B   5�   #   5�      P� 5�       �@d�	IsChecked$
 TrueY�5�   &   . �5�   "   �� 	 � ��
 5�   &     5�   *   $
 Menu=�6B   $��Center=�5�   B   $��Center=�5�   B   5�   #   5�      5�      5�      5�      �� 5�   
   $��1��6   $��1��5�      #��[ 5�      ��5�      �� *CurrentView+5�      5�      5�      
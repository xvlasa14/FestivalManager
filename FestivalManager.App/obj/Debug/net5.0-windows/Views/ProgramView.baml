   M S B A M L   `   `   `  ����N  JFestivalManager.App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:FestivalManager.App.ViewsFestivalManager.App.Views  5      U QSystem.Runtime, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a7,clr-namespace:System;assembly=System.RuntimeSystem 5      O,clr-namespace:FestivalManager.App.ViewModelsFestivalManager.App.ViewModels  5	      +    %FestivalManager.App.Views.ProgramView   5      \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      2self'clr-namespace:FestivalManager.App.Views  5      9system,clr-namespace:System;assembly=System.Runtime  5      =
viewmodels,clr-namespace:FestivalManager.App.ViewModels  5	      _	 [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3b+http://schemas.microsoft.com/xaml/behaviors 	 5
         Base#��[  5      .��5      �   � RowDefinitions  5   
   �� 5      $
��Auto �6   �� 5      $	��10* �6   �� 5      $��10 �6   .+�5   
   � $��0��6   $��20, 20, 20, 10q�5       � ColumnDefinitions 5      �� 5      $	��300 �6#   �� 5      $��* �6#   .+�5!      �� $��0��6   $��PROGRAM OVERVIEW��5"      $��30(�5#        	TitleFont#��[ 5$        DarkSecondary#��[ 5%      $
��Left=�5&      $��Bottom=�5'      �� 5*      -   5        $��AddSlotButton��5,      $��1��5*      $
��Left=�5+        BasicButton#��[ 5-      $��0,2,0,0q�5.      ��5/      �� *AddSlotCommand+.��50      ��  �� Orientation$ 
Horizontal=�6   .+�51      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ PlusBold=�6.   �� 52      $��Add Slot��6    53      54      56      �� 59   
   $��1��6   $ Vertical=�5:      .+�5<      �� -   5         ��Name$ 
ComboPanel��5<      $ Vertical=�5=      $��30 10q�5>      $	��300��5?      $
��Left=�5@      .+�5A      ��   
TitleBlock#��[ 6   $��PICK STAGE:��5B      $��20(�5C      �� 5D      -   5         ��Name$ 
StageCombo��5D        MyCombo#��[ 5E       �� DisplayMemberPath$
 Name��5H      ��5F      �� *Stages+ �� SelectedItem 5G      �� *SelectedStage+5I      5K      �� 5O      -   5         ��Name$ SlotListView��5O   #   $��30q�6   ��5P      �� *Slots+��5S      �� 5T      .R�5U      �� $
��Left=�6%   $ 
Horizontal=�5V   %   5W      * 	 $Microsoft.Xaml.Behaviors.Interaction	   Triggers	 5Y      + 	 %Microsoft.Xaml.Behaviors.EventTrigger  5Z      
   	EventName$
 SelectionChanged��6%   * 	 $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5[      2 	 ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command 60   �� *SlotSelectedCommand+   CommandParameter 5\   0   ��  �� ElementName$ SlotListView�� �� Path$ SelectedItem�5]      ��5a      �� 5b      .R�5c      ��  ��Name$ SlotBase��6!   $	��400��63     LighterBase#��[ 5d   !    J� Effect 5e      3  -System.Windows.Media.Effects.DropShadowEffect  5f   "      
BlurRadius$ 5Q�63      ShadowDepth$ 0Q�5g   3     ColorShadow   Color# [ 5h   3   ._�5k      �� $	��250��6)   .+�5m   "   ��   
DarkAccent#��[ 6-    	 PinkBase#��[	 6V   �� 5n   &   $��18(�60   ��5o   0   �� *	StartTime+ �� StringFormat$ 
{0:dd.MM.}�� �� UpdateSourceTrigger$ PropertyChanged=�5p   #   �� 5q   "   #��[	 6,   �� 5r   &   ��60   �� *	StartTime+$ 	{0:HH:mm}��$ PropertyChanged=� �� 5s   &   $	�� - ��60    �� 5t   &   ��60   �� *	EndTime+$ 	{0:HH:mm}��$ PropertyChanged=�5u   #   �� 5x   "   $��20(�6,    	
 Dusty#��[
 5y   ,    �� Padding$
 0 10q�5z   ,    �� TextAlignment$ Center=�5{   ,   #��[ 5|   ,   $��SemiBold"�5}   ,     TextFont#��[ 5~   ,   ��5   ,   �� *	Band.Name+$ PropertyChanged=��� 5�   "   $ 
Horizontal=�6-   $��Center=�5�   -   $��20q�5�   -   .+�5�   &     $��0 0 10 0q�6>   #��[ 5�   >   $ 	MusicNote=�5�   >   $��18��5�   >   $��18��5�   >   �� 5�   &   $��SemiBold"�60   $��16(�5�   0   #��[ 5�   0   #��[ 5�   0   ��5�   0   �� *
Band.Genre+$ PropertyChanged=�5�   #   �� 5�   "   $ Vertical=�6-   $
��20 0q�5�   -   .+�5�   &   �� $��Description:��60   $��18(�5�   0   #��[ 5�   0   $��SemiBold"�5�   0   �� 5�   &   $
��Wrap=�60   $
 Left=�5�   0   $��16(�5�   0   $ 5q�5�   0   $��0 0 0 20q�5�   0   ��5�   0   �� *	Band.Info+$ PropertyChanged=�5�   #   5�      5�      5�      5�      5�      5�      5�      
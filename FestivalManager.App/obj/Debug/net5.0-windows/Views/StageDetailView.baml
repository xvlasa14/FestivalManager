   M S B A M L   `   `   `  ����N  JFestivalManager.App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:FestivalManager.App.ViewModelsFestivalManager.App.ViewModels  5      /    )FestivalManager.App.Views.StageDetailView   5      \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      C
viewModels,clr-namespace:FestivalManager.App.ViewModels     5      b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5         Base#��[  5
      .��5      �   � RowDefinitions  5   
   �� 5      $
��1.5* �6   �� 5      $��8* �6   �� 5      $��5* �6   .+�5   
   � $��0��6   $��Center=�5       � ColumnDefinitions 5      �� 5      $��4* �6#   �� 5      $��3* �6#   .+�5      �� $��0��6   $��Center=�5        DarkSecondary#��[ 5      $
��Left=�5       �� Padding$
 20 0q�5       �� 5!        EditableTextField#��[ 5"       �� 	MaxLength$ 35��5$      $��0q�5%      $��30(�5&        	TitleFont#��[ 5'      " �� VerticalScrollBarVisibility$ Disabled=�5(      ��5!      ��  �� Path$ 
Model.Name� �� UpdateSourceTrigger$ PropertyChanged=�.  (MaterialDesignThemes.Wpf.TextFieldAssist   CharacterCounterStyle 5#      Z� 5(      5)      � 5+      $��1��6   $��Stretch=�5,       5.      �� 5/      �� 50      �� 51      .+�54      �� $��0��6   $��Right=�55        BasicButton#��[ 56      ��57      �� *EditStageCommand+.��58      ��  �� Orientation$ 
Horizontal=�6!   .+�59      '  !MaterialDesignThemes.Wpf.PackIcon  	   Kind$	 ContentSave=�62   �� 5:      $��Save Changes��6$   5;      5<      �� 5=      $��2��6   $
��Left=�5>      #��[ 5?      ��5@      �� *RevertCommand+.��5A      �� $ 
Horizontal=�6!   .+�5B        $	 UndoVariant=�62   �� 5C      $
��Back��6$   5D      5E      �� 5F      $��1��6   #��[ 5G      ��5H      �� *RemoveStageCommand+.��5I      �� $ 
Horizontal=�6!   .+�5J        $	 
RemoveBold=�62   �� 5K      $��Remove��6$   5L      5M      5N      5O      � 5Q   
   $��1��6   $��Stretch=�5R      $��10q�5S      $��Stretch=�5T       5U      �� 5V      �� 5W      .+�5Z      �� $��0��6   $��Center=�5[      $	��300��5\      $	��500��5]      $
��20 0q�5^      .+�5_      �� $��	Location:��6     
TitleBlock#��[ 5`      $��20(�5a      �� 5b      #��[ 6   $	 500��5d      ��5c      �� $ 
Model.Info�$ PropertyChanged=�5d      �� 5f      $��Center=�6   $	��200��5g      $	��500��5h        TextBlockBase#��[ 5i      .+�5j      �� $��	Image URL��6    $
��Left=�5k       #��[ 5l       �� 5m        	FieldBase#��[ 6   ._�5n      ��   	TextField#��[ 6"   $ 0��5p   "   ��5o   "   �� *Model.Image+$ PropertyChanged=�5p   "   5q      5r      5s      �� 5u      $��1��6   $��Center=�5w      $ Vertical=�5x      ��5v      �� *Height+
 �� RelativeSource
 �� *FindAncestor+ �� AncestorType Grid.+�5y      ��  	 ImagePlaceholder#��[	 6   $��10q�5z      ._�5{      �� ��6   �� *Model.Image+ �� TargetNullValue Z� 5|      5      5�      �� 5�   
   $��2��6    
 LighterBase#��[
 5�      �� 5�   
   $��2��6   .+�5�      �� $��Performing bands:��6   #��[ 5�      $ 20 10q�5�      $��20(�5�      �� 5�      $
��30 0q�6   ��5�      �� *Bands+��5�      �� 5�      .R�5�      �� $
��Left=�6%   $��Center=�5�   %   $ 
Horizontal=�5�   %   5�      ��5�      �� 5�      .R�5�      �� $	��150��6!   $	��150��5�   !   $��0q�5�   !   #��[	 5�   !   ._�5�      �� $��Center=�6(   #��[ 5�   (   $ 0q�5�   (   ��5�   (   �� *Name+5�   (   5�      5�      5�      5�      5�      5�      
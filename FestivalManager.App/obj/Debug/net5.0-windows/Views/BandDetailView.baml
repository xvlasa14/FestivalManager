   M S B A M L   `   `   `  ����N  JFestivalManager.App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:FestivalManager.App.ViewModelsFestivalManager.App.ViewModels  5      .    (FestivalManager.App.Views.BandDetailView   5      \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      C
viewModels,clr-namespace:FestivalManager.App.ViewModels     5      b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5         Base#��[  5
      .��5      �   � RowDefinitions  5   
   �� 5      $
��1.5* �6   �� 5      $��8* �6   �� 5      $��5* �6   .+�5   
   � $��0��6   $��Center=�5       � ColumnDefinitions 5      �� 5      $��4* �6#   �� 5      $��3* �6#   .+�5      �� $��0��6   $��Center=�5        DarkSecondary#��[ 5      $
��Left=�5        �� Padding$
 20 0q�63   �� 5!        EditableTextField#��[ 5"       �� 	MaxLength$ 35��5#      $��0q�5$      $��30(�5%        	TitleFont#��[ 5'      " �� VerticalScrollBarVisibility$ Disabled=�5(      ��5!      ��  �� Path$ 
Model.Name� �� UpdateSourceTrigger$ PropertyChanged=�.  (MaterialDesignThemes.Wpf.TextFieldAssist   CharacterCounterStyle 5&      Z� 5(      5)      � 5,      $��1��6   $��Stretch=�5-       5/      �� 50      �� 51      �� 52      .+�55      �� $��0��6   $��Right=�6)     BasicButton#��[ 56      ��57      �� *EditBandCommand+.��58      ��  �� Orientation$ 
Horizontal=�6!   .+�59      '  !MaterialDesignThemes.Wpf.PackIcon  	   Kind$	 ContentSave=�62   �� 5:      $��Save Changes��6$   5;      5<      �� 5>      $��2��6   $
��Left=�5?      #��[ 5@      ��5A      �� *RevertCommand+.��5B      �� $ 
Horizontal=�6!   .+�5C        $	 UndoVariant=�62   �� 5D      $
��Back��6$   5E      5F      �� 5H      $��1��6   #��[ 5I      ��5J      �� *RemoveBandCommand+.��5K      �� $ 
Horizontal=�6!   .+�5L        $	 
RemoveBold=�62   �� 5M      $��Remove��6$   5N      5O      5R      5S      � 5U   
   $��1��6    5V      �� 5W      $
��2.5* �6#   �� 5X      $��2* �6#   .+�5\      � $��0��6   $
��20 0q�5]      .+�5_      � ��6   �� *ActualHeight+
 �� RelativeSource
 ��  �� Mode$ FindAncestor=� �� AncestorType Grid  5`      �� 5a      $��5* �6(   �� 5b      $	��12* �6(   .+�5e      � $��0��6     5f      �� 5g      $��* �6,   �� 5h      $
��1.5* �6,   .+�5k      � $��0��6   $��Center=�6,   $��Stretch=�5l       5m      �� 5n   "   �� 5o   "   .+�5r      �� $��0��6)   $��10q�5s   )   $ 
Horizontal=�5t   )   .+�5u   "     $	 Globe=�6:     	Secondary#��[ 5v   :   �� 5w   "     
TitleBlock#��[ 6,   $ 0q�5x   ,   $��20(�5y   ,   �� 5z   &   $ Hidden=�6.   $��0q�6S   #��[ 5|   .    5{   .   Z� ��5}   .   �� $ Model.Country�$ PropertyChanged=�5~   #   5      �� 5�      $��1��6)   $��10q�5�   )   $ 
Horizontal=�5�   )   .+�5�   "     $	 Music=�6:   #��[ 5�   :   �� 5�   "   #��[ 6,   $ 0q�5�   ,   $��20(�5�   ,   �� 5�   &   $ Hidden=�6.   $��0q�6S   #��[ 5�   .    5�   .   Z� ��5�   .   �� $ Model.Genre�$ PropertyChanged=�5�   #   5�      5�      �� 5�      $��1��6"   #��[ 6/   $	 100��5�   t   ��6"   �� $ Model.ShortDescription�$ PropertyChanged=�6t   5�      �� 5�      $��1��6!   .+�5�      �� #��[ 6$   $��About the band:��5�   $   $ 10q�5�   $   $��18(�5�   $   �� 5�      #��[ 6"   $	 500��5�   s   ��6"   �� $ Model.LongDescription�$ PropertyChanged=�6s   5�      5�      5�      � 5�      $
��20 0q�6   $��1��5�        5�      �� 5�      $��3* �6$   �� 5�      .+�5�      �� $��0��6   $��Center=�6&   $��Center=�6C     ImagePlaceholder#��[ 5�      ._�5�      �� ��6   �� *Model.Image+ �� TargetNullValue Z� 5�      �� 5�      $��1��6     TextBlockBase#��[ 6*   .+�5�      �� $��	Image URL��6    #��[ 5�       �� 5�      $	��500��6    	 	FieldBase#��[	 5�      ._�5�      �� $ 0��6"    
 	TextField#��[
 5�   "   ��5�   "   �� *Model.Image+$ PropertyChanged=�5�      5�      5�      5�      �� 5�   
   $��2��6     LighterBase#��[ 5�      �� 5�   
   $��2��6   .+�5�      �� $��Performances:��6   #��[ 5�      $ 20 10q�5�      $��20(�5�      �� 5�      $
��30 0q�6   ��5�      �� *Slots+��5�      �� 5�      .R�5�      �� $
��Left=�6%   $��Center=�5�   %   $ 
Horizontal=�5�   %   5�      ��5�      �� 5�      .R�5�      �� $	��100��5�   !   $��0q�5�   !   #��[ 5�   !   ��5�   !   �� *ActualHeight+
 �� *Self+._�5�      �� .+�5�   "   ��   PinkBase#��[ 6,     
DarkAccent#��[ 5�   ,   �� 5�   &   $��18(�60   ��5�   0   �� *	StartTime+ �� StringFormat$ 
{0:dd.MM.}��$ PropertyChanged=�5�   #   �� 5�   "   $��15(�6,   #��[ 6:   �� 5�   &   ��60   �� *	StartTime+$ 	{0:HH:mm}��$ PropertyChanged=� �� 5�   &   $	�� - ��60    �� 5�   &   ��60   �� *	EndTime+$ 	{0:HH:mm}��$ PropertyChanged=�5�   #   �� 5�   "   $��Center=�6,   #��[ 5�   ,   $ 	0,20,0,20q�5�   ,   ��5�   ,   �� *
Stage.Name+5�   ,   5�      5�      5�      5�      5�      5�      5�      
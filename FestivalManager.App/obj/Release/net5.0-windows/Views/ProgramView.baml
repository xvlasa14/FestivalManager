   M S B A M L   `   `   `  ���� N  JFestivalManager.App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:FestivalManager.App.ViewsFestivalManager.App.Views  +    %FestivalManager.App.Views.ProgramView   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  2self'clr-namespace:FestivalManager.App.Views     Base#��[  .���   � RowDefinitions  �� $
��Auto ��� $	��10* ��� $��10 �.+�� $��0��$��20, 20, 20, 10q� � ColumnDefinitions �� $	��300 ��� $��* ��� $��* �.+��� $��0��$��PROGRAM OVERVIEW��$��30(�  	TitleFont#��[   DarkSecondary#��[ $
��Left=�$��Bottom=��� -   $��AddSlotButton��$��1��$
��Left=�  BasicButton#��[ $��0,2,0,0q�.����  �� Orientation$ 
Horizontal=�.+�'  !MaterialDesignThemes.Wpf.PackIcon     Kind$ PlusBold=��� $��Add Slot���� $��2��$��Right=�$��Bottom=�  	SearchBox#��[ � $��1��$��Center=�$��Center=�.+�R� -   $��MockData������  �� 
TargetType" Q�.���  �� Property �@Q�
IsExpanded �� Value$
 True����  � �� ��  �� 
TargetType" R�.R��� $ 
Horizontal=� � 	Resources 	 �� DataType)   #FestivalManager.App.Views.MockStage
 �� ItemsSource)   #FestivalManager.App.Views.StageSlot��%�   (��       *, +)(�� B     *, +)�� "	  
 �� *Slots+.R��� 
����� ����� *Name+�� "	  .R��� $ Vertical=�.+��� ���� *
BandName+�� 
��� � ����� *	Beginning+�� 
��� � ����� *Ending+
   M S B A M L   `   `   `  ����H  DTP2_14E_A2022, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:TP2_14E_A2022.PagesTP2_14E_A2022.Pages  5      clr-namespace:   5      %    TP2_14E_A2022.Pages.OutilCreate   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:TP2_14E_A2022.Pages     5      c _MaterialDesignThemes.MahApps, Version=0.2.8.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a_ [MaterialDesignThemes.Wpf, Version=4.8.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5      globalclr-namespace:   5        N� Title$  OutilCreate��5      $	��450��6   $	��800��6(    � 	Resources 5         errorMessage �� 
TargetType �� Property �� Value  SnackbarSuccessStyle'  !MaterialDesignThemes.Wpf.Snackbar   BoolToBrushConverter  BoolToBrushConverterF  @MaterialDesignThemes.Wpf.Converters.BooleanToVisibilityConverter   BooleanToVisibilityConverter0   *TP2_14E_A2022.Pages.BoolToTooltipConverter  BoolToTooltipConverter��%+  &	        &	 J     &	 �     &	 �     &	 �     �� 5   
   " ��6%   .�5      ��  � ��
 �  ��6+   5      �� 5   
   "  6-   .�5      ��  � �� �	#B3FFFFFF6+   �� 5       � ��
 ����6+   5        5   
   6&     5   
   66     5   
   6'   5      .��5      � 
������� � ColumnDefinitions 5   
   �� 5      $
��0.4* �6   �� 5      $
��0.8* �6   �� 5      $
��0.4* �6    � RowDefinitions 5   
   �� 5       $��0.45* �6   �� 5!      $��1* �6   .+�5$   
     -   5          Name$ MessageValidation��5$   "   $��0��6=   $��0��6M   $��3��6Z   $��Center=�6n   $	��Top=�6�      MessageQueue 5%      3  -MaterialDesignThemes.Wpf.SnackbarMessageQueue  5&      5(      �� 5*   
   $��1��6   	 �� Orientation$	 Vertical=�6&   $	��Top=�6=   $��
395,0,25,0q�6V   $��2��6j   .+�5+      �� $	 
Horizontal=�6   $��Right=�64   .+�5,      �� $��15(�6   $��Bonjour��6&   �� 5-      -   5        
 ��Name$
 nomCompletTextBlock��5-        	overLabel#���  6:   $��15(�6^   $��Center=�6l   5.      �� 5/      -   5        $��0��5/      $��1��6%   #���  65   $��16(�6Y   $��Right=�6g   �� 6�   $�Me déconnecter��6�   6�   50      �� 52   
   -   5        $��Retour��52      ���	#FF7DB569$��Right=�69   $��
0,89,25,19q�6U   $��2��6�   $	��133��6�   �� 54   
   $��../Ressources/logo.png��6   $	��150��60   $	��150��6@   $��0��6O   $��0��6_   $
��Left=�6l   $	��Top=�6�   6�   �� 56   
   ���	#FF7DB569 J� IsHitTestVisible$ False��6%   $��1��6>   $��0��6K   $��3��6[   $��	0,0,0,-55q�6o   �� 57   
   $��1��6   $
��Left=�6$   $	��350��6?   $��	32,20,0,0q�6L   $��1��6_   
���   �$	��Top=�6{   $	��342��6�   ���	#FFF7FBF96�   �� 59   
   $��1��6   $��1��6"   $	 Vertical=�62   $��Center=�6I   $��Center=�6f    K� ZIndex$ 1��6�   $	��208��6�   $	��195��6�   .+�5:      �� $	��Nom��6   ���	#FF009019$��14��6:   �� 5;      -   5        $��
NomTextBox��5;      �� 5<      -   5        $
 NomErreurTextBlock��5<      #��[  64   $��0,0,0,5q�6Z   �� 5>      $��Description��6   ���	#FF009019$��14��6B   �� 5?      -   5        $��DescriptionTextBox��5?      �� 5@      -   5        $ 
 DescriptionErreurTextBlock��5@      #��[  6<   $��0,0,0,5q�6b   �� 5B      -	   5        $��EstBriseCheckBox��5B      $��Est brisé?��6/   ���	#FF0090196D   5C      �� 5E   
   -
   5        $	��100��5E      $	��200��6       MaterialDesignDarkForeground#���  6J   ���	#FF7DB569$��Créer��6�   $��3��6�   $��175,247,175,31q�6�    �� 	IsDefault$
 True��6�   $��1��6�   5F      5I      5J      
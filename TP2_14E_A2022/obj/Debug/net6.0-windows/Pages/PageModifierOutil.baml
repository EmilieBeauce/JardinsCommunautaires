   M S B A M L   `   `   `  ����H  DTP2_14E_A2022, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:TP2_14E_A2022.PagesTP2_14E_A2022.Pages  5      clr-namespace:   5      +    %TP2_14E_A2022.Pages.PageModifierOutil   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      3local!clr-namespace:TP2_14E_A2022.Pages     5      c _MaterialDesignThemes.MahApps, Version=0.2.8.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a_ [MaterialDesignThemes.Wpf, Version=4.8.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5      globalclr-namespace:   5        N� Title$  PageModifierOutil��5      $	��450��5      $	��800��5	       N� 
Background
 ����� � 	Resources 5         errorMessage �� 
TargetType �� Property �� Value  SnackbarSuccessStyle'  !MaterialDesignThemes.Wpf.Snackbar   BoolToBrushConverter  BoolToBrushConverterF  @MaterialDesignThemes.Wpf.Converters.BooleanToVisibilityConverter   BooleanToVisibilityConverter0   *TP2_14E_A2022.Pages.BoolToTooltipConverter  BoolToTooltipConverter��%+  &	        &	 J     &	 �     &	 �     &	 �     �� 5   
   " ��6%   .�5      ��  � ��
 �  ��6+   5      �� 5   
   "  6-   .�5      ��  � �� �	#B3FFFFFF6+   �� 5       � ��
 ����6+   5        5   
   6&     5   
   66     5   
   6'   5      .��5      � $��	0,-39,0,0q�6    � ColumnDefinitions 5   
   �� 5      $
��0.4* �6   �� 5      $
��0.8* �6   �� 5      $
��0.4* �6    � RowDefinitions 5    
   �� 5!      $��0.45* �6   �� 5"      $��1* �6   .+�5%   
     -   5          Name$ MessageValidation��5%   "   $��0��6=   $��0��6M   $��3��6Z   $��Center=�6n   $	��Top=�6�   	   MessageQueue	 5&      3  -MaterialDesignThemes.Wpf.SnackbarMessageQueue  5'      5)      �� 5+   
   $��2��6   
 �� Orientation$
 Vertical=�6%   $	��Top=�6<   $��0,0,20,0q�6T   .+�5,      �� $
 
Horizontal=�6   $��Right=�62   .+�5-      �� $��15(�6   $��Bonjour��6&   �� 5.      -   5         ��Name$ nomCompletTextBlock��5.        	overLabel#���  69   $��15(�6]   $��Center=�6k   5/      �� 50      -   5        $��0��50      $��1��6%   #���  65   $��16(�6Y   $��Right=�6g   Me déconnecter6�   51      �� 54   
   -   5        $	��100��54      $��Retour��6    ���	#FF7DB569$��0,0,0,23q�6k   $��Center=�6}   $	��156��6�   $��2��6�   $��32��6�   $��Bottom=�6�   �� 55   
   $��../Ressources/logo.png��6   $	��150��60   $	��150��6@   $��0��6O   $��0��6_   $
��Left=�6l   $	��Top=�6�   6�   �� 56   
   ���	#FF7DB569 J� IsHitTestVisible$ False��6%   $��1��6>   $��0��6K   $��3��6[   $��	0,0,0,-55q�6o   �� 57   
   $��1��6   $
��Left=�6$   $	��350��6?   $��	32,20,0,0q�6L   $��1��6_   
���   �$	��Top=�6{   $	��342��6�   ���	#FFF7FBF96�   �� 59   
   $��1��6   $��1��6"   $
 Vertical=�62   $��Center=�6I   $��Center=�6f    K� ZIndex$ 1��6�   $	��208��6�   $	��195��6�   .+�5:      �� $	��Nom��6   ���	#FF009019$��14��6:   �� 5;      -   5        $��
NomTextBox��5;      $��0,0,0,0q�6(   �� 5<      -   5        $ NomError��5<      
���  ��$��14��6;   $y�	Collapsed=�6G   �� 5>      $��Description��6   ���	#FF009019$��0,10,0,0q�6B   $��14��6T   �� 5?      -   5        $��DescriptionTextBox��5?      $��0,0,0,0q�60   �� 5@      -   5        $ DescriptionError��5@      
���  ��$��14��6D   $y�	Collapsed=�6P   �� 5A      -	   5        $��EstBriseCheckBox��5A      $��0, 20, 0, 0q�6/   $��	Est Brise��6D   ���	#FF0090196X   5B      �� 5D   
   -
   5        $	��100��5D      $	��200��6       MaterialDesignDarkForeground#���  6J   ���	#FF7DB569$��Mettre à jour��6�   $��3��6�   $��175,247,175,31q�6�    �� 	IsDefault$
 True��6�   $��1��6�   5E      5F      5G      
   M S B A M L   `   `   `  ����\  XMaterialDesign.Avalonia.PackIcon, Version=1.25.0.0, Culture=neutral, PublicKeyToken=null}Xclr-namespace:MaterialDesign.Avalonia.PackIcon;assembly=MaterialDesign.Avalonia.PackIcon MaterialDesign.Avalonia.PackIcon  5      H DTP2_14E_A2022, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:TP2_14E_A2022.PagesTP2_14E_A2022.Pages 5      +   %TP2_14E_A2022.Pages.PageAjouterMembre   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      c _MaterialDesignThemes.MahApps, Version=0.2.8.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a_ [MaterialDesignThemes.Wpf, Version=4.8.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5      dwpfXclr-namespace:MaterialDesign.Avalonia.PackIcon;assembly=MaterialDesign.Avalonia.PackIcon   5      /local!clr-namespace:TP2_14E_A2022.Pages   5        N� Title$  PageAjouterMembre��5       � 	Resources 5         errorMessage �� 
TargetType �� Property �� Value  SnackbarErrorStyle'  !MaterialDesignThemes.Wpf.Snackbar��%�   &	        &	 J     �� 5   
   " ��6%   .�5      ��  � ��
 �  ��6+   5      �� 5   
   "  6+   .�5      ��  � �� �	#B3FFFFFF6+   �� 5       � ��
 �  ��6+   5      5      .��5      � 
������� � ColumnDefinitions 5   
   �� 5      $
��0.4* �6   �� 5      $
��0.8* �6   �� 5      $
��0.4* �6    � RowDefinitions 5   
   �� 5      $��0.45* �6   �� 5       $��1* �6   .+�5#   
   �� -   5        $��../Ressources/logo.png��5#      $	��150��60   $	��150��6@   $��0��6O   $��0��6_   $
��Left=�6l   $	��Top=�6�   6�     5%   
   -   5          Name$ MessageValidation��5%   "   $��Center=�6=   $	��Top=�6Z   $��0,0,0,20q�6r      MessageQueue 5&      3  -MaterialDesignThemes.Wpf.SnackbarMessageQueue  5'      5)      �� 5+   
   $��2��6   	 �� Orientation$	 Vertical=�6&   $	��top=�6=   $��0,0,20,0q�6V   .+�5,      �� $	 
Horizontal=�6   $��Right=�64   .+�5-      �� $��15(�6   .��6(   	Bonjour61   �� 5.      -   5        
 ��Name$
 nomCompletTextBlock��5.        	overLabel#���  6:   $��15(�6^   $��Center=�6l   6�   5/      �� 50      -   5        $��0��50      $��1��6%   #���  65   $��16(�6Y   $��Right=�6g   Me déconnecter6�   51      �� 53   
   ���	#FF7DB569 J� IsHitTestVisible$ False��6%   $��1��6?   $��0��6L   $��3��6\   $��	0,0,0,-55q�6p   �� 54   
   $��1��6   $
��Left=�6$   $	��350��6?   $��	32,20,0,0q�6L   $��1��6_   
���   �$	��Top=�6{   $	��342��6�   ���	#FFF7FBF955      �� 56   
   $��1��6   $��1��6"   $	 Vertical=�62   $��Center=�6I   $��Center=�6f    K� ZIndex$ 1��6�   $	��208��6�   $	��195��6�   .+�57      �� $��Prénom��6   ���	#FF009019$��14��6=   �� 58      -   5         ��Name$ prenomTextBox��58      �� 59      -   5        $
 prenomErrorTextBlock��59      #��[  66   �� 5:      $	��Nom��6   ���	#FF009019$��14��6:   �� 5;      -   5        $ 
nomTextBox��5;       J� RenderTransformOrigin$ 0.483,-0.753&�6*   �� 5<      -   5        $
 nomErrorTextBlock��5<      #��[  63   5=      �� 5@   
   -	   5         ��Name$ AjouterMembre��5@      $	��100��6(   $	��200��67      MaterialDesignDarkForeground#���  6k   ���	#FF7DB569$��Ajouter le membre��6�   $��3��6�   $��175,290,175,-12q�6�    �� 	IsDefault$
 True��6  $��1��6  5A      �� 5B   
   -
   5        $ AjouterAdresse��5B      $	��100��6)   $	��200��68   #���  6m   ���	#FF7DB569$��Ajouter adresse��6�   $��3��6�   $��175,243,175,35q�6�   $
 True��6  $��1��6  5C      5D      5E      
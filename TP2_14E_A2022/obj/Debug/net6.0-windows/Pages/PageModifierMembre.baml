   M S B A M L   `   `   `  ����\  XMaterialDesign.Avalonia.PackIcon, Version=1.25.0.0, Culture=neutral, PublicKeyToken=null}Xclr-namespace:MaterialDesign.Avalonia.PackIcon;assembly=MaterialDesign.Avalonia.PackIcon MaterialDesign.Avalonia.PackIcon  5      H DTP2_14E_A2022, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:TP2_14E_A2022.PagesTP2_14E_A2022.Pages 5      ,   &TP2_14E_A2022.Pages.PageModifierMembre   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      c _MaterialDesignThemes.MahApps, Version=0.2.8.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a_ [MaterialDesignThemes.Wpf, Version=4.8.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5      dwpfXclr-namespace:MaterialDesign.Avalonia.PackIcon;assembly=MaterialDesign.Avalonia.PackIcon   5      /local!clr-namespace:TP2_14E_A2022.Pages   5        N� Title$  PageModifierMembre��5       � 	Resources 5         errorMessage �� 
TargetType �� Property �� Value  SnackbarErrorStyle'  !MaterialDesignThemes.Wpf.Snackbar��%�   &	        &	 J     �� 5   
   " ��6%   .�5      ��  � ��
 �  ��6+   5      �� 5   
   "  6+   .�5      ��  � �� �	#B3FFFFFF6+   �� 5       � ��
 �  ��6+   5      5      .��5      � 
������� � ColumnDefinitions 5   
   �� 5      $
��0.4* �6   �� 5      $
��0.8* �6   �� 5      $
��0.4* �6    � RowDefinitions 5   
   �� 5      $��0.45* �6   �� 5       $��1* �6   .+�5#   
   �� -   5        $��../Ressources/logo.png��5#      $	��150��60   $	��150��6@   $��0��6O   $��0��6_   $
��Left=�6l   $	��Top=�6�   6�     5$   
   -   5          Name$ MessageValidation��5$   "   $��Center=�6=   $	��Top=�6Z   $��0,0,0,20q�6r      MessageQueue 5%      3  -MaterialDesignThemes.Wpf.SnackbarMessageQueue  5&      5(      �� 5*   
   $��1��6   	 �� Orientation$	 Vertical=�6&   $��Bottom=�6=   $��395,0,25,91q�6Y   $��2��6n   .+�5+      �� $	 
Horizontal=�6   $��Right=�64   .+�5,      �� $��15(�6   .��6(   	Bonjour61   �� 5-      -   5        
 ��Name$
 nomCompletTextBlock��5-        	overLabel#���  6:   $��15(�6^   $��Center=�6l   6�   5.      �� 5/      -   5        $��0��5/      $��1��6%   #���  65   $��16(�6Y   $��Right=�6g   Me déconnecter6�   50      �� 52   
   ���	#FF7DB569 J� IsHitTestVisible$ False��6%   $��1��6?   $��0��6L   $��3��6\   $��	0,0,0,-55q�6p   �� 53   
   $��1��6   $
��Left=�6$   $	��350��6?   $��	32,20,0,0q�6L   $��1��6_   
���   �$	��Top=�6{   $	��342��6�   ���	#FFF7FBF954      �� 55   
   $��1��6   $��1��6"   $	 Vertical=�62   $��Center=�6I   $��Center=�6f    K� ZIndex$ 1��6�   $	��208��6�   $	��195��6�   .+�56      �� $��Prénom��6   ���	#FF009019$��14��6=   �� 57      -   5         ��Name$ prenomTextBox��57      �� 59      $	��Nom��6   ���	#FF009019$��14��6:   �� 5:      -   5        $ 
nomTextBox��5:       J� RenderTransformOrigin$ 0.483,-0.753&�6*   5;      �� 5=   
   -   5         ��Name$ ModifierMembre��5=      $	��100��6)   $	��200��68      MaterialDesignDarkForeground#���  6m   ���	#FF7DB569$��Modifier le membre��6�   $��3��6�   $��175,290,175,-12q�6�    �� 	IsDefault$
 True��6
  $��1��6  5>      5?      5@      
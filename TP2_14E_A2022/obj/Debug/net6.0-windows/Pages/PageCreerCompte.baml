   M S B A M L   `   `   `  ����H  DTP2_14E_A2022, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:TP2_14E_A2022.PagesTP2_14E_A2022.Pages  5      )    #TP2_14E_A2022.Pages.PageCreerCompte   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:TP2_14E_A2022.Pages     5      c _MaterialDesignThemes.MahApps, Version=0.2.8.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a_ [MaterialDesignThemes.Wpf, Version=4.8.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5        N� Title$  PageCreerCompte��5
       � 	Resources 5         errorMessage �� 
TargetType �� Property �� Value  SnackbarErrorStyle'  !MaterialDesignThemes.Wpf.Snackbar��%�   &	        &	 J     �� 5   
   " ��6%   .�5      ��  � ��
 �  ��6+   5      �� 5   
   "  6+   .�5      ��  � �� �	#B3FFFFFF6+   �� 5       � ��
 �  ��6+   5      5      .��5      � 
������� � ShowGridLines$
 True��6   $��20,20,20,20q�63    � ColumnDefinitions 5   
   �� 5      $	��800 �6   �� 5      $��* �6   .+�5   
   �� -   5        $��../Ressources/logo.png��5      $	��200��60   $	��200��6@   $��90,115,480,106q�6O   6g     5   
   -   5          Name$ MessageValidation��5   "   $��Center=�6=   $	��Top=�6Z   $��0,0,0,20q�6r      MessageQueue 5       3  -MaterialDesignThemes.Wpf.SnackbarMessageQueue  5!      5#      �� 5%   
   $	��Top=�6   $	��400��6-   $��
347,80,0,0q�6:   $
��Left=�6N   $	��395��6i   .+�5'      �� 	 J� IsHitTestVisible$	 False��6   $��Prénom��61   $��Center=�6?   $��Center=�6Z   $��0,0,0,5q�6w   ���	#FF0090196�   �� 5(      -   5        
 ��Name$
 prenomTextBox��5(   \   $	��250��6   $��Center=�6$   $��Center=�6?   $��2q�6s   
���   �6~   �� 5)      -   5         ��Name$ prenomErreurTextBlock��5)      #��[  67   $��Center=�6]   �� 5+      $	 False��6   $	��Nom��61   $��Center=�6<   $��Center=�6W   $��0,0,0,5q�6t   ���	#FF0090196�   �� 5,      -   5        $
 
nomTextBox��5,   \   $	��250��6   $��Center=�6$   $��Center=�6?   $��2q�6p   
���   �6{   �� 5-      -   5        $ nomErreurTextBlock��5-      #��[  64   $��Center=�6Z   �� 5/      $	 False��6   $��Adresse courriel��61   $��Center=�6I   $��Center=�6d   $��0,0,0,5q�6�   ���	#FF0090196�   �� 50      -   5        $
 courrielTextBox��50   \   $	��250��6   $��Center=�6$   $��Center=�6?   $��2q�6u   
���   �6�   �� 51      -   5        $ courrielErreurTextBlock��51      #��[  69   $��Center=�6_   �� 53      $	 False��6   $��Mot de passe��61   $��Center=�6E   $��Center=�6`   $��0,0,0,5q�6}   ���	#FF0090196�   G� 54      -	   5         G�Name$ mdpPasswordBox��54   `   $	��250��6   $��Center=�6(   $��Center=�6C   $��2q�6x   
���   �6�   �� 55      -
   5        $ mdpErreurTextBlock��55      #��[  64   $��Center=�6Z   �� 57      $	 False��6   $"��Confirmation du mot de passe��61   $��Center=�6U   $��Center=�6p   $��0,0,0,5q�6�   ���	#FF0090196�   G� 58      -   5        $ confirmationPasswordBox��58   `   $	��250��6   $��Center=�6(   $��Center=�6C   $��2q�6�   
���   �6�   �� 59      -   5        $! confirmationErreurTextBlock��59      #��[  6=   $��Center=�6c   �� 5;      -   5          
boutonBleu#��[ 5;      $	��100��69   $	��200��6H   $��5,25,5,5q�6w   $��30��6�    ! MaterialDesignLightBackground#���  6�    ! MaterialDesignLightForeground#���  6�   ���	#FF7DB569.��6'  
S'inscrire5=      5>      5@      5A      
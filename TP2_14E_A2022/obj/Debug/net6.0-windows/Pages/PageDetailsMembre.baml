   M S B A M L   `   `   `  ����H  DTP2_14E_A2022, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:TP2_14E_A2022.PagesTP2_14E_A2022.Pages  5      +    %TP2_14E_A2022.Pages.PageDetailsMembre   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      c _MaterialDesignThemes.MahApps, Version=0.2.8.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a_ [MaterialDesignThemes.Wpf, Version=4.8.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5      /local!clr-namespace:TP2_14E_A2022.Pages   5        N� Title$  PageDetailsMembre��5
       � 	Resources 5         errorMessage �� 
TargetType �� Property �� Value  SnackbarSuccessStyle'  !MaterialDesignThemes.Wpf.Snackbar��%�   &	        &	 J     �� 5   
   " ��6%   .�5      ��  � ��
 �  ��6+   5      �� 5   
   "  6-   .�5      ��  � �� �	#B3FFFFFF6+   �� 5       � ��
 ����6+   5      5      .��5      � 
������� � ColumnDefinitions 5   
   �� 5      $
��0.4* �6   �� 5      $
��0.8* �6   �� 5      $
��0.4* �6    � RowDefinitions 5   
   �� 5       $��0.45* �6   �� 5!      $��1* �6   .+�5$   
   �� -   5        $��../Ressources/logo.png��5$      $	��150��60   $	��150��6@   $��0��6O   $��0��6_   $
��Left=�6l   $	��Top=�6�   6�   �� 5%   
   ���	#FF7DB569 J� IsHitTestVisible$ False��6%   $��1��6>   $��0��6K   $��3��6[   $��	0,0,0,-55q�6o   �� 5&   
   $��1��6   $
��Left=�6$   $	��350��6?   $��	32,20,0,0q�6L   $��1��6_   
���   �$	��Top=�6{   $	��342��6�   ���	#FFF7FBF96�   �� 5'   
   -   5        $��Retour��5'      ���	#FF7DB569$��Right=�69   $	��Top=�6U   $��
0,120,25,0q�6m   $��2��6�   $	��133��6�   �� 5)   
   $��2��6    �� Orientation$ Vertical=�6%   $	��Top=�6<   $��0,0,20,0q�6T   .+�5*      �� $ 
Horizontal=�6   $��Right=�62   .+�5+      �� $��15(�6   $��Bonjour��6&   �� 5,      -   5        	 ��Name$	 nomCompletTextBlock��5,        	overLabel#���  69   $��15(�6]   $��Center=�6k   5-      �� 5.      -   5        $��0��5.      $��1��6%   #���  65   $��16(�6Y   $��Right=�6g   Me déconnecter6�   5/      �� 51   
   $��1��6   $��1��6"   $ Vertical=�62   $��Center=�6I   $��Center=�6f   
 K� ZIndex$
 1��6�   $	��208��6�   $	��320��6�   .+�53      �� $ 
Horizontal=�6   $��	0,-60,0,0q�63   .+�54      �� $
��Bold"�6F   $��18(�6X   ���	#FF009019��6   �� *MembreSelectionne.Prenom+6f   �� 55      $�� ��6   �� 56      $
��Bold"�6C   $��18(�6U   ���	#FF009019��6   �� *MembreSelectionne.Nom+6c   57      �� 5:      $��Adresse��6   $
��Bold"�6'   $��16(�69   $��
0,-20,0,10q�6G   �� 5;      -   5        $	 AdresseMessageTxt��5;      $��16(�63   $��Italic$�6A   �� 5<      $��16(�68   ��6   �� *NuméroImmeuble+68   �� 5=      $��16(�6/   ��6   �� *Unité+6/   �� 5>      $��16(�6-   ��6   �� *Rue+6-   �� 5?      $��16(�64   ��6   �� *
CodePostal+64   �� 5@      $��16(�6/   ��6   �� *Ville+6/   �� 5B      $ 
Horizontal=�6   $��0,0,0,0q�62   .+�5C      �� -   5         ��Name$ EstPayeCheckBox��5C      $��16(�64   $��Payé��6B   $��
0,-2,50,20q�6Q    d� 	IsChecked 6e   �� *MembreSelectionne.EstPaye+ �� Mode$ TwoWay=�6�   �� 5D      -   5        $	 FeeAmountTextBlock��5D      $��Italic$�69   $��16(�6L   5E      �� 5G      -   5        $	 LotMessageTxt��5G      $��16(�6/   $��Italic$�6=   $��0,0,0,0q�6Q   5I      5K      5L      
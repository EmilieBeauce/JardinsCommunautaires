   M S B A M L   `   `   `  ����H  DTP2_14E_A2022, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:TP2_14E_A2022.PagesTP2_14E_A2022.Pages  5      _ [MaterialDesignThemes.Wpf, Version=4.8.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aeHclr-namespace:MaterialDesignThemes.Wpf;assembly=MaterialDesignThemes.WpfMaterialDesignThemes.Wpf 5      (    "TP2_14E_A2022.Pages.PageLireOutils   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:TP2_14E_A2022.Pages     5      c _MaterialDesignThemes.MahApps, Version=0.2.8.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5      TwpfHclr-namespace:MaterialDesignThemes.Wpf;assembly=MaterialDesignThemes.Wpf   5        N� Title$  PageLireOutils��5      $	��450��6   $	��800��6+    � 	Resources 5         SnackbarSuccessStyle �� 
TargetType'  !MaterialDesignThemes.Wpf.Snackbar �� Property �� Value��%�   &	        �� 5   
   "  6-   .�5      ��  � �� �	#B3FFFFFF6+   �� 5       � ��
 ����6+   5      5      .��5      � 
�������$��	0,-39,0,0q�6    � ColumnDefinitions 5   
   �� 5      $
��0.4* �6   �� 5      $
��0.8* �6   �� 5      $
��0.4* �6    � RowDefinitions 5   
   �� 5      $��0.45* �6   �� 5      $��1* �6   .+�5   
   �� $��1��6   $��0,0,20,0q�6&    �� Orientation$ Vertical=�68   $	��Top=�6O   $��2��6g   .+�5       �� $ 
Horizontal=�6   $��Right=�62   .+�5!      �� $��15(�6   $��Bonjour��6&   �� 5"      -   5         ��Name$ nomCompletTextBlock��5"        	overLabel#���  69   $��15(�6]   $��Center=�6k   5#      �� 5$      -   5        $��0��5$      $��1��6%   #���  65   $��16(�6Y   $��Right=�6g   Me déconnecter6�   5%      �� 5(   
   $��../Ressources/logo.png��6   $	��150��60   $	��150��6@   $��0��6O   $��Center=�6_   $	��152��6z   $��0,0,50,0q�6�   �� 5)   
   -   5        $	��100��5)      $��Retour��6    ���	#FF7DB569$��0,0,0,23q�6]   $��Center=�6o   $	��156��6�   $��2��6�   $��32��6�   $��Bottom=�6�     5+   
   -   5        	  Name$	 MessageValidation��5+      $��0��62   $��0��6B   $��4��6O   $��Center=�6c   $	��Top=�6�   
   MessageQueue
 5,      3  -MaterialDesignThemes.Wpf.SnackbarMessageQueue  5-      5/      �� 52   
   ���	#FF7DB569 J� IsHitTestVisible$ False��6%   $��1��6>   $��0��6K   $��4��6[   $��	0,0,0,-55q�6o   �� 53   
   -   5         ��Name$ OutilsListBox��53      $��1��6)   $��3��66   $��124,0,124,-47q�54   
   $	��350��6!   
���   �$��1q�55      ���	#FFF7FBF9��58      �� 59      .R�5:      �  5;      �� 5<      $��80 �6/   �� 5=      $	��260 �6/   �� 5>      $��30 �6/   �� 5?      $��50 �6/   �� 5@      $��* �6/   �� 5A      $��* �6/   .+�5E      �� $��0��6$   $��0,6,20,0q�6I   ��64   �� *Nom+��5F      �� 5G   "   " ��6(   .�5H   &   ��  � ��
 �   �6C    �� Triggers 5I   &   �� 5J   *    �� Binding 66   �� *
EstBrise+ �� Value True6S   .a�5K   .   ��  � ��
 �  ��6K   �� 5L   .    � ��$
 Bold"�6K   5M   +   5O   #   5Q      �� 5R      $��1��6%   $ 
Horizontal=�65   $��0,6,20,0q�6N   .+�5S      �� ��6(   �� *Description+��5T   "   �� 5U   &   " ��6,   .�5V   *   ��  � ��
 �   �6G    5W   *   �� 5X   .    6:   �� *
EstBrise+ True6W   .a�5Y   2   ��  � ��
 �  ��6O   5[   /   5]   '   5_      5a      �� 5c      -   5        $��3��5c   !   $��Right=�61     MaterialDesignFlatButton#��[ 5e   !   .��5f      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$	 Eye=�6+   5g      �� 5h      -   5        $��4��5h   !   $��Right=�61   #��[ 5j   	   .��5k        $ Pencil=�6+   5l      �� 5m      -   5        $��5��5m   !   $��Right=�61   #��[ 5o   	   .��5p        $ Delete=�6+   5q      5u      5v      5{      �� 5~   
   -	   5        $��Ajouter��5~      ���	#FF7DB569$��
0,0,300,23q�6P   $��2��6d   $��Right=�6x   $	��134��6�   $��32��6�   $��Bottom=�6�   5�      5�      
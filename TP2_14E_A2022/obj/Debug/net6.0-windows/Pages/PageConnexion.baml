   M S B A M L   `   `   `  ����H  DTP2_14E_A2022, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:TP2_14E_A2022.PagesTP2_14E_A2022.Pages  5      '    !TP2_14E_A2022.Pages.PageConnexion   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:TP2_14E_A2022.Pages     5      c _MaterialDesignThemes.MahApps, Version=0.2.8.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a_ [MaterialDesignThemes.Wpf, Version=4.8.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5        N� Title$  PageConnexion��5
       � 	Resources 5         errorMessage �� 
TargetType �� Property �� Value  SnackbarSuccessStyle'  !MaterialDesignThemes.Wpf.Snackbar��%�   &	        &	 J     �� 5   
   " ��6%   .�5      ��  � ��
 �  ��6+   5      �� 5   
   "  6-   .�5      ��  � �� �	#B3FFFFFF6+   �� 5       � ��
 ����6+   5      5      .��5      � 
������� � ShowGridLines$
 True��6   $��
35,0,110,0q�63   $	��530��6G   $��Center=�6T   .+�5   
     -   5          Name$ MessageValidation��5   "   $��Center=�6=   $	��Top=�6Z   $��0,0,0,20q�6r      MessageQueue 5      3  -MaterialDesignThemes.Wpf.SnackbarMessageQueue  5      5      �� 5   
   $	��Top=�6   $	��310��6-   $��400,140,-20,0q�6:   .+�5      ��  J� IsHitTestVisible$ False��6   $��Adresse courriel��61   $��Center=�6I   $��Center=�6d   $��0,0,0,5q�6�   ���	#FF0090196�   �� 5      -   5        	 ��Name$	 courrielTextBox��5   \   $	��250��6   $��Center=�6$   $��Center=�6?   $��5q�6u   
���   �6�   �� 5       -   5        
 ��Name$
 courrielErreurTextBlock��5       #��[  69   $��0,0,0,5q�6_   �� 5"      $ False��6   $��Mot de passe��61   $��Center=�6E   $��Center=�6`   $��0,0,0,5q�6}   ���	#FF0090196�   G� 5#      -   5         G�Name$ mdpPasswordBox��5#   `   $	��250��6   $��Center=�6(   $��Center=�6C   $��5q�6x   
���   �6�   �� 5$      -   5        $
 mdpErreurTextBlock��5$      #��[  64   $��0,0,0,5q�6Z   �� 5&      -   5          
boutonBleu#��[ 5&      $	��100��69   $	��200��6H   $��5,20,5,5q�6u   ���	#FF7DB569.��6�   Se connecter6�   �� 5'      $��Center=�6   $��
0,20,0,-10q�61   .��6E   Pas de compte ?6V   �� 5)      $��Center=�6   $��16(�61   .��5*      �� -   5          	overLabel#���  5*      
S'inscrire6v   5+      5,      �� 5-   
   $��/Ressources/logo.png��6   $	��200��6.   $	��200��6>   $��89,161,349,147q�6M    J� RenderTransformOrigin$ 0.513,0.425&�6e   5.      5/      
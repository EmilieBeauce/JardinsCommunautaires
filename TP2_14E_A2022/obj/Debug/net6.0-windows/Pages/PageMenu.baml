   M S B A M L   `   `   `  ����H  DTP2_14E_A2022, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:TP2_14E_A2022.PagesTP2_14E_A2022.Pages  5      "    TP2_14E_A2022.Pages.PageMenu   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:TP2_14E_A2022.Pages     5        N� Title$  PageMenu��5	      .��5      � 
������� � ColumnDefinitions 5   
   �� 5      $
��0.4* �6   �� 5      $
��0.8* �6   �� 5      $
��0.4* �6    � RowDefinitions 5   
   �� 5      $��0.45* �6   �� 5      $��1* �6   .+�5   
   �� $��../Ressources/logo.png��6   $	��150��60   $	��150��6@   $��0��6O   $��0��6_   $
��Left=�6l   $	��Top=�6�   6�   �� 5   
   $��2��6    �� Orientation$ Vertical=�6&   $	��top=�6=   $��0,0,20,0q�6V   .+�5      �� $ 
Horizontal=�6   $��Right=�64   .+�5      �� $��15(�6   $��Bonjour��6'   �� 5      -   5         ��Name$ nomCompletTextBlock��5         	overLabel#���   6:   $��15(�6^   $��Center=�6l   5      �� 5      -   5        $��0��5      $��1��6%   #���   65   $��16(�6Y   $��Right=�6g   Me déconnecter6�   5      �� 5!   
   ���	#FF7DB569 J� IsHitTestVisible$ False��6%   $��1��6?   $��0��6L   $��3��6\   �� 5#   
   $��1��6   $��1��6#   $ Vertical=�63   $��Center=�6J   .+�5$      ��   
boutonMenu#��[ 6   $	��300��69   $��50��6E   $��5,5,5,20q�6Q   .��6d   	Jardins6m   �� 5%      -   5        #��[ 5%      $	��300��69   $��50��6E   $��5,5,5,20q�6Q   .��6z   	Matériel6�   �� 5&      -   5         ��Name$ 	btnMembre��5&      #��[ 6)   $	��300��6M   $��50��6Y   $��5,5,5,20q�6e   .��6�   	Membres6�   5'      5)      5*      
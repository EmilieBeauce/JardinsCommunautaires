   M S B A M L   `   `   `  ����H  DTP2_14E_A2022, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:TP2_14E_A2022.PagesTP2_14E_A2022.Pages  5      _ [MaterialDesignThemes.Wpf, Version=4.8.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aeHclr-namespace:MaterialDesignThemes.Wpf;assembly=MaterialDesignThemes.WpfMaterialDesignThemes.Wpf 5	      9!clr-namespace:TP2_14E_A2022.PagesTP2_14E_A2022.Pages  5      %    TP2_14E_A2022.Pages.PageMembres   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      c _MaterialDesignThemes.MahApps, Version=0.2.8.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5      ?	iconPacks-http://metro.mahapps.com/winfx/xaml/iconpacks   5      /local!clr-namespace:TP2_14E_A2022.Pages   5      TwpfHclr-namespace:MaterialDesignThemes.Wpf;assembly=MaterialDesignThemes.Wpf   5	      T PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3f6mah,http://metro.mahapps.com/winfx/xaml/controls  5
      2
converters!clr-namespace:TP2_14E_A2022.Pages  5      -   5          N� Title$  PageMembres��5       � 	Resources 5         errorMessage �� 
TargetType �� Property �� Value  SnackbarSuccessStyle'  !MaterialDesignThemes.Wpf.SnackbarF  @MaterialDesignThemes.Wpf.Converters.BooleanToVisibilityConverter   BooleanToVisibilityConverter0   *TP2_14E_A2022.Pages.BoolToTooltipConverter  BoolToTooltipConverter��%  &	        &	 J     &	 �     &	 �     �� 5   
   " ��6%   .�5      ��  � ��
 �  ��6+   5      �� 5   
   "  6-   .�5      ��  � �� �	#B3FFFFFF6+   �� 5       � ��
 ����6+   5        5   
   66     5   
   6'   5      .��5      � 
������� � ColumnDefinitions 5!   
   �� 5"      $
��0.4* �6   �� 5#      $
��0.8* �6   �� 5$      $
��0.4* �6    � RowDefinitions 5'   
   �� 5(      $��0.45* �6   �� 5)      $��1* �6   .+�5,   
   �� -   5         ��Name$
 Logo��5,      $��../Ressources/logo.png��6   $	��150��6>   $	��150��6N   $��0��6]   $��0��6m   $
��Left=�6z   $	��Top=�6�   6�   �� 5-   
   -   5        $	��100��5-      $��Retour��6    ���	#FF7DB569$��0,0,0,23q�6a   $��Center=�6s   $	��156��6�   $��2��6�   $��32��6�   $��Bottom=�6�     5/   
   -   5          Name$ MessageValidation��5/      $��1��62   $��0��6B   $��Center=�6O   $	��Top=�6l   $��0,0,0,20q�6�   	   MessageQueue	 50      3  -MaterialDesignThemes.Wpf.SnackbarMessageQueue  51      53      �� 55   
   $��2��6   
 �� Orientation$
 Vertical=�6&   $	��top=�6=   $��0,0,20,0q�6V   .+�56      �� $
 
Horizontal=�6   $��Right=�64   .+�57      �� $��15(�6   $��Bonjour��6&   �� 58      -   5         ��Name$ nomCompletTextBlock��58        	overLabel#���  6:   $��15(�6^   $��Center=�6l   59      �� 5:      -   5        $��0��5:      $��1��6%   #���  65   $��16(�6Y   $��Right=�6g   �� 6�   $�Me déconnecter��6�   6�   5;      �� 5=   
   ���	#FF7DB569 J� IsHitTestVisible$ False��6%   $��1��6?   $��0��6L   $��3��6\   �� 5?   
   $��1��6   $
 Vertical=�6"   $	��Top=�69   $��	90,20,0,0q�6Q   $��3��6d   $
��Left=�6x   $	��630��6�   .+�5@      �� -   5         ��Name$ MembresListBox��5@      )  #MaterialDesignThemes.Wpf.HintAssist   
Background
 ���� 
���   �$��1q�5C      $	��554��5D      $	��278��5E      ���	#FFF4F8F3 J� RenderTransformOrigin$ 0.269,0.576&�6e    5G       �� 
TargetType ��Name �� Padding J� SnapsToDevicePixels �� Triggers P� Property P� Value �� 
TargetName��%�  '��       �� 5H      " ��6   .�5I      ��  � ��$ 5q�64   �� 5J       � �� 5K      �� 5L   "   " ��62   .R�5M   &   �� $ Bd��6-   #��z��69   #��z��5N   )   #��z��5O   )   # z��5P   )   ._�5Q   *   �� #��z��6;   #��z��5R   7   # z 5S   7   #��z��5T   7   5U   '    5V   &   P� 5W   *    �@��
IsSelected$
 True��6H   . �5X   .   �� $ Bd��65    � ��
 �����6[   �� 5Y   .   $ Bd��65    � ��
 �   �6\   �� 5Z   .   $ Bd��65    � ��$ 1q�6`   5[   +   P� 5\   *    �@J�IsMouseOver$
 True��6I   . �5]   .   �� $ Bd��65    � ��
 �����6[   5^   +   5`   #   5b      5c      5d      z�5e      V� 5f      .~�5g      �� �� 5h       �� AngleY$ 0Q�6(   �� 5i       �� Angle$ 0.331Q�6*   T� 5j       T� Y$ -0.967Q�6-    T� X$ -0.119Q�68   5k      ��5n      �� 5o      .R�5p      �  5q      �� 5r   "   $��80 �63   �� 5s   "   $	��260 �63   �� 5t   "   $��30 �63   �� 5u   "   $��50 �63   �� 5v   "   $��* �63   �� 5w   "   $��* �63   .+�5z      �� $��0��6(   $��0��65   $��0,6,20,0q�6]   ��6E   �� *Prenom+6]   �� 5{      $��0��6(   $��0��65   $��0,6,20,0q�6]   ��6E   �� *Prenom+6]   �� 5|      $��1��6)   $
 
Horizontal=�69   $��0,6,20,0q�6R   .+�5}   "   �� ��6,   �� *Nom+'  !MaterialDesignThemes.Wpf.PackIcon  5~   "      Kind$ Alert=�6:   ��6G   �� *	EstPaye+ � ToolTip 6f   �� *	EstPaye+ �� 	Converter# [ 5      �� 5�      $��3��6%   $��Right=�65     MaterialDesignFlatButton#��[ 5�   !   ��5�   !   �� *DataContext.DetailsMembre+ �� RelativeSource ��   �� AncestorType"  N���5�   !   �� .��5�   "     $	 Eye=�6/   5�      �� 5�      $��4��6%   $��Right=�65   #��[ 5�   !   ��5�   !   �� *DataContext.ModifierMembre+ �� "  N���5�   !   �� .��5�   "     $ Pencil=�6/   5�      �� 5�      $��5��6%   $��Right=�65   #��[ 5�   !   ��5�   !   �� *DataContext.SupprimerMembre+ �� "  N���5�   !   �� .��5�   "     $ Delete=�6/   5�      5�      5�      5�      5�      �� 5�   
   -   5        ! ��Name$! Ajouter_un_Membre��5�      $��Ajouter��6-   ���	#FF7DB569$��
0,0,300,22q�6z   $��32��6�   $��Bottom=�6�   $��2��6�   $��Right=�6�   $	��133��6�   5�      5�      
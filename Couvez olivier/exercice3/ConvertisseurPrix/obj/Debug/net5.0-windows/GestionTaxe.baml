   M S B A M L   `   `   `  ����L  HConvertisseurPrix, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:ConvertisseurPrixConvertisseurPrix  5   	   #    ConvertisseurPrix.GestionTaxe   5   	   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:ConvertisseurPrix     5   	   -   5          �Name$  GestTaxe��5   	    � Title$ Gestion de la taxe��5   	   $	��300��6$   $	��300��61   ���	#FF2D2D30.��5	      � .+�5
   
   �� $��Label��6   $��Center=�6    $��0,79,0,0q�6=   $	��Top=�6O   $��5��6g   ���	#FF18B9C1$	��280��6�   �� 5   
   -   5         ��Name$ 
lblPrixTtc��5      $��Taux de taxe��6$   $��Center=�6;   $��	0,103,0,0q�6X   $	��Top=�6k   ���	#FFB2AAAA$
��Bold"�6�   �� 5   
   -   5         ��Name$ txtbTaxe��5      $
��Left=�6p   $��
94,148,0,0q�6�    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��120��6�   $��30��6�   ��6$   �� *
TauxTaxe+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5   
   -   5        $ lblTitre��5      $��Reglage du taux de taxe��6"   $��Center=�6D   $��0,22,0,0q�6a   $	��Top=�6s   ���	#FFB2AAAA$��20(�6�   $��Century Gothic)�6�   $
��Bold"�6�   5      5      
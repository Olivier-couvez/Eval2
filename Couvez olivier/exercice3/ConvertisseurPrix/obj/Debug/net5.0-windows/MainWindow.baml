   M S B A M L   `   `   `  ����L  HConvertisseurPrix, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:ConvertisseurPrixConvertisseurPrix  5   	   "    ConvertisseurPrix.MainWindow   5   	   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:ConvertisseurPrix     5   	   -   5          �Name$  ConvertisseurPrix��5   	    � Title$ Convertisseur de prix��5   	   $	��500��6'   $	��500��64   $��Century Gothic)�6@   $��14(�6\   $
��Bold"�6j   ���	#FF2D2D30.��5	      � .+�5
   
   �� -   5         ��Name$ lblTitre��5
      $��Convertisseur TTC <--> HT��6"   $
��Left=�6L   $��
100,24,0,0q�6g   $	��Top=�6{   ���	#FFB2AAAA$��20(�6�   �� 5   
   -   5        $ 
lblPrixTtc��5      $��Prix TTC��6$   $
��Left=�67   $��207,126,0,0q�6R   $	��Top=�6g   ���	#FFB2AAAA6   �� 5   
   -   5        $ lblHT��5      $��Prix HT��6   $
��Left=�61   $��207,233,0,0q�6L   $	��Top=�6a   ���	#FFB2AAAA6y   �� 5   
   -   5         ��Name$ btnTaxe��5      $
��Taxe��6C   $
��Left=�6R   $��385,337,0,0q�6m   $	��Top=�6�   ���	#FF203ADE$��71��6�   ���	#FF707070��6"   �� *CommandeTaxe+6�   �� 5   
   -   5        $ btnSens��5      $
��Sens��6C   $
��Left=�6R   $��385,376,0,0q�6m   $	��Top=�6�   ���	#FF203ADE$��70��6�   ���	#FF707070��6"   �� *CommandeSens+6�   �� 5   
   -   5         ��Name$ txtbTTC��5      $
��Left=�6t   $��177,171,0,0q�6�    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��120��6�   $��30��6�   ��6#   ��  �� Path$ PrixTTC� �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5   
   -   5        $ txtbHT��5      $
��Left=�6q   $��177,281,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��120��6�   $��30��6�   ��6"   �� $ PrixHT�$ TwoWay=�$ PropertyChanged=�6�   �� 5   
   $��Label��6   $��Center=�6    $��0,79,0,0q�6=   $	��Top=�6O   $��5��6g   ���	#FF18B9C1$	��480��6�   �� 5   
   $��Label��6   $��Center=�6    $��	0,223,0,0q�6=   $	��Top=�6P   $��5��6h   ���	#FF18B9C1$	��480��6�   5      5      
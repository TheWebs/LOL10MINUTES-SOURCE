   M S B A M L   `   `   `  ����T  PMahApps.Metro, Version=1.1.2.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	   G CLOL10MINUTES, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:LOL10MINUTESLOL10MINUTES 5   	      LOL10MINUTES.MainWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   	   ,localclr-namespace:LOL10MINUTES     5   	     � Title$  LOL10MINUTES��5	   	   $	��483��6   $	��948��6+    � 
ResizeMode$ CanMinimize=�67    � WindowStartupLocation$ CenterScreen=�6P   (   "MahApps.Metro.Controls.MetroWindow   RightWindowCommands 5
      +   %MahApps.Metro.Controls.WindowCommands  5      .@�5      �� -   5        $��Add HUD��5      6[   �� 5      -   5        $��Refresh��5      6]   �� 5      -   5        $��Game Stats (BETA)��5      6h   �� 5      -   5        $��LoL Path��5      6_   �� 5      -   5        $��Change Cursor��5      6d   5      .��5      � $	��452��6   $	��Top=�6   ���	#FF0C0C0C � ColumnDefinitions 5   
   �� 5      $
��255* �6   �� 5      $
��262* �6   .+�5   
   �� -   5         ��Name$ listBox��5      $
��Left=�6#   $	��432��6>   $��	10,10,0,0q�6K   $	��Top=�6^   $	��366��6v   
������ 6�   �� 5   
   -   5         ��Name$ image��5      $
��Left=�6   $	��344��6:   $��	381,0,0,0q�6G   $	��Top=�6Z   $	��559��6r   $��2��6~    � Cursor$
 Hand��6�   6�   �� 5   
   -   5         ��Name$ button��5      $��Patch!��6!   $
��Left=�62   $��54��6M   $��274,356,0,0q�6Y   $	��Top=�6n   $	��192��6�   $��1��6�   $
 Hand��6�   6�   �� 5   
   -	   5        $ button_Copy��5      $��Restore��6&   $
��Left=�68   $��54��6S   $��381,356,0,0q�6_   $	��Top=�6t   $	��192��6�   $��2��6�   $
 Hand��6�   6�   �� 5   
   -
   5        	 ��Name$	 label��5      $��Done!��6   $��1��6/   $
��Left=�6?   $��66��6Z   $��115,349,0,0q�6f   $	��Top=�6{   $	��155��6�   $��Century Gothic)�6�   $��48(�6�   5      5       
   M S B A M L   `   `   `  ����@  <tema1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:tema1tema1  5   	       tema1.Divertisment   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:tema1     5   	     � Title$  Divertisment��5   	   $	��450��6   $	��800��6+      	dictionar � DataContext# [  5	   
   ��5
      �� 5   
    �� ImageSource$ imagini/background.jpg��6    j� Stretch$
 Fill=�6:   .��5      �  J� RenderTransformOrigin$ 0.496,0.477&�6   .+�5   
   � -   5        $��reguli_grid��5      $
��Left=�5      $	��152��6*   $��	25,17,0,0q�5      $	��Top=�6"   $	��755��6:   .+�5      �� $��Modulul de divertisment��6   $��Center=�5      $��147,8,169,0q�61   $	��Top=�5      $	��439��6,   $��51��68   $��Center=�5      $��Center=�5      $��25(�5      $��Calibri)�6   $
��Bold"�64   �� 5      $
��Left=�6   $��	29,51,0,0q�5      $
��Wrap=�5      $����Reguli: In acest modul vor fi 5 intrebari compuse fie din explicatia, fie imaginea unui cuvant. Va trebui sa ghicesti cuvantul asociat. Dupa fiecare cuvant vei da click pe butonul -Next- pentru a trece la urmatorul cuvant. Rezultatul jocului va fi afisat la sfarsit, dar vei primi si o validare a fiecarui raspuns pe parcurs.��5      $	��Top=�5      $	��106��5      $	��672��6%   $��17(�5      $��Gabriola)�6'   $��Medium"�6=   $ 0.5,0.5&�6Q   5      �� 5    
   -   5        $��start��5!      $��Start��5       $
��Left=�5"      $��340,224,0,0q�5#      $	��Top=�6&   $��75��5$      $��25(�5%      $ 1.008,0.917&�6   $��60��6C   ��5&      �� 5'       �� 
TargetType" ��6   .�5(      ��  �� Property � �� �� Value$ Gabriola)�6?   �� 5)       � ��
 �����63   �� 5*       �@�Cursor$
 Hand��6/    �� Triggers 5+      P� 5,      	 P� Property	 �@J�IsMouseOver
 P� Value
 . . �5-      ��  � ��
 �����6;   5.      50      ��52      �� 53       �� 
TargetType" ��6"   .R�54      �� $��75��6   $��40��6(    �� CornerRadius$ 10��55   !   #��z��56   !   ._�57      �� $��Center=�6+   $��Center=�58   /   59      5:      5<      �� 5=   
   -   5        $
��next��5>      $
��Next��5=      $
��Left=�6    $��667,323,0,0q�5?      $	��Top=�6&   $��75��5@      $��25(�6   $y�Hidden=�5A      ��5C      �� 5D      " ��6   .�5E      ��  � ��$ Gabriola)�6?   �� 5F       � ��
 �����63   �� 5G       �@�Cursor$
 Hand��6/    5H      P� 5I      	 �@J�IsMouseOver
 . . �5J      ��  � ��
 �����6;   5K      5M      ��5O      �� 5P      " ��6"   .R�5Q      �� $��75��6   $��40��6(   $ 10��5R   !   #��z��5S   !   ._�5T      �� $��Center=�6+   $��Center=�5U   /   5V      5W      5Y      � 5Z   
   $
��Left=�6   $	��403��6*   $��20,1,0,0q�67   $	��Top=�6I   $	��760��6a   .+�5[      �� -   5        $��	descriere��5\      $��	Descriere��5[      $
��Left=�5]      $��
108,70,0,0q�5^      $	��Top=�6(   $ -0.463,-4.66&�5_      $	��165��69   $	��505��5`      $y�Hidden=�5a      $
��Wrap=�5b      $��23(�5c      $��Gabriola)�6"   $��Medium"�68   �� 5e      -   5        $��imagine��5f      $
��Left=�5e      $y�Hidden=�5g      $	��250��5h      $��
255,51,0,0q�6!   $	��Top=�5i      $	��322��6,   �� 5k      -   5        $��raspuns��5o      $
��Left=�5k      $y�Hidden=�5l      $��39��5m      $��235,321,0,0q�6"    �� TextWrapping$
 Wrap=�5n      $	��Top=�5p      $	��330��6.   �� 5q      -   5        $
��rasp��5s      $��Raspuns:��5q      $y�Hidden=�5r      $
��Left=�5t      $��130,316,0,0q�5u      $	��Top=�6)   $��87��5v      $��43��6   
�������$��25(�5x      $��Gabriola)�6"   $��Medium"�68   5|      5      5�      
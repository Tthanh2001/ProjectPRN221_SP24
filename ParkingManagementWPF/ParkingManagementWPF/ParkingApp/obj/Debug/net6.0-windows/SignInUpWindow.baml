   M S B A M L   `   `   `  ����E  AParkingApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:ParkingApp
ParkingApp  5   	       ParkingApp.SignInUpWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:ParkingApp     5   	     � Title$  ParkingManagement��5   	   $	��450��6#   $	��800��60    � 
ResizeMode$ NoResize=�5	   	    � WindowStartupLocation$ CenterScreen=�5
   	    � 	Resources 5         
MenuButton �� 
TargetType �� Property �� Value �� 
TargetType �� Triggers	 P� Property
 P� Value��%�  &	        �� 5   
   " ��6#   .�5      ��  � ��$ 50��6'   �� 5       � ��$	 400��6&   �� 5       �@�Cursor$
 Hand��6'   �� 5       � �� �#4651486+   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   ._�5      �� $��Center=�6/   $��Center=�6L   5      5      5       5      P� 5      	 �@J�IsMouseOver$

 True��61   . �5      ��  � �� �#6a746c63   5      5       5!      .��5#      � -   5        ��5%   
   �� 5&       �� ImageSource$* $Assets/Picture/parkingBackground.png��6    j� Stretch$ UniformToFill=�6L   .+�5)   
   ��  �� Orientation$ Vertical=�6   .+�5*      �� $ 
Horizontal=�6   .+�5+      �� -   5         ��Name$ btnLoginPage��5+      $��Login��6/   #��[  6?   $��22(�6c   
�������5,      �� 5-      -   5        $ btnRegisterPage��5-      $��Register��62   #��[  6E   $��22(�6i   
�������5.      5/       � 51      -   5          �Name$
 Main��51        � NavigationUIVisibility$ Hidden=�6"   53      55      56      
   M S B A M L   `   `   `  ����J  FMasterServer.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:MasterServer.UI.ViewsMasterServer.UI.Views  5      G(clr-namespace:MasterServer.UI.ViewModelsMasterServer.UI.ViewModels  5	          MasterServer.UI.Views.Log   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      R NMvvmDialogs, Version=9.1.0.0, Culture=neutral, PublicKeyToken=3d3b9708589bc73e8md/https://github.com/fantasticfiasco/mvvm-dialogs  5      T PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3f6mah,http://metro.mahapps.com/winfx/xaml/controls  5      /local#clr-namespace:MasterServer.UI.Views  5      1vm(clr-namespace:MasterServer.UI.ViewModels  5	      -   5        (  "MahApps.Metro.Controls.MetroWindow   Name$  
LogsWindow��5      $  MvvmDialogs.DialogServiceViews   IsRegistered .  � Title$ Server Logs��5      $	��450��5      $	��800��5       � 	Resources 5       �� Source�� 5   
   $, &../MasterServerResourceDictionary.xaml?�6   %    ��5      �� 5   
    �� 
TargetType" �6   .�5      ��  �� Property � �� �� Value
 �����6+   5      .��5      �  � RowDefinitions 5   
   �� 5      $��60 �6   �� 5      $��5* �6   �� 5      $��60 �6   .+�5   
   (  "MahApps.Metro.Controls.SplitButton  $
��15 5q�6   $
��10 0q�5       $
��Left=�5!      $��0��5$      +  %MahApps.Metro.Controls.ControlsHelper	   CornerRadius$	 5��5%      $��Center=�5&      ���#005FFF
�������$��0q�5)      
   
ArrowBrush

 �������5"      �� *LogList.Keys+ �� SelectedItem 5#      �� *ShowSelectedItem+5*      �� 5+   
   $��15 15q�6   $��1��5,      $	 5��5.      2  ,MahApps.Metro.Controls.HeaderedControlHelper   HeaderBackground �#DDDDDD   ContentCharacterCasing$ Normal=�50         HeaderFontWeight$
 Bold"�51      
���������5-      �� *ShowSelectedItem+.��53      �� .��54      �� $
��15 0q�55      
���������54      �� *SelectedServerLogText+56      57      58      �� 59   
   $��0��6   $��2��5:      $��Right=�5;      $��Center=�5<      $��Close��5=      $
��20 0q�5>      $
��15 0q�5?      $	 5��5@      $ Normal=�5A      $��Normal"�5B      
����������#555555$��1q�5E      ��5F      �� *CloseWindowCommand+��5G      ��  �� ElementName$ 
LogsWindow��5H      5I      
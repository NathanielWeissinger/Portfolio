   M S B A M L   `   `   `  ����J  FMasterServer.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:MasterServer.UI.ViewModelsMasterServer.UI.ViewModels  5      =#clr-namespace:MasterServer.UI.ViewsMasterServer.UI.Views  5	      O,clr-namespace:MasterServer.UI.CustomControlsMasterServer.UI.CustomControls  5
      "    MasterServer.UI.Views.Server   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      R NMvvmDialogs, Version=9.1.0.0, Culture=neutral, PublicKeyToken=3d3b9708589bc73e8md/https://github.com/fantasticfiasco/mvvm-dialogs  5      T PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3f6mah,http://metro.mahapps.com/winfx/xaml/controls  5      1vm(clr-namespace:MasterServer.UI.ViewModels  5      /local#clr-namespace:MasterServer.UI.Views  5	      9custom,clr-namespace:MasterServer.UI.CustomControls  5
      -   5        (  "MahApps.Metro.Controls.MetroWindow   Name$  ServerWindow��5      $  MvvmDialogs.DialogServiceViews   IsRegistered . $	��450��5      $	��800��5       � Title 5      �� *
ServerName+ � 	Resources 5       �� Source�� 5   
   $, &../MasterServerResourceDictionary.xaml?�6   %    ��5      �� 5   
    �� 
TargetType" �6   .�5      ��  �� Property � �� �� Value
 �����6+   5      .��5      �  � ColumnDefinitions 5   
   �� 5      �� 5      �� 5      	 � RowDefinitions	 5    
   �� 5!      �� 5"      �� 5#      $��50 �6   .+�5&   
   � $��0��6   $��10,20,20,10q�5'       5(      �� 5)      	 5+      �� 5,      �� 5-      �� 5.      �� 5/      .+�52      =   7MasterServer.UI.CustomControls.DisplayNumberInfoControl  $��0��6.   
   DisplayLabelText$
 Lobbies:��53   .      DisplayInfoNumber 54   .   �� *DataContext.LobbyCount+ �� ElementName$ ServerWindow��  55      $��1��6.   $
 Active Players:��56   .    57   .   �� *DataContext.ActivePlayerCount+$ ServerWindow��=   7MasterServer.UI.CustomControls.DisplayStringInfoControl  58      $��2��6.      DisplayLabelText$ Time Up:��59   .      DisplayInfoText 5:   .   �� *DataContext.TimeUp+$ ServerWindow��  5;      $��3��6.   $ Created:��5<   .    5=   .   �� *DataContext.CreatedOn+$ ServerWindow��5>      �� 5@   
   $��1��6   $��0��5A      $��10,20,20,10q�5B      $��Lobbies��5C      +  %MahApps.Metro.Controls.ControlsHelper   ContentCharacterCasing$ Normal=�5D      2  ,MahApps.Metro.Controls.HeaderedControlHelper   HeaderBackground �#007FFF   HeaderFontWeight$
 Bold"�5F         CornerRadius$ 5��5G      
�������.��5I      �� ��6   �� *LobbiesList+5J      �� 5L   
   $��2��6   $��0��5M      $��10,20,20,10q�5N      $��Players��5O      $ Normal=�5P       �#007FFF$
 Bold"�5R      $ 5��5S      
�������.��5U      �� ��6   �� *PlayersList+5V      �� 5X   
   $��1��6   $��0��5Y      $��3��5Z      $
��Logs��5[      $
��15,0q�5\      $ Normal=�5]       �#007FFF$
 Bold"�5_      $ 5��5`      
�������.��5b      �� $	��Top=�5c      $��Visible=�5d      ��. ��5b      �� *
ServerLogs+��5f      �� 5g      .R�5h      � .+�5i      �� ��6(   �� *	TimeStamp+�� 5j      $	�� - ��6(   �� 5k      ��6(   �� *
LogMessage+5l      5m      5o      5p      �� 5r   
   $��2��6   $��3��5s      $��Close��5t      $��Bottom=�5u      $��Right=�5v      $
��25,5q�5w      $��15,10q�5x      
���   �$��1q�5z      $ 5��5{      $ Normal=�5|      ��5}      �� *CloseWindowCommand+��5~      �� $ ServerWindow��5      5�      
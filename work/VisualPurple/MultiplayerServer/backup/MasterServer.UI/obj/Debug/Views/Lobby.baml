   M S B A M L   `   `   `  ����J  FMasterServer.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:MasterServer.UI.ViewModelsMasterServer.UI.ViewModels  5      O,clr-namespace:MasterServer.UI.CustomControlsMasterServer.UI.CustomControls  5	      =#clr-namespace:MasterServer.UI.ViewsMasterServer.UI.Views  5
      !    MasterServer.UI.Views.Lobby   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      R NMvvmDialogs, Version=9.1.0.0, Culture=neutral, PublicKeyToken=3d3b9708589bc73e8md/https://github.com/fantasticfiasco/mvvm-dialogs  5      T PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3f6mah,http://metro.mahapps.com/winfx/xaml/controls  5      1vm(clr-namespace:MasterServer.UI.ViewModels  5      9custom,clr-namespace:MasterServer.UI.CustomControls  5	      /local#clr-namespace:MasterServer.UI.Views  5
      -   5        (  "MahApps.Metro.Controls.MetroWindow   Name$  LobbyWindow��5      $  MvvmDialogs.DialogServiceViews   IsRegistered . $	��450��5      $	��800��5       � Title 5      �� *	LobbyName+ � 	Resources 5       �� Source�� 5   
   $, &../MasterServerResourceDictionary.xaml?�6   %    ��5      �� 5   
    �� 
TargetType" �6   .�5      ��  �� Property � �� �� Value
 �����6+   5      .��5      �  � ColumnDefinitions 5   
   �� 5      �� 5      	 � RowDefinitions	 5    
   �� 5!      �� 5"      �� 5#      $��50 �6   .+�5%   
   � $��0��6   $��10,20,50,20q�5&       5'      �� 5(      	 5*      �� 5+      �� 5,      �� 5-      �� 5.      �� 5/      .+�52      =   7MasterServer.UI.CustomControls.DisplayStringInfoControl  
   DisplayLabelText$
 Server:��6.   $��0��54   .   $��0��55   .      DisplayInfoText 53   .   �� *DataContext.ServerName+ �� ElementName$ LobbyWindow��55   .   =   7MasterServer.UI.CustomControls.DisplayNumberInfoControl  56         DisplayLabelText$ Active Players:��6.   $��0��58   .   $��1��59   .      DisplayInfoNumber 57   .   �� *DataContext.ActivePlayers+$ LobbyWindow��59   .     5:      $
 Facilitator:��6.   $��0��5<   .   $��2��5=   .    5;   .   �� *DataContext.FacilitatorName+$ LobbyWindow��5=   .     5>      $
 Time Up:��6.   $��0��5@   .   $��3��5A   .    5?   .   �� *DataContext.TimeUp+$ LobbyWindow��5A   .     5B      $
 Created:��6.   $��0��5D   .   $��4��5E   .    5C   .   �� *DataContext.CreatedOn+$ LobbyWindow��5E   .   5F      �� 5H   
   $��1��6   $��0��5I      $��10,20,20,10q�5J      $��Players��5K      
�������+  %MahApps.Metro.Controls.ControlsHelper   ContentCharacterCasing$ Normal=�5M      2  ,MahApps.Metro.Controls.HeaderedControlHelper   HeaderBackground �#007FFF   HeaderFontWeight$
 Bold"�5O         CornerRadius$ 5��5P      .��5Q      �� $	��Top=�5R      $��Visible=�5S      ��. ��5Q      �� *ActivePlayersInLobby+��5U      �� 5V      .R�5W      �  5X      �� 5Y   "   $��3* �63   �� 5Z   "   $��* �63   	 5\      �� 5]   "   .+�5_      �� $��0��6(   $��0��5`   (   $
��Left=�5a   (   $��Center=�5b   (   ��5c   (   �� *Value+5k      5l      5n      5o      �� 5q   
   $��1��6   $��0��5r      $��2��5s      $
��Logs��5t      $
��15 0q�5u      
�������$ Normal=�5w       �#007FFF$
 Bold"�5y      $ 5��5z      .��5{      �� $	��Top=�5|      $��Visible=�5}      ��. ��5{      �� *	LobbyLogs+��5      �� 5�      .R�5�      � .+�5�      �� ��6(   �� *	TimeStamp+�� 5�      $	�� - ��6(   �� 5�      ��6(   �� *
LogMessage+5�      5�      5�      5�      �� 5�   
   $��1��6   $��3��5�      $��Close��5�      $��Bottom=�5�      $��Right=�5�      $
��25,5q�5�      $��15,10q�5�      $ Normal=�5�      $��Normal"�5�      ��5�      �� *CloseWindowCommand+��5�      �� $ LobbyWindow��5�      5�      
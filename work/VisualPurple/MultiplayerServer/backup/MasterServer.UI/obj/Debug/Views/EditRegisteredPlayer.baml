   M S B A M L   `   `   `  ����J  FMasterServer.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:MasterServer.UI.ViewModelsMasterServer.UI.ViewModels  5      =#clr-namespace:MasterServer.UI.ViewsMasterServer.UI.Views  5	      G(clr-namespace:MasterServer.UI.ConvertersMasterServer.UI.Converters  5
      0    *MasterServer.UI.Views.EditRegisteredPlayer   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      R NMvvmDialogs, Version=9.1.0.0, Culture=neutral, PublicKeyToken=3d3b9708589bc73e8md/https://github.com/fantasticfiasco/mvvm-dialogs  5      T PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3f6mah,http://metro.mahapps.com/winfx/xaml/controls  5      1vm(clr-namespace:MasterServer.UI.ViewModels  5      /local#clr-namespace:MasterServer.UI.Views  5	      9
converters(clr-namespace:MasterServer.UI.Converters  5
      -   5        (  "MahApps.Metro.Controls.MetroWindow   Name$  EditPlayerWindow��5      $  MvvmDialogs.DialogServiceViews   IsRegistered .  � Title$ Edit Player��5      $	��800��5      $	��500��5       � 	Resources 5       �� MergedDictionaries �� Source5   /MasterServer.UI.Converters.IntToStringConverter   IntToStringConverter�� 5   
    5      �� 5      $, &../MasterServerResourceDictionary.xaml?�6%   %   &	          5      6.   5      ��5      �� 5   
    �� 
TargetType" �6   .�5      ��  �� Property � �� �� Value
 �����6+   5      .��5!      � $��10q�6   	 � ColumnDefinitions	 5"   
   �� 5#      $��3* �6   �� 5$      $��2* �6   �� 5%      
 � RowDefinitions
 5'   
   �� 5(      $��2* �6   �� 5)      $��3* �6   �� 5*      $��2* �6   �� 5+      $��3* �6   �� 5,      $��2* �6   �� 5-      $��3* �6   �� 5.      $��2* �6   �� 5/      $��3* �6   �� 50      $��2* �6   �� 51      $��3* �6   �� 52      $��2* �6   �� 53      $��3* �6   �� 54      $��2* �6   �� 55      $��3* �6   �� 56      $��2* �6   �� 57      $��3* �6   �� 58      $��3* �6   �� 59      $��3* �6   �� 5:      $��60 �6   .+�5=   
   �� $��0��6   $��0��5>      $
��Name��5?      $��Bottom=�5@      �� 5A   
   -   5         ��Name$ 	NameEntry��5D      $��0��5A      $��1��5B      $��2��5C      $��Center=�5E      +  %MahApps.Metro.Controls.ControlsHelper   CornerRadius$ 5��5F      
�������$��2q�5H      ��5I      �� *PlayerFullName+�� 5K   
   $��0��6   $��2��5L      $��	Player ID��5M      $��Bottom=�5N      �� 5O   
   $��0��6   $��3��5P      
�������$��2q�5R      $��Center=�5S       �� CornerRadius$ 5��5T      
�������$
��auto��5V      $��27.95��5W      ._�5X      �� -   5         ��Name$ PlayerIDEntry��5X      $��Center=�5Y       �� TextAlignment$
 Left=�5Z      $��5 0 0 0q�5[      ��5\      �� *
PlayerID+5]      �� 5^   
   -   5         ��Name$ logsBtn��5d      $��1��5^      $��3��5_      $��Right=�5`      $
��Logs��5a      $
��30 0q�5b      $��40��5c      
�������
�������   ContentCharacterCasing$ Normal=�5i      $��16(�5j      $��Normal"�5k      ��5e      �� *PlayerLogsCommand+��5f      �� *
PlayerID+ �� 	Converter# [  5k      �� 5n   
   $��0��6   $��4��5o      $��Gender��5p      $��Bottom=�5q      �� 5r   
   -   5        $ GenderEntry��5t      $��0��5r      $��5��5s      $��Center=�5u      $ 5��5v      
�������$��2q�5x      ��5y      �� *PlayerGender+�� 5{   
   $��0��6   $��6��5|      $	��SSN��5}      $��Bottom=�5~      �� 5   
   -   5        $ SSNEntry��5�      $��0��5      $��7��5�      $��Center=�5�      $ 5��5�      
�������$��2q�5�      ��5�      �� *	PlayerSSN+�� 5�   
   $��0��6   $��8��5�      $��Password��5�      $��Bottom=�5�      �� 5�   
   -   5        $ PasswordEntry��5�      $��0��5�      $��9��5�      $��Center=�5�      $ 5��5�      
�������$��2q�5�      ��5�      �� *PlayerPassword+�� 5�   
   $��0��6   $��10��5�      $
��Unit��5�      $��Bottom=�5�      (  "MahApps.Metro.Controls.SplitButton  5�   
   $��0��6   $��11��5�      $��Center=�5�      $
��Left=�5�      $ 5��5�      ��5�      �� *
UnitList+ �� SelectedItem 5�      �� *
PlayerUnit+�� 5�   
   $��0��6   $��12��5�      $
��Rank��5�      $��Bottom=�5�        5�   
   $��0��6   $��13��5�      $��Center=�5�      $
��Left=�5�      $ 5��5�      ��5�      �� *
RankList+ 5�      �� *
PlayerRank+�� 5�   
   $��0��6   $��14��5�      $��Job Code��5�      $��Bottom=�5�        5�   
   $��0��6   $��15��5�      $��Center=�5�      $
��Left=�5�      $ 5��5�      ��5�      �� *	JobList+ 5�      �� *PlayerJobCode+�� 5�   
   $��0��6   $��16��5�      $��Status��5�      $
��Left=�5�      $��Center=�5�      )  #MahApps.Metro.Controls.ToggleSwitch  5�   
   $��0��6   $��16��5�      $��Right=�5�      $�� ��5�         ContentDirection$ LeftToRight=�5�         IsOn 5�      �� *PlayerStatus+�� 5�   
   $��0��6   $��17��5�      $��Facilitator��5�      $
��Left=�5�      $��Center=�5�        5�   
   $��0��6   $��17��5�      $��Right=�5�      $�� ��5�      $ LeftToRight=�5�       5�      �� *PlayerIsFacilitator+�� 5�   
   $��0��6   $��18��5�      $��Delete��5�      
���  ��
�������$
��Left=�5�      $��40��5�      $
��30,0q�5�      $ 5��5�      $ Normal=�5�      $��16(�5�      $��Normal"�5�      ��5�      �� *DeletePlayerCommand+��5�      ��  �� ElementName$ EditPlayerWindow��5�      �� 5�   
   $��0��6   $��18��5�      $��Reset��5�      
�������
�������$��Right=�5�      $��40��5�      $
��30,0q�5�      $ 5��5�      $ Normal=�5�      $��16(�5�      $��Normal"�5�      ��5�      �� *ResetPlayerCommand+5�      �� 5�   
    �� Orientation$ 
Horizontal=�6   $��1��5�      $��2��5�      $��18��5�      $��Right=�5�      .+�5�      �� $
��Save��6   ���#007FFF
�������$
��Left=�5�      $
��30,0q�5�      $��40��5�      $ 5��5�      $ Normal=�5�      $��16(�5�      $��Normal"�5�      $
��15,0q�5�      ��5�      �� *SavePlayerCommand+5�      �� 5�      $��Close��6   
�������
���   �$��1q�5     $
��25,0q�5     $��40��5     $ 5��5     $ Normal=�5     $��16(�5     $��Normal"�5     ��5	     �� *CloseWindowCommand+��5
     �� $ EditPlayerWindow��5     5     5     
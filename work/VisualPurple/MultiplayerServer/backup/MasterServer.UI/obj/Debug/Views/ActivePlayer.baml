   M S B A M L   `   `   `  ����J  FMasterServer.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:MasterServer.UI.ViewsMasterServer.UI.Views  5      O,clr-namespace:MasterServer.UI.CustomControlsMasterServer.UI.CustomControls  5	      G(clr-namespace:MasterServer.UI.ViewModelsMasterServer.UI.ViewModels  5
      G(clr-namespace:MasterServer.UI.ConvertersMasterServer.UI.Converters  5      (    "MasterServer.UI.Views.ActivePlayer   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      R NMvvmDialogs, Version=9.1.0.0, Culture=neutral, PublicKeyToken=3d3b9708589bc73e8md/https://github.com/fantasticfiasco/mvvm-dialogs  5      T PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3f6mah,http://metro.mahapps.com/winfx/xaml/controls  5      /local#clr-namespace:MasterServer.UI.Views  5      9custom,clr-namespace:MasterServer.UI.CustomControls  5	      1vm(clr-namespace:MasterServer.UI.ViewModels  5
      9
converters(clr-namespace:MasterServer.UI.Converters  5      -   5        (   "MasterServer.UI.Views.CustomWindow   Name$  ActivePlayerWindow��5      $  MvvmDialogs.DialogServiceViews   IsRegistered . $	��300��5      $	��400��5      
�������   ClientIDText 5      �� *
ClientID+ � Title 5      �� *
PlayerName+ � 	Resources 5       �� MergedDictionaries �� Source6   0MasterServer.UI.Converters.ToUpperValueConverter   ToUpperValueConverter�� 5   
    5      �� 5      $, &../MasterServerResourceDictionary.xaml?�6%   %   &	          5      6/   5      (  "MahApps.Metro.Controls.MetroWindow   TitleTemplate 5      �� 5   
   .R�5      � $��Stretch=�6    � ColumnDefinitions 5       �� 5!      �� 5"      .+�5$      �� $��0��6   $
��Left=�5&      $��Center=�5'       % !MahApps.Fonts.Family.Window.Title#���  5(       " MahApps.Font.Size.Window.Title#���  5)      	 �� Padding$		 5 0q�5*      $��0 0 0 2q�5+      ��5%      �� 
 �� RelativeSource
 ��  �� AncestorType"   �� Path$ Title� �� 	Converter# [  5+      �� 5,      
���   �$��1q�5-       �� CornerRadius$ 5��5.      $��1��5/      $��Center=�50      $��Right=�51      $��20��52      ._�53      �� $��Center=�54       $��Center=�55       #���  56       #���  57       $
	 15 5q�58       $��0 0 0 2q�59       
���   ���53       �� 
 �� "  $ ClientIDText�5:       5;      5<      5=      .��5?      �  5@   
    �� 
TargetType �� Property �� Value��%V   '��       �� 5A      " ��6   .�5B      ��  � ��$ 14(�5C      5D      5E       5F   
   �� 5G       � RowDefinitions 5I   
   �� 5J      �� 5K      $��50 �6   .+�5N   
   � $��0��6   $��0��5O      $
��20,0q�5P       5Q      �� 5R      �� 5S       5U      �� 5V      �� 5W      �� 5X      �� 5Y      �� 5Z      .+�5]      �� $��0��6   $��0��5^      $��
Player ID:��5_      $��Center=�5`      $
��Left=�5a      �� 5b      -   5         ��Name$ PlayerID��5d      $��0��5b      $��1��5c      $��Center=�5f      $��Right=�5g      ��5e      �� *
PlayerID+5g      �� 5i      $��1��6   $��0��5j      $��Current Server:��5k      $��Center=�5l      $
��Left=�5m      �� 5n      -   5        $ CurrentServer��5p      $��1��5n      $��1��5o      $��Center=�5r      $��Right=�5s      ��5q      �� *CurrentServer+5s      �� 5u      $��2��6   $��0��5v      $��Current Lobby:��5w      $��Center=�5x      $
��Left=�5y      �� 5z      -   5        $ CurrentLobby��5|      $��2��5z      $��1��5{      $��Center=�5~      $��Right=�5      ��5}      �� *CurrentLobby+5      �� 5�      $��3��6   $��0��5�      $��Status:��5�      $��Center=�5�      $
��Left=�5�      9   3MasterServer.UI.CustomControls.StatusDisplayControl  5�      $��3��6*   $��1��5�   *   $��Right=�5�   *      ActiveStatus 5�   *   �� *Status+�� 5�      $��4��6   $��0��5�      $��Facilitator?:��5�      $��Center=�5�      $
��Left=�5�      D   >MasterServer.UI.CustomControls.FacilitatorDisplayWidgetControl  5�      $��4��65   $��1��5�   *   $��Right=�5�   *      FacilitatorStatus 5�   *   �� *IsFacilitator+5�      �� 5�   
   $��1��6   $��0��5�       �� Orientation$ 
Horizontal=�5�      $��Right=�5�      .+�5�      �� -   5         ��Name$ 	curLogBtn��5�      $��Current Log��5�      $
��5,10q�5�      $
��10,0q�5�      
�������
�������
�������+  %MahApps.Metro.Controls.ControlsHelper   ContentCharacterCasing$ Normal=�5�      $��Normal"�5�      $��14(�5�      ��5�      �� *ShowPlayerLogCommand+��5�      �� *
PlayerID+�� 5�      -   5        $ editBtn��5�      $
��Edit��5�      $
��5,10q�5�      $
��25,0q�5�      ���#007FFF���#007FFF
�������$ Normal=�5�      $��Normal"�5�      $��14(�5�      ��5�      �� *ShowEditPlayerCommand+��5�      �� *
PlayerID+�� 5�      -   5        $ closeBtn��5�      $��Close��5�      $
��5,10q�5�      $
��25,0q�5�      
���   �$ Normal=�5�      $��Normal"�5�      $��14(�5�      ��5�      �� *CloseWindowCommand+��5�      ��  �� ElementName$ ActivePlayerWindow��5�      5�      5�      
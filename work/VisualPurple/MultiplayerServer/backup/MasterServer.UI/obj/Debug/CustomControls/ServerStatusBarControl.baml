   M S B A M L   `   `   `  ����J  FMasterServer.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:MasterServer.UI.ViewModelsMasterServer.UI.ViewModels  5      O,clr-namespace:MasterServer.UI.CustomControlsMasterServer.UI.CustomControls  5      O,clr-namespace:MasterServer.UI.CustomControlsMasterServer.UI.CustomControls  5	      ;    5MasterServer.UI.CustomControls.ServerStatusBarControl   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7vm(clr-namespace:MasterServer.UI.ViewModels     5      >local,clr-namespace:MasterServer.UI.CustomControls     5      T PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3f6mah,http://metro.mahapps.com/winfx/xaml/controls  5      9custom,clr-namespace:MasterServer.UI.CustomControls  5	      .��5      �   � RowDefinitions  5   
   �� 5      $
��40px �6   �� 5      $
��40px �6    � ColumnDefinitions 5   
   �� 5      �� 5      .+�5   
   �� $
��10,5q�6   $��0��5      $��0��5      $��Stretch=�5      
�������+  %MahApps.Metro.Controls.ControlsHelper   CornerRadius$ 5��5      .��5      � 
������  5      �� 5       �� 5!      .+�5#      �� $
��Left=�6   $��Center=�5$      $��10,0,0,0q�5%      $��Connections��5&      $��14(�5'      $��0��5(      9   3MasterServer.UI.CustomControls.NumberDisplayControl  5)      $��1��6.   $��Right=�5*   .      DisplayNumber 5+   .   �� * ServerStatus.ActiveConnections+5,      5-      �� 5/   
   $
��10,5q�6   $��0��50      $��1��51      $��Stretch=�52      
�������$ 5��54      .��55      � 
������  56      �� 57      $��* �6'   �� 58      $��* �6'   .+�5:      �� $
��Left=�6   $��Center=�5;      $��10,0,0,0q�5<      $��Lobbies��5=      $��14(�5>      $��0��5?        5@      $��1��6.   $��Right=�5A   .    5B   .   �� *ServerStatus.ActiveLobbies+5C      5D      �� 5F   
   $
��10,5q�6   $��1��5G      $��0��5H      $��Stretch=�5I      
�������$ 5��5K      .��5L      � 
������  5M      �� 5N      $��* �6'   �� 5O      $��* �6'   .+�5Q      �� $
��Left=�6   $��Center=�5R      $��10,0,0,0q�5S      $��Servers��5T      $��14(�5U      $��0��5V        5W      $��1��6.   $��Right=�5X   .    5Y   .   �� *ServerStatus.ActiveServers+5Z      5[      �� 5]   
   $
��10,5q�6   $��1��5^      $��1��5_      $��Stretch=�5`      
�������$ 5��5b      .��5c      � 
������  5d      �� 5e      $��* �6'   �� 5f      $��* �6'   .+�5h      �� $
��Left=�6   $��Center=�5i      $��10,0,0,0q�5j      $��Active Players��5k      $��14(�5l      $��0��5m        5n      $��1��6.   $��Right=�5o   .    5p   .   �� *ServerStatus.ActivePlayers+5q      5r      5s      5t      
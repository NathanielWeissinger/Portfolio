   M S B A M L   `   `   `  ����J  FMasterServer.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:MasterServer.UI.ViewModelsMasterServer.UI.ViewModels  5      O,clr-namespace:MasterServer.UI.CustomControlsMasterServer.UI.CustomControls  5	      =#clr-namespace:MasterServer.UI.ViewsMasterServer.UI.Views  5
      -    'MasterServer.UI.Views.RegisteredPlayers   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      R NMvvmDialogs, Version=9.1.0.0, Culture=neutral, PublicKeyToken=3d3b9708589bc73e8md/https://github.com/fantasticfiasco/mvvm-dialogs  5      T PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3f6mah,http://metro.mahapps.com/winfx/xaml/controls  5      1vm(clr-namespace:MasterServer.UI.ViewModels  5      9custom,clr-namespace:MasterServer.UI.CustomControls  5	      /local#clr-namespace:MasterServer.UI.Views  5
      -   5        $  MvvmDialogs.DialogServiceViews    IsRegistered  .  � Title$ Registered Players��5      $	��610��5      $	��800��5       � 	Resources 5       �� Source�� 5   
   $, &../MasterServerResourceDictionary.xaml?�6   %    ��5      �� 5   
    �� 
TargetType(  "MahApps.Metro.Controls.MetroWindow"  6   .�5      ��  �� Property � �� �� Value
 �����6+   5      .��5      � $
��10,0q�6    � ColumnDefinitions 5   
   �� 5       � RowDefinitions 5   
   �� 5       $��60 �6   �� 5!      �� 5"      $��50 �6   .+�5%   
   5   /MasterServer.UI.CustomControls.SearchBarControl  -   5        	  Name$	 	SearchBar��5%   "   $��0��5&   "   $��0��5'   "   $	��600��5(   "   $��30��5)   "   $
��Left=�5*   "   
   
SearchText
 5+   "   �� *SearchTextString+ �� UpdateSourceTrigger$ PropertyChanged=� �� Delay$	 300�� �� Mode$ TwoWay=�&   System.Windows.Controls.DataGrid  5,   
   -   5          Name$ registeredPlayerGrid��5-      $��1��5,         AlternatingRowBackground �#80CFFF   SelectionMode$ Extended=�50         AutoGenerateColumns .     CanUserAddRows .  ��5.      �� *RegisteredPlayers+   ColumnHeaderStyle 53      �� 54      =  7System.Windows.Controls.Primitives.DataGridColumnHeader"  6   .�55      ��  � �� �#007FFF63   �� 56       � ��
 �����63   �� 57       � ��$
 Bold"�63   �� 58       � ��$ 5q�60   �� 59       � �� �#006FFF64   �� 5:       � ��$ 1q�68   5;         Columns 5=      0  *System.Windows.Controls.DataGridTextColumn  5>      ,  &System.Windows.Controls.DataGridColumn   Header$ 	Player ID��6%      
IsReadOnly .    Width5  /System.Windows.Controls.DataGridLengthConverter$ 2* 6a   1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding 68   �� *Id+6a     5?      $
 Name��6%    . $ 3* 6^    63   �� *Name+6^     5@      $
 Rank��6%    . $ 2* 6^    63   �� *Rank+6^     5A      $
 Unit��6%    . $ * 6^    63   �� *Unit+6^     5B      $ Job Code��6%    . $ 2* 6e    67   �� *	JobCode+6e     5C      $ Facilitator?��6%    . $ 2* 6o    6;   �� *IsFacilitator+6o     5D      $ Status��6%    . $ 2* 6d    65   �� *
IsActive+6d   4
  .System.Windows.Controls.DataGridTemplateColumn
  5E      $
 Edit��6)    
  CellTemplate 5F      �� 5G      .R�5H      ��  ��Name$ editPlayerViewBtn��6%   $
��Edit��5I   %   ��5J   %   ��  �� Path$- 'DataContext.EditRegisteredPlayerCommand� �� RelativeSource ��  �� Mode$ FindAncestor=� �� AncestorType" ���5K   %   ��  �� $ FindAncestor=�$ DataGridL�$ SelectedItem�5L      5N      5P      �� 5R   
   -   5        $ 
refreshBtn��5R      $��3��5S      $
��Left=�5T      $��90��5U      $��30��5V      $��↻ Refresh��5W      $��Normal"�5X      +  %MahApps.Metro.Controls.ControlsHelper   ContentCharacterCasing$ Normal=�5Y      ��5Z      �� *OnLoad+�� 5\   
   $��3��6   $��Right=�5]        �� Orientation$  
Horizontal=�5^      .+�5_      �� -   5        $ previousBtn��5`      $��30��5_      $��Center=�5a      $��60��5b      $��Previous��5c      $ Normal=�5d      $��Normal"�5e      $��1q�5g      ��5f      �� *PaginationPreviousCommand+5g      �� 5h      -   5        ! ��Name$! pageBtnWrapper��5h      ��5i      �� *ButtonNumbers+��5j      �� 5k      .R�5l      �� $  
Horizontal=�6%   5m      5o      �� 5p      -   5        $ nextBtn��5q      $��30��5p      $��Center=�5r      $��60��5s      $
��Next��5t      $ Normal=�5u      $��Normal"�5v      $��1q�5x      ��5w      �� *PaginationNextCommand+5x      5y      5z      5{      
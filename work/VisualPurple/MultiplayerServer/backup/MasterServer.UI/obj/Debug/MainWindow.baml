   M S B A M L   `   `   `  ����J  FMasterServer.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:MasterServer.UI.CustomControlsMasterServer.UI.CustomControls  5      G(clr-namespace:MasterServer.UI.ViewModelsMasterServer.UI.ViewModels  5      T PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls 5      1clr-namespace:MasterServer.UIMasterServer.UI  5	           MasterServer.UI.MainWindow   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      ?custom,clr-namespace:MasterServer.UI.CustomControls     5      7vm(clr-namespace:MasterServer.UI.ViewModels     5      Kmah;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5      /localclr-namespace:MasterServer.UI     5	      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5
      -   5          � Title$  Master Server��5      $	��450��5      $	��800��5      *  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5      +  %Microsoft.Xaml.Behaviors.EventTrigger  5   
      	EventName$ Closing��6   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5      2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command 6$   �� *	OnClose+ �� IsAsync . 5       � 	Resources 5       �� Source�� 5   
   $) #MasterServerResourceDictionary.xaml?�6   %    ��5      �� 5   
    �� 
TargetType" �6   .�5      �� 	 �� Property	 � ��
 �� Value

 �����6+   5      .��5       �  � RowDefinitions 5!   
   �� 5"      $��18 �6   �� 5#      $
��auto �6   �� 5$      �� 5%      �� 5&       � ColumnDefinitions 5(   
   �� 5)      $	��300 �6   �� 5*      �� 5+      �� 5,      .+�5/   
   0   *MasterServer.UI.CustomControls.MenuControl  $��0��6   $��0��50      $��4��51       � DataContext 52      �� *MenuViewModel+;   5MasterServer.UI.CustomControls.ServerStatusBarControl  54   
   $��1��6(   $��1��55   (   $��3��56   (   $��0,15,0,0q�57   (    58   (   �� *ServerStatusBarViewModel+�� 5:   
   $��1��6   $��0��5;      $��4��5<      $��5q�5=      $��
Server Log��5>      +  %MahApps.Metro.Controls.ControlsHelper   ContentCharacterCasing$ Normal=�5?      2  ,MahApps.Metro.Controls.HeaderedControlHelper   HeaderBackground �#007FFF   HeaderFontWeight$
 Bold"�5A         CornerRadius$ 5��5B      
�������.��5D      �� $	��Top=�5E      $��Visible=�5F      ��. ��5D      �� *
ServerLogs+��5H      �� 5I      .R�5J      � .+�5K      �� ��6(   �� *	TimeStamp+�� 5L      $	�� - ��6(   �� 5M      ��6(   �� *
LogMessage+5N      5O      5Q      5R      7	   1MasterServer.UI.CustomControls.StatusModalControl	  5T   
   $��2��6$   $��1��5U   $   $��3��5V   $   $��3��5W   $    5X   $   �� *StatusModalViewModel+5Y      5Z      
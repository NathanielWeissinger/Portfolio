   M S B A M L   `   `   `  ����J  FMasterServer.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:MasterServer.UI.CustomControlsMasterServer.UI.CustomControls  5      8    2MasterServer.UI.CustomControls.ImportStatusControl   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      >local,clr-namespace:MasterServer.UI.CustomControls     5        � DataContext  5	      ��  �� RelativeSource �� *Self+.��5
      � $��Center=�6   y�5      ��  �� Path$ ImportStatusVisibility� � ColumnDefinitions 5   
   �� 5       � RowDefinitions 5   
   �� 5      �� 5      .+�5   
   ��  �� CornerRadius$ 5��6   $��40��5      $	��150��5      $��Center=�5      $��0��5      ��5      �� $ StatusBackgroundColor�._�5      �� $��Center=�5      $��Center=�5       �� Padding$
 20 0q�5      ��5      �� $ 
StatusText���5      �� $ StatusForegroundColor�5      5      �� 5   
   
�������$��1q�5       $ 5��5!      $��Center=�5#      $
��0 15q�5$      $��1��5%      y�5"      �� $ StatusLogButtonVisibility�._�5&      �� 
�������
�������$��View Log��5(      $��14(�5)      $��20 10q�5*      5+      5,      5-      
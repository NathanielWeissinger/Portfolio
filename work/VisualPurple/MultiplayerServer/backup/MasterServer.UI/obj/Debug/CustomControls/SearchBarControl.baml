   M S B A M L   `   `   `  ����J  FMasterServer.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:MasterServer.UI.CustomControlsMasterServer.UI.CustomControls  5      5    /MasterServer.UI.CustomControls.SearchBarControl   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      >local,clr-namespace:MasterServer.UI.CustomControls     5      -   5          >�Name$  SearchBarControler��5
      .��5      ��  �� CornerRadius$ 5��6   
�������
�������$��1q�5      ._�5   
   � $��Stretch=�6    � ColumnDefinitions 5      �� 5       � RowDefinitions 5      �� 5      .+�5      �� -   5         ��Name$ SearchTextBox��5      $��0��5      $��0��5      $��30��5       �� MaxLines$ 1��5      
������ 
������ ��5      ��  �� ElementName$ SearchBarControler�� �� Path$ 
SearchText� �� UpdateSourceTrigger$ PropertyChanged=�5      �� 5      $��0��6   $��0��5      $��Search��5       
�������$��Center=�5"      	 �� Padding$	 7q�5#      
 J� IsHitTestVisible
 .  ��5%      �� 5&       �� 
TargetType" ��6    �� Triggers 5'      �� 5(       �� Binding 6*   �� *Text+$ SearchTextBox�� �� Value  6^   .a�5)   "   ��  �� Property � y� �� Value$ Visible=�6?   5*      .�5,      ��  � y�$ Hidden=�67   5-      5/      �� 50      -   5        $��0��50      $��0��51      $	��❌��52      $��16(�54      
������ 
������ ���#ABABAB$��Right=�58      $��Center=�59      $��0q�5:      $��0q�5;      5<      5=      5>      
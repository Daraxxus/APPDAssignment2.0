   M S B A M L   `   `   `  ����L  HAPPDAssignment2.0, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:APPDAssignment2._0.WindowsAPPDAssignment2._0.Windows  5   	   '    !APPDAssignment2._0.Windows.SignUp   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   :local(clr-namespace:APPDAssignment2._0.Windows     5   	     � Title$  SignUp��5   	   $	��300��6   $	��480��6%   .��5	      �  � RowDefinitions 5
   
   �� 5      $��50 �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��50 �6    � ColumnDefinitions 5   
   �� 5      $	��200 �6   �� 5      $��* �6   .+�5   
   �� $��Center=�6   $��Right=�6/   $��30��6K   $��0��6W   $��20(�6g   $��92��6u   $
��0,10q�6�   	Username:6�   �� 5   
   $��Center=�6   $��Right=�6/   $��30��6K   $��1��6X   $��0��6e   $��20(�6u   $��48��6�   $��0,12,0,14.667q�6�   NRIC:6�   �� 5   
   $��Center=�6   $��Right=�6/   $��30��6K   $��2��6X   $��0��6e   $��20(�6u   $��86��6�   	Password:6�   �� 5   
   $��Center=�6   $��Right=�6/   $��30��6K   $��3��6X   $��0��6e   $��20(�6u   $	��168��6�   Comfirm Password:6�   �� 5   
   -   5         ��Name$ cancelButton��5      $��Cancel��6'   $��1��68   $��Bottom=�6H   $��Right=�6c   $��	0,0,10,10q�6   $��4��6�   $��30��6�   $	��100��6�   6�   �� 5   
   -   5        $ registerButton��5      $��Register��6)   $��1��6<   $��Right=�6L   $��0,10.333,120.333,9.667q�6h   $��4��6�   $	��100��6�   6�   �� 5   
   -   5         ��Name$ usernameBox��5      $��1��6'   $
��Left=�67   $��30��6R   $��
15,10,0,10q�6^   $��20(�6r   $��Center=�6�   $	��200��6�   �� 5   
   -   5        $ NRICBox��5      $��1��6#   $
��Left=�63   $��30��6N   $��
15,10,0,10q�6Z   $��1��6n   $��20(�6|   $��Center=�6�   $	��200��6�   �� 5   
   -   5        $ passwordBox��5      $��1��6'   $
��Left=�67   $��30��6R   $��15,0,0,0q�6^   $��2��6p   $��20(�6}   $��Center=�6�   $	��200��6�   �� 5    
   -   5        $ 
confrimBox��5       $��1��6&   $
��Left=�66   $��30��6Q   $��15,0,0,0q�6]   $��3��6o   $��20(�6|   $��Center=�6�   $	��200��6�   5!      5"      
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Phone_Store_Management
{
    public class LVItem:StackPanel
    {
        
        public LVItem()
        {
            
        }
        public LVItem(string ControlName, string DisplayName, PackIconKind DisplayIcon)
        {
            //StackPanel stackPanel = new StackPanel();
            PackIcon packIcon = new PackIcon();
            TextBlock textBlock = new TextBlock();
            //stackPanel.Height = 60;
            //Height = 60;
            Orientation = Orientation.Horizontal;
            //stackPanel.Orientation = Orientation.Horizontal;
            this.Name = ControlName;
            packIcon.Kind = DisplayIcon;
            packIcon.Width = packIcon.Height = 25;
            packIcon.VerticalAlignment = System.Windows.VerticalAlignment.Center;
            packIcon.Margin = new System.Windows.Thickness(10, 10, 10, 10);
            Children.Add(packIcon);
            //stackPanel.Children.Add(packIcon);
            textBlock.Text = DisplayName;
            textBlock.FontSize = 17;
            textBlock.VerticalAlignment = System.Windows.VerticalAlignment.Center;
            textBlock.Margin = new System.Windows.Thickness(20, 0, 0, 0);
            //stackPanel.Children.Add(textBlock);
            Children.Add(textBlock);
        }

        
    }
}

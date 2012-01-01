using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace SystemColorsSwatchBrowser
{
    /// <summary>
    /// Interaction logic for Swatch.xaml
    /// </summary>
    public partial class Swatch : UserControl
    {
        public ObservableCollection<ColorDescriptor> Colors { get; set; }
        public string Title { get; set; }
        
        public Swatch(string title, IEnumerable<ColorDescriptor> colors)
        {
            this.Title = title;
            this.Colors = new ObservableCollection<ColorDescriptor>(colors);

            InitializeComponent();
            this.DataContext = this;

            LayoutSwatch();
        }

        private void LayoutSwatch()
        {
            foreach (var color in this.Colors)
            {
                this.colorsPanel.Children.Add(
                    new Microsoft.Windows.Themes.SystemDropShadowChrome
                        {
                            Margin = new Thickness(10.0d),
                            Color = System.Windows.Media.Colors.Gray,
                            Child = new ColorPanel(color),
                            Width = 141,
                            Height = 141,
                        });
            }
        }
    }
}

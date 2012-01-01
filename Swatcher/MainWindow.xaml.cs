using System;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Media;

namespace SystemColorsSwatchBrowser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CreateSwatch();
        }

        private void CreateSwatch()
        {
            CreateSwatch("System Colors", typeof(SystemColors));
            CreateSwatch("Built-in Colors", typeof(Colors));
        }

        private void CreateSwatch(string builtInColors, Type type)
        {
            var swatch = new Swatch(
                builtInColors, 
                type.GetProperties(BindingFlags.Static | BindingFlags.GetProperty | BindingFlags.Public)
                    .Where(p => p.PropertyType == typeof(Color))
                    .Select(p => new ColorDescriptor 
                        { 
                            Name = p.Name, 
                            Color = (Color)p.GetValue(null, null)
                        }));

            this.swatchPanel.Children.Add(swatch);
        }
    }
}

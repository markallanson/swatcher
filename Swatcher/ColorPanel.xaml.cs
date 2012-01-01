using System.Windows.Controls;
using System.Windows.Media;

namespace SystemColorsSwatchBrowser
{
    /// <summary>
    /// Interaction logic for ColorPanel.xaml
    /// </summary>
    public partial class ColorPanel : UserControl
    {
        public string ColorName { get; set; }
        public SolidColorBrush ColorBrush { get; set; }

        public ColorPanel(ColorDescriptor colorDescriptor)
        {
            this.ColorName = colorDescriptor.Name;
            this.ColorBrush = new SolidColorBrush(colorDescriptor.Color);

            InitializeComponent();
        }
    }
}

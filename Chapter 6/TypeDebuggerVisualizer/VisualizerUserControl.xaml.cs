using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TypeDebuggerVisualizer
{
    /// <summary>
    /// Interaction logic for VisualizerUserControl.xaml
    /// </summary>
    public partial class VisualizerUserControl : UserControl
    {
        public VisualizerUserControl()
        {
            InitializeComponent();
        }

        public VisualizerUserControl(DebuggerData data):this()
        {
            this.propertyGrid.SelectedObject = data;
        }
    }
}

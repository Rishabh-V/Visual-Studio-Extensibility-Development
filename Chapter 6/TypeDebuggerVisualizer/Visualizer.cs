using Microsoft.VisualStudio.DebuggerVisualizers;
using System;
using System.ComponentModel;
using System.Windows;

namespace TypeDebuggerVisualizer
{
    public class Visualizer : DialogDebuggerVisualizer
    {
        protected override void Show(IDialogVisualizerService windowService, IVisualizerObjectProvider objectProvider)
        {
            if (windowService == null)
            {
                throw new ArgumentNullException(nameof(windowService));
            }

            if (objectProvider == null)
            {
                throw new ArgumentNullException(nameof(objectProvider));
            }

            // Get the object to display a visualizer for.
            //       Cast the result of objectProvider.GetObject() 
            //       to the type of the object being visualized.
            var data = objectProvider.GetObject() as dynamic;

            var displayData = new DebuggerData() { Data = data };

            // Display your view of the object.
            var control = new VisualizerUserControl(displayData);

            var win = new Window
            {
                Title = $"Type Visualizer",
                Width = 150,
                Height = 50,
                WindowStartupLocation = WindowStartupLocation.CenterScreen,
                Content = control
            };

            win.ShowDialog();
        }
    }

    public class DebuggerData
    {
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public dynamic Data { get; set; }
    }
}


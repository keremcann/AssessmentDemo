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

namespace AspNetWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void demo_MouseMove(object sender, MouseEventArgs e)
        {

            // get the position of the mouse relative to the Canvas
            var mousePos = e.GetPosition(cnvs);

            // center the rect on the mouse
            double left = mousePos.X - (demo.ActualWidth / 2);
            double top = mousePos.Y - (demo.ActualHeight / 2);
            Canvas.SetLeft(demo, left);
            Canvas.SetTop(demo, top);
        }
    }
}

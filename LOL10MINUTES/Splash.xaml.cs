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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace LOL10MINUTES
{
    /// <summary>
    /// Interaction logic for Splash.xaml
    /// </summary>
    public partial class Splash : Window
    {
        public static void DoEvents()
        {
            Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, new Action(delegate { }));
        }
        public Splash()
        {
            InitializeComponent();
            progressbar.Maximum = 30000;
            progressbar.Minimum = 0;
            this.Topmost = true;
            this.Show();
            int i = 0;
            while(i < 30000)
            {
                progressbar.Value = i;
                i++;
                DoEvents();
            }
            System.Threading.Thread.Sleep(1000);
            MainWindow window = new MainWindow();
            window.Show();
            this.Close();
        }
    }
}

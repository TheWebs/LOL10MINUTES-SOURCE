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
using MahApps.Metro;
using MahApps.Metro.Controls;
using System.IO;
using System.Net;
using Microsoft.Win32;
using Ookii.Dialogs;

namespace LOL10MINUTES
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            if (File.Exists(Directory.GetCurrentDirectory() + "\\Path.txt"))
            {
                string caminho = Directory.GetCurrentDirectory() + "\\HUDS";
                foreach (string dir in Directory.GetDirectories(caminho))
                {
                    DirectoryInfo dirinf = new DirectoryInfo(dir);
                    listBox.Items.Add(dirinf.Name);
                }
                listBox.SelectedIndex = 0;
            }
            else
            {
                EscolhePasta();
                string caminho = Directory.GetCurrentDirectory() + "\\HUDS";
                foreach (string dir in Directory.GetDirectories(caminho))
                {
                    DirectoryInfo dirinf = new DirectoryInfo(dir);
                    listBox.Items.Add(dirinf.Name);
                }
                listBox.SelectedIndex = 0;
            }

        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try {
                var c = new WebClient();
                var bytes = c.DownloadData(File.ReadAllText(Directory.GetCurrentDirectory() + "\\HUDS\\" + listBox.SelectedItem.ToString() + "\\preview.txt"));
                var ms = new MemoryStream(bytes);

                var bi = new BitmapImage();
                bi.BeginInit();
                bi.StreamSource = ms;
                bi.EndInit();
                image.Source = bi;
                label.Content = "";
            }catch (Exception ex )
            {
                label.Content = "Erro!";
                LogMessageToFile(ex.Message);
            }
        }

        private void image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            preview novo = new preview();
            double top = image.Source.Height;
            double left = image.Source.Width;
            novo.Top = top;
            novo.Left = left;
            novo.image.Height = image.Source.Height;
            novo.image.Width = image.Source.Width;
            novo.image.Source = image.Source;
            novo.Show();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try {
                DirectoryInfo joao = new DirectoryInfo(Directory.GetDirectories(File.ReadAllText(Directory.GetCurrentDirectory() + "\\Path.txt") + "\\RADS\\solutions\\lol_game_client_sln\\releases\\")[0]);
                //C:\Riot Games\League of Legends\RADS\solutions\lol_game_client_sln\releases\0.0.1.78\deploy\DATA\menu\hud
                File.Copy(Directory.GetCurrentDirectory() + "\\HUDS\\" + listBox.SelectedItem.ToString() + "\\hudatlas.dds", File.ReadAllText(Directory.GetCurrentDirectory() + "\\Path.txt") + "\\RADS\\solutions\\lol_game_client_sln\\releases\\" + joao.Name + "\\deploy\\DATA\\menu\\hud\\hudatlas.dds", true);
                label.Content = "Done!";
            }
            catch(Exception ex)
            {
                label.Content = "Erro!";
                LogMessageToFile(ex.Message);
            }
        }

        private void button_Copy_Click(object sender, RoutedEventArgs e)
        {
            try {
                DirectoryInfo joao = new DirectoryInfo(Directory.GetDirectories(File.ReadAllText(Directory.GetCurrentDirectory() + "\\Path.txt") + "\\RADS\\solutions\\lol_game_client_sln\\releases\\")[0]);
                File.Delete(File.ReadAllText(Directory.GetCurrentDirectory() + "\\Path.txt") + "\\RADS\\solutions\\lol_game_client_sln\\releases\\" + joao.Name + "\\deploy\\DATA\\menu\\hud\\hudatlas.dds");
                label.Content = "Done!";
            } catch(IOException ex)
            {
                label.Content = "Erro!";
                LogMessageToFile(ex.Message);
            }
            }

        private void AddHud_Click(object sender, RoutedEventArgs e)
        {
            AddHudWindow hud = new AddHudWindow();
            hud.Show();
        }

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Arrow;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            listBox.Items.Clear();
            string caminho = Directory.GetCurrentDirectory() + "\\HUDS";
            foreach (string dir in Directory.GetDirectories(caminho))
            {
                DirectoryInfo dirinf = new DirectoryInfo(dir);
                listBox.Items.Add(dirinf.Name);
            }
            listBox.SelectedIndex = 0;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //LolNexus GameScout = new LolNexus();    {League Game Stats}
            //GameScout.Show();
            MessageBox.Show("Available on ext update ^^", "LOL10MINUTES - LoL Scout");
        }

        public string GetTempPath()
        {
            string path = Directory.GetCurrentDirectory() + "\\log.txt";
            return path;
        }

        public void LogMessageToFile(string msg)
        {
            System.IO.StreamWriter sw = System.IO.File.AppendText(
                GetTempPath());
            try
            {
                string logLine = System.String.Format(
                    "{0:G} : {1}.", System.DateTime.Now, msg);
                sw.WriteLine(logLine);
            }
            finally
            {
                sw.Close();
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            EscolhePasta();
        }

        private void EscolhePasta()
        {
            Ookii.Dialogs.Wpf.VistaFolderBrowserDialog pasta = new Ookii.Dialogs.Wpf.VistaFolderBrowserDialog();
            pasta.Description = "Please select your League of Legends folder";
            pasta.RootFolder = Environment.SpecialFolder.MyComputer;
            pasta.ShowDialog();
            File.WriteAllText(Directory.GetCurrentDirectory() + "\\path.txt", pasta.SelectedPath.ToString());
        }
    }
}

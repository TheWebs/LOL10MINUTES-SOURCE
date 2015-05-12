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
using MahApps.Metro.Controls;
using System.IO;
using System.Diagnostics;

namespace LOL10MINUTES
{
    /// <summary>
    /// Interaction logic for Change_cursor.xaml
    /// 
    /// C:\Riot Games\League of Legends\RADS\solutions\lol_game_client_sln\releases\0.0.1.88\deploy\DATA\Images\UI
    /// </summary>
    public partial class Change_cursor : MetroWindow
    {
        public Change_cursor()
        {
            InitializeComponent();
            string caminho = Directory.GetCurrentDirectory() + "\\Cursors";
            foreach (string dir in Directory.GetDirectories(caminho))
            {
                DirectoryInfo dirinf = new DirectoryInfo(dir);
                listBox1.Items.Add(dirinf.Name);
            }
            listBox1.SelectedIndex = 0;
        }

        private void listBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string pasta = Directory.GetCurrentDirectory();
            imagem1.Source = new BitmapImage(new Uri (pasta + "\\Cursors\\" + listBox1.SelectedItem.ToString() + "\\Hand1.png"));
            imagem2.Source = new BitmapImage(new Uri(pasta + "\\Cursors\\" + listBox1.SelectedItem.ToString() + "\\Hand2.png"));
            imagem3.Source = new BitmapImage(new Uri(pasta + "\\Cursors\\" + listBox1.SelectedItem.ToString() + "\\HoverEnemy.png"));
            label1.Content = "";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DirectoryInfo joao = new DirectoryInfo(Directory.GetDirectories(File.ReadAllText(Directory.GetCurrentDirectory() + "\\Path.txt") + "\\RADS\\solutions\\lol_game_client_sln\\releases\\")[0]);
            try
            {
                File.Copy(Directory.GetCurrentDirectory() + "\\Cursors\\" + listBox1.SelectedItem.ToString() + "\\Hand1.tga", File.ReadAllText(Directory.GetCurrentDirectory() + "\\Path.txt") + "\\RADS\\solutions\\lol_game_client_sln\\releases\\" + joao.Name + "\\deploy\\DATA\\Images\\UI\\Hand1.tga", true);
                File.Copy(Directory.GetCurrentDirectory() + "\\Cursors\\" + listBox1.SelectedItem.ToString() + "\\Hand2.tga", File.ReadAllText(Directory.GetCurrentDirectory() + "\\Path.txt") + "\\RADS\\solutions\\lol_game_client_sln\\releases\\" + joao.Name + "\\deploy\\DATA\\Images\\UI\\Hand2.tga", true);
                File.Copy(Directory.GetCurrentDirectory() + "\\Cursors\\" + listBox1.SelectedItem.ToString() + "\\HoverEnemy.tga", File.ReadAllText(Directory.GetCurrentDirectory() + "\\Path.txt") + "\\RADS\\solutions\\lol_game_client_sln\\releases\\" + joao.Name + "\\deploy\\DATA\\Images\\UI\\HoverEnemy.tga", true);
                label1.Content = "Done!";
            }
            catch (Exception ex)
            {
                LogMessageToFile(ex.Message);
                label1.Content = "Error!";
            }
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DirectoryInfo joao = new DirectoryInfo(Directory.GetDirectories(File.ReadAllText(Directory.GetCurrentDirectory() + "\\Path.txt") + "\\RADS\\solutions\\lol_game_client_sln\\releases\\")[0]);
            try
            {
                File.Delete(File.ReadAllText(Directory.GetCurrentDirectory() + "\\Path.txt") + "\\RADS\\solutions\\lol_game_client_sln\\releases\\" + joao.Name + "\\deploy\\DATA\\Images\\UI\\Hand1.tga");
                File.Delete(File.ReadAllText(Directory.GetCurrentDirectory() + "\\Path.txt") + "\\RADS\\solutions\\lol_game_client_sln\\releases\\" + joao.Name + "\\deploy\\DATA\\Images\\UI\\Hand2.tga");
                File.Delete(File.ReadAllText(Directory.GetCurrentDirectory() + "\\Path.txt") + "\\RADS\\solutions\\lol_game_client_sln\\releases\\" + joao.Name + "\\deploy\\DATA\\Images\\UI\\HoverEnemy.tga");
                label1.Content = "Done!";
            }catch(Exception ex)
            {
                LogMessageToFile(ex.Message);
                label1.Content = "Error!";
            }
        }
    }
}

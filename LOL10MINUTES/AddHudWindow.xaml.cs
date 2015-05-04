﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using Microsoft.Win32;
using System.IO;

namespace LOL10MINUTES
{
    /// <summary>
    /// Interaction logic for AddHudWindow.xaml
    /// </summary>
    public partial class AddHudWindow : MetroWindow
    {
        string caminho;
        string nome;
        string preview;
        public AddHudWindow()
        {
            InitializeComponent();
            textBox.IsReadOnly = true;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            // Set filter options and filter index.
            openFileDialog1.Filter = "HUD Files (.dds)|*.dds|All Files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;

            openFileDialog1.Multiselect = false;

            // Call the ShowDialog method to show the dialog box.
            bool? userClickedOK = openFileDialog1.ShowDialog();

            // Process input if the user clicked OK.
            if (userClickedOK == true)
            {
                // Open the selected file to read.
                caminho = openFileDialog1.FileName;
                textBox.Text = caminho;
                textBox.ToolTip = caminho;
                
                
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists(caminho))
            {
                nome = textBox2.Text;
                preview = textBox1.Text;
                try
                {
                    Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\HUDS\\" + nome);
                    File.WriteAllText(Directory.GetCurrentDirectory() + "\\HUDS\\" + nome + "\\preview.txt", preview);
                    File.Move(caminho, Directory.GetCurrentDirectory() + "\\HUDS\\" + nome + "\\hudatlas.dds");
                    MessageBox.Show("Added " + nome + " sucefully!");
                    this.Close();
                }
                catch (IOException ex)
                {
                    textBox.Text = "Erro!";
                    textBox1.Text = "Erro!";
                    textBox2.Text = "Erro!";
                }
            }
            else
            {
                MessageBox.Show("Erro!", "LOL10MINUTES : Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            }
        }
    }


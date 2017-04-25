using System;
using System.IO;
using System.Windows;
using System.Windows.Media;
using Microsoft.Win32;

namespace POO
{
    /// <summary>
    ///     Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            convert.IsEnabled = false;
        }

        private void open_Click(object sender, RoutedEventArgs e)
        {
            var ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == true)
            {
                filePath.Text = ofd.FileName;
            }
        }

        private void convert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SVG svg = SVG.FromFile(filePath.Text);
                svg.Save();
                errorLabel.Content = "Conversion réussie !";
            }
            catch (FileNotFoundException err)
            {
                MessageBox.Show("Fichier introuvable: " + err.FileName);
                return;
            }
        }

        private void filePath_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            convert.IsEnabled = filePath.Text != "";
        }
    }
}
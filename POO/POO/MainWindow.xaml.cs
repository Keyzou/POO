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

        private string _lastFile = "";

        public MainWindow()
        {
            InitializeComponent();
            endPanel.Visibility = Visibility.Hidden;
            convert.IsEnabled = false;
        }

        private void open_Click(object sender, RoutedEventArgs e)
        {
            var ofd = new OpenFileDialog
            {
                Filter = "Fichiers CSV | *.csv",
                DefaultExt = "csv"
            };
            if (ofd.ShowDialog() == true)
            {
                filePath.Text = ofd.FileName;
            }
        }

        private void convert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var sfd = new SaveFileDialog
                {
                    Filter = "Fichiers SVG | *.svg",
                    DefaultExt = "svg"
                };
                if (sfd.ShowDialog() == false) return;
                var svg = SVG.FromFile(filePath.Text, cb3D.IsChecked, cbContour.IsChecked);
                svg.Save(sfd.FileName);
                errorLabel.Content = "Conversion réussie !";
                endPanel.Visibility = Visibility.Visible;
                _lastFile = sfd.FileName;
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

        private void ouvrirBtn_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(_lastFile);
        }
    }
}
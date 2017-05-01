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
            endPanel.Visibility = Visibility.Collapsed;
            _3DPanel.Visibility = Visibility.Collapsed;
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
                var svg = SVG.FromFile(filePath.Text, cb3D.IsChecked, cbContour.IsChecked, (int) sliderProfondeur.Value);
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

        private void sliderProfondeur_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            labelProfondeur.Content = "Profondeur: " + (int) sliderProfondeur.Value;
        }

        private void cb3D_Checked(object sender, RoutedEventArgs e)
        {
            _3DPanel.Visibility = cb3D.IsChecked != null && cb3D.IsChecked.Value ? Visibility.Visible : Visibility.Collapsed;
        }
    }
}
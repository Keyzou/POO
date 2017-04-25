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
                if (filePath != null) MessageBox.Show(File.ReadAllText(filePath?.Text));
            }
            catch (FileNotFoundException err)
            {
                MessageBox.Show("Fichier introuvable: " + err.FileName);
                return;
            }
        }
    }
}
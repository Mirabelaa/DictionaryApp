using System;
using System.Collections.Generic;
using System.IO;
using System.Web.UI.WebControls;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using MessageBox = System.Windows.MessageBox;

namespace tema1
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Admin : Window
    {
        public Admin()
        {
            InitializeComponent();
            SortedSet<string> categorii = (DataContext as Dictionar).GetCategorii();
            foreach (string s in categorii)
                comboBox.Items.Add(s);
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            if (Verificare())
            {
                if(categorieExistenta.IsChecked==true && comboBox.Text != String.Empty)
                {
                    
                    Cuvant cuvant = (DataContext as Dictionar).GetCuvant(nume.Text, descriere.Text, comboBox.Text, imag.Text);
                    (DataContext as Dictionar).AdaugareCuvant(cuvant);
                    MessageBox.Show("Cuvant adaugat!");
                    Clear();
                }
                else if(categorieNoua.IsChecked==true && categorie.Text != String.Empty)
                {
                    
                    Cuvant cuvant = (DataContext as Dictionar).GetCuvant(nume.Text, descriere.Text, categorie.Text, imag.Text);
                    (DataContext as Dictionar).AdaugareCuvant(cuvant);
                    MessageBox.Show("Cuvant adaugat!");
                    comboBox.Items.Add(categorie.Text);
                    Clear();
                }
                else
                    MessageBox.Show("Categoria trebuie adaugata!");

            }

        }

        private void Modificare_Click(object sender, RoutedEventArgs e)
        {
            if (Verificare())
            {
                (DataContext as Dictionar).CautareCuvant(nume, descriere, categorie, imag);
                MessageBox.Show("Cuvant modificat!");
                Clear();
            }
        }

        private void Stergere_Click(object sender, RoutedEventArgs e)
        {
            if (nume.Text != string.Empty)
            {
                (DataContext as Dictionar).Stergere(nume);
                MessageBox.Show("Cuvant sters!");
                Clear();
            }
            else
                MessageBox.Show("Numele trebuie completat!");
        }

        void Clear()
        {
            nume.Clear();
            categorie.Clear();
            descriere.Clear();
        }

        public bool Verificare()
        {
            if (nume.Text == string.Empty)
            {
                MessageBox.Show("Numele trebuie completat!");
                return false;
            }

            if (descriere.Text == string.Empty)
            {
                MessageBox.Show("Descrierea trebuie completata!");
                return false;
            }

            if (imag.Text == string.Empty)
            {
                MessageBox.Show("Calea catre imagine trebuie completata!");
                return false;
            }

            return true;
        }
        private void Button_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (nume.Text != string.Empty)
            {
                (DataContext as Dictionar).AfisareDetalii(nume, descriere, categorie, imag);
            }
            else
                MessageBox.Show("Numele trebuie completat!");
        }

        private void Image_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            string folderpath = System.IO.Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\resurse\\imaginiCuvinte\\";
            openFileDialog.Multiselect = false;
            openFileDialog.Filter = "JPG Files (*.jpg)|*.jpg|PNG Files (*.png)|*.png|GIF Files (*.gif)|*.gif";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (!Directory.Exists(folderpath))
                    Directory.CreateDirectory(folderpath);
                string filePath = folderpath + Path.GetFileName(openFileDialog.FileName);
                File.Copy(openFileDialog.FileName, filePath, true);
                Image.Source = new BitmapImage(new Uri(filePath));
                Image.Stretch = System.Windows.Media.Stretch.Uniform;
                imag.Text = filePath;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
            this.Close();
        }

        private void categorieExistenta_Checked(object sender, RoutedEventArgs e)
        {
            categorieNoua.IsChecked = false;
        }

        private void categorieNoua_Checked(object sender, RoutedEventArgs e)
        {
            categorieExistenta.IsChecked = false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace tema1
{
    /// <summary>
    /// Interaction logic for Cautare.xaml
    /// </summary>
    public partial class Cautare : Window
    {
        public Cautare()
        {
            InitializeComponent();
            SortedSet<string> categorii = (DataContext as Dictionar).GetCategorii();
           
            cauta.CharacterCasing = System.Windows.Controls.CharacterCasing.Lower;
            foreach (string s in categorii)
                comboBox.Items.Add(s);
        }
       
        private void cauta_TextChanged(object sender, TextChangedEventArgs e)
        {
            List<string> sugestii = new List<string>();
            if (comboBox.SelectedItem != null)
                sugestii = (DataContext as Dictionar).GetCuvinteCategorie(comboBox.Text);
            else
                sugestii = (DataContext as Dictionar).GetNumeCuvinte();
            if (string.IsNullOrEmpty(cauta.Text)==false)
            {
                listBox.Items.Clear();
                listBox.Visibility= System.Windows.Visibility.Visible;
                foreach (string s in sugestii)
                {
                    if (s.StartsWith(cauta.Text))
                        listBox.Items.Add(s);
                }
            }
            else if(cauta.Text=="")
            {
                listBox.Items.Clear();
                foreach (string s in sugestii)
                {
                    listBox.Items.Add(s);
                }
            }
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            listBox.Visibility = System.Windows.Visibility.Hidden;
            foreach (Cuvant cuvant in (DataContext as Dictionar).GetCuvinte())
            {
                if (cuvant.Denumire.Equals(listBox.SelectedItem))
                {
                    nume.Content = "Denumire: " + cuvant.Denumire;
                    nume.Visibility = System.Windows.Visibility.Visible;
                    descriere.Text = "Descriere: \n\n" + cuvant.Descriere;
                    descriere.Visibility= System.Windows.Visibility.Visible;
                    categorie.Content = "Categorie: " + cuvant.Categorie;
                    categorie.Visibility= System.Windows.Visibility.Visible;
                    imagine.Source= new BitmapImage(new Uri(cuvant.Imagine));
                    imagine.Stretch = System.Windows.Media.Stretch.Uniform;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
            this.Close();
        }

    }
}

using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace tema1
{
    /// <summary>
    /// Interaction logic for Divertisment.xaml
    /// </summary>
    public partial class Divertisment : Window
    {
        private int index = 0;
        private int raspunsuriCorecte = 0;

        public Divertisment()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            reguli_grid.Visibility = System.Windows.Visibility.Hidden;
            start.Visibility = System.Windows.Visibility.Hidden;
            next.Visibility = System.Windows.Visibility.Visible;
            raspuns.Visibility = System.Windows.Visibility.Visible;
            rasp.Visibility = System.Windows.Visibility.Visible;
            VizualizareIntrebare();
        }

        private void next_Click(object sender, RoutedEventArgs e)
        {
            index++;
            if (index == 4)
                next.Content = "Finish";
            if (raspuns.Text == string.Empty)
            {
                MessageBox.Show("Raspunsul trebuie completat!");
            }
            else if ((DataContext as Dictionar).VerificareRaspuns(raspuns.Text, (DataContext as Dictionar).GetIndicii()[index - 1].Denumire) == true)
            {
                MessageBox.Show("Raspuns corect!");
                raspuns.Clear();
                raspunsuriCorecte++;
                VerificareFinala();
                VizualizareIntrebare();
            }
            else
            {
                MessageBox.Show("Raspunsul gresit!\nRaspuns corect " + (DataContext as Dictionar).GetIndicii()[index - 1].Denumire);
                raspuns.Clear();
                VerificareFinala();
                VizualizareIntrebare();
            }

        }
        private void VizualizareIntrebare()
        {
            if (index < 5)
            {
                if ((DataContext as Dictionar).ImagineSauDescriere() == 0)
                    AfisareDescriere((DataContext as Dictionar).GetIndicii()[index]);

                else
                {
                    if ((DataContext as Dictionar).VerificareImagine((DataContext as Dictionar).GetIndicii()[index]))
                        AfisareImagine((DataContext as Dictionar).GetIndicii()[index]);
                    else
                        AfisareDescriere((DataContext as Dictionar).GetIndicii()[index]);
                }
            }
        }
        private void AfisareDescriere(Cuvant cuvant)
        {
            imagine.Visibility = System.Windows.Visibility.Hidden;
            descriere.Visibility = System.Windows.Visibility.Visible;
            descriere.Text = "Descriere: " + cuvant.Descriere;
        }
        private void AfisareImagine(Cuvant cuvant)
        {
            descriere.Visibility = System.Windows.Visibility.Hidden;
            imagine.Visibility = System.Windows.Visibility.Visible;
            imagine.Source = new BitmapImage(new Uri(cuvant.Imagine));
            imagine.Stretch = System.Windows.Media.Stretch.Uniform;
        }
        private void VerificareFinala()
        {
            if (index == 5)
            {
                MessageBox.Show("Ai raspuns corect la " + raspunsuriCorecte + "/5 intrebari!");
                Divertisment joc = new Divertisment();
                joc.Show();
                this.Close();
            }
        }
    }
}
